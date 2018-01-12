using System;

namespace BusinessObjects
{
    public class Fatura
    {
        #region ATRIBUTOS
        int id;
        double valor;
        DateTime data;
        Contrato contrato;
        #endregion

        #region CONSTRUTORES
        /// <summary>
        /// Uma fatura tem um ID, um valor e uma
        /// </summary>
        /// <param name="id">Id na base de dados</param>
        /// <param name="valor">Valor a pagar</param>
        /// <param name="data">Data de emição</param>
        public Fatura(int id, double valor, DateTime data, Contrato contrato)
        {
            this.id = id;
            this.valor = valor;
            this.data = data;
            this.contrato = contrato;
        }
        #endregion

        #region PROPRIEDADES
        public int Id
        {
            get { return id; }
        }

        public double Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        public DateTime Data
        {
            get { return data; }
            set { data = value; }
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
