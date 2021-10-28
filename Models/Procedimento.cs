using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProgettoRistorazione.Models
{
    public class Procedimento
    {
        public int PiattoId { get; set; }
        public int IngredienteId { get; set; }
        [JsonIgnore]
        public Piatto Piatto { get; set; }
        public Ingrediente Ingrediente { get; set; }

    }
}
