USE M_OPFLIX

INSERT Categorias(Nome)
	VALUES('Ficcao'),('Drama'),('Acao'),('Infantil'),('Aventura'),('Fantasia'),('Comedia')
INSERT Categorias(Nome)
	VALUES('Terror'),('Musical'),('Suspense'),('Animação')

INSERT Plataformas(Nome)
	VALUES ('Netflix'),('Cinema'),('Amazon'),('Outro'),('VHS')

INSERT Usuarios(Nome,Email,Senha,DataNascimento,Admin)
	VALUES ('Erik','erik@email.com','BA3253876AED6BC22D4A6FF53D8406C6AD864195ED144AB5C87621B6C233B548BAEAE6956DF346EC8C17F5EA10F35EE3CBC514797ED7DDD3145464E2A0BAB413','1999-01-30',1),('Cassiana','cassiana@email.com','123456','1993-07-01',1),('Helena','helena@email.com','BA3253876AED6BC22D4A6FF53D8406C6AD864195ED144AB5C87621B6C233B548BAEAE6956DF346EC8C17F5EA10F35EE3CBC514797ED7DDD3145464E2A0BAB413','1997-08-07',0),('Roberto','rob@email.com','BA3253876AED6BC22D4A6FF53D8406C6AD864195ED144AB5C87621B6C233B548BAEAE6956DF346EC8C17F5EA10F35EE3CBC514797ED7DDD3145464E2A0BAB413','2005-01-24',0),('Raul','ra@gmail.com','BA3253876AED6BC22D4A6FF53D8406C6AD864195ED144AB5C87621B6C233B548BAEAE6956DF346EC8C17F5EA10F35EE3CBC514797ED7DDD3145464E2A0BAB413','2002-04-19',1),('Cleiton','c@gmail.com','BA3253876AED6BC22D4A6FF53D8406C6AD864195ED144AB5C87621B6C233B548BAEAE6956DF346EC8C17F5EA10F35EE3CBC514797ED7DDD3145464E2A0BAB413','1999-05-12',0),('Ricardo','ri@gmail.com','BA3253876AED6BC22D4A6FF53D8406C6AD864195ED144AB5C87621B6C233B548BAEAE6956DF346EC8C17F5EA10F35EE3CBC514797ED7DDD3145464E2A0BAB413','2000-08-22',0)

UPDATE Usuarios SET Admin = 1 WHERE IdUsuario = 3

INSERT TiposTitulos(Tipo)
	VALUES('Filme'),('Serie'),('Documentario')

INSERT Titulos(Nome,Sinopse,Duracao,DataLancamento,IdPlataforma,IdCategoria,IdTipoTitulo)
	VALUES('Viuva Negra','Uma agente inflitrada bate em macho.',165,'2020-05-01',2,3,1),
	('Doutor_Estranho_2','Doutor Estranho usa magia para bater em seus inimigos.', 173, '2021-11-05',2,1,1),
	('Batwoman','A nova super heroina.',200,'2019-10-06',4,3,2),('Frozen 2','A nevasca chegou.',140,'2019-02-13',2,4,1),
	('Turma da Monica Licoes','Os famoso jovens de Mauricio de Souza em aventuras mirabolantes.',150, '2019-08-02',2,4,1),
	('Sonic O Filme','O ourico mais querido dos jogos agora nas telinhas.',130,'2019-05-25',2,4,1),
	('Flash','Ele corre muito rapido.'	,3000,'2014-10-07',	1,	1,	2),
	('Dark',	'Viagem temporal.'	,1000,'2017-10-10'	,1	,1,2),
	('Avatar 2',	'Os caras grandes azuis.'	,180,'2020-12-18'	,2,	1,	1),
	('Mulan',	'A moca que finge ser homem para se alistar no exercito.',	155, '2020-05-27',	2,	5,	1),
	('Malevola 2',	'Novas ameacas chegam ao reino de Malevola.',	144,'2020-04-09',	2,	6,	1),
	('Godzilla Vs Kong','Os dois gigantes saem na porrada.',	180,'2020-04-22',	2,	1,	1),
	('Animais Fantasticos 3',	'A continuacao da serie de filmes.',	176,'2020-11-19',	2,	6,	1),
	('Minions 2',	'Os pequeninos da Disney estao de volta.',135,'2020-06-02',	2,	4,	1),
	('Barbie',	'As princesas da Disney agora viraram Live Action.',	144, '2020-04-14',	2,	7,	1)

