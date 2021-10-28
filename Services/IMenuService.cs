using ProgettoRistorazione.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoRistorazione.Services
{
    interface IMenuService
    {

        public List<Menu> Elenco();
        public List<Menu> CercaPerRistorante(int ris);
        public List<Menu> CercaPerPiatto(int piatto);
        public Menu Aggiungi(Menu nuovo);
        public Menu Aggiorna(int r, int p, Menu m);
        public Menu Remove(int p, int r);

    }
}
