using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;


namespace DataLayer
{
    public static class Avarias
    {
        private static List<Avaria> avarias = new List<Avaria>();

        public static Avaria GetById(int id)
        {
            DBConnection db;
            Avaria avaria = avarias.FindLast(x => x.Id == id);
            DataTable table;

            int contrato_id, tipo_id, utilizador_id, estado_id;
            string descricao, imagem;

            Utilizador uti;
            Contrato contrato;
            TipoAvaria tipo;
            EstadoAvaria estado;

            //1º tenta ver se ja tem esse tipo em memoria
            if (avaria != null)
                return avaria;

            //Caso nao tenha esse tipo em memoria vai à base de dados
            db = new DBConnection();
            table = db.Query("SELECT * FROM avaria WHERE id = @0", id);

            //Se o id não existir também na base de dados retorna objeto default
            if (table.Rows.Count == 0)
                return null;

            //criar variaveis necessarias par ao objeto de utilizador
            descricao = table.Rows[0].Field<string>("descricao");
            utilizador_id = table.Rows[0].Field<int>("utilizador_id");
            contrato_id = table.Rows[0].Field<int>("contrato_id");
            imagem = table.Rows[0].Field<string>("imagem");
            tipo_id = table.Rows[0].Field<int>("tipo_avaria_id");
            estado_id = table.Rows[0].Field<int>("estado_id");

            uti = Utilizadores.GetById(utilizador_id);
            contrato = Contratos.GetById(contrato_id);
            tipo = TiposAvaria.GetById(tipo_id);
            estado = EstadosAvaria.GetById(estado_id);

            //Criar novo objeto de Utilizador
            avaria = new Avaria(id, tipo, descricao, imagem, estado);
            avarias.Add(avaria);

            return avaria;
        }


        public static List<Avaria> Where(string atributo, string operador, object valor)
        {
            List<Avaria> avarias = new List<Avaria>();
            DBConnection db = new DBConnection();
            DataTable table;

            string descricao, imagem;
            int id, contrato_id, tipo_id, estado_id;

            Contrato contrato;
            EstadoAvaria estado;
            TipoAvaria tipo;

            table = db.Query("SELECT * FROM avaria WHERE " + atributo + " " + operador + " @0", valor);

            //Percorrer todas as linhas retornadas da base de dados
            foreach (DataRow row in table.Rows)
            {
                id = row.Field<int>("id");
                descricao = row.Field<string>("descricao");
                imagem = row.Field<string>("imagem");
                contrato_id = row.Field<int>("contrato_id");
                tipo_id = row.Field<int>("tipo_avaria_id");
                estado_id = row.Field<int>("estado_id");

                contrato = Contratos.GetById(contrato_id);
                estado = EstadosAvaria.GetById(estado_id);
                tipo = TiposAvaria.GetById(tipo_id);

                avarias.Add(new Avaria(id, tipo, descricao, imagem, estado));
            }

            return avarias;
        }

        public static Avaria Novo(string descricao, string imagem, Contrato contrato, Utilizador utilizador, TipoAvaria tipo, EstadoAvaria estado)
        {
            int id = 0;
            int rows;
            Avaria novoAvaria;
            DBConnection conn = new DBConnection();
            DataTable dt;

            //Inserir morada na base de dados
            rows = conn.NonQuery("INSERT INTO avaria (descricao, utilizador_id, imagem, contrato_id, tipo_avaria_id, estado_id) VALUES (@0, @1, @2, @3, @4, @5)", descricao, utilizador.Id, contrato.Id, tipo.Id, estado.Id);

            dt = conn.Query("SELECT * FROM utilizador WHERE codigo = @0 AND utilizador_id = @1 AND contrato_id = @2 AND tipo_avaria_id = @3 AND estado_id = @4 ORDER BY id DESC LIMIT 1", utilizador.Id, contrato.Id, tipo.Id, estado.Id);

            id = dt.Rows[dt.Rows.Count - 1].Field<int>("id");

            novoAvaria = new Avaria(id, tipo, descricao, imagem, estado);
            avarias.Add(novoAvaria);

            return novoAvaria;
        }

    }
}
