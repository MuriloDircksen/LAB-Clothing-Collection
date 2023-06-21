# LABFashion

Projeto desenvolvido utilizando Visual Studio 22, .net 7.0, e sql server 19, para criação API Rest em C# com uso de .Net, como requisito para conclusão do projeto I do módulo II do curso DevinHouse turma Audaces.

## Ferramentas e requisitos necessárias para rodar o projeto
- Visual Studio 22
- Sql server express 19
- SDK 7.0
- Pacote AutoMapper 12.0.1
- Pacote Microsoft.AspNetCore.Mvc.NewtonsoftJson 7.0.5
- Pacote Microsoft.AspNetCore.OpenApi 7.0.5
- Pacote Microsoft.EntityFrameworkCore 7.0.5
- Pacote Microsoft.EntityFrameworkCore.Design 7.0.5
- Pacote Microsoft.EntityFrameworkCore.SqlServer 7.0.5
- Pacote Microsoft.EntityFrameworkCore.Tools 7.0.5


### Como rodar a Aplicação

1. Iniciar sua IDE
2. Inicie o sistema sql server
3. Conectar o banco de dados 
4. Rodar a aplicação no visual studio
5. Esperar carregar página web da documentação da API usando swagger.


### Modelo JSON de entrada
```json
[
  {
    "email": "pedro.henrique.monteiro@serteccontabil.com.br",
    "tipoUsuario": "ADMINISTRADOR",
    "status": "ATIVO",
    "id": 1,
    "nomeCompleto": "Pedro Henrique Danilo Monteiro",
    "genero": "Masculino",
    "dataNascimento": "1968-05-22T00:00:00",
    "cpfOuCnpj": "58080200343",
    "telefone": "48985460199"
    "colecao": {
                  "id": 5,
                  "nomeColecao": "stringstri",
                  "idUsuario": 1,
                  "marca": "string",
                  "orcamento": 10,
                  "dataLancamento": "2023-06-15T00:00:00",
                  "estacao": "OUTONO",
                  "status": "ATIVO",
                  "modelo": {
                              "id": 4,
                              "nomeModelo": "string",
                              "idColecao": 5,
                              "tipo": "BERMUDA",
                              "layout": "BORDADO"
                            }
                }
  }
 ]
```
### Diagrama Relacional de Entidades
![alt text](https://github.com/MuriloDircksen/LAB-Clothing-Collection/blob/main/LABClothingCollection/imagem/diagrama%20relacional.PNG)

### Tipos de dados

- id -> identificador criado automaticamente
- nomeCompleto -> String de preenchimento obrigatório com minimo de 10 e máximo de 200 caracteres
- Genero" -> String de preenchimento não obrigatório com máximo de 50 caracteres
- DataNascimento -> DateTime de preenchimento obrigatório
- CpfOuCnpj -> String de preenchimento obrigatório de 11 ou 14 caracteres
- Email -> String de preenchimento obrigatório 
- TipoUsuario -> Enum que apresenta a lista de valores que o satisfazem
- Status -> Enum que apresenta a lista de valores que o satisfazem
- NomeColecao -> String de preenchimento obrigatório com minimo de 10 e máximo de 200 caracteres
- IdUsuario ->Inteiro de preenchimento obrigatório
- Estacao -> Enum que apresenta a lista de valores que o satisfazem
- Marca -> String de preenchimento obrigatório
- Orcamento -> Number de preenchimento obrigatório
- DataLancamento -> DateTime de preenchimento obrigatório
- NomeModelo -> String de preenchimento obrigatório com minimo de 5 e máximo de 200 caracteres
- IdColecao ->Inteiro de preenchimento obrigatório
- Tipo -> Enum que apresenta a lista de valores que o satisfazem
- Layout -> Enum que apresenta a lista de valores que o satisfazem


### Autor

Murilo Dircksen
https://www.linkedin.com/in/murilodircksen/
