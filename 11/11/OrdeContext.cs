using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework5
{
    class OrdeContext:DbContext
    {
        public OrdeContext() : base("OrderDataBase")
        {
            Database.SetInitializer(
              new DropCreateDatabaseIfModelChanges<OrdeContext>());
        }
        public DbSet<Order> Orders { get; set; }
    }
}
