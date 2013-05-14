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

        public MeldungsNummerTyp erstelleWarenausgang(ProduktDetailsTyp prod, int Anzahl)
        {
            return prodRepo.erstelleWarenausgang(prod, Anzahl);
        }

        public MeldungsNummerTyp erstelleWareneingang(ProduktDetailsTyp prod, int Anzahl, object lieferSchein)
        {
            throw new NotImplementedException();
        }

        public bool pruefeLagerbestand(ProduktNummerTyp prod, int Anzahl)
        {
            throw new NotImplementedException();
        }

        public ProduktNummerTyp erstelleProdukt(ProduktDetailsTyp prod)
        {
            return prodRepo.erstelleProdukt(prod);
        }

        public ProduktDetailsTyp[] getProdukte()
        {
            return prodRepo.getProdukte();
        }


        public ProduktDetailsTyp getProdukt(ProduktNummerTyp prodNr)
        {
            return prodRepo.getProdukt(prodNr);
        }
    }
}
