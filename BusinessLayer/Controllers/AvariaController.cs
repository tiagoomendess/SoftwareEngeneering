using BusinessObjects;
using DataLayer;
using System.Collections.Generic;


namespace BusinessLayer.Controllers
{
    public static class AvariaController
    {
        public static List<Avaria> Index()
        {
            Utilizador uti = Utilizadores.Autenticado();
            List<Avaria> avarias = Avarias.Where("utilizador_id", "=", uti.Id);

            return avarias;
        }

        public static List<TipoAvaria> Tipos()
        {
            List<TipoAvaria> avarias = TiposAvaria.GetAll();
            return avarias;
        }

        public static bool Add(string descricao, string local, TipoAvaria tipo)
        {
            string imagem = "";
            //Avarias.Novo(descricao,imagem,)
            return true;
        }

        public static bool Resolvida()
        {
            return true;
        }
    }
}
