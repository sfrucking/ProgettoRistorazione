using System.Collections.Generic;
using Utility;

namespace ProgettoRistorazione.Models
{
    public class Ingrediente : Entity
    {
        public string NomeIngrediente { get; set; }
        public ICollection<Procedimento> Piatto { get; set; }
    }
}