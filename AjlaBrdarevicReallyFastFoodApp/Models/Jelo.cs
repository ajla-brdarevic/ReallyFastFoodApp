using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjlaBrdarevicReallyFastFoodApp.Models
{
    public class Jelo
    {
        public int Id { get; set; }
        public string Slika { get; set; }
        public string Ime { get; set; }
        public decimal Cijena { get; set; }
        public bool Odabrano { get; set; }
        public int Kalorije { get; set; }
        public int Kolicina { get; set; }
    }
}
