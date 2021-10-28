using ProgettoRistorazione.Data;
using ProgettoRistorazione.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoRistorazione.Services
{
    public class PreavvisoService : IRelationService<Preavviso>
    {
        private readonly DataContext _contesto;

        public PreavvisoService(DataContext contesto)
        {
            _contesto = contesto;
        }

        public Preavviso Aggiorna(int x, int y, Preavviso up)
        {
            Preavviso p = _contesto.Preavvisi.FirstOrDefault(ri => ri.PiattoId == x && ri.AllergeneId == y);
            _contesto.Entry(p).CurrentValues.SetValues(up);
            _contesto.SaveChanges();

            return p;
        }

        public Preavviso Aggiungi(Preavviso nuovo)
        {
            var nuovoP = _contesto.Preavvisi.Add(nuovo);
            _contesto.SaveChanges();

            return nuovoP.Entity;
        }

        public Preavviso CercaChiaveCombinata(int x, int y)
        {
            var pr = _contesto.Preavvisi.FirstOrDefault(ri => ri.PiattoId == x && ri.AllergeneId == y);

            return pr;
        }

        public List<Preavviso> CercaPerX(int x)
        {
            var pia = _contesto.Preavvisi.Where(p => p.PiattoId == x).ToList();

            if (pia is null)
                throw new Exception("Piatto non trovato");

            return pia;
        }

        public List<Preavviso> CercaPerY(int y)
        {
            var all = _contesto.Preavvisi.Where(p => p.AllergeneId == y).ToList();

            if (all is null)
                throw new Exception("Piatto non trovato");

            return all;
        }

        public List<Preavviso> Elenca() => _contesto.Preavvisi.ToList();

        public Preavviso Elimina(int x, int y)
        {
            Preavviso pr = _contesto.Preavvisi.FirstOrDefault(ri => ri.PiattoId == x && ri.AllergeneId == y);
            _contesto.Preavvisi.Remove(pr);
            _contesto.SaveChanges();

            return pr;
        }
    }
}
