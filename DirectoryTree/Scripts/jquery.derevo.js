/* 
 (c) 2009-2012 r3code.habrahabr.ru 
 По вопросам модификации под задачу обращайтесь http://r3code.free-lance.ru
 
 Скрипт: Построение дерева по готовому HTML списку.
 http://r3code.habrahabr.ru/blog/59823/
 
 24/02/2012
 + Добавлено дописывание CSS класса 'subtree' для li содержащих поддеревья 
 
 19/05/2009 
 Выделяем узлы имющие поддеревья и добавляем у ним метку.
 Определяет поведение узлов дерева при клике на них. 
  - Изменяет состояние маркера раскрытия (открыт/закрыт).
  - Узлы содержащие в себе другие узлы, по клику разворачиваются 
    или сворачиваются, в зависимости от текущего состояния. 
  - При переходе с одного узла на другой снимается выделение (.current) 
    и пеходит на выбранный узел.
  - Определяет последний узел с поддеревом и скрывает соединительную 
    линию до следующего узла этого уровня.
  - Сохранаяет состояние узлов (откр./закр.) и выбранный узел в cookies.
  - При установленных cookies состояние узлов восстанавливается при загрузке. 
  
*/
//=================================================================================

$(document).ready(function () {
 /* Расставляем маркеры на узлах, имющих внутри себя поддерево.
    Выбираем элементы 'li' которые имеют вложенные 'ul', ставим для них 
    маркер, т.е. находим в этом 'li' вложенный тег 'a' 
    и в него дописываем маркер '<em class="marker"></em>'.
    a:first используется, чтобы узлам ниже 1го уровня вложенности 
    маркеры не добавлялись повторно. 
 */
 var root = $('#multi-derevo');
 // уникальные идентификаторы всем узлам, сквозная нумерация (Nested set)
 $('li', root).each(function (index) {
    this.id = 'n' + index;
 });
 $('li:has("ul")', root).addClass('subtree').find('a:first').prepend('<em class="marker"></em>');
 
 // выбрать текущий узел
 var current_id = $.cookie('current_node');
 if(current_id) $('#'+current_id).find('a:first').toggleClass('current');

 // вешаем событие на клик по ссылке
 //-----------------------------------
 $('li span', root).click(function () {
    // снимаем выделение предыдущего узла
    $('a.current', root).removeClass('current'); 
    var a = $('a:first',this.parentNode);
    a.toggleClass('current');
    var current_id = a.parent('li').attr('id');
    //alert(a.parents('li').get(0).tagName+"#"+a.parents('li').attr('id'));
    setCookie('current_node',a.parents('li').attr('id') || null);
    // Выделяем выбранный узел
    toggleNode(this.parentNode);
 });
 //postLoad(); // функция раскрытия по текущему url
 openNodes(); // открыть по данным cookie
})

//---------------------------------------------------------------------------------
// Выделил функцию разворачивания дерева в отдельную	
function toggleNode(Node) {// node= li
 prepareLast(Node); 
 // анимация раскрытия узла и изменение состояния маркера
 var ul=$('ul:first',Node);// Находим поддерево
 if (ul.length) {// поддерево есть
    ul.slideToggle(200); //свернуть или развернуть
    // Меняем сосотояние маркера на закрыто/открыто
    var em=$('em:first',Node);// this = 'li span'
    // было em.hasClass('open')?em.removeClass('open'):em.addClass('open');
    em.toggleClass('open'); 
    saveTreeState();
 }     
}

// функция обработки последнего узла в уровне
function prepareLast(Node) {
 /* если это последний узел уровня, то соединительную линию к следующему
 рисовать не нужно */	
 $(Node).each(function(){
    if (!$(this).next().length) {
       /* берем корень разветвления <li>, в нем находим поддерево <ul>,
          выбираем прямых потомков ul > li, назначаем им класс 'last' */
       $(this).find('ul:first > li').addClass('last');
    }  
 }) 
}
// функция разворачивания дерева до выбранной ранее ссылки
function postLoad(){
 var url = window.location.toString();
 var max = 0;
 var a = null;
 $('#multi-derevo li span a').each(function(){
    // сравниваем адрес страницы и ссылку из атрибута
    if(url.indexOf(this.href) >= 0 && this.href.length > max){
       a = this;
       max = this.href.length; 
    }
 });
 // если узел не виден, то разворачиваем дерево 
 if ($(a).is(':hidden') || $(a).parents(':hidden').length) {
    var li = $(a).parents().filter('li');
    prepareLast(li);
    toggleNode(li);
 }
 // выделим выбранный узел
 if (a) {
    $(a).toggleClass('current');
 }
 else { // первый показ, выберем первую ссылку (можно убрать если не нужно)
    $('#multi-derevo li span a:first').toggleClass('current');  
 }
}

// подготовка информации о сосотояниях узлов
function GetOpenedNodes(items){ // li:has('ul')
  var str = [];
  $(items).each(function() {
    var res = $(this).attr('id');
    var state = $('em:first',this).hasClass('open') ? 1 : '';
    if(res && state){ 
      str.push(res);
    }
  });
  return str.join(',');
}

// сохранить полный список открытых узлов
function saveTreeState(){ 
  var open_id = GetOpenedNodes($('#multi-derevo li:has("ul")')) || null;
  setCookie("open_nodes", open_id);
  return false;
} 

// раскрытие узлов по указанному списку
function openNodes(){
   // читаем куки и открываем узлы
  var open_nodes = $.cookie("open_nodes");
    if(open_nodes) {
    var nodes = open_nodes.split(',');
    
    if(nodes[0]){ 
      for(var node in nodes){
        nodes[node] = '#' + nodes[node];   
      }
      var ids = nodes.join(',');
      $(ids).each(function() {
         toggleNode($(this));
      });
    }
  }
  return false;
}

// настройки хранить в Cookies 1 день
function setCookie(name, value){
  var DAY = 24 * 60 * 60 * 1000;
  var date = new Date();
  date.setTime(date.getTime() + (1 * DAY)); // 1 день 
  $.cookie(name, value, {expires: date});
  // alert("Cookie set: "+name+"="+value);
}
