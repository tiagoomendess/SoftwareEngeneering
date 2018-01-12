using BusinessObjects;
using DataLayer;
using DataLayer.API;
using System;
using System.Collections.Generic;

namespace Testes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("A iniciar teste!");

            //Log.PrintLog();

            //Console.WriteLine("---------------Pedidos pelo NIF-------------------------");

            ////Todos os pedidos são por nif

            //Servico municipio1 = new Servico("utilizadores");
            //Utilizador u = (Utilizador)municipio1.Pedir(215532546);
            //Console.WriteLine(u.Nome);

            //Servico municipio2 = new Servico("faturas");
            //Fatura f = (Fatura)municipio2.Pedir(215532546);
            //Console.WriteLine(f.Valor + "Euros");


            //Servico municipio3 = new Servico("contratos");
            //Contrato c = (Contrato)municipio3.Pedir(215532546);
            //Console.WriteLine(c.Codigo);

            //Console.WriteLine("------------------Todos os Elementos----------------------");

            //List<object> todos = municipio1.PedirTodos();

            //foreach (Utilizador item in todos)
            //{
            //    Console.WriteLine("--------------" + item.Nif + "--------------");
            //    Console.WriteLine(item.Nome);
            //    Console.WriteLine(item.Email);
            //    Console.WriteLine("--------------------------------------------");
            //}

            //Console.WriteLine("------------------Todos os Elementos por NIF----------------------");

            //List<object> todosNif = municipio2.PedirTodos(215532546);

            //foreach (Fatura item2 in todosNif)
            //{
            //    Console.WriteLine("--------------" + item2.Data + "--------------");
            //    Console.WriteLine(item2.Valor + " Euros");
            //    Console.WriteLine(item2.Id);
            //    Console.WriteLine("--------------------------------------------");
            //}

            
            Console.WriteLine(Utilizadores.PedidoAcesso("264628773", "tiago@mendes.com.pt").ToString());
            DateTime data = DateTime.Now;
            Utilizadores.Novo("ze@oliveira.pt", data, "ze", "ze1234", "917920418", "12345678",TiposUtilizador.GetById(1));
            Log.PrintLog();

            Console.ReadLine();
        }
    }
}
