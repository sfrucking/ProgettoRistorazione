using System.Collections.Generic;
using Utility;

namespace ProgettoRistorazione.Models
{
    public class Allergene : Entity
    {
        public string NomeAllergene { get; set; }
        public ICollection<Preavviso> Piatto { get; set; }
    }
}