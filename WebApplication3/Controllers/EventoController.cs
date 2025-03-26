using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class EventoController : Controller
    {
        // GET: Evento
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Listar()
        {
            Evento.GerarLista(Session);
            return View(Session["ListaEvento"] as List<Evento>);
        }
        public ActionResult Exibir(int id)
        {
            return View((Session["ListaEvento"] as List<Evento>).ElementAt(id));
        }

        public ActionResult Delete(int id)
        {
            return View((Session["ListaEvento"] as List<Evento>).ElementAt(id));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Evento());
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View((Session["ListaEvento"] as List<Evento>).ElementAt(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Evento evento)
        {
            Evento.Procurar(Session, id)?.Excluir(Session);
            return RedirectToAction("Listar");
        }
        public ActionResult Create(Evento evento)
        {
            evento.Adicionar(Session);
            return RedirectToAction("Listar");
        }

        public ActionResult Edit(int id, Evento evento)
        {
            Evento.Procurar(Session, id)?.Editar(Session, evento, id);
            return RedirectToAction("Listar");
        }
    }
}