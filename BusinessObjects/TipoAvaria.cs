using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class TipoAvaria
    {
        int id;
        string denominacao;

        public TipoAvaria(int id, string denominacao)
        {
            this.id = id;
            this.denominacao = denominacao;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Denominacao
        {
            get { return denominacao; }
            set { Denominacao = value; }
        }

        public override bool Equals(object obj)
        {
            TipoAvaria aux;

            if (obj.GetType() == typeof(TipoAvaria))
                aux = (TipoAvaria)obj;
            else
                return false;

            //Um tipo é igual ao outro se tiver o mesmo Id
            return aux.Id == this.id;
        }

        public override int GetHashCode()
        {
            var hashCode = 2057244990;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(denominacao);
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Denominacao);
            return hashCode;
        }
    }
}
