using BusinessObjects;
using DataLayer;
using System;
using System.Collections.Generic;


namespace BusinessLayer.Controllers
{
    public static class LeituraController
    {
        public static List<Leitura> TodasLeituras()
        {
            List<Leitura> leituras = new List<Leitura>();
            Utilizador uti = Utilizadores.Autenticado();
            List<Contrato> contratos = Contratos.Where("utilizador_id", "=", uti.Id.ToString());

            foreach (Contrato contrato in contratos)
            {
                foreach (Leitura leitura in Leituras.Where("contrato_id", "=", contrato.Id.ToString()))
                {
                    leituras.Add(leitura);
                }
            }
                   
            return leituras;
        }

        public static Leitura Add(int valor, Contrato contrato)
        {
            Utilizador uti = Utilizadores.Autenticado();
            DateTime data = DateTime.Now;
            Leitura leitura = Leituras.Novo(valor, data, contrato);

            return leitura;
        }
    }
}
