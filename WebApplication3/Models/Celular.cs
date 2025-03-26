using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Celular
    {
        public int Numero { get; set; }
        public string Marca { get; set; }

        public bool Novo { get; set; }


        public static void GerarLista(HttpSessionStateBase session)
        {
            if (session["ListaCelular"] != null)
            {
                if (((List<Celular>)session["ListaCelular"]).Count > 0)
                {
                    return;
                }
            }
            var lista = new List<Celular>();
            lista.Add(new Celular { Numero = 12, Marca = "Samsung", Novo = true });
            lista.Add(new Celular { Numero = 13, Marca = "Lg", Novo = false });
            lista.Add(new Celular { Numero = 10, Marca = "Apple", Novo = true });

            session.Remove("ListaCelular");
            session.Add("ListaCelular", lista);

        }
        public static Celular Procurar(HttpSessionStateBase session, int id)
        {
            if (session["ListaCelular"] != null)
            {
                return (session["ListaCelular"] as List<Celular>).ElementAt(id);
            }
            return null;
        }
        public void Excluir(HttpSessionStateBase session)
        {
            if (session["ListaCelular"] != null)
            {
                (session["ListaCelular"] as List<Celular>).Remove(this);
            }
        }
        public void Adicionar(HttpSessionStateBase session)
        {
            if (session["ListaCelular"] != null)
            {
                (session["ListaCelular"] as List<Celular>).Add(this);
            }
        }
        public void Editar(HttpSessionStateBase session, Celular celular, int index)
        {
            if (session["ListaCelular"] != null)
            {
                var listaCelular = (List<Celular>)session["ListaCelular"];
                listaCelular[index] = celular;

            }

        }

    }
}