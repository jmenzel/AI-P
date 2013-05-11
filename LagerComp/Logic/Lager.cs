using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HES.Lager.Repository.Entity;
using HES.Lager.Produkt.Repository.Entity;
using HES.Lager.Produkt.Repository;

namespace HES.Lager.Logic
{
    class Lager : ILager
    {
        ICompProdukt prodRepo;
        
        public Lager()
        {
            prodRepo = new ProduktRepo();
        }

        public string erstelleWarenausgang(ProduktDetailsTyp prod, int Anzahl)
        {
            throw new NotImplementedException();
        }

        public string erstelleWareneingang(ProduktDetailsTyp prod, int Anzahl, object lieferSchein)
        {
            throw new NotImplementedException();
        }

        public bool pruefeLagerbestand(ProduktDetailsTyp prod, int Anzahl)
        {
            throw new NotImplementedException();
        }

        public string erstelleProdukt(ProduktDetailsTyp prod)
        {
            return prodRepo.erstelleProdukt(prod);
        }

        public ProduktDetailsTyp[] getProdukte()
        {
            return prodRepo.getProdukte();
        }
    }
}
