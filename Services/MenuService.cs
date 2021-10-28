using ProgettoRistorazione.Data;
using ProgettoRistorazione.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoRistorazione.Services
{
    public class MenuService : IMenuService
    {
        private readonly DataContext _contesto;

        public MenuService(DataContext contesto)
        {
            _contesto = contesto;
        }

        public Menu Aggiorna(int r, int p, Menu m)
        {
            Menu mn = _contesto.Menus.FirstOrDefault(ri => ri.RistoranteId == r && ri.PiattoId == p);
            _contesto.Entry(mn).CurrentValues.SetValues(m);
            _contesto.SaveChanges();

            return m;
        }

        public Menu Aggiungi(Menu nuovo)
        {
            var nuovoMenu = _contesto.Menus.Add(nuovo);
            _contesto.SaveChanges();

            return nuovoMenu.Entity;
        }

        public List<Menu> CercaPerPiatto(int piatto)
        {
            var pia = _contesto.Menus.Where(p => p.PiattoId == piatto).ToList();

            if (pia is null)
                throw new Exception("Ristorante non trovato");

            return pia;
        }

        public List<Menu> CercaPerRistorante(int ris)
        {
            var risto = _contesto.Menus.Where(r => r.RistoranteId == ris).ToList();

            if (risto is null)
                throw new Exception("Ristorante non trovato");

            return risto;
        }

        public List<Menu> Elenco() => _contesto.Menus.ToList();

        public Menu Remove(int p, int r)
        {
            Menu mn = _contesto.Menus.FirstOrDefault(ri => ri.RistoranteId == r && ri.PiattoId == p);
            _contesto.Menus.Remove(mn);
            _contesto.SaveChanges();

            return mn;
        }
    }
}
