using MySql.Data.MySqlClient;
using System.Data;


namespace DataLayer
{
    /// <summary>
    /// Representa uma conexao a base de dados
    /// </summary>
    public class DBConnection
    {
        private MySqlConnection connection;
        private MySqlCommand cmd;
        private MySqlDataReader dr;
        private string server;
        private string database;
        private string uid;
        private string password;

        /// <summary>
        /// Construtor do objeto
        /// </summary>
        public DBConnection()
        {
            Initialize();
        }

        /// <summary>
        /// Inicializa os valores
        /// </summary>
        private void Initialize()
        {
            server = "ts.mendes.com.pt";
            database = "quiosque_db";
            uid = "app";
            password = "ES2017PL";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        /// <summary>
        /// Abre a conexão à base de dados
        /// </summary>
        /// <returns>Verdadeiro se abrir com sucesso ou falso se não conseguir abrir</returns>
        private bool OpenConnection()
        {
            try
            {
                Log.Info("A abrir conexão com a Base de Dados.");
                connection.Open();
                Log.Info("Conexão com a base de dados aberta.");
                return true;
            }
            catch (MySqlException ex)
            {
                //Caso não consiga conectar vai dar log do erro
                switch (ex.Number)
                {
                    case 0:
                        Log.Erro("Não foi possivel conectar com o servidor.");
                        break;

                    case 1045:
                        Log.Erro("Utilizador ou password errada na base de dados.");
                        break;
                    default:
                        Log.Erro("Erro ao conectar à base de dados:\n" + ex.ToString());
                        break;

                }
                return false;
            }
        }

        /// <summary>
        /// Fecha a conexão à base de dados
        /// </summary>
        /// <returns>Verdadeiro se sucesso ou falso se nao fechar</returns>
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                Log.Info("Conexão com a Base de dados foi fechada.");
                return true;
            }
            catch (MySqlException ex)
            {
                Log.Erro(ex.Message);
                return false;
            }
        }


        /// <summary>
        /// Metodo para executar um insert ou um update, não retorna nenhum dataset
        /// </summary>
        /// <param name="query">Query </param>
        /// <param name="parametros">Parametros a preencher na query</param>
        /// <returns>Retorna o numero de linhas afetadas pela query</returns>
        public int NonQuery(string query, params object[] parametros)
        {
            int rowsAfected;
            cmd = new MySqlCommand();
            cmd.Connection = this.connection;

            if (OpenConnection() == true)
            {
                cmd.CommandText = query;

                for (int i = 0; i < parametros.Length; i++)
                {
                    cmd.Parameters.AddWithValue("@" + i, parametros[i]);
                }

                cmd.Prepare();
                rowsAfected = cmd.ExecuteNonQuery();
                CloseConnection();
                return rowsAfected;
            }

            return 0;
        }


        /// <summary>
        /// Faz uma query à base de dados
        /// </summary>
        /// <param name="query">Query</param>
        /// <param name="parametros">Parametros por ordem na query</param>
        /// <returns>Retorna o resultado da query da base de dados</returns>
        public DataTable Query(string query, params object[] parametros)
        {
            cmd = new MySqlCommand();
            cmd.Connection = this.connection;
            DataTable dt = new DataTable();

            if (this.OpenConnection())
            {
                cmd.CommandText = query;

                for (int i = 0; i < parametros.Length; i++)
                {
                    cmd.Parameters.AddWithValue("@" + i, parametros[i]);
                }

                cmd.Prepare();
                dr = cmd.ExecuteReader();
                dt.Load(dr);
                CloseConnection();

                return dt;
            }

            return null;
        }
    }
}
