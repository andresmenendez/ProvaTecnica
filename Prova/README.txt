O ATHOS – DESÁFIO TÉCNICO constitui numa aplicação Web API MVC 5 com Entity framework conectado ao banco de dados SQL Server.

-Para resolver o desafio foi adotada a estratégia de Criar uma classe ProvaDbContext herdando de DbContext com os devidos DBSets para cada uma das persistências necessárias do database. Foram criadas classes Models para cada uma das persitências com o mesmo padrão das tabelas do database. Foram criadas também as Views para cada umas das persistências juntamente com as interfaces para Criar, Editar, Remover e Detalhar. É possível cadastrar Usuários, Administradoras, Condomínios além de Enviar o Comunicado através das páginas. A APIController foi criada para fazer o cadrastro dos Usuários, Administradoras e Enviar o comunicado. No Projeto de teste foi criada a controller AssunstosControllerTest para que possa ser executado o teste de envio do comunicado. Um arquivo de log temporário é criado para simular o envio do comunicado atras de email.

- Para rodar o projeto é necessário ter uma instância local do SQL SERVER na sua máquina. Depois disso é só executar o projeto Prova na solution Prova.

Link para o source code do Projeto no GITHUB: https://github.com/andresmenendez/ProvaTecnica
Segue um link para uma demonstração do Desafio rodando: https://www.screencast.com/t/osZc4dctq

