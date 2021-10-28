using ProgettoRistorazione.Data;
using ProgettoRistorazione.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoRistorazione.Services
{
    public class ProcedimentoService : IRelationService<Procedimento>
    {
        private readonly DataContext _contesto;

        public ProcedimentoService(DataContext contesto)
        {
            _contesto = contesto;
        }

        public Procedimento Aggiorna(int x, int y, Procedimento up)
        {
            Procedimento p = _contesto.Procedimenti.FirstOrDefault(ri => ri.PiattoId == x && ri.IngredienteId == y);
            _contesto.Entry(p).CurrentValues.SetValues(up);
            _contesto.SaveChanges();

            return p;
        }

        public Procedimento Aggiungi(Procedimento nuovo)
        {
            var nuovoP = _contesto.Procedimenti.Add(nuovo);
            _contesto.SaveChanges();

            return nuovoP.Entity;
        }

        public Procedimento CercaChiaveCombinata(int x, int y)
        {
            var pr = _contesto.Procedimenti.FirstOrDefault(ri => ri.PiattoId == x && ri.IngredienteId == y);

            return pr;
        }

        public List<Procedimento> CercaPerX(int x)
        {
            var pia = _contesto.Procedimenti.Where(p => p.PiattoId == x).ToList();

            if (pia is null)
                throw new Exception("Piatto non trovato");

            return pia;
        }

        public List<Procedimento> CercaPerY(int y)
        {
            var ing = _contesto.Procedimenti.Where(p => p.PiattoId == y).ToList();

            if (ing is null)
                throw new Exception("Ingrediente non trovato");

            return ing;
        }

        public List<Procedimento> Elenca() => _contesto.Procedimenti.ToList();

        public Procedimento Elimina(int x, int y)
        {
            Procedimento pr = _contesto.Procedimenti.FirstOrDefault(ri => ri.PiattoId == x && ri.IngredienteId == y);
            _contesto.Procedimenti.Remove(pr);
            _contesto.SaveChanges();

            return pr;
        }
    }
}
