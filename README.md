Instruções de uso:

Foi feita uma migração que cria a tabela "Produto" e popula a tabela com alguns produtos. 
Para a migração funcionar devidamente basta mudar a conection string que está no arquivo "appsettings.Development.json" na API, colocando as informações do seu banco de dados.
Caso o nome da base não for alterado, é preciso criar um banco de dados chamado ProdutoDB para a migração rodar normlamente.

O usuário e senha de autenticação foi feita de forma estática, onde:
username: admin
password: 1234
