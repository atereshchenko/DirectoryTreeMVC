using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DirectoryTree.Models
{
    public class WorkerContext : DbContext
    {
        public WorkerContext() : base("WorkerConnection") { }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<VwMaterialsClasses> VwMaterialsClasses { get; set; }
        public DbSet<DirectoryTree.Models.New.VwMaterials> VwMaterials { get; set; }
    }
}