using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DentalWeb.Controllers
{
    public class Prislista : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
