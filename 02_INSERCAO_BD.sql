INSERT INTO USUARIOS (EMAIL, SENHA, TIPOUSUARIO)
VALUES('admin@admin.com','admin','ADMINISTRADOR'),
('cliente@cliente.com','cliente','CLIENTE')

SELECT * FROM USUARIOS

INSERT INTO ESTUDIOS (NOMEESTUDIO)
VALUES('Blizzard'),('Rockstar Studios'),('Square Enix')

SELECT * FROM ESTUDIOS

INSERT INTO JOGOS (NOMEJOGO, DESCRICAO, DATALANCAMENTO, VALOR, ID_ESTUDIOS)
VALUES('Diablo III','� um jogo que cont�m bastante a��o e � viciante, seja voc� um novato ou um f�','15/05/2012','99.00',1),
('Red Dead Redemption II','jogo eletr�nico de a��o-aventura western','26/11/2018','120.00',2)

SELECT * FROM JOGOS