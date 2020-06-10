using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DirectoryTree.Models;
using DirectoryTree.Models.New;
using System.Data.Entity;
using System.Dynamic;

namespace DirectoryTree.Controllers
{
    public class MaterialController : Controller
    {
        ProjectsDataAccessLayer ObjectProjects = new ProjectsDataAccessLayer();
        WorkerContext db = new WorkerContext();

        /// <summary>
        /// "Универсальный" поиск
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult USearch()
        {
            Log.Info(User.Identity.Name, "Material/USearch [HttpGet]");
            return View();
        }

        /// <summary>
        /// "Универсальный" поиск
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public ActionResult USearch(string filter)
        {
            Log.Info(User.Identity.Name, "Material/USearch [HttpPost]");
            ViewBag.filter = filter;
            return View();
        }

        /// <summary>
        /// "Универсальный" поиск
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [Authorize]
        public ActionResult GetMaterialSearch(string filter)
        {
            if (filter == null || filter == "")
            {
                return HttpNotFound("Фильтр поиска должен не может быть пустым");
            }
            List<Materials> materials = new List<Materials>();
            materials = ObjectProjects.GetMaterialSearch(filter).ToList();
            Log.Info(User.Identity.Name, "Material/GetMaterialSearch/" + filter);
            return View("_TableUSearchMaterial", materials);            
        }        

        /// <summary>
        /// Список материалов по категории
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        public ActionResult Items(int id)
        {
            if (id == null)
            {
                Log.Info(User.Identity.Name, "Material/Items/"+ id.ToString() + " | HttpNotFound" );
                return HttpNotFound("Id cannot be empty");                
            }
            else
            {
                List<Materials> materials = new List<Materials>();
                materials = ObjectProjects.GetMaterials(id).ToList();
                if (materials.Count() > 0)
                {
                    ViewBag.Message = materials.ElementAtOrDefault(0).MaterialsClassesName;
                    Log.Info(User.Identity.Name, "Material/Items/" + id.ToString());
                    return View(materials);
                }
                else
                {
                    Log.Info(User.Identity.Name, "Material/Items/"+ id.ToString() + " | HttpNotFound");                    
                    return View(materials);
                }
            }
        }

        /// <summary>
        /// Материал по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public ActionResult Item(int id)
        {   
            ViewMaterialsModels vmDemo = new ViewMaterialsModels();
            vmDemo.Materials = ObjectProjects.GetMaterial(id);            
            if (vmDemo.Materials.Count() > 0)
            {
                ViewBag.Title = vmDemo.Materials.ElementAtOrDefault(0).Name;
                vmDemo.MaterialsMakers = ObjectProjects.GetSubdivisions(id);                
                vmDemo.MaterialsParameters = ObjectProjects.GetMaterialsParameters(id);
                Log.Info(User.Identity.Name, "Material/Item/" + id.ToString());
                return View(vmDemo);
            }
            else
            {
                Log.Info(User.Identity.Name, "Material/Item/"+ id.ToString() + " | HttpNotFound ");
                return HttpNotFound("Material not found");
            }       
        }

        /// <summary>
        /// Дерево категорий материалов
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult TreeView()
        {
            IEnumerable<VwMaterialsClasses> Materials = db.VwMaterialsClasses;
            ViewBag.Materials = Materials;
            Log.Info(User.Identity.Name, "Material/TreeView");
            return View();
        }

        /// <summary>
        /// Дерево категорий материалов
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult Catalog()
        {
            List<VwMaterialsClasses> catalog = db.VwMaterialsClasses.ToList();
            return PartialView(catalog);
        }

        /// <summary>
        /// Тестовый метод
        /// </summary>
        /// <returns></returns>
        public ActionResult TestTreeView()
        {
            return View();
        }
    }
}
