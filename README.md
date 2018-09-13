# Braspag SDK para .NET Standard

[![Build status](https://braspag.visualstudio.com/Innovation/_apis/build/status/Braspag-DotNet-SDK)](https://braspag.visualstudio.com/Innovation/_build/latest?definitionId=470)

SDK para integração simplificada nos serviços da plataforma [Braspag](https://www.braspag.com.br/packages/Braspag.Sdk/)

### Features

* Assembly para .NET Standard 2.0
* Instalação simplificada utilizando [NuGet](http://www.braspag.com.br/#solucoes), sem necessidade de arquivos de configuração
* Endpoints Braspag já configurados no pacote
* Seleção de ambientes Sandbox ou Production
* Métodos assíncronos para melhor desempenho nas requisições
* Client para a API do Pagador (Autorização, Captura, Cancelamento/Estorno, Consulta)
* Client para a API do Cartão Protegido (Salvar cartão, Recuperar cartão, Invalidar cartão)

### Exemplo de Uso

```csharp

/* Criação do Cliente Pagador */
var pagadorClient = new PagadorClient(new PagadorClientOptions
{
    Environment = Environment.Sandbox,
    Credentials = new MerchantCredentials
    {
        MerchantId = "ID_DA_LOJA",
        MerchantKey = "CHAVE_DA_LOJA"
    }
});

/* Criação da requisição para nova transação */
var request = new SaleRequest
{
    MerchantOrderId = "123456789",
    Customer = new CustomerData
    {
        Name = "Bjorn Ironside",
        Birthdate = "1990-12-25",
        IdentityType = "CPF",
        Identity = "762.502.520-96",
        Email = "bjorn.ironside@vikings.com.br"
    },
    Payment = new PaymentDataRequest
    {
        Provider = "Simulado",
        Type = "CreditCard",
        Amount = 150000,
        ServiceTaxAmount = 0,
        Currency = "BRL",
        Country = "BRA",
        Installments = 1,
        SoftDescriptor = "Braspag SDK",
        CreditCard = new CreditCardData
        {
            CardNumber = "4485623136297301",
            Holder = "BJORN IRONSIDE",
            ExpirationDate = "12/2025",
            SecurityCode = "123",
            Brand = "visa"
        }
    }
};

/* Obtenção do resultado da operação */
var response = await client.CreateSaleAsync(request);

```