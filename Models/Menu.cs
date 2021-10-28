using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProgettoRistorazione.Models
{
    public class Menu
    {
        public int PiattoId { get; set; }
        public int RistoranteId { get; set; }
        public float Prezzo { get; set; }
        [JsonIgnore]
        public Ristorante Ristorante { get; set; }
        public Piatto Piatto { get; set; }
        
    }
}
