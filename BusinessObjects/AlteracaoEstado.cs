using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class AlteracaoEstado
    {
        #region ATRIBUTOS
        int id;
        DateTime data;
        EstadoAvaria estado;
        Avaria avaria;
        #endregion

        #region CONSTRUTORES

        /// <summary>
        /// Estado da avaria
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data">Data da alteração</param>
        /// <param name="estado">Estado da avaria</param>
        public AlteracaoEstado(int id, DateTime data, EstadoAvaria estado, Avaria avaria)
        {
            this.id = id;
            this.data = data;
            this.estado = estado;
            this.avaria = avaria;
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

        public EstadoAvaria Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public Avaria Avaria
        {
            get { return avaria; }
            set { avaria = value; }
        }
        #endregion

        #region METODOS
        #endregion

    }
}
