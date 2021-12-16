using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
//Detta är en Treatment model som använder sig av Entity Framework Core delarna etc 

// Den ska ärva information och funktionalitet ifrån DbContext
namespace DentalWeb.Models
{
    public class TreatmentsModel : DbContext
    {
        public TreatmentsModel()
        {
            //Om databasen ej finns kommer det att skapas en
            Database.EnsureCreated();
        }

        //Lägger till metoder som dbcontext har
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            //när dbcontext används så används SQLite
            options.UseSqlite("Data Source=treatments.db");
        }

        //Databas som listar behandlingarna etc. Se Homecontroller
        public DbSet<Teeth> Teethz { get; set; }

    }
}
