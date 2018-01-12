using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataLayer
{
    public static class Leituras
    {
        private static List<Leitura> leituras = new List<Leitura>();

        /// <summary>
        /// Adiciona Leitura na Base de dados e cria objecto
        /// </summary>
        /// <param name="valor">Valor da leitura</param>
        /// <param name="data">Data que foi efectuada</param>
        /// <param name="contrato">Contrato associado</param>
        /// <returns></returns>
        public static Leitura Novo(int valor, DateTime data, Contrato contrato)
        {
            int id = 0;
            int rows;
            Leitura novaLeitura;
            DBConnection conn = new DBConnection();
            DataTable dt;

            //Inserir morada na base de dados
            rows = conn.NonQuery("INSERT INTO leitura (valor, data, contrato_id) VALUES (@0, @1, @2)", valor, data, contrato.Id);

            dt = conn.Query("SELECT * FROM leitura WHERE valor = @0 AND contrato_id = @1 ORDER BY id DESC LIMIT 1", valor, contrato.Id);

            id = dt.Rows[dt.Rows.Count - 1].Field<int>("id");

            novaLeitura = new Leitura(id, data, valor, contrato);
            leituras.Add(novaLeitura);

            return novaLeitura;
        }

        /// <summary>
        /// Devolve todas as leituras com uma certa condição
        /// </summary>
        /// <param name="atributo">Parametro a ser comparado</param>
        /// <param name="operador">Termo de avaliação</param>
        /// <param name="valor">Valor a comparar</param>
        /// <returns></returns>
        public static List<Leitura> Where(string atributo, string operador, object valor)
        {
            List<Contrato> contratos = new List<Contrato>();
            DBConnection db = new DBConnection();
            DataTable table;

            int id, valorLeitura, contrato_id;
            DateTime data;
            Contrato contrato;

            table = db.Query("SELECT * FROM leitura WHERE " + atributo + " " + operador + " @0", valor);

            //Percorrer todas as linhas retornadas da base de dados
            foreach (DataRow row in table.Rows)
            {
                id = row.Field<int>("id");
                valorLeitura = row.Field<int>("valor");
                data = row.Field<DateTime>("data");
                contrato_id = row.Field<int>("contrato_id");

                contrato = Contratos.GetById(contrato_id);

                leituras.Add(new Leitura(id, data, valorLeitura, contrato));
            }

            return leituras;
        }
    }
}
