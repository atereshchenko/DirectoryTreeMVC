using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DirectoryTree.Models.New
{
    /// <summary>
    /// Класс Технических Параметров по материалу
    /// </summary>
    public class MaterialsParameters
    {
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public int ParameterId { get; set; }
        public string ParameterName { get; set; }
        public string Value { get; set; }
        public string Unit { get; set; }
    }
}