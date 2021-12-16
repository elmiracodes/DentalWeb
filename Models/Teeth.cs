using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


//Denna klass motsvarar tabellen i treatmentmodels dvs behandlingar i sqlite

namespace DentalWeb.Models
{
    public class Teeth
    {
        public int Id { get; set; }
        public string Namn { get; set; }
        public string Beskrivning { get; set; }
    }
}
