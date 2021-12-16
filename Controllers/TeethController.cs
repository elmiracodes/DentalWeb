using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentalWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace DentalWeb.Controllers
{
    public class TeethController : Controller
    {
        public IActionResult Index()
        { 
            
            // Listan från databaserna finns tillgänglig inom using klammrarna
            using (TreatmentsModel db = new TreatmentsModel())
            { 
              
                var behandlingslista = db.Teethz.ToList();
                return View(behandlingslista);
            }
           
        }
        // Skapa sidan Create för att kunna lägga till behandlingar i databasen
        // GET metod 
        public IActionResult Create()
        {
            return View();
        }

        //Det som kommer hit blir en ny behandling
        //HttpPost tar hand om svaren från formuläret som skickade modellen till controllern

        [HttpPost]
        public IActionResult Create(Teeth nyTeeth)
        {
            using (TreatmentsModel db = new TreatmentsModel())
            {
                db.Teethz.Add(nyTeeth);
                db.SaveChanges();
                return RedirectToAction("Index");
                // Du blir redirectad till index
            }


            


        }

    }
}
