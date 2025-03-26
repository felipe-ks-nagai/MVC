﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class AlunoController : Controller
    {
        // GET: Aluno
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Listar()
        {
            Aluno.GerarLista(Session);
            return View(Session["ListaAluno"] as List<Aluno>);
        }
        public ActionResult Exibir(int id)
        {
            return View((Session["ListaAluno"] as List<Aluno>).ElementAt(id));
        }

        public ActionResult Delete(int id)
        {
            return View((Session["ListaAluno"] as List<Aluno>).ElementAt(id));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Aluno());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View((Session["ListaAluno"] as List<Aluno>).ElementAt(id));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(int id, Aluno aluno)
        {
            Aluno.Procurar(Session, id)?.Excluir(Session);
            return RedirectToAction("Listar");
        }


        public ActionResult Create(Aluno aluno)
        {
            aluno.Adicionar(Session);
            return RedirectToAction("Listar");
        }

        public ActionResult Edit(int id, Aluno aluno)
        {
            Aluno.Procurar(Session, id)?.Editar(Session, aluno, id);
            return RedirectToAction("Listar");
        }


    }
}