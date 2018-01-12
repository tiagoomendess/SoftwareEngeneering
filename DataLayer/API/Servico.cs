using BusinessObjects;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace DataLayer.API
{
    public class Servico
    {
        #region ATRIBUTOS

        string servico;
        const string URL = "https://isi.andrade.pt/api/";

        #endregion

        #region CONSTRUTORES

        /// <summary>
        /// Inicia Serviço para pedir ao servidor
        /// </summary>
        /// <param name="servico">Tipo de dados a pedir</param>
        public Servico(string servico)
        {
            this.servico = servico;
        }

        #endregion

        #region METODOS

        /// <summary>
        /// Pede a base de dados do municipio todos os items do tipo inicializado
        /// </summary>
        /// <returns>Todos os dados registados na base de dados</returns>
        public List<Object> PedirTodos()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL + this.servico);
                request.Method = "GET";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                string content = string.Empty;

                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        content = sr.ReadToEnd();
                    }
                }

                dynamic jsonObj = JsonConvert.DeserializeObject(content);

                //Verificas erros enviados do servidor
                /*if ((string)jsonObj["erro"] != null)
                {
                    Log.Erro((string)jsonObj["erro"]);
                    throw new Exception("ERRO:" + (string)jsonObj["erro"]);
                }*/

                List<Object> resultado = new List<object>();

                foreach (var obj in jsonObj)
                {

                    /*if ("faturas".Equals(this.servico))
                    {
                        Morada morada = new Morada((int)obj["id"], (string)obj["morada"], (int)obj["porta"], (string)obj["codigoPostal"], (string)obj["localidade"]);
                        Contrato contrato = new Contrato((int)obj["id"], (DateTime)obj["contrato"]["dataInicio"], (string)obj["codigoPostal"], morada);
                        Fatura fatura = new Fatura((int)obj["id"], (double)obj["valor"], (DateTime)obj["dataFim"], contrato);

                        resultado.Add(fatura);
                    }

                    if ("contratos".Equals(this.servico))
                    {
                        Morada morada = new Morada((int)obj["id"], (string)obj["rua"], (int)obj["porta"], (string)obj["codigoPostal"], (string)obj["localidade"]);
                        Contrato contrato = new Contrato((int)obj["id"], (DateTime)obj["dataInicio"], (string)obj["codigoPostal"], morada);

                        resultado.Add(contrato);
                    }

                    if ("utilizadores".Equals(this.servico))
                    {
                        TipoUtilizador tipo = new TipoUtilizador();
                        Utilizador utilizador = new Utilizador((int)obj["id"], (string)obj["name"], (string)obj["nif"], (string)obj["email"], (DateTime)obj["dataNascimento"], "+351", tipo);

                        resultado.Add(utilizador);
                    }*/

                }

                if (resultado != null)
                    return resultado;
            }
            catch (WebException e)
            {
                Log.Erro("Pedido de serviço não disponivel. Erro: " + e.Message);
                throw new Exception("ERRO: Pedido ao servidor não disponivel");
            }


            Log.Erro("Não existem " + this.servico);
            throw new Exception("ERRO: Não existem " + this.servico);

        }

        /// <summary>
        /// Pede todos os elemente referentes ao NIF
        /// </summary>
        /// <param name="nif">Identificacao dos dados pedidos</param>
        /// <returns>Lista de todos os documentos referentes ao NIF pedido</returns>
        public List<Object> PedirTodos(int nif)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL + this.servico + "/all/" + nif);
                request.Method = "GET";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                string content = string.Empty;

                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        content = sr.ReadToEnd();
                    }
                }

                dynamic jsonObj = JsonConvert.DeserializeObject(content);

                //Verificas erros enviados do servidor
                /*if ((string)jsonObj["erro"] != null)
                {
                    Log.Erro((string)jsonObj["erro"]);
                    throw new Exception("ERRO:" + (string)jsonObj["erro"]);
                }*/

                List<Object> resultado = new List<object>();

                /*foreach (var obj in jsonObj)
                {

                    if ("faturas".Equals(this.servico))
                    {
                        Morada morada = new Morada((int)obj["id"], (string)obj["contrato"]["morada"], (int)obj["contrato"]["porta"], (string)obj["contrato"]["codigoPostal"], (string)obj["contrato"]["localidade"]);
                        Contrato contrato = new Contrato((int)obj["id"], (DateTime)obj["contrato"]["dataInicio"], (string)obj["codigoPostal"], morada);
                        Fatura fatura = new Fatura((int)obj["id"], (double)obj["valor"], (DateTime)obj["dataFim"], contrato);

                        resultado.Add(fatura);
                    }

                    if ("contratos".Equals(this.servico))
                    {
                        Morada morada = new Morada((int)obj["id"], (string)obj["rua"], (int)obj["porta"], (string)obj["codigoPostal"], (string)obj["localidade"]);
                        Contrato contrato = new Contrato((int)obj["id"], (DateTime)obj["dataInicio"], (string)obj["codigoPostal"], morada);

                        resultado.Add(contrato);
                    }

                    if ("utilizadores".Equals(this.servico))
                    {
                        TipoUtilizador tipo = new TipoUtilizador();
                        Utilizador utilizador = new Utilizador((int)obj["id"], (string)obj["name"], (string)obj["nif"], (string)obj["email"], (DateTime)obj["dataNascimento"], "+351", tipo);

                        resultado.Add(utilizador);
                    }

                }*/

                if (resultado != null)
                    return resultado;
            }
            catch (WebException e)
            {
                Log.Erro("Pedido de serviço não disponivel. Erro: " + e.Message);
                throw new Exception("ERRO: Pedido ao servidor não disponivel");
            }

            Log.Erro("Não existem " + this.servico);
            throw new Exception("ERRO: Não existem " + this.servico);
        }

        /// <summary>
        /// Pede um elemento em especifico
        /// </summary>
        /// <param name="id">Identificação do elemento - NIF</param>
        /// <returns>Objecto do elemento pedido com toda informação</returns>
        public object Pedir(int id)
        {
            string content = string.Empty;

            try
            {
                //Pedido ao Servidor
                HttpWebRequest request = WebRequest.Create(URL + this.servico + "/" + id) as HttpWebRequest; ;
                request.Method = "GET";


                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                //Recolhe dados recebidos
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        content = sr.ReadToEnd();
                    }
                }

                //Passa para formato JSON
                var obj = JObject.Parse(content);

                //Verificas erros enviados do servidor
                /*if ((string)obj["erro"] != null)
                {
                    Log.Erro((string)obj["erro"]);
                    throw new Exception("ERRO:" + (string)obj["erro"]);
                }*/

                /*if ("faturas".Equals(this.servico))
                {
                    Morada morada = new Morada((int)obj["id"], (string)obj["contrato"]["rua"], (int)obj["contrato"]["porta"], (string)obj["contrato"]["codigoPostal"], (string)obj["contrato"]["localidade"]);

                    Contrato contrato = new Contrato((int)obj["id"], (DateTime)obj["contrato"]["dataInicio"], (string)obj["codigoPostal"], morada);

                    Fatura fatura = new Fatura((int)obj["id"], (double)obj["valor"], (DateTime)obj["dataFim"], contrato);

                    return fatura;
                }

                if ("contratos".Equals(this.servico))
                {
                    Morada morada = new Morada((int)obj["id"], (string)obj["rua"], (int)obj["porta"], (string)obj["codigoPostal"], (string)obj["localidade"]);

                    Contrato contrato = new Contrato((int)obj["id"], (DateTime)obj["dataInicio"], (string)obj["codigoPostal"], morada);

                    return contrato;
                }

                if ("utilizadores".Equals(this.servico))
                {
                    TipoUtilizador tipo = new TipoUtilizador();
                    Utilizador utilizador = new Utilizador((int)obj["id"], (string)obj["name"], (string)obj["nif"], (string)obj["email"], (DateTime)obj["dataNascimento"], "+351", tipo);
                    return utilizador;
                }*/
            }

            catch (WebException e)
            {
                Log.Erro("Pedido de serviço não disponivel. Erro: " + e.Message);
                throw new Exception("ERRO: Pedido ao servidor não disponivel");
            }

            Log.Erro("Pedido de serviço não disponivel.");
            throw new Exception("ERRO: Pedido ao servidor não disponivel");
        }

        #endregion
    }
}
