using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using ProgettoRistorazione.Models;
using ProgettoRistorazione.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoRistorazione.Controllers
{
    [Route("[Controller]")]
    public class RistoranteController : Controller
    {
        private readonly IService<Ristorante> _servizio;

        public RistoranteController(IService<Ristorante> servizio)
        {
            _servizio = servizio;
        }

        [HttpGet]
        public IActionResult GetAll() => Json(_servizio.Elenco());

        [HttpGet("{id}")]
        public IActionResult CercaId([FromRoute] int id) => Json(_servizio.Cerca(id));

        [HttpDelete("{id}")]
        public IActionResult Rimuovi([FromRoute] int id) => Json(_servizio.Rimuovi(id));

        [HttpPost]
        public IActionResult Add([FromBody] Ristorante r) => Json(_servizio.Aggiungi(r));

        [HttpPut("{id}")]
        public IActionResult Up([FromBody] Ristorante r, [FromRoute] int id) => Json(_servizio.Aggiorna(id, r));

        /*public IActionResult Index()
        {
            return View();
        }*/
    }
}
