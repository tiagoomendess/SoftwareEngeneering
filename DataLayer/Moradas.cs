using BusinessObjects;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DataLayer
{
    public static class Moradas
    {
        private static List<Morada> moradas = new List<Morada>();

        /// <summary>
        /// Procura na base de dados moradas que coorespondam à condição
        /// </summary>
        /// <param name="atributo"></param>
        /// <param name="operador"></param>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static List<Morada> Where(string atributo, string operador, object valor)
        {
            List<Morada> moradas = new List<Morada>();
            DBConnection db = new DBConnection();
            DataTable table;

            int id, numero;
            string rua, localidade, codigoPostal;

            table = db.Query("SELECT * FROM utilizador WHERE " + atributo + " " + operador + " @0", valor);

            //Percorrer todas as linhas retornadas da base de dados
            foreach (DataRow row in table.Rows)
            {
                id = row.Field<int>("id");
                rua = row.Field<string>("rua");
                numero = row.Field<int>("numero");
                codigoPostal = row.Field<string>("codigo_postal");
                localidade = row.Field<string>("localidade");

                moradas.Add(new Morada(id, rua, numero, codigoPostal, localidade));
            }

            return moradas;
        }

        /// <summary>
        /// Vai buscar uma instancia de Morada à Base de dados ou a memoria
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Morada GetById(int id)
        {
            DBConnection db;
            Morada morada = moradas.FindLast(x => x.Id == id);
            DataTable table;

            string rua, codigoPostal, localidade;
            int numero;

            //1º tenta ver se ja tem esse tipo em memoria
            if (morada != null)
                return morada;

            //Caso nao tenha esse tipo em memoria vai à base de dados
            db = new DBConnection();
            table = db.Query("SELECT * FROM morada WHERE id = @0", id);

            //Se o id não existir também na base de dados retorna objeto default
            if (table.Rows.Count == 0)
                return null;

            //criar variaveis necessarias par ao objeto de utilizador
            rua = table.Rows[0].Field<string>("rua");
            numero = table.Rows[0].Field<int>("numero");
            codigoPostal = table.Rows[0].Field<string>("codigo_postal");
            localidade = table.Rows[0].Field<string>("localidade");

            //Criar novo objeto de Utilizador
            morada = new Morada(id, rua, numero, codigoPostal, localidade);
            moradas.Add(morada);

            return morada;
        }

        /// <summary>
        /// Retira todas as moradas da base de dados
        /// </summary>
        /// <returns></returns>
        public static List<Morada> GetAll()
        {
            List<Morada> todasMoradas = new List<Morada>();
            DBConnection con = new DBConnection();
            DataTable table;

            int id, numero;
            string rua, codigoPostal, localidade;

            table = con.Query("SELECT * FROM morada");

            foreach (DataRow row in table.Rows)
            {
                id = row.Field<int>("id");
                rua = row.Field<string>("rua");
                numero = row.Field<int>("numero");
                codigoPostal = row.Field<string>("codigo_postal");
                localidade = row.Field<string>("localidade");
                todasMoradas.Add(new Morada(id, rua, numero, codigoPostal, localidade));
            }

            moradas.RemoveAll(x => x.Id != 0);
            moradas.AddRange(todasMoradas.ToList());

            return todasMoradas;
        }

        public static Morada Novo(string rua, int numero, string codigoPostal, string localidade)
        {
            int id = 0;
            int rows;
            Morada novaMorada;
            DBConnection conn = new DBConnection();
            DataTable dt;

            //Inserir morada na base de dados
            rows = conn.NonQuery("INSERT INTO morada (rua, numero, codigoPostal, localidade) VALUES (@0, @1, @2, @3)", rua, numero, codigoPostal, localidade);

            dt = conn.Query("SELECT * FROM utilizador WHERE rua = @0 AND numero = @1 AND codigo_postal = @2 ORDER DESC LIMIT 1", rua, numero, codigoPostal);

            id = dt.Rows[dt.Rows.Count - 1].Field<int>("id");

            novaMorada = new Morada(id, rua, numero, codigoPostal, localidade);
            moradas.Add(novaMorada);

            return novaMorada;
        }
    }
}
