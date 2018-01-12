using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class PedidoAcesso
    {
        #region ATRIBUTOS

        int id;
        string codigo;
        string nif;
        string email;

        #endregion

        #region CONSTRUTORES

        /// <summary>
        /// O pedido de acesso é feito quando o utilizador inicia a aplicação pela primeira vez
        /// </summary>
        /// <param name="codigo">Token</param>
        /// <param name="nif">Numero de Identificação Fiscal</param>
        /// <param name="email">Email do utilizador</param>
        public PedidoAcesso(int id, string codigo, string nif, string email)
        {
            this.id = id;
            this.codigo = codigo;
            this.nif = nif;
            this.email = email;
        }
        #endregion

        #region PROPRIEDADES

        public int Id
        {
            get { return id; }
        }

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public string Nif
        {
            get { return nif; }
            set { nif = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        #endregion

        #region METODOS
        #endregion
    }
}
