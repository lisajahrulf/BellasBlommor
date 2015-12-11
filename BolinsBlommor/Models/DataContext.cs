using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BolinsBlommor.Models
{
    public class DataContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public DataContext() : base("name=DataContext")
        {
        }

        public System.Data.Entity.DbSet<BolinsBlommor.Models.Bouqette> Bouqettes { get; set; }

        public System.Data.Entity.DbSet<BolinsBlommor.Models.Order> Orders { get; set; }

        public System.Data.Entity.DbSet<BolinsBlommor.Models.DeliveryPerson> DeliveryPersons { get; set; }

        public System.Data.Entity.DbSet<BolinsBlommor.Models.OrderBouqette> OrderBouqette { get; set; }

    }
}
