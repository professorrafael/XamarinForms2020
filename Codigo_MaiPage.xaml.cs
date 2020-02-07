	//TODO - Lógica do App
            //TODO - Validações
            string cep = CEP.Text.Trim();
            Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

            RESULTADO.Text = string.Format("Endereço: {0},{1} {2}", end.End_localidade, end.End_uf, end.End_logradouro);

            //TODO - 