INSERT Titulos(Nome,Sinopse,Duracao,DataLancamento,IdPlataforma,IdCategoria,IdTipoTitulo,Classificacao)
	VALUES('O Rei Leão','O Rei Leão, da Disney, dirigido por Jon Favreau, retrata uma jornada pela savana africana, onde nasce o futuro rei da Pedra do Reino, Simba. O pequeno leão que idolatra seu pai, o rei Mufasa, é fiel ao seu destino de assumir o reinado. Mas nem todos no reino pensam da mesma maneira. Scar, irmão de Mufasa e ex-herdeiro do trono, tem seus próprios planos. A batalha pela Pedra do Reino é repleta de traição, eventos trágicos e drama, o que acaba resultando no exílio de Simba. Com a ajuda de dois novos e inusitados amigos, Simba terá que crescer e voltar para recuperar o que é seu por direito', 118,'2019-07-08',2,9,1,'L'),
		  ('La Casa De Papel 3 temp','Oito habilidosos ladrões se trancam na Casa da Moeda da Espanha com o ambicioso plano de realizar o maior roubo da história e levar com eles mais de 2 bilhões de euros. Para isso, a gangue precisa lidar com as dezenas de pessoas que manteve como refém, além dos agentes da força de elite da polícia, que farão de tudo para que a investida dos criminosos fracasse.',650,'2019-07-19',2,10,2,'16'),
		  ('Deuses Americanos','Shadow Moon é um ex-vigarista que serve como segurança e companheiro de viagem para o Sr. Wednesday, um homem fraudulento que é, na verdade, um dos velhos deuses, e está na Terra em uma missão: reunir forças para lutar contra as novas entidades.',620,'2017-04-30',4,2,2,'18+'),
		  ('Toy Story 4','Woody sempre teve certeza sobre o seu lugar no mundo e que sua prioridade é cuidar de sua criança, seja Andy ou Bonnie. Mas quando Bonnie adiciona um relutante novo brinquedo chamado Garfinho ao seu quarto, uma aventura na estrada ao lado de velhos e novos amigos mostrará a Woody quão grande o mundo pode ser para um brinquedo.',100,'2019-06-20',2,11,1,'L')

INSERT Titulos(Nome,Sinopse,Duracao,DataLancamento,IdPlataforma,IdCategoria,IdTipoTitulo,Classificacao)
	VALUES('Guardiões da Galáxia','Os carinhas vão para a galaxia com um guaxinim fofo e uma árvore falante',140,'2014-07-31',2,3,1,'12'),
		('Guardiões da Galáxia','Os carinhas vão para a galaxia com um guaxinim fofo e uma árvore falante',140,'2014-07-31',1,3,1,'12')


DELETE FROM Titulos WHERE IdTitulo = 19

UPDATE Titulos
SET Nome = REPLACE(Nome,'_',' ')

UPDATE Titulos
SET Nome = 'La Casa De Papel - 3º Temporada'
WHERE IdTitulo = 18

INSERT Favoritos(IdUsuario,IdTitulo)
	VALUES(5,5),(5,6),(2,1),(2,4),(4,9),(6,12),(6,13),(7,16),(7,8)

UPDATE Categorias
SET Nome = 'Ficção Científica'
WHERE IdCategoria = 1

UPDATE Titulos SET DataLancamento = '1994-07-08' WHERE IdTitulo = 17
UPDATE Titulos SET IdPlataforma = 5 WHERE IdTitulo = 17

UPDATE Titulos SET Classificacao = 'L'
WHERE IdTitulo = 10

UPDATE Usuarios
SET IMAGEM = 'https://i.ytimg.com/vi/Hlz7ass3gRk/maxresdefault.jpg'
	
UPDATE Usuarios
SET IMAGEM = 'https://s.yimg.com/ny/api/res/1.2/S_.T.QCJ1jjT8geJAvkNFg--~A/YXBwaWQ9aGlnaGxhbmRlcjtzbT0xO3c9ODAw/http://media.zenfs.com/en/homerun/feed_manager_auto_publish_494/b486faff10c2459650d92f309bad2527'
WHERE IdUsuario < 5

UPDATE USUARIOS
SET imagem = 'https://rockntech.com.br/wp-content/uploads/2014/12/gatos-famosos-na-internet_13.jpg'
WHERE IdUsuario <4

UPDATE USUARIOS
SET imagem = 'https://www.tediado.com.br/wp-content/uploads/2019/02/fotos-de-gatos-maine-coon-que-sao-super-majestosos-e-fofos-01.jpg'
WHERE IdUsuario <3
