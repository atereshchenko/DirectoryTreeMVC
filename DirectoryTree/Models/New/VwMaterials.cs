using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DirectoryTree.Models.New
{
    public class VwMaterials
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public string MaterialsClassesName { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string NumberOZM { get; set; }
        public string Mark { get; set; }
        public string NumberMaker { get; set; }
        public string NormDoc { get; set; }
    }
}