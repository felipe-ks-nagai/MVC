﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Xml.Linq;
using Microsoft.Ajax.Utilities;

namespace WebApplication3.Models
{
    public class Aluno
    {
        public string Nome { get; set; }

        public string RA { get; set; }

        

        public static void GerarLista(HttpSessionStateBase session)
        {
            if (session["ListaAluno"] != null)
            {
                if(((List<Aluno>)session["ListaAluno"]).Count > 0)
                {
                    return;
                }
            }
            
            var  lista = new List<Aluno>();
            lista.Add(new Aluno { Nome = "Rodrigo Manga", RA = "42424"});
            lista.Add(new Aluno { Nome = "Lula", RA = "13"});
            lista.Add(new Aluno { Nome = "Bolsonaro", RA = "22"});

            session.Remove("ListaAluno");
            session.Add("ListaAluno", lista);

        }
        public void Adicionar(HttpSessionStateBase session)
        {
            if (session["ListaAluno"] != null)
            {
                (session["ListaAluno"] as List<Aluno>).Add(this);
            }
        }

        public static Aluno Procurar(HttpSessionStateBase session, int id)
        {
            if (session["ListaAluno"] != null)
            {
                return (session["ListaAluno"] as List<Aluno>).ElementAt(id);
            }
            return null;
        }

        public void Excluir(HttpSessionStateBase session)
        {
            if (session["ListaAluno"] != null)
            {
                (session["ListaAluno"] as List<Aluno>).Remove(this);
            }
        }

        public void Editar(HttpSessionStateBase session, Aluno aluno, int index)
        {
            if (session["ListaAluno"] != null)
            {
                var listaAlunos = (List<Aluno>)session["ListaAluno"];
                listaAlunos[index] = aluno;

            }

        }


    }


}