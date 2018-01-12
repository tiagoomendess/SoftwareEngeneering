using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{

    /// <summary>
    /// Gere todas as instancias de TipoUtilizador na memoria e na base de dados
    /// </summary>
    public static class TiposUtilizador
    {
        private static List<TipoUtilizador> tiposUtilizador = new List<TipoUtilizador>();

        /// <summary>
        /// Procura um TipoUtilizador que tenha o ID especificado
        /// </summary>
        /// <param name="id">Id a procurar</param>
        /// <returns>Retorna um TipoUtilizador com o ID pedido ou null se nao existir</returns>
        public static TipoUtilizador GetById(int id)
        {
            DBConnection db;
            TipoUtilizador tipo = tiposUtilizador.Find(x => x.Id == id);
            DataTable table;

            //1º tenta ver se ja tem esse tipo em memoria
            if (tipo != null)
                return tipo;

            //Caso nao tenha esse tipo em memoria vai à base de dados
            db = new DBConnection();
            table = db.Query("SELECT * FROM tipo_utilizador WHERE id = @0", id);

            //Se o id não existir também na base de dados retorna objeto default
            if (table.Rows.Count == 0)
                return null;

            //Criar novo objeto de TipoUtilizador
            tipo = new TipoUtilizador(table.Rows[0].Field<int>("id"), table.Rows[0].Field<string>("denominacao"));
            tiposUtilizador.Add(tipo);
            return tipo;
        }

        /// <summary>
        /// Retorna todos os Tipos de Utilizador
        /// </summary>
        /// <returns>Uma lsita com TipoUtilizador</returns>
        public static List<TipoUtilizador> GetAll()
        {
            List<TipoUtilizador> tipos = new List<TipoUtilizador>();
            DBConnection con = new DBConnection();
            DataTable table;

            table = con.Query("SELECT * FROM tipo_utilizador");

            foreach (DataRow row in table.Rows)
            {
                tipos.Add(new TipoUtilizador(row.Field<int>("id"), row.Field<string>("denominacao")));
            }

            tiposUtilizador.RemoveAll(x => x.Id != 0);
            tiposUtilizador.AddRange(tipos.ToList());

            return tipos;
        }

        /// <summary>
        /// Procura na base de dados instancias que coorespondam à condição
        /// </summary>
        /// <param name="atributo">Nome do atributo da base de dados</param>
        /// <param name="operador">Operador a aplicar</param>
        /// <param name="valor">Valor do atributo</param>
        /// <returns>Lista de objetos que cooresponde à condição dos parametros</returns>
        public static List<TipoUtilizador> Where(string atributo, string operador, object valor)
        {
            List<TipoUtilizador> tiposUtilizador = new List<TipoUtilizador>();
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

                tiposUtilizador.Add(new TipoUtilizador(id, denominacao));
            }

            return tiposUtilizador;
        }

    }
}
