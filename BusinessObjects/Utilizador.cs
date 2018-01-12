using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    public class Utilizador
    {
        #region ATRIBUTOS
        int id;
        string nome;
        string nif;
        string email;
        DateTime dataNascimento;
        string telemovel;
        TipoUtilizador tipo;
        #endregion

        #region CONSTRUTORES

        /// <summary>
        /// Cria uma instancia de Utilizador com os atributos pro defeito
        /// </summary>
        public Utilizador()
        {
            id = 0;
            nome = "";
            nif = "";
            email = "";
            telemovel = "";
            dataNascimento = DateTime.Now;
            tipo = new TipoUtilizador();
        }

        /// <summary>
        /// Utilizador da aplicação
        /// </summary>
        /// <param name="id">Id do utilizador</param>
        /// <param name="nome">Nome do Utilizador</param>
        /// <param name="nif">Numero de Indetificação fiscal</param>
        /// <param name="email">Email</param>
        /// <param name="morada">Morada</param>
        /// <param name="data">Data de Nascimento</param>
        /// <param name="pass">Palavra chave de acesso</param>
        /// <param name="tlm">Numero de Telemovel</param>
        /// <param name="tipo">Tipo de utilizador</param>
        public Utilizador(int id, string nome, string nif, string email, DateTime data, string tlm, TipoUtilizador tipo)
        {
            this.id = id;
            this.nome = nome;
            this.nif = nif;
            this.email = email;
            dataNascimento = data;
            telemovel = tlm;
            this.tipo = tipo;
        }
        #endregion

        #region PROPRIEDADEES

        public int Id
        {
            get { return id; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
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

        public DateTime DataNascimento
        {
            get { return dataNascimento; }
            set { dataNascimento = value; }
        }

        public string Telemovel
        {
            get { return telemovel; }
            set { telemovel = value; }
        }

        public TipoUtilizador Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        #endregion

        #region METODOS

        /// <summary>
        /// Comprar se dois objetos sao iguais
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            Utilizador aux;

            if (obj.GetType() == typeof(Utilizador))
                aux = (Utilizador)obj;
            else
                return false;

            return (aux.Id == id);
        }

        public override int GetHashCode()
        {
            var hashCode = -1340116820;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nome);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nif);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(email);
            hashCode = hashCode * -1521134295 + dataNascimento.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(telemovel);
            hashCode = hashCode * -1521134295 + EqualityComparer<TipoUtilizador>.Default.GetHashCode(tipo);
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nome);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nif);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
            hashCode = hashCode * -1521134295 + DataNascimento.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Telemovel);
            hashCode = hashCode * -1521134295 + EqualityComparer<TipoUtilizador>.Default.GetHashCode(Tipo);
            return hashCode;
        }

        #endregion
    }
}
