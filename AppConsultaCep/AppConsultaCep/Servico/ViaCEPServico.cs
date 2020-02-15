using AppConsultaCep.Servico.Modelo;
using Newtonsoft.Json;
using System.Net;

namespace AppConsultaCep.Servico
{
    public class ViaCEPServico
    {
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";

        //Método para buscar o cep digitado pelo usuário
        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            //Criando uma variável para passar como parâmetro
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);

            //Fazer a busca na Internet
            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(NovoEnderecoURL);

            //Deserializar o Conteudo para converter em um objeto do tipo Endereco
            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);

            //Verificando se o CEP digitado existe
            if (end == null || end.cep == null) return null;

            //Retornar a variável end
            return end;
        }
    }
}
