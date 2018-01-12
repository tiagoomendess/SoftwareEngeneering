using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DataLayer
{

    public static class Contratos
    {
        private static List<Contrato> contratos = new List<Contrato>();

        /// <summary>
        /// Retorna contratos dada uma condição
        /// </summary>
        /// <param name="atributo">Atributo a comparar</param>
        /// <param name="operador">Tipo de comparação</param>
        /// <param name="valor">Valor a comparar</param>
        /// <returns></returns>
        public static List<Contrato> Where(string atributo, string operador, object valor)
        {
            List<Contrato> contratos = new List<Contrato>();
            DBConnection db = new DBConnection();
            DataTable table;

            int id, utilizador_id, morada_id;
            string codigo;
            DateTime dataInicio;
            Utilizador utilizador;
            Morada morada;

            table = db.Query("SELECT * FROM contrato WHERE " + atributo + " " + operador + " @0", valor);

            //Percorrer todas as linhas retornadas da base de dados
            foreach (DataRow row in table.Rows)
            {
                id = row.Field<int>("id");
                codigo = row.Field<string>("codigo");
                utilizador_id = row.Field<int>("utilizador_id");
                morada_id = row.Field<int>("morada_id");
                dataInicio = row.Field<DateTime>("data_inicio");

                morada = Moradas.GetById(morada_id);
                utilizador = Utilizadores.GetById(utilizador_id);

                contratos.Add(new Contrato(id, dataInicio, codigo, morada, utilizador));
            }

            return contratos;
        }

        /// <summary>
        /// Devolve todos os contratos
        /// </summary>
        /// <returns></returns>
        public static List<Contrato> GetAll()
        {
            List<Contrato> todosContratos = new List<Contrato>();
            DBConnection con = new DBConnection();
            DataTable table;

            int id, utilizador_id, morada_id;
            string codigo;
            DateTime dataInicio;
            Utilizador uti;
            Morada morada;

            table = con.Query("SELECT * FROM contrato");

            foreach (DataRow row in table.Rows)
            {
                id = row.Field<int>("id");
                codigo = row.Field<string>("codigo");
                dataInicio = row.Field<DateTime>("data_inicio");

                utilizador_id = row.Field<int>("utilizador_id");
                morada_id = row.Field<int>("utilizador_id");

                uti = Utilizadores.GetById(utilizador_id);
                morada = Moradas.GetById(morada_id);

                todosContratos.Add(new Contrato(id, dataInicio, codigo, morada, uti));
            }

            contratos.RemoveAll(x => x.Id != 0);
            contratos.AddRange(todosContratos.ToList());

            return todosContratos;
        }

        /// <summary>
        /// Cria novo contrato na base de dados
        /// </summary>
        /// <param name="codigo">Codigo de indentificação</param>
        /// <param name="dataInicio">Data de Inicio de Contrato</param>
        /// <param name="morada">Objecto Morada do utilizador</param>
        /// <param name="utilizador">Utilizador dono do contrato</param>
        /// <returns>Objecto Contrato criado</returns>
        public static Contrato Novo(string codigo, DateTime dataInicio, Morada morada, Utilizador utilizador)
        {
            int id = 0;
            int rows;
            Contrato novoContrato;
            DBConnection conn = new DBConnection();
            DataTable dt;

            //Inserir morada na base de dados
            rows = conn.NonQuery("INSERT INTO contrato (codigo, utilizador_id, morada_id, data_inicio) VALUES (@0, @1, @2, @3)", codigo, utilizador.Id, morada.Id, dataInicio);

            dt = conn.Query("SELECT * FROM utilizador WHERE codigo = @0 AND utilizador_id = @1 AND morada_id = @2 ORDER BY id DESC LIMIT 1", codigo, utilizador.Id, morada.Id);

            id = dt.Rows[dt.Rows.Count - 1].Field<int>("id");

            novoContrato = new Contrato(id, dataInicio, codigo, morada, utilizador);
            contratos.Add(novoContrato);

            return novoContrato;
        }

        /// <summary>
        /// Devolve contrato pelo ID
        /// </summary>
        /// <param name="id">ID do contrato a pedir</param>
        /// <returns>Objecto contrato</returns>
        public static Contrato GetById(int id)
        {
            DBConnection db;
            Contrato contrato = contratos.FindLast(x => x.Id == id);
            DataTable table;

            int utilizador_id, morada_id;
            string codigo;
            DateTime dataInicio;
            Utilizador uti;
            Morada morada;

            //1º tenta ver se ja tem esse tipo em memoria
            if (contrato != null)
                return contrato;

            //Caso nao tenha esse tipo em memoria vai à base de dados
            db = new DBConnection();
            table = db.Query("SELECT * FROM contrato WHERE id = @0", id);

            //Se o id não existir também na base de dados retorna objeto default
            if (table.Rows.Count == 0)
                return null;

            //criar variaveis necessarias par ao objeto de utilizador
            codigo = table.Rows[0].Field<string>("codigo");
            utilizador_id = table.Rows[0].Field<int>("utilizador_id");
            morada_id = table.Rows[0].Field<int>("morada_id");
            dataInicio = table.Rows[0].Field<DateTime>("data_inicio");

            uti = Utilizadores.GetById(utilizador_id);
            morada = Moradas.GetById(morada_id);

            //Criar novo objeto de Utilizador
            contrato = new Contrato(id, dataInicio, codigo, morada, uti);
            contratos.Add(contrato);

            return contrato;
        }
    }
}
