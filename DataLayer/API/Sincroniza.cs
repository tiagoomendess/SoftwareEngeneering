using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataLayer.API
{
    public class Sincroniza
    {

        /// <summary>
        /// Atualiza faturas na BD da BD antiga referentes ao nif
        /// </summary>
        /// <param name="nif"></param>
        /// <returns></returns>
        public bool Faturas(int nif)
        {
            Servico servico = new Servico("faturas");
            List<object> faturas = servico.PedirTodos(nif);

            DBConnection db = new DBConnection();
            DataTable table;

            table = db.Query("SELECT * FROM faturas");

            foreach (Fatura item in faturas)
            {

                //Percorrer todas as linhas retornadas da base de dados
                foreach (DataRow row in table.Rows)
                {
                    if (item.Data == row.Field<DateTime>("data"))
                    {

                    }
                }
            }


            return false;
        }
    }
}
