using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DirectoryTree.Models.New
{
    public class ViewMaterialsModels
    {
        public IEnumerable<Materials> Materials { get; set; }
        public IEnumerable<MaterialsMakers> MaterialsMakers { get; set; }
        public IEnumerable<MaterialsParameters> MaterialsParameters { get; set; }
    }
}