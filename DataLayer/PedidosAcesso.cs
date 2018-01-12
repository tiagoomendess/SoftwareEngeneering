using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public static class PedidosAcesso
    {

        public static PedidoAcesso Novo(string nif, string email)
        {

            PedidoAcesso novo;
            DBConnection db = new DBConnection();
            int rows, id;
            Random r = new Random();
            string codigo = r.Next(100000, 999999).ToString();
            DataTable dt;

            rows = db.NonQuery("INSERT INTO pedido_acesso (nif, email, codigo) VALUES (@0, @1, @2)", nif, email, codigo);

            dt = db.Query("SELECT * FROM pedido_acesso WHERE email = @0", email);

            id = dt.Rows[0].Field<int>("id");

            novo = new PedidoAcesso(id, codigo, nif, email);

            return novo;
        }

        public static List<PedidoAcesso> Where(string atributo, string operador, object valor)
        {
            List<PedidoAcesso> pedidos = new List<PedidoAcesso>();
            DBConnection db = new DBConnection();
            DataTable table;

            int id;
            string email, codigo, nif;

            table = db.Query("SELECT * FROM pedido_acesso WHERE " + atributo + " " + operador + " @0", valor);

            if (table == null)
                return pedidos;

            //Percorrer todas as linhas retornadas da base de dados
            foreach (DataRow row in table.Rows)
            {
                id = row.Field<int>("id");
                email = row.Field<string>("email");
                codigo = row.Field<string>("codigo");
                nif = row.Field<string>("nif");

                pedidos.Add(new PedidoAcesso(id, codigo, nif, email));
            }

            return pedidos;
        }
    }
}
