﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OrderezeTask.Models
{
    public class ImageContext:DbContext
    {
        public DbSet<Image> Images { get; set; }
    }
}