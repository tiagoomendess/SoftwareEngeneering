using BusinessObjects;
using DataLayer;
using System;
using System.Collections.Generic;
using DataLayer.API;

namespace BusinessLayer.Controllers
{
    public static class UtilizadorController
    {
        /// <summary>
        /// Faz pedido com os dados do utilizador para receber dados de acesso
        /// </summary>
        /// <param name="nif">NIF do utilizador</param>
        /// <param name="email">Email do Utilizador</param>
        /// <returns>True - Registado na Base de Dados</returns>
        public static bool PedirAcesso(string nif, string email)
        {
            return Utilizadores.PedidoAcesso(nif, email);
        }

        /// <summary>
        /// Autenticação do utilizador
        /// </summary>
        /// <param name="nif">Nif de identificação</param>
        /// <param name="pass">Palavra-Passe de acesso</param>
        /// <returns></returns>
        public static bool Login(string nif, string pass)
        {
            return Utilizadores.Login(nif, pass);
        }

        /// <summary>
        /// Retira utilizador logado
        /// </summary>
        /// <param name="uti">Utilizador Logado</param>
        /// <returns></returns>
        public static bool Logout(Utilizador uti)
        {
            Utilizadores.Logout(uti);
            return true;            
        }

        /// <summary>
        /// Definir palavra passe
        /// </summary>
        /// <param name="codigo">Codigo Forncido de Acesso</param>
        /// <param name="pass">Nova palavra passe do utilizador</param>
        /// <param name="passRep">Repetição de segurança</param>
        /// <returns></returns>
        public static bool DefinirPass(string codigo, string pass, string passRep)
        {
            //List<PedidoAcesso> pedidos;
            //PedidoAcesso pedido;
            //Utilizador user;
            //MyRestClient rest;

            if (pass.Equals(passRep))
            {
                //pedidos = PedidosAcesso.Where("codigo", "=", codigo);

                //if (pedidos.Count < 1)
                //    return false;

                //pedido = pedidos[0];

                //rest = new MyRestClient("http://utentes.cloudapp.net/Utentes.svc/rest/utente/getbynifnoauth/" + pedido.Nif);
                

                //user = Utilizadores.Novo(pedido.Email, null,);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Login pelo Facebook
        /// </summary>
        /// <returns></returns>
        public static bool Facebook()
        {
            //return Utilizadores.
            return true;
        }

        /// <summary>
        /// Identifica utilizador logado
        /// </summary>
        /// <returns></returns>
        public static Utilizador Autencicado()
        {
            return Utilizadores.Autenticado();
        }



        /// <summary>
        /// Registos do log - SÓ PARA TESTES !
        /// </summary>
        /// <returns></returns>
        public static List<string> GetLog()
        {
            return Log.PrintLog();
        }
    }
}
