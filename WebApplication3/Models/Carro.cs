using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Carro
    {
        public string Placa { get; set; }
        public int Ano {  get; set; }

        public string Cor { get; set; }

        public string Car {  get; set; }

        public static void GerarLista(HttpSessionStateBase session)
        {
            if (session["ListaCarro"] != null)
            {
                if (((List<Carro>)session["ListaCarro"]).Count > 0)
                {
                    return;
                }
            }
            var lista = new List<Carro>();
            lista.Add(new Carro { Placa = "32145124", Ano = 2020, Cor = "Rosa" });
            lista.Add(new Carro { Placa = "23fs65", Ano = 2019, Cor = "Preto" });
            lista.Add(new Carro { Placa = "3dfv21", Ano = 2022, Cor = "Branco" });

            session.Remove("ListaCarro");
            session.Add("ListaCarro", lista);

        }
        public static Carro Procurar(HttpSessionStateBase session, int id)
        {
            if (session["ListaCarro"] != null)
            {
                return (session["ListaCarro"] as List<Carro>).ElementAt(id);
            }
            return null;
        }

        public void Excluir(HttpSessionStateBase session)
        {
            if (session["ListaCarro"] != null)
            {
                (session["ListaCarro"] as List<Carro>).Remove(this);
            }
        }
        public void Adicionar(HttpSessionStateBase session)
        {
            if (session["ListaCarro"] != null)
            {
                (session["ListaCarro"] as List<Carro>).Add(this);
            }
        }
        public void Editar(HttpSessionStateBase session, Carro carro, int index)
        {
            if (session["ListaCarro"] != null)
            {
                var listaCarros = (List<Carro>)session["ListaCarro"];
                listaCarros[index] = carro;

            }

        }
    }
}