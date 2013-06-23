using HES.AuftragserfassungComp;
using HES.Kunde;
using HES.Lager;
using HES.TransportComp.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HESCommunicationLib.Transport
{
    public interface ITDLConnector
    {
        void setKundenComp(IKunde kunde);
        void setAuftragserfassungComp(IAuftragserfassung auftrag);
        void setLagerComp(ILager lager);

        void putTransportauftrag(TransportauftragTyp ta);
    }
}
