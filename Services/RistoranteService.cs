using ProgettoRistorazione.Data;
using ProgettoRistorazione.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;

namespace ProgettoRistorazione.Services
{
    public class RistoranteService : IService<Ristorante>
    {
        /*private Database db;

        private static RistoranteService _instanza = null;

        public RistoranteService()
        {
            this.db = new Database("ProgettoIV");
        }

        public static RistoranteService GetInstance()
        {
            if (_instanza == null)
                _instanza = new RistoranteService();

            return _instanza;
        }*/

        private readonly DataContext _contesto;

        public RistoranteService(DataContext contesto)
        {
            _contesto = contesto;
        }

        public Ristorante Aggiorna(int id, Ristorante up)
        {
            up.Id = id;
            _contesto.Ristoranti.Find(up.Id);

            _contesto.Update(up);
            _contesto.SaveChanges();

            return up;
        }

        public Ristorante Aggiungi(Ristorante nuovo)
        {
            var nuovoRis = _contesto.Ristoranti.Add(nuovo);
            _contesto.SaveChanges();

            return nuovoRis.Entity;
        }

        public Ristorante Cerca(int id)
        {
            var ris = _contesto.Ristoranti.FirstOrDefault(r => r.Id == id);

            if(ris is null)
                throw new Exception("Ristorante non trovato");

            return ris;
        }

        public List<Ristorante> Elenco() => _contesto.Ristoranti.ToList();

        public Ristorante Rimuovi(int id)
        {
            var ris = _contesto.Ristoranti.Remove(Cerca(id));
            _contesto.SaveChanges();

            return ris.Entity;
        }
    }
}
