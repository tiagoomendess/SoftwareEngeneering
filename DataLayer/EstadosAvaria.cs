using BusinessObjects;
using System.Collections.Generic;
using System.Data;


namespace DataLayer
{
    public static class EstadosAvaria
    {
        private static List<EstadoAvaria> estados = new List<EstadoAvaria>();

        public static EstadoAvaria GetById(int id)
        {
            DBConnection db;
            EstadoAvaria estado = estados.FindLast(x => x.Id == id);
            DataTable table;
          
            string denominacao;

            //1º tenta ver se ja tem esse tipo em memoria
            if (estado != null)
                return estado;

            //Caso nao tenha esse tipo em memoria vai à base de dados
            db = new DBConnection();
            table = db.Query("SELECT * FROM estado_avaria WHERE id = @0", id);

            //Se o id não existir também na base de dados retorna objeto default
            if (table.Rows.Count == 0)
                return null;

            //criar variaveis necessarias par ao objeto de utilizador
            denominacao = table.Rows[0].Field<string>("denominacao");

            //Criar novo objeto de Utilizador
            estado = new EstadoAvaria(id, denominacao);
            estados.Add(estado);

            return estado;
        }
    }
}
