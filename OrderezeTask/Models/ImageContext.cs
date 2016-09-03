using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OrderezeTask.Models
{
    public class ImageContext:DbContext
    {
        //Find Connection String
        public ImageContext(): base("name = DbImage") 
        {
                   
        }
        public DbSet<Image> Images { get; set; }
    }
}