using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Morada
    {
        #region ATRIBUTOS

        int id;
        string rua;
        int numero;
        string localidade;
        string codigoPostal;

        #endregion

        #region CONSTRUTORES

        /// <summary>
        /// Contrutor de Morada
        /// </summary>
        /// <param name="id">Id da morada</param>
        /// <param name="rua">Rua</param>
        /// <param name="numero">Numero da porta</param>
        /// <param name="codigo">Codigo Postal</param>
        public Morada(int id, string rua, int numero, string codigo, string localidade)
        {
            this.id = id;
            this.rua = rua;
            this.numero = numero;
            this.codigoPostal = codigo;
            this.localidade = localidade;
        }
        #endregion

        #region PROPRIEDADES
        public int Id
        {
            get { return id; }
        }

        public string Rua
        {
            get { return rua; }
            set { rua = value; }
        }

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public string CodigoPostal
        {
            get { return codigoPostal; }
            set { codigoPostal = value; }
        }

        public string Localidade
        {
            get { return localidade; }
            set { localidade = value; }
        }
        #endregion

        #region METODOS

        public override bool Equals(object obj)
        {
            Morada aux;

            if (obj.GetType() == typeof(Morada))
                aux = (Morada)obj;
            else
                return false;

            return aux.Id == id;
        }

        public override int GetHashCode()
        {
            var hashCode = 1746911320;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(rua);
            hashCode = hashCode * -1521134295 + numero.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(localidade);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(codigoPostal);
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Rua);
            hashCode = hashCode * -1521134295 + Numero.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CodigoPostal);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Localidade);
            return hashCode;
        }
        #endregion
    }
}
