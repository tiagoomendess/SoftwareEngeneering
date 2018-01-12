using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using DataLayer.API;
using Newtonsoft.Json.Linq;

namespace DataLayer
{

    /// <summary>
    /// Gere todos os objetos de Utilizador na memoria e na base de dados
    /// </summary>
    public static class Utilizadores
    {

        private static List<Utilizador> utilizadores = new List<Utilizador>();
        private static Utilizador autenticado;

        /// <summary>
        /// Pedir para se regista na aplicação
        /// </summary>
        /// <returns></returns>
        public static bool PedidoAcesso(string nif, string email)
        {

            Log.Info("A pedir acesso para o nif " + nif);
            MyRestClient rest;
            List<Utilizador> users = Utilizadores.Where("nif", "=", nif);
            List<PedidoAcesso> pedidos = PedidosAcesso.Where("nif", "=", nif);
            JObject jsonObject;
            PedidoAcesso pedido;

            //Se ja existir um utilizador com o nif registado retornar falso
            if (users.Count > 0)
            {
                Log.Info("Nif existe na base de dados local, não permitir novo pedido de acesso!");
                return false;
            }

            Log.Info("Nif não existe na base de dados local");

            //Se ja existe um pedido para aquele nif
            if (pedidos.Count > 0)
            {
                Log.Info("Ja existe um pedido com o nif, não permitir novo pedido de acesso!");
                return false;
            }

            rest = new MyRestClient("http://utentes.cloudapp.net/Utentes.svc/rest/utente/getbynifnoauth/" + nif);
            jsonObject = rest.GetJsonObject();

            if (jsonObject == null)
            {
                Log.Erro("Nao foi possivel estabelecer conexão com o servidor do municipio.");
                return false;
            }
            
            if ((bool)jsonObject.GetValue("Sucesso"))
            {
                //fazer codigo para pedir acesso
                Log.Info("Nif existe na base de dados do municipio");
                pedido = PedidosAcesso.Novo(nif, email);
                Log.Info("Foi feito um pedido de acesso para o nif " + nif + " com o id " + pedido.Id + " com o codigo " + pedido.Codigo + ".");

            }
            else
            {
                Log.Info("Nif NÃO existe na base de dados do municipio");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Devolve o utilizador autenticado no momento
        /// </summary>
        /// <returns>Um utilizador autenticado ou null caso não esteja nenhum utilizador autenticado</returns>
        public static Utilizador Autenticado()
        {
            return autenticado;
        }

        /// <summary>
        /// Faz o login do utilizador
        /// </summary>
        /// <param name="nif">NIF do utilizador</param>
        /// <param name="password">Password</param>
        /// <returns>Verdadeiro se o login for bem sucedido e falso se falhar</returns>
        public static bool Login(string nif, string password)
        {
            Utilizador user;
            DataTable table;
            DBConnection db;
            Regex reg = new Regex(@"\d{9}");
            string dbHashedPassword;
            bool success;

            if (!reg.Match(nif).Success)
                return false;

            db = new DBConnection();
            table = db.Query("SELECT id, password FROM utilizador WHERE nif = @0", nif);

            if (table.Rows.Count != 1)
                return false;

            dbHashedPassword = table.Rows[0].Field<string>("password");

            success = BCrypt.Net.BCrypt.Verify(password, dbHashedPassword);
            if (success)
            {
                user = Utilizadores.GetById(table.Rows[0].Field<int>("id"));
                utilizadores.Add(user);
                autenticado = user;
                return true;
            }

            //O login falhou
            return false;
        }

        /// <summary>
        /// Faz o logout do utilizador
        /// </summary>
        /// <param name="utilizador">Utilizador que se pretende terminar a sessao</param>
        public static void Logout(Utilizador utilizador)
        {
            Guarda(utilizador);
            autenticado = null;
            return;
        }

        /// <summary>
        /// Pesquisa por um utilizador
        /// </summary>
        /// <param name="atributo">Nome do atributo</param>
        /// <param name="operador">Operador a aplicar</param>
        /// <param name="valor">Valor do atributo</param>
        /// <returns>Todas as instancias que coorespondam à condição</returns>
        public static List<Utilizador> Where(string atributo, string operador, object valor)
        {
            List<Utilizador> users = new List<Utilizador>();
            DBConnection db = new DBConnection();
            DataTable table;

            int id;
            string email, nome, nif, telemovel;
            DateTime dataNascimento;
            TipoUtilizador tipo;
            
            table = db.Query("SELECT * FROM utilizador WHERE " + atributo + " " + operador + " @0", valor);

            if (table == null)
                return users;

            //Percorrer todas as linhas retornadas da base de dados
            foreach (DataRow row in table.Rows)
            {
                id = row.Field<int>("id");
                email = row.Field<string>("email");
                nome = row.Field<string>("nome");
                nif = row.Field<string>("nif");
                telemovel = row.Field<string>("telemovel");
                dataNascimento = row.Field<DateTime>("data_nascimento");
                tipo = TiposUtilizador.GetById(row.Field<int>("tipo_utilizador_id"));

                users.Add(new Utilizador(id, nome, nif, email, dataNascimento, telemovel, tipo));
            }

            return users;
        }


        /// <summary>
        /// Procura um utilizador pelo id
        /// </summary>
        /// <param name="id">ID a procurar</param>
        /// <returns>Instancia de utilizador coorespondente ou null se nao existir</returns>
        public static Utilizador GetById(int id)
        {
            DBConnection db;
            Utilizador utilizador = utilizadores.FindLast(x => x.Id == id);
            DataTable table;

            string email, nome, nif, telemovel;
            DateTime dataNascimento;
            TipoUtilizador tipo;

            //1º tenta ver se ja tem esse tipo em memoria
            if (utilizador != null)
                return utilizador;

            //Caso nao tenha esse tipo em memoria vai à base de dados
            db = new DBConnection();
            table = db.Query("SELECT * FROM utilizador WHERE id = @0", id);

            //Se o id não existir também na base de dados retorna objeto default
            if (table.Rows.Count == 0)
                return utilizador;

            //criar variaveis necessarias par ao objeto de utilizador
            email = table.Rows[0].Field<string>("email");
            nome = table.Rows[0].Field<string>("nome");
            nif = table.Rows[0].Field<string>("nif");
            telemovel = table.Rows[0].Field<string>("telemovel");
            dataNascimento = table.Rows[0].Field<DateTime>("data_nascimento");
            tipo = TiposUtilizador.GetById(table.Rows[0].Field<int>("tipo_utilizador_id"));

            //Criar novo objeto de Utilizador
            utilizador = new Utilizador(id, nome, nif, email, dataNascimento, telemovel, tipo);
            utilizadores.Add(utilizador);
            return utilizador;
        }

        /// <summary>
        /// Guarda um utilizador já existente
        /// </summary>
        /// <param name="user">Utilizador a guardar</param>
        /// <returns>Verdadeiro se guardar, falso se nao conseguir guardar</returns>
        public static bool Guarda(Utilizador user)
        {
            DBConnection connection = new DBConnection();
            int rows = 0;

            utilizadores.Remove(user);

            rows = connection.NonQuery("UPDATE utilizador SET email = @0, data_nascimento = @1, nome = @2, telemovel = @3, nif = @4, tipo_utilizador_id = @5 WHERE id = @6", user.Email, user.DataNascimento, user.Nome, user.Telemovel, user.Nif, user.Tipo.Id, user.Id);

            if (rows == 1)
            {
                utilizadores.Add(user);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Cria um novo utilizador
        /// </summary>
        /// <param name="email">Email do Utilizador</param>
        /// <param name="dataNascimento">Data de nascimento</param>
        /// <param name="nome">Nome</param>
        /// <param name="password">Password</param>
        /// <param name="telemovel">Numero de Telemovel</param>
        /// <param name="nif">Numero de identificação fiscarl</param>
        /// <param name="tipo">Tipo de utilizador</param>
        /// <returns>Instancia de utilizador acabade de criar</returns>
        public static Utilizador Novo(string email, DateTime dataNascimento, string nome, string password, string telemovel, string nif, TipoUtilizador tipo)
        {
            int id = 0;
            string pwd = BCrypt.Net.BCrypt.HashPassword(password);
            int rows;
            Utilizador newUser;
            DBConnection conn = new DBConnection();
            DataTable dt;

            //Inserir user na base de dados
            rows = conn.NonQuery("INSERT INTO utilizador (email, data_nascimento, nome, password, telemovel, nif, tipo_utilizador_id) VALUES (@0, @1, @2, @3, @4, @5, @6)",
                email, dataNascimento, nome, pwd, telemovel, nif, tipo.Id);

            dt = conn.Query("SELECT * FROM utilizador WHERE email = @0", email);
            
            id = dt.Rows[dt.Rows.Count - 1].Field<int>("id");
            newUser = new Utilizador(id, nome, nif, email, dataNascimento, telemovel, tipo);

            utilizadores.Add(newUser);

            return newUser;
        }
    }
}
