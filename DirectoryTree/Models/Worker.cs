﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DirectoryTree.Models
{
    public class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }        
        public string PassHash { get; set; }
    }
}