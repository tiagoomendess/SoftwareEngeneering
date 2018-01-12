using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Leitura
    {
        #region ATRIBUTOS
        int id;
        DateTime data;
        int valor;
        Contrato contrato;
        #endregion

        #region CONSTRUTORES

        /// <summary>
        /// Inicializa Leitura
        /// </summary>
        /// <param name="data">Data quando foi feita a leitura</param>
        /// <param name="valor">Valor registado na leitura</param>
        public Leitura(int id, DateTime data, int valor, Contrato contrato)
        {
            this.id = id;
            this.data = data;
            this.valor = valor;
            this.contrato = contrato;
        }

        #endregion

        #region PROPRIEDADES
        public int Id
        {
            get { return id; }
        }
        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }

        public int Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        public Contrato Contrato
        {
            get { return contrato; }
            set { contrato = value; }
        }
        #endregion

        #region METODOS
        #endregion
    }
}
