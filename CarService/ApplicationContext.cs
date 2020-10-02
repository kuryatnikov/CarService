using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarService.Models;

namespace CarService
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("DefaultConnection")
        {
        }
        public DbSet<Car> Phones { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<EngType> EngTypes { get; set; }
        public DbSet<EngWork> EngWorks { get; set; }
    }
}
