INSERT INTO USUARIOS (EMAIL, SENHA, TIPOUSUARIO)
VALUES('admin@admin.com','admin','ADMINISTRADOR'),
('cliente@cliente.com','cliente','CLIENTE')

SELECT * FROM USUARIOS

INSERT INTO ESTUDIOS (NOMEESTUDIO)
VALUES('Blizzard'),('Rockstar Studios'),('Square Enix')

SELECT * FROM ESTUDIOS

INSERT INTO JOGOS (NOMEJOGO, DESCRICAO, DATALANCAMENTO, VALOR, ID_ESTUDIOS)
VALUES('Diablo III','é um jogo que contém bastante ação e é viciante, seja você um novato ou um fã','15/05/2012','99.00',1),
('Red Dead Redemption II','jogo eletrônico de ação-aventura western','26/11/2018','120.00',2)

SELECT * FROM JOGOS