using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DirectoryTree.Models.New
{
    /// <summary>
    /// Класс Категорий материалов
    /// </summary>
    public class MaterialsClasses
    {
        [Display(Name = "Id")]
        [Required]
        public int Id { get; set; }

        [Display(Name = "IdParent")]
        [Required]
        public int? IdParent { get; set; }

        [Display(Name = "Code")]
        [Required]
        public string Code { get; set; }

        [Display(Name = "Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "OrderNumber")]
        [Required]
        public int?  OrderNumber { get; set; }

        [Display(Name = "Status")]
        [Required]
        public int? Status { get; set; }

        [Display(Name = "IdOperator")]
        [Required]
        public int? IdOperator { get; set; }

        [Display(Name = "IdOperator2")]
        [Required]
        public int? IdOperator2 { get; set; }

        [Display(Name = "MarkMask")]
        [Required]
        public string MarkMask { get; set; }

        [Display(Name = "IdSAPClass")]
        [Required]
        public string IdSAPClass { get; set; }

        [Display(Name = "CustomMaterials")]
        [Required]
        public bool CustomMaterials { get; set; }

    }
}