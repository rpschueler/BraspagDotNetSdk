# Braspag SDK para .NET Standard

| Develop | Master |
|---|---|
| [![Build status](https://braspag.visualstudio.com/Innovation/_apis/build/status/Braspag-DotNet-SDK?branchName=develop)](https://braspag.visualstudio.com/Innovation/_build/latest?definitionId=470) | [![Build status](https://braspag.visualstudio.com/Innovation/_apis/build/status/Braspag-DotNet-SDK?branchName=master)](https://braspag.visualstudio.com/Innovation/_build/latest?definitionId=470) |

SDK para integra��o simplificada nos servi�os da plataforma [Braspag](http://www.braspag.com.br/#solucoes)

### Features

* Assembly para .NET Standard 2.0
* Instala��o simplificada utilizando [NuGet](https://www.nuget.org/packages/Braspag.Sdk/), sem necessidade de arquivos de configura��o
* Endpoints Braspag j� configurados no pacote
* Sele��o de ambientes Sandbox ou Production
* M�todos ass�ncronos para melhor desempenho nas requisi��es
* Client para a API Braspag Auth (Obten��o de tokens de acesso)
* Client para a API do Pagador (Autoriza��o, Captura, Cancelamento/Estorno, Consulta)
* Client para a API do Cart�o Protegido (Salvar cart�o, Recuperar cart�o, Invalidar cart�o)
* Client para a API de an�lises do Velocity

### Pagador: Exemplo de Uso

```csharp

/* Cria��o do Cliente Pagador */
var pagadorClient = new PagadorClient(new PagadorClientOptions
{
    Environment = Environment.Sandbox,
    Credentials = new MerchantCredentials
    {
        MerchantId = "ID_DA_LOJA",
        MerchantKey = "CHAVE_DA_LOJA"
    }
});

/* Cria��o da requisi��o para nova transa��o */
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

/* Obten��o do resultado da opera��o */
var response = await pagadorClient.CreateSaleAsync(request);

```


### Cart�o Protegido: Exemplo de Uso

```csharp

/* Cria��o do Cliente Cart�o Protegido */
var cartaoProtegidoClient = new CartaoProtegidoClient(new CartaoProtegidoClientOptions
{
    Environment = Environment.Sandbox,
    Credentials = new MerchantCredentials
    {
        MerchantKey = "CHAVE_DA_LOJA"
    }
});

/* Salvar cart�o em cofre PCI */
var request = new SaveCreditCardRequest
{
    CustomerName = "Bjorn Ironside",
    CustomerIdentification = "762.502.520-96",
    CardHolder = "BJORN IRONSIDE",
    CardExpiration = "10/2025",
    CardNumber = "1000100010001000"
};

/* Obten��o do resultado da opera��o */
var response = await cartaoProtegidoClient.SaveCreditCardAsync(request);

```