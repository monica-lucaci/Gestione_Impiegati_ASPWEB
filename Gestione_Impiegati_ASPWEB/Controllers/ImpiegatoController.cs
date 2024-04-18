using Gestione_Impiegati_ASPWEB.Models;
using Gestione_Impiegati_ASPWEB.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gestione_Impiegati_ASPWEB.Controllers
{
    public class ImpiegatoController : Controller
    {

        private readonly ImpiegatoService _service;
        public ImpiegatoController(ImpiegatoService service)
        {
            _service = service;
        }

        public IActionResult ListaImpiegati()
        {
            List<Impiegato> elenco = _service.ElencoTuttiImpiegati();
            return View(elenco);
        }

        public IActionResult Inserimento()
        {
            return View();
        }

        [HttpPost]
        public RedirectResult Salvataggio(Impiegato objImp)
        {
            if (_service.InserisciImpiegato(objImp))
                return Redirect("/Impiegato/ListaImpiegati");
            else
               return  Redirect("/Impiegato/Errore");
        }

        public IActionResult Dettaglio(string varMatr)
        {
            if (string.IsNullOrEmpty(varMatr))
                return Redirect("/Impiegato/Errore");
            Impiegato? impiegato = _service.RicercaImpiegatoPerMatricola(varMatr);
            if (impiegato is null)
                return Redirect("/Impiegato/Errore");

            return View(impiegato);
        }


    }
}
