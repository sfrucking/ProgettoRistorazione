using Microsoft.AspNetCore.Mvc;
using ProgettoRistorazione.Models;
using ProgettoRistorazione.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoRistorazione.Controllers
{
    [Route("[Controller]")]
    public class PiattiController : Controller
    {
        private readonly IService<Piatto> _servizio;

        public PiattiController(IService<Piatto> servizio)
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
        public IActionResult Add([FromBody] Piatto p) => Json(_servizio.Aggiungi(p));

        [HttpPut("{id}")]
        public IActionResult Up([FromBody] Piatto p, [FromRoute] int id) => Json(_servizio.Aggiorna(id, p));
        /*public IActionResult Index()
        {
            return View();
        }*/
    }
}
