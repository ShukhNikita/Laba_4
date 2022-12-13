using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace Product.Context
{
    public class ProductContext: DbContext
    {
        public DbSet<ActivityTypes> activityTypes { get; set; }
        public DbSet<Companies> companies { get; set; }
        public DbSet<MeasurementUnits> measurementUnits { get; set; }
        public DbSet<OwnershipForms> ownershipForms { get; set; }
        public DbSet<ProductionTypes> productionTypes { get; set; }
        public DbSet<ProductReleasePlans> productReleasePlans { get; set; }
        public DbSet<Products> products { get; set; }
        public DbSet<ProductSalesPlans> productSalesPlans { get; set; }
        public IEnumerable ProductionTypes { get; internal set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {   
            optionsBuilder.UseSqlServer(Connection.GetConnetion());
        }*/

        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
        }
    }
}
