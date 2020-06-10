using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DirectoryTree.Models.New
{
    /// <summary>
    /// Класс Материалов
    /// </summary>
    public class Materials
    {
        [Display(Name = "Id")]
        [Required]
        public int Id { get; set; }

        [Display(Name = "IdClass")]
        [Required]
        public int IdClass { get; set; }

        [Display(Name = "Stage")]
        [Required]
        public int? Stage { get; set; }

        [Display(Name = "Номер")]
        [Required]
        public string Number { get; set; }

        [Display(Name = "№ ОЗМ")]
        [Required]
        public string NumberOZM { get; set; }

        [Display(Name = "Код производителя")]
        [Required]
        public string NumberMaker { get; set; }

        [Display(Name = "Марка")]
        [Required]
        public string Mark { get; set; }

        [Display(Name = "Название")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Type")]
        [Required]
        public string Type { get; set; }

        [Display(Name = "Unit")]
        [Required]
        public string Unit { get; set; }

        [Display(Name = "Weight")]
        [Required]
        public double? Weight { get; set; }

        [Display(Name = "Currency")]
        [Required]
        public string Currency { get; set; }

        [Display(Name = "Price")]
        [Required]
        public double? Price { get; set; }

        [Display(Name = "IdMaker")]
        [Required]
        public int? IdMaker { get; set; }

        [Display(Name = "RequireAlternativeMaker")]
        [Required]
        public bool? RequireAlternativeMaker { get; set; }

        [Display(Name = "NormDoc")]
        [Required]
        public string NormDoc { get; set; }

        [Display(Name = "NormDocMaterial")]
        [Required]
        public string NormDocMaterial { get; set; }

        [Display(Name = "Info")]
        [Required]
        public string Info { get; set; }

        [Display(Name = "Has2DDraw")]
        [Required]
        public bool? Has2DDraw { get; set; }

        [Display(Name = "Has3DModel")]
        [Required]
        public bool? Has3DModel { get; set; }

        [Display(Name = "Stock")]
        [Required]
        public double? Stock { get; set; }

        [Display(Name = "IdUpdater")]
        [Required]
        public int? IdUpdater { get; set; }        

        [Display(Name = "DateOfUpdate")]
        [Required]
        public DateTime? DateOfUpdate { get; set; }

        [Display(Name = "IdStatus")]
        [Required]
        public int IdStatus { get; set; }

        [Display(Name = "IdWorkFlowCurrentNode")]
        [Required]
        public int? IdWorkFlowCurrentNode { get; set; }

        [Display(Name = "IdDBCreator")]
        [Required]
        public int? IdDBCreator { get; set; }       

        [Display(Name = "DBDateOfCreate")]
        [Required]
        public DateTime? DBDateOfCreate { get; set; }

        [Display(Name = "IdDBUpdater")]
        [Required]
        public int? IdDBUpdater { get; set; }        

        [Display(Name = "DBDateOfUpdate")]
        [Required]
        public DateTime? DBDateOfUpdate { get; set; }

        [Display(Name = "DBUpdaterCompName")]
        [Required]
        public string DBUpdaterCompName { get; set; }

        [Display(Name = "DBStatus")]
        [Required]
        public int? DBStatus { get; set; }

        [Display(Name = "DeleteReason")]
        [Required]
        public string DeleteReason { get; set; }

        [Display(Name = "IdReplacedMaterial")]
        [Required]
        public int? IdReplacedMaterial { get; set; }

        [Display(Name = "SapLoaded")]
        [Required]
        public bool? SapLoaded { get; set; }

        [Display(Name = "UsedOnNLMK")]
        [Required]
        public bool? UsedOnNLMK { get; set; }

        [Display(Name = "Price_old")]
        [Required]
        public double? Price_old { get; set; }

        [Display(Name = "Название категории материала")]
        [Required]
        public string MaterialsClassesName { get; set; }

        [Display(Name = "IdUpdaterName")]
        [Required]
        public string IdUpdaterName { get; set; }

        [Display(Name = "IdDBCreatorName")]
        [Required]
        public string IdDBCreatorName { get; set; }

        [Display(Name = "IdDBUpdaterName")]
        [Required]
        public string IdDBUpdaterName { get; set; }

        [Display(Name = "StageDescription")]
        [Required]
        public string StageDescription { get; set; }

        [Display(Name = "StatusValue")]
        [Required]
        public string StatusValue { get; set; }
    }
}