using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public static class TiposAvaria
    {
        private static List<TipoAvaria> tiposAvaria = new List<TipoAvaria>();

        /// <summary>
        /// Procura um TipoUtilizador que tenha o ID especificado
        /// </summary>
        /// <param name="id">Id a procurar</param>
        /// <returns>Retorna um TipoUtilizador com o ID pedido ou null se nao existir</returns>
        public static TipoAvaria GetById(int id)
        {
            DBConnection db;
            TipoAvaria tipo = tiposAvaria.Find(x => x.Id == id);
            DataTable table;

            //1º tenta ver se ja tem esse tipo em memoria
            if (tipo != null)
                return tipo;

            //Caso nao tenha esse tipo em memoria vai à base de dados
            db = new DBConnection();
            table = db.Query("SELECT * FROM tipo_avaria WHERE id = @0", id);

            //Se o id não existir também na base de dados retorna objeto default
            if (table.Rows.Count == 0)
                return null;

            //Criar novo objeto de TipoUtilizador
            tipo = new TipoAvaria(table.Rows[0].Field<int>("id"), table.Rows[0].Field<string>("denominacao"));
            tiposAvaria.Add(tipo);
            return tipo;
        }

        /// <summary>
        /// Retorna todos os Tipos de Utilizador
        /// </summary>
        /// <returns>Uma lsita com TipoUtilizador</returns>
        public static List<TipoAvaria> GetAll()
        {
            List<TipoAvaria> tipos = new List<TipoAvaria>();
            DBConnection con = new DBConnection();
            DataTable table;

            table = con.Query("SELECT * FROM tipo_avaria");

            foreach (DataRow row in table.Rows)
            {
                tipos.Add(new TipoAvaria(row.Field<int>("id"), row.Field<string>("denominacao")));
            }

            tiposAvaria.RemoveAll(x => x.Id != 0);
            tiposAvaria.AddRange(tipos.ToList());

            return tipos;
        }

        /// <summary>
        /// Procura na base de dados instancias que coorespondam à condição
        /// </summary>
        /// <param name="atributo">Nome do atributo da base de dados</param>
        /// <param name="operador">Operador a aplicar</param>
        /// <param name="valor">Valor do atributo</param>
        /// <returns>Lista de objetos que cooresponde à condição dos parametros</returns>
        public static List<TipoAvaria> Where(string atributo, string operador, object valor)
        {
            List<TipoAvaria> tiposAvaria = new List<TipoAvaria>();
            DBConnection db = new DBConnection();
            DataTable table;

            int id;
            string denominacao;

            table = db.Query("SELECT * FROM tipo_utilizador WHERE " + atributo + " " + operador + " @0", valor);

            //Percorrer todas as linhas retornadas da base de dados
            foreach (DataRow row in table.Rows)
            {
                id = row.Field<int>("id");
                denominacao = row.Field<string>("denominacao");

                tiposAvaria.Add(new TipoAvaria(id, denominacao));
            }

            return tiposAvaria;
        }
    }
}
