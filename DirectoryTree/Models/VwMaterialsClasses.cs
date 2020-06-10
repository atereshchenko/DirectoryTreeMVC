using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DirectoryTree.Models
{
    public class VwMaterialsClasses
    {
        public int Id { get; set; }        
        public int? ParentId { get; set; }  // ссылка на id родительского меню
        public string Name { get; set; }
        public VwMaterialsClasses Parent { get; set; }    // родительское меню
        public ICollection<VwMaterialsClasses> Children { get; set; }   // дочерние пункты меню        
        public VwMaterialsClasses()
        {
            Children = new List<VwMaterialsClasses>();            
        }
    }
}