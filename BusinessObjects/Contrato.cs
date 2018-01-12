using System;


namespace BusinessObjects
{
    public class Contrato
    {
        #region ATRIBUTOS
        int id;
        DateTime dataInicio;
        string codigo;
        Morada morada;
        Utilizador utilizador;
        #endregion

        #region CONSTRUTORES
        public Contrato(int id, DateTime dataInicio, string codigo, Morada morada, Utilizador utilizador)
        {
            this.id = id;
            this.dataInicio = dataInicio;
            this.codigo = codigo;
            this.morada = morada;
            this.utilizador = utilizador;
        }
        #endregion

        #region PROPRIEDADES
        public int Id
        {
            get { return id; }
        }

        public DateTime DataInicio
        {
            get { return dataInicio; }
            set { dataInicio = value; }
        }

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public Morada Morada
        {
            get { return morada; }
            set { morada = value; }
        }

        public Utilizador Utilizador
        {
            get { return utilizador; }
        }
        #endregion

        #region METODOS

        #endregion
    }
}
