using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Avaria
    {
        #region ATRIBUTOS
        int id; //Identificador unico da base de dados
        TipoAvaria tipo;
        string descricao;//Descrição da avaria
        string imagem; //URL da imagem
        EstadoAvaria estadoAtual;

        #endregion

        #region CONSTRUTORES

        /// <summary>
        /// Descreve uma avaria aberta por um utilizador
        /// </summary>
        /// <param name="id">Id da base de dados</param>
        /// <param name="tipo">Tipo de avaria</param>
        /// <param name="descricao">Descrição da avaria</param>
        /// <param name="imagem">Url da imagem, pode ser null</param>
        /// <param name="estados">Estados pela qual a avaria ja passou</param>
        /// <param name="estadoAtual">Estado atual da avaria</param>
        public Avaria(int id, TipoAvaria tipo, string descricao, string imagem, EstadoAvaria estadoAtual)
        {
            this.id = id;
            this.tipo = tipo;
            this.descricao = descricao;
            this.imagem = imagem;
            this.EstadoAtual = estadoAtual;
        }

        #endregion

        #region PROPRIEDADES
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        internal TipoAvaria Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        public string Imagem
        {
            get { return imagem; }
            set { imagem = value; }
        }

        public EstadoAvaria EstadoAtual
        {
            get { return estadoAtual; }
            set { estadoAtual = value; }
        }
        #endregion

        #region METODOS
        public override bool Equals(object obj)
        {
            Avaria aux;

            if (obj.GetType() == typeof(Avaria))
                aux = (Avaria)obj;
            else
                return false;

            return aux.Id == this.Id;
        }

        public override int GetHashCode()
        {
            var hashCode = 1977366636;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<TipoAvaria>.Default.GetHashCode(tipo);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(descricao);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(imagem);
            hashCode = hashCode * -1521134295 + EqualityComparer<EstadoAvaria>.Default.GetHashCode(estadoAtual);
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<TipoAvaria>.Default.GetHashCode(Tipo);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Descricao);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Imagem);
            hashCode = hashCode * -1521134295 + EqualityComparer<EstadoAvaria>.Default.GetHashCode(EstadoAtual);
            return hashCode;
        }



        #endregion
    }
}
