using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DirectoryTree.Models.New
{
    /// <summary>
    /// Класс поставщиков
    /// </summary>
    public class MaterialsMakers
    {
        public int Id { get; set; }
        public int? MaterialId { get; set; }
        public string Subdivision { get; set; }
        public double? Price { get; set; }
        public string Currency { get; set; }
    }
}