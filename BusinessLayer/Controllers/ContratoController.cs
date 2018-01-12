using BusinessObjects;
using DataLayer;
using System.Collections.Generic;


namespace BusinessLayer.Controllers
{
    public static class ContratoController
    {
        public static List<Contrato> TodasLeituras()
        {
            Utilizador utilizador = Utilizadores.Autenticado();
            List<Contrato> contratos = Contratos.Where("utilizador_id", "=", utilizador.Id.ToString());
            return contratos;
        }
    }
}
