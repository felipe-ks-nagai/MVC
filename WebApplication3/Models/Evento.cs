using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Evento
    {
        public string Local { get; set; }
        public string Data { get; set; }

        public static void GerarLista(HttpSessionStateBase session)
        {
            if (session["ListaEvento"] != null)
            {
                if (((List<Evento>)session["ListaEvento"]).Count > 0)
                {
                    return;
                }
            }
            var lista = new List<Evento>();
            lista.Add(new Evento { Local = "Casa do Miguel", Data = "23/03/2021" });
            lista.Add(new Evento { Local = "Parque das aguas", Data = "12/04/2024" });
            lista.Add(new Evento { Local = "Aniversario do Miguel", Data = "25/06/2025" });

            session.Remove("ListaEvento");
            session.Add("ListaEvento", lista);

        }
        public static Evento Procurar(HttpSessionStateBase session, int id)
        {
            if (session["ListaEvento"] != null)
            {
                return (session["ListaEvento"] as List<Evento>).ElementAt(id);
            }
            return null;
        }

        public void Excluir(HttpSessionStateBase session)
        {
            if (session["ListaEvento"] != null)
            {
                (session["ListaEvento"] as List<Evento>).Remove(this);
            }
        }
        public void Adicionar(HttpSessionStateBase session)
        {
            if (session["ListaEvento"] != null)
            {
                (session["ListaEvento"] as List<Evento>).Add(this);
            }
        }
        public void Editar(HttpSessionStateBase session, Evento evento, int index)
        {
            if (session["ListaEvento"] != null)
            {
                var listaEvento = (List<Evento>)session["ListaEvento"];
                listaEvento[index] = evento;

            }

        }
    }
}