O ATHOS � DES�FIO T�CNICO constitui numa aplica��o Web API MVC 5 com Entity framework conectado ao banco de dados SQL Server.

-Para resolver o desafio foi adotada a estrat�gia de Criar uma classe ProvaDbContext herdando de DbContext com os devidos DBSets para cada uma das persist�ncias necess�rias do database. Foram criadas classes Models para cada uma das persit�ncias com o mesmo padr�o das tabelas do database. Foram criadas tamb�m as Views para cada umas das persist�ncias juntamente com as interfaces para Criar, Editar, Remover e Detalhar. � poss�vel cadastrar Usu�rios, Administradoras, Condom�nios al�m de Enviar o Comunicado atrav�s das p�ginas. A APIController foi criada para fazer o cadrastro dos Usu�rios, Administradoras e Enviar o comunicado. No Projeto de teste foi criada a controller AssunstosControllerTest para que possa ser executado o teste de envio do comunicado. Um arquivo de log tempor�rio � criado para simular o envio do comunicado atras de email.

- Para rodar o projeto � necess�rio ter uma inst�ncia local do SQL SERVER na sua m�quina. Depois disso � s� executar o projeto Prova na solution Prova.

Link para o source code do Projeto no GITHUB: https://github.com/andresmenendez/ProvaTecnica
Segue um link para uma demonstra��o do Desafio rodando: https://www.screencast.com/t/osZc4dctq

