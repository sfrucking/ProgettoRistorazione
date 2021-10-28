using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProgettoRistorazione.Models
{
    public class Preavviso
    {
        public int PiattoId { get; set; }
        public int AllergeneId { get; set; }
        [JsonIgnore]
        public Piatto Piatto { get; set; }
        public Allergene Allergene { get; set; }

    }
}
