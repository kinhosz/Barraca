# Barraca

Uma webApi simples para gerenciamento de vendas e adição de estoques em uma barraquinha. O sistema contém clientes, produtos e pedidos.

### run server
dotnet watch run --launcher-profile https

### run sql-server
sudo systemctl start mssql-server
sudo systemctl status mssql-server

### migrations
dotnet ef migrations add NomeDaMigracao

dotnet ef database update

### Swagger
`/swagger`: para testar a API

## Controllers

### Customer

* `GET /Customer?<uuid>`: Consulta um customer pelo uuid.

* `POST/Customer`:
```cpp
body = {
  "name": "string",
  "email": "string"
}
```

cria um customer passando o o nome e o email.

* `GET/Customer/email?<email>`: consulta um customer pelo email.

* `GET/customers`: retorna a lista de todos os customers.

* `GET/debts?<uuid>`: consulta orders pendentes de um customer.

### Order

* `GET/Order?<uuid>`: consulta uma order pelo uuid.

* `POST/Order`
```cpp
body = {
    "customerId": "string",
    "state": "string"
}
```
cria uma order.

* `PUT/Order?<uuid>`
```cpp
body = {
    "payment": "string"
}
```
Atualiza o paymentState de uma order.

* `GET/orders`: consulta todas orders.

### Product

* `GET/Product?<uuid>`: consulta um product pelo uuid.

* `POST/Product/`:
```cpp
body = {
  "title": "string",
  "description": "string",
  "value": 0
}
```
Cria um produto.

### Products 

* `GET/Products`: consulta todos os produtos

* `GET/Products/availables`: Consulta todos os produtos que estão no estoque (com problemas!)

### Replenishment

* `GET/Replenishment?<uuid>`: consulta uma informação sobre adição de produtos no estoque.

* `POST/Replenishment`:
```cpp
body = {
    "productUuid": "string",
    "quantity": "int"
}
```
Adiciona uma certa quantidade de um único produto no estoque.

* `GET/replenishments`: consulta todas adições de produtos no estoque.

### Shop

* `POST/Shop`:
```cpp
body = {
    "orderUuid": "string",
    "productUuid": "string",
    "quantity": "Int"
}
```
Similar ao replenishment, a diferença é que o shop é apenas um auxiliar para o order para informar quantos produtos de um mesmo tipo
foram comprados em uma única compra.