# CarregamentoEV API

## Descrição

A **CarregamentoEV API** é uma aplicação que facilita o gerenciamento de estações de carregamento para veículos elétricos. A API permite que os usuários realizem operações básicas (CRUD) para gerenciar estações de carregamento, incluindo adicionar novas estações, visualizar informações detalhadas, atualizar e excluir registros.  

Além disso, a API foi projetada para ser utilizada como backend para sistemas que necessitem dessas funcionalidades, sendo ideal para empresas ou iniciativas que busquem oferecer suporte a veículos elétricos.  

---

## Estrutura do Projeto

### Principais Funcionalidades:

1. **Gerenciamento de Estações de Carregamento**:
   - Adicionar, listar, visualizar, editar e excluir estações de carregamento.
2. **Swagger UI**:
   - Uma interface visual que permite a interação e teste direto dos endpoints.
3. **Banco de Dados**:
   - Utiliza o **Oracle Database** para armazenar os dados.

---

## Tecnologias Utilizadas

- **ASP.NET Core** para desenvolvimento da API.
- **Entity Framework Core** para acesso ao banco de dados.
- **Oracle Database** como banco de dados relacional.
- **Swagger UI** para documentação interativa da API.


## Configuração e Execução do Projeto

1. **Clone o Repositório**:
git clone https://github.com/PedroLuizPrado/GlobalSolution_.NET.git
-------------------------------------------------------------------------
2. **Configure a Connection String**:
- Abra o arquivo appsettings.json e configure a string de conexão com o Oracle Database:
"ConnectionStrings": {
    "DefaultConnection": "Seu_Oracle_Connection_String"
}
---------------------------------------------------------------------------------
3. **Instale as Dependências**:
- Certifique-se de ter o SDK do .NET instalado e execute:

dotnet restore
----------------------------------------------------------------------------------
4. **Execute as Migrações**:
-Para garantir que o banco de dados esteja configurado corretamente, rode

dotnet ef database update
-------------------------------------------------------------------------------
5. **Execute o Projeto**:

dotnet run
------------------------------------------------------------------------------


## Endpoints da API
1. **Listar todas as estações**
GET /ChargingStation

- Descrição: Retorna uma lista com todas as estações de carregamento cadastradas.
Resposta:
json
Copiar código
[
    {
        "id": 1,
        "name": "Estação A",
        "location": "Rua 123, Cidade X",
        "status": "Disponível"
    },
    {
        "id": 2,
        "name": "Estação B",
        "location": "Avenida Y, Cidade Z",
        "status": "Ocupado"
    }
]

2. **Visualizar detalhes de uma estação**
GET /ChargingStation/Details/{id}

Parâmetros:
id: ID da estação que deseja consultar.
- Descrição: Retorna os detalhes de uma estação específica.
Resposta (se encontrado):
json
Copiar código
{
    "id": 1,
    "name": "Estação A",
    "location": "Rua 123, Cidade X",
    "status": "Disponível"
}
Erro: Se o ID não for encontrado:
json
Copiar código
{
    "error": "Estação não encontrada"
}



3. **Adicionar uma nova estação**
POST /ChargingStation/Create

Corpo da Requisição:
json
Copiar código
{
    "name": "Estação Nova",
    "location": "Praça 456, Cidade W",
    "status": "Disponível"
}
 - Descrição: Cria uma nova estação de carregamento no sistema.
Resposta (em caso de sucesso):
json
Copiar código
{
    "message": "Estação criada com sucesso"
}


4. **Editar uma estação existente**
POST /ChargingStation/Edit/{id}

Parâmetros:
id: ID da estação que deseja editar.
Corpo da Requisição:
json
Copiar código
{
    "name": "Estação Editada",
    "location": "Avenida Nova, Cidade K",
    "status": "Manutenção"
}
- Descrição: Atualiza os dados de uma estação existente.
Resposta (em caso de sucesso):
json
Copiar código
{
    "message": "Estação atualizada com sucesso"
}


5.  **Excluir uma estação**
POST /ChargingStation/Delete/{id}

Parâmetros:
id: ID da estação que deseja excluir.
- Descrição: Remove uma estação do sistema.
Resposta (em caso de sucesso):
json
Copiar código
{
    "message": "Estação removida com sucesso"
}
Como Testar a API
Via Swagger UI:

Acesse https://localhost:7179 após iniciar o projeto.
## Utilize a interface do Swagger para explorar os endpoints.
Via Postman:

Configure o Postman para acessar os endpoints descritos acima.
Certifique-se de enviar o corpo correto para os métodos POST.
Resposta Padrão:

Todos os métodos retornam mensagens JSON, seja com os dados solicitados ou mensagens de erro.


