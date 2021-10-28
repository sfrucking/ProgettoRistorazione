using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;

namespace ProgettoRistorazione.Models
{
    public class Ristorante : Entity
    {

        public string NomeRistorante { get; set; }
        public string RagioneSociale { get; set; }
        public string Piva { get; set; }
        public string Regione { get; set; }
        public string Citta { get; set; }
        public string Via { get; set; }
        public int NCivico { get; set; }
        public ICollection<Menu> Menus { get; set; }

    }
}
