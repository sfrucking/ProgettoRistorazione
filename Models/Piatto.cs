using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;

namespace ProgettoRistorazione.Models
{
    public class Piatto : Entity
    {

        public string NomePiatto { get; set; }
        public ICollection<Procedimento> Ingredienti { get; set; }
        public ICollection<Preavviso> Allergeni { get; set; }
        public ICollection<Menu> Menus { get; set; }

    }
}
