using Gestione_Impiegati_ASPWEB.Models;
using Gestione_Impiegati_ASPWEB.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Gestione_Impiegati_ASPWEB.Services
{
    public class ImpiegatoService
    {
        private readonly ImpiegatoRepository _repository;
        public ImpiegatoService(ImpiegatoRepository repository)
        {
            _repository = repository;
        }

        public List<Impiegato> ElencoTuttiImpiegati()
        {
            return _repository.GetAll();
        }

        public bool InserisciImpiegato(Impiegato imp)
        {
            return _repository.Insert(imp);
        }

        public Impiegato? RicercaImpiegatoPerMatricola(string varMatr)
        {
            return _repository.GetByMatricola(varMatr);
        }

        public bool EliminaImpiegatoPerMatricola(string varMatr)
        {
            Impiegato? tmp = _repository.GetByMatricola(varMatr);
            if (tmp == null)
                return false;
            return _repository.Delete(tmp.ImpiegatoId);
        }

        public bool ModificaImpiegato(Impiegato impV, Impiegato impN)
        {
            impV.Nome = impN.Nome;
            impV.Cognome = impN.Cognome;
            impV.Ruolo = impN.Ruolo;
            impV.RepartoRif = impN.RepartoRif;
            impV.Indirizzo = impN.Indirizzo;
            impV.Citta = impN.Citta;
            impV.Provincia = impN.Provincia;

            return _repository.Update(impV);
        }






    }

}
