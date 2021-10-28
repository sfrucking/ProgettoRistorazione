using Microsoft.EntityFrameworkCore;
using ProgettoRistorazione.Data;
using ProgettoRistorazione.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoRistorazione.Services
{
    public class PiattoService : IService<Piatto>
    {

        private readonly DataContext _contesto;

        public PiattoService(DataContext contesto)
        {
            _contesto = contesto;
        }

        public Piatto Aggiorna(int id, Piatto up)
        {
            var piatto = Cerca(id);

            _contesto.Piatti.Where(p => p == piatto);
            _contesto.SaveChanges();

            return piatto;
        }

        public Piatto Aggiungi(Piatto nuovo)
        {
            var nuovoPiatto = _contesto.Piatti.Add(nuovo);
            _contesto.SaveChanges();

            return nuovoPiatto.Entity;
        }

        public Piatto Cerca(int id)
        {
            var piatto = _contesto.Piatti.FirstOrDefault(p => p.Id == id);

            if (piatto is null)
                throw new Exception("Piatto non trovato");

            return piatto;
        }

        public List<Piatto> Elenco() => _contesto.Piatti.Include(p => p.Ingredienti).ToList();

        public Piatto Rimuovi(int id)
        {
            var piatto = _contesto.Piatti.Remove(Cerca(id));
            _contesto.SaveChanges();

            return piatto.Entity;
        }
    }
}
