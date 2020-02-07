using AppConsultaCep.Servico;
using AppConsultaCep.Servico.Modelo;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace AppConsultaCep
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs args)
        {
            //TODO - Validações
            string cep = CEP.Text.Trim();

            if(isValidCEP(cep))
            {
                try
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                    if(end != null)
                    {
                        RESULTADO.Text = string.Format("Endereço: {2} de {3} {0},{1}", end.localidade, end.uf, end.logradouro, end.bairro);
                    }
                    else
                    {
                        DisplayAlert("ERRO: ", "O endereço para o CEP informado, não foi encontrado !!!!" + cep, "OK");
                    }                    
                }
                catch(Exception e)
                {
                    DisplayAlert("ERRO CRÍTICO: ", e.Message, "OK");
                }
            }
            else
            {
                //
            }
        }

        //Método para validar o CEP
        private bool isValidCEP(string cep)
        {
            bool valido = true;

            if(cep.Length!= 8)
            {
                DisplayAlert("ERRO: ", "CEP Inválido !!!! O CEP deve conter 8 caracteres.", "Ok");
                valido = false;
            }

            int NovoCEP = 0;
            if(!int.TryParse(cep, out NovoCEP))
            {
                DisplayAlert("ERRO: ", "CEP Inválido !!!! O CEP deve conter somente números.", "Ok");
                valido = false;
            }

            return valido;
        }
    }
}
//Parei na aula 31