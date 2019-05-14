# Morais.Core

API feita em C# conectando no banco de dados <a href="https://www.mongodb.com/">MongoDB Atlas</a>. Veja também o <a href="https://github.com/moraisandre/Morais.CRUD.Web">front</a> feito em Angular que utiliza esse Core para cadastrar Clientes no sistema.

## Modelo Cliente no MongoDB
```json
{
	"_id": {
		"$oid": "5cd709b81c9d440000f9fb06"
	},
	"documento": "11122233344",
	"TipoPessoa": {
		"$numberInt": "1"
	},
	"Nome": "André Morais",
	"Endereco": "Av Paulista, 123",
	"Email": "morais@andremorais.com.br"
}
```

## Web Config

Alterar `MongoDBConnectionString` e colocar a string de conexão. Nesse exemplo eu usei o <a href="https://www.mongodb.com/">MongoDB Atlas</a>.

```xml
<add key="MongoDBConnectionString" value="mongodb+srv://user:password@moraiscluster-xdmnl.mongodb.net/nomedatabase?connect=replicaSet" />
```
Mudar a key `MongoDBBase` e colocar o nome da base criada.

```xml
<add key="MongoDBBase" value="nomedatabase" />
```
