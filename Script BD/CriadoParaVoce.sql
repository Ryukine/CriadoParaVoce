USE master
IF EXISTS(select * from sys.databases where name='CriadoParaVoce')
DROP DATABASE CriadoParaVoce
GO
CREATE DATABASE CriadoParaVoce
GO
/*SELECT * FROM sys.databases CriadoParaVoce*/
USE CriadoParaVoce
GO
/*
DROP TABLE [dbo].[tbUsuario] 
GO
DROP TABLE [dbo].[tbNivelAcesso] 
GO
DROP TABLE [dbo].[tbCliente] 
GO
DROP TABLE [dbo].[tbContato] 
GO
drop TABLE [dbo].[tbVendedor]
GO
drop TABLE [dbo].[tbCliente]
GO	
DROP TABLE [dbo].[tbProduto]
go
DROP TABLE [dbo].[tbLancamento]
GO
DROP TABLE [dbo].[tbPeriodo]
GO
DROP TABLE [dbo].[tbTipoTitulo]
GO
*/
CREATE TABLE tbNivelAcesso (/**/
    CodigoNivel       int             IDENTITY primary KEY Not null,
    NomeNivel         VARCHAR(50),
    AbreviacaoNivel   VARCHAR(3),
    StatusNivel       int
)	
GO
INSERT INTO tbNivelAcesso (NomeNivel, AbreviacaoNivel, StatusNivel) VALUES ('ADMINISTRADOR', 'ADM', 1)
GO
CREATE TABLE dbo.tbDepartamento(/**/
	CodigoDepartamento		INT		IDENTITY	PRIMARY KEY not null,
	NomeDepartamento		Varchar(80),
	DescricaoDepartamento	Varchar(100),
	StatusDepartamento		INT
)
go
INSERT INTO tbNivelAcesso (NomeNivel, AbreviacaoNivel, StatusNivel)	VALUES ('Administrador', 'ADM', 1)
GO
INSERT INTO tbNivelAcesso (NomeNivel, AbreviacaoNivel, StatusNivel)	VALUES ('Vendedor', 'VND', 1)
GO
INSERT INTO tbNivelAcesso (NomeNivel, AbreviacaoNivel, StatusNivel)	VALUES ('Supervisor', 'SUP', 1)
GO
INSERT INTO tbDepartamento(NomeDepartamento, DescricaoDepartamento, StatusDepartamento) VALUES ('Estampa de camisas', 'Estampar Camisas', 1)
GO
INSERT INTO tbDepartamento(NomeDepartamento, DescricaoDepartamento, StatusDepartamento) VALUES ('Gerenciar Estampas', 'Ver a qualidade de estampa dos produtos', 1)
GO
INSERT INTO tbDepartamento(NomeDepartamento, DescricaoDepartamento, StatusDepartamento) VALUES ('Estampa de canecas', 'Estampar Canecas', 1)
GO
INSERT INTO tbDepartamento(NomeDepartamento, DescricaoDepartamento, StatusDepartamento) VALUES ('Loja', 'Tudo envolvido com a loja, vendedor, gerente, organizador', 1)
GO
INSERT INTO tbDepartamento(NomeDepartamento, DescricaoDepartamento, StatusDepartamento) VALUES ('Estoque', 'Todos envolvidos em gerenciar o estoque, qualidade do estoque, quantidade de estoque', 1)
GO
SELECT * FROM tbDepartamento
GO
CREATE TABLE dbo.tbCargo(/**/
	CodigoCargo		INT		IDENTITY	PRIMARY KEY not null,
	NomeCargo		Varchar(80),
	DescricaoCargo	Varchar(80),
	StatusCargo		INT
)
GO
INSERT INTO tbCargo(NomeCargo, DescricaoCargo, StatusCargo) VALUES ('Maquinista de estampa','Manuseio da maquina de estampa', 1)
GO
INSERT INTO tbCargo(NomeCargo, DescricaoCargo, StatusCargo) VALUES ('Gerenciador do estoque','Atualiza dados sobre o estoque', 1)
GO
INSERT INTO tbCargo(NomeCargo, DescricaoCargo, StatusCargo) VALUES ('Gerente de qualidade','Gerencia a qualidade do produto e da estampa', 1)
GO
CREATE TABLE dbo.tbFuncionario(/**/
	CodigoFunc				int		IDENTITY	PRIMARY KEY Not null,
	NomeFuncionario			Varchar(50),
	Sexo					Char(1)	,
    EmailFuncionario        VARCHAR(50),
	CpfFuncionario			VARCHAR(14),
    NascimentoFuncionario   DATETIME,
	StatusFuncionario		int,
	FotoFuncionario			Varchar(Max),
    NomeFoto                Varchar(100),
	Logradouro				Varchar(100),
	CEP						Varchar(10),
	UF						char(2),
	Cidade					Varchar(80),
	Bairro					Varchar(80),
	Numero					Varchar(20),
	Complemento				Varchar(100),
	CodigoDepartamento		INT,
	CodigoCargo				INT,
	--CodigoUsuario			int,

	CONSTRAINT FK_tbCargo_tbFunc FOREIGN KEY (CodigoCargo) REFERENCES tbCargo (CodigoCargo)
,
	--CONSTRAINT FK_tbUsuario_tbFuc FOREIGN KEY (CodigoUsuario) REFERENCES tbUsuario (CodigoUsuario) 

)
GO
SELECT * FROM tbFuncionario
GO
INSERT INTO tbFuncionario(NomeFuncionario, Sexo, CpfFuncionario, NascimentoFuncionario, StatusFuncionario) 
VALUES	('Caixa', 'M', '000.000.000-00', '20/02/1994', 1)
GO
INSERT INTO tbFuncionario(NomeFuncionario, Sexo, CpfFuncionario, NascimentoFuncionario, StatusFuncionario) 
VALUES	('João Basílio', 'M', '491.156.639-65', '20/02/1994', 1)
GO
INSERT INTO tbFuncionario(NomeFuncionario, Sexo, CpfFuncionario, NascimentoFuncionario, StatusFuncionario) 
VALUES	('Breno Rodrigues', 'M', '026.505.657-80', '10/05/1996', 1)
GO
INSERT INTO tbFuncionario(NomeFuncionario, Sexo, CpfFuncionario, NascimentoFuncionario, StatusFuncionario) 
VALUES	('Marianny Arrouba', 'F', '204.912.932-75', '30/09/1992', 1)
GO
INSERT INTO tbFuncionario(NomeFuncionario, Sexo, CpfFuncionario, NascimentoFuncionario, StatusFuncionario) 
VALUES	('Felipe Oliveira', 'm', '554.260.302-51', '30/10/1992', 1)
GO
INSERT INTO tbFuncionario(NomeFuncionario, Sexo, CpfFuncionario, NascimentoFuncionario, StatusFuncionario) 
VALUES	('Thiago Gomes', 'm', '542.658.828-70', '01/10/1990', 1)
GO
CREATE TABLE tbUsuario (/**/
    CodigoUsuario       int             IDENTITY primary KEY Not null,
    NomeUsuario         VARCHAR(100)						 not null,
    NomeSistema         VARCHAR(50),
    SenhaSistema        VARCHAR(100),
    PinUsuario          VARCHAR(4),
    CodigoNivelAcesso   int,
    StatusUsuario       bit,
    PerguntaUsuario     VARCHAR(100),
    RespostaUsuario     NVARCHAR(100),
	CodigoFunc			int,

	CONSTRAINT FK_tbNivelAcesso_tbUsuario FOREIGN KEY (CodigoNivelAcesso) REFERENCES tbNivelAcesso (CodigoNivel),
	CONSTRAINT FK_tbFunc_tbUsuario FOREIGN KEY (CodigoFunc) REFERENCES tbFuncionario (CodigoFunc) 
)
GO
INSERT INTO tbUsuario(NomeUsuario, NomeSistema, SenhaSistema, CodigoNivelAcesso, StatusUsuario, CodigoFunc)
VALUES ('Thiago Gomes','iZIUhbR0e/0=','Thi@123', 1 , 1, 5)
GO
INSERT INTO tbUsuario(NomeUsuario, NomeSistema, SenhaSistema, CodigoNivelAcesso, StatusUsuario, CodigoFunc)
VALUES ('Felipe','Felipe','iZIUhbR0e/0=', 2 , 1, 4)
GO
INSERT INTO tbUsuario(NomeUsuario, NomeSistema, SenhaSistema, CodigoNivelAcesso, StatusUsuario, CodigoFunc)
VALUES ('Lucas','Simon','iZIUhbR0e/0=', 2 , 1, 2)
GO
SELECT * FROM tbUsuario
GO
CREATE TABLE login
( 
	id INT PRIMARY KEY IDENTITY, 
	usuario VARCHAR(100) NOT NULL unique, 
	senha VARCHAR(20) NOT NULL, 
	email VARCHAR(100) NOT NULL unique, 
	nivel_acesso VARCHAR(100) NOT NULL,
	CodigoUsuario Int,

	CONSTRAINT FK_tbUsuario_tblogin FOREIGN KEY (CodigoUsuario) REFERENCES tbUsuario (CodigoUsuario),
)
GO
INSERT INTO login VALUES ('admin', '123456', 'admin@admin.com', 0, 1);
GO 
select * from login; 
GO
CREATE TABLE tbFALE_CONOSCO
(
	--WEB
	IDMSG		  INT IDENTITY PRIMARY KEY,
	EMAIL		  VARCHAR(50)  NOT NULL,
	NOME		  VARCHAR(50)  NOT NULL,
	Assunto		  VARCHAR(50)  ,
	TELEFONE	  VARCHAR(20)  NOT NULL,
	MSG			  VARCHAR(max) NOT NULL,
	DATA_MSG	  DATETIME	   NOT NULL DEFAULT GETDATE(),
	STATUS_MSG	  BIT		   DEFAULT 1,

	--DESKTOP
	CodigoUsuario			INT, -- FOREIGN KEY REFERENCES FUNCIONARIO
	DATA_RESP_MSG			DATETIME	   NULL,
	RESP_MSG				VARCHAR(400) NULL,

	CONSTRAINT FK_tbUsuario_tbFale_Conosco FOREIGN KEY (CodigoUsuario) REFERENCES tbUsuario (CodigoUsuario),
)	

GO
INSERT INTO tbFALE_CONOSCO(Email, nome,telefone,MSG,STATUS_MSG) VALUES ('nayaravolpato@gmail.com', 'Nayara', '11970812585', 'Produtos muito bons,gostei demais', 1)
Go
INSERT INTO tbFALE_CONOSCO(Email, nome,telefone,MSG,STATUS_MSG) VALUES ('naynay@gmail.com', 'Natalia', '11999794026', 'Nao gostei da camisa,não compro mais', 1)
Go
INSERT INTO tbFALE_CONOSCO(Email, nome,telefone,MSG,STATUS_MSG) VALUES ('pedro6hgf@gmail.com', 'Pedro', '14971823345', 'Gostei muito da caneca,tem boa qualidade', 1)
Go
INSERT INTO tbFALE_CONOSCO(Email, nome,telefone,MSG,STATUS_MSG) VALUES ('mrmvolpato@yahoo.com', 'Marcia', '22999798820', 'Onde fica localizada a loja?', 1)
Go
INSERT INTO tbFALE_CONOSCO(Email, nome,telefone,MSG,STATUS_MSG) VALUES ('tayna22@gmail.com', 'Tayná', '43966557890', 'Aceita pagamneto no cartão?', 1)
Go
INSERT INTO tbFALE_CONOSCO(Email, nome,telefone,MSG,STATUS_MSG) VALUES ('Luciano3399@gmail.com', 'Luciano', '11966888979', 'Produtos muito bons', 1)
Go
INSERT INTO tbFALE_CONOSCO(Email, nome,telefone,MSG,STATUS_MSG) VALUES ('Nathan1309@gmail.com', 'Nathan', '22934456798', 'Tem tamanho M da camisa dos vingadores?', 1)
Go
INSERT INTO tbFALE_CONOSCO(Email, nome,telefone,MSG,STATUS_MSG) VALUES ('maryAA20@gmail.com', 'Mary', '11930467898', 'fazem capinhas de celular personalizadas?', 0)
Go
INSERT INTO tbFALE_CONOSCO(Email, nome,telefone,MSG,STATUS_MSG) VALUES ('Thiago4040@gmail.com', 'Thiago', '11955080878', 'Voces vendem canecas em branco?', 0)
Go
INSERT INTO tbFALE_CONOSCO(Email, nome,telefone,MSG,STATUS_MSG) VALUES ('thiagi-araujo@hotmail.com.br', 'Thiago', '11955080878', 'Voces vendem canecas em branco?', 1)
GO
SELECT * FROM dbo.tbFALE_CONOSCO
Go
SELECT * from dbo.tbUsuario;	
GO
--SELECT * FROM tblLogradouros$
GO

CREATE TABLE dbo.tbCliente (/**/
    CodigoCliente       int             IDENTITY    not null,
    NomeCliente         VARCHAR(50)                 not null,
	Sexo				char(1),
	EmailCliente		Varchar(80),
	CpfCliente			Varchar(14),
	Telefone			Varchar(16),
    DataNascimento      DATETIME,
	Logradouro			Varchar(100),
	CEP					Varchar(10),
	UF					char(2),
	Cidade				Varchar(80),
	Bairro				Varchar(80),
	Numero				Varchar(20),
	Complemento			Varchar(100),
    ObsCliente          VARCHAR(200),
    StatusCliente       BIT,
    CONSTRAINT PK_Cliente PRIMARY KEY NONCLUSTERED (CodigoCliente)
)
GO
SELECT * FROM tbCliente

GO
insert into tbCliente(NomeCliente, CpfCliente, StatusCliente) values ('Caixa','000.000.000-00' ,1)
GO
insert into tbCliente(NomeCliente, CpfCliente, StatusCliente) values ('MARIA MERCEDES','057.058.612-73' ,1)
go
insert into tbCliente(NomeCliente, CpfCliente, StatusCliente) values ('JOAO ANTONIO','991.417.150-80' ,1)
go
insert into tbCliente(NomeCliente, CpfCliente, StatusCliente) values ('LINDA OLIVEIRA','566.153.429-95' ,1)
go
insert into tbCliente(NomeCliente, CpfCliente, StatusCliente) values ('SUZANA LUCCA','655.179.149-26' ,1)
go
insert into tbCliente(NomeCliente, CpfCliente, StatusCliente) values ('WALTER OLIVEIRA','912.953.390-21' ,1)
go
insert into tbCliente(NomeCliente, CpfCliente, StatusCliente) values ('MARANA RIBEIRO','490.989.895-60' ,1)
go
insert into tbCliente(NomeCliente, CpfCliente, StatusCliente) values ('CARLOS SANTANA','614.731.871-33' ,1)
go
insert into tbCliente(NomeCliente, CpfCliente, StatusCliente) values ('NATAN MORAES','485.670.650-03' ,1)
go
insert into tbCliente(NomeCliente, CpfCliente, StatusCliente) values ('NATALIA SILVA','511.642.434-03' ,1)
go
insert into tbCliente(NomeCliente, CpfCliente, StatusCliente) values ('LARISSA MORAIS','166.666.286-08' ,1)
go
insert into tbCliente(NomeCliente, CpfCliente, StatusCliente) values ('TAINA RODRIGUES','624.998.831-97' ,1)
go
insert into tbCliente(NomeCliente, CpfCliente, StatusCliente) values ('ROSANA SILVA','189.513.554-03' ,1)
go
insert into tbCliente(NomeCliente, CpfCliente, StatusCliente) values ('MONICA OLIVEIRA','505.380.323-40' ,1)
GO
CREATE TABLE USUARIOWEB(
IdUsuario		int identity Primary key,
Login			varchar(100),
senha			varchar(100),
perfil			varchar(100),
CodigoCliente	int,

	CONSTRAINT FK_tbCliente_USUARIOWEB FOREIGN KEY (CodigoCliente) REFERENCES tbCliente (CodigoCliente) 
)
GO
INSERT INTO USUARIOWEB (Login, senha) VALUES ('Thiago', 123) 
GO
update USUARIOWEB SET perfil='usuario' Where IdUsuario= 1
GO
INSERT INTO USUARIOWEB (Login, senha, perfil) VALUES ('carlos', 123 ,'adm')
GO
SELECT * FROM USUARIOWEB 
GO
CREATE TABLE DBO.tbTipoContato(/**/
    CodigoTipoContato   INT             IDENTITY    not null,
    NomeTipoContato     VARCHAR(50)                 not null,
    StatusTipoContato   BIT,
    CONSTRAINT PK_TipoContato PRIMARY KEY NONCLUSTERED (CodigoTipoContato)
)
go
INSERT INTO tbTipoContato(NomeTipoContato, StatusTipoContato) VALUES ('Celular', 1)
go
INSERT INTO tbTipoContato(NomeTipoContato, StatusTipoContato) VALUES ('Empresarial', 1)
go
INSERT INTO tbTipoContato(NomeTipoContato, StatusTipoContato) VALUES ('Residencial', 1)
Go
CREATE TABLE dbo.tbContatoCliente(/**/
    IdContato           INT             IDENTITY    not null,
    ConteudoContato     VARCHAR(200)                NOT NULL,
    StatusContato       BIt,
    CodigoCliente       Int,
    CodigoTipoContato   Int,
    CONSTRAINT PK_ContatoCli PRIMARY KEY NONCLUSTERED (IdContato),
    CONSTRAINT FK_Cliente_Contato FOREIGN KEY (CodigoCliente) REFERENCES dbo.tbCliente (CodigoCliente),
    CONSTRAINT FK_TipoContato_Contato FOREIGN KEY (CodigoTipoContato) REFERENCES dbo.tbTipoContato (CodigoTipoContato)  
)
GO
INSERT INTO tbContatoCliente(ConteudoContato, StatusContato, CodigoCliente, CodigoTipoContato) VALUES ('11994587126', 1, 1, 1)
GO
INSERT INTO tbContatoCliente(ConteudoContato, StatusContato, CodigoCliente, CodigoTipoContato) VALUES ('1143269546', 1, 1, 3)
GO
INSERT INTO tbContatoCliente(ConteudoContato, StatusContato, CodigoCliente, CodigoTipoContato) VALUES ('1122014759', 1, 1, 2)
GO
CREATE TABLE dbo.tbContatoFuncionario(/**/
    IdContato				 INT             IDENTITY    not null,
	ConteudoContato			 VARCHAR(200)                NOT NULL,
    StatusContato			 Bit,
    CodigoFuncionario		 Int,
    CodigoTipoContato		 Int,
    CONSTRAINT PK_ContatoFunc PRIMARY KEY NONCLUSTERED (IdContato),
    CONSTRAINT FK_Funcionario_ContatoFunc FOREIGN KEY (CodigoFuncionario) REFERENCES dbo.tbFuncionario (CodigoFunc),
    CONSTRAINT FK_TipoContato_ContatoFunc FOREIGN KEY (CodigoTipoContato) REFERENCES dbo.tbTipoContato (CodigoTipoContato)  
)
GO
SELECT * FROM tbContatoFuncionario
GO
INSERT INTO tbContatoFuncionario(ConteudoContato, StatusContato, CodigoFuncionario, CodigoTipoContato) VALUES ('11976541876', 1 , 1, 1)
GO
INSERT INTO tbContatoFuncionario(ConteudoContato, StatusContato, CodigoFuncionario, CodigoTipoContato) VALUES ('1145879687', 1 , 2, 3)
GO
INSERT INTO tbContatoFuncionario(ConteudoContato, StatusContato, CodigoFuncionario, CodigoTipoContato) VALUES ('1522574548', 1 , 1, 2)

GO
Create TABLE dbo.tbFornecedor(/**/
	FornecedorId		int			IDENTITY	primary key not null,
	Descricao			Varchar(80),
	Site				Varchar(80),
	StatusFornecedor	int,
	Contato				Varchar(80),
	Cnpj				Varchar(18),
	Inscricao			Varchar(50),
	Email				Varchar(80),
	Whatsapp			Varchar(20),
	TelefoneFixo		Varchar(20),
	TelefoneCelular		Varchar(20),
	Logradouro			Varchar(100),
	CEP					Varchar(10),
	UF					char(2),
	Cidade				Varchar(80),
	Bairro				Varchar(80),
	Numero				Varchar(20),
	Complemento			Varchar(100)
)
GO
INSERT INTO tbFornecedor (Descricao, Site, StatusFornecedor, Contato, Cnpj, Inscricao, Email, Whatsapp, Logradouro, CEP, UF, Cidade, Bairro, Numero, Complemento) 
VALUES ('Paul', 'Google.com', 1, '(11) 96523-4258', '99.999.999/9999-99', '', 'Paul_1983@Hotmail.com', '(11) 96523-4258', 'Rua Silverstone', '06402150', 'SP', 'Barueri', 'Parque Santa Luzia', '138', '')
GO
INSERT INTO tbFornecedor (Descricao, Site, StatusFornecedor, Contato, Cnpj, Inscricao, Email, Whatsapp, Logradouro, CEP, UF, Cidade, Bairro, Numero, Complemento) 
VALUES ('Juca', 'https://www.atacadaodaroupa.com/fornecedores-de-roupas', 1, '(11) 96523-4258', '17.747.088/0001-02', '', 'Juca_Prado@Outlook.com', '(11) 96872-3987', 'Rua Joaquim Nabuco', '06402150', 'PE', 'Santa Cruz do Capibaribe', 'Santa Tereza', '110', '')
GO
SELECT * FROM tbFornecedor
GO
CREATE TABLE dbo.tbCategoria(/**/
	CategoriaID					int			IDENTITY	primary key not null,
	DescricaoCategoria			Varchar(80) not null,
	Tamanho					 	int,
	StatusCategoria			int
)
GO
INSERT INTO tbCategoria (DescricaoCategoria, StatusCategoria) VALUES ('Camisas', 1)
GO
INSERT INTO tbCategoria (DescricaoCategoria, StatusCategoria) VALUES ('Caneca', 1)
GO
INSERT INTO tbCategoria (DescricaoCategoria, StatusCategoria) VALUES ('Capas', 1)
GO
INSERT INTO tbCategoria (DescricaoCategoria, StatusCategoria) VALUES ('Capa de Sofa', 1)
GO
INSERT INTO tbCategoria (DescricaoCategoria, StatusCategoria) VALUES ('Banner Coorporativo', 0)
GO
INSERT INTO tbCategoria (DescricaoCategoria, StatusCategoria) VALUES ('Chinelo', 1)
GO
INSERT INTO tbCategoria (DescricaoCategoria, StatusCategoria) VALUES ('Roupas de Frio',1)
GO
CREATE TABLE dbo.tbArte(/**/
	IdArte		int		IDENTITY	primary key not null,
	NomeArte	Varchar(80) not null,
	arquivoArte varchar(max) not null,	
	PrecoArte	decimal(10,2),
	Altura		int,
	Largura		int,
)
GO
INSERT tbARTE VALUES ('Elefante Rosa', 'C:\imagens\elefante_rosa.jpg', 10.00, 30, 60)
GO
INSERT tbARTE VALUES ('Foto do Jão', 'C:\imagens\jao.jpg', 15.00, 40, 50)
GO
INSERT tbARTE VALUES ('Padrão', 'C:\imagens\lisa.jpg', 0.00, 30, 30)
GO
SELECT * FROM tbArte
GO
CREATE TABLE DBO.tbProduto(/**/
    CodigoProduto			INT             IDENTITY    PRIMARY KEY not null,
    NomeProduto				VARCHAR(80),
    --QuantMinimaEstoque		int,
	CategoriaId					int,
    StatusProduto			bit,
	PrecoProduto			Decimal(10,2),
	FornecedorID			Int,
	FotoDoProduto			Varchar(max),
    --QuantMaximaEstoque		int
	CONSTRAINT FK_tbCategoria_Produto FOREIGN KEY (CategoriaID) REFERENCES dbo.tbCategoria (CategoriaId),
	CONSTRAINT FK_tbFornecedor_Produto FOREIGN KEY (FornecedorID) REFERENCES dbo.tbFornecedor (FornecedorId),
 )
go
INSERT INTO tbProduto(NomeProduto, CategoriaId, StatusProduto, PrecoProduto) Values ('Camisa Branca', 1, 1, 15)
GO
INSERT INTO tbProduto(NomeProduto, CategoriaId, StatusProduto, PrecoProduto) Values ('Caneca Branca', 2, 1, 10)
GO
INSERT INTO tbProduto(NomeProduto, CategoriaId, StatusProduto, PrecoProduto) Values ('Capa Samsung Galaxy S10', 3, 1, 20)
GO
INSERT INTO tbProduto(NomeProduto, CategoriaId, StatusProduto, PrecoProduto) Values ('Capa Motorola G5s', 3, 1, 15)
GO
INSERT INTO tbProduto(NomeProduto, CategoriaId, StatusProduto, PrecoProduto) Values ('Banner', 5,1, 150)
GO
INSERT INTO tbProduto(NomeProduto, CategoriaId, StatusProduto, PrecoProduto) Values ('Adesivo', 1,1, 20)
GO
INSERT INTO tbProduto(NomeProduto, CategoriaId, StatusProduto, PrecoProduto) Values ('Capa Iphone 11', 3,1, 20)
GO
INSERT INTO tbProduto(NomeProduto, CategoriaId, StatusProduto, PrecoProduto) Values ('Capa Iphone 8', 3,1, 20)
GO
INSERT INTO tbProduto(NomeProduto, CategoriaId, StatusProduto, PrecoProduto) Values ('Capa Iphone 7', 3,1, 20)
GO
INSERT INTO tbProduto(NomeProduto, CategoriaId, StatusProduto, PrecoProduto) Values ('Capa Iphone 6s', 3,1, 20)
GO
INSERT INTO tbProduto(NomeProduto, CategoriaId, StatusProduto, PrecoProduto) Values ('Capa Samsung Galaxy Note10', 3,1, 20)
GO
INSERT INTO tbProduto(NomeProduto, CategoriaId, StatusProduto, PrecoProduto) Values ('Chinelo', 6,1, 20)
GO
INSERT INTO tbProduto(NomeProduto, CategoriaId, StatusProduto, PrecoProduto) Values ('Camisa Preta', 1,1, 20)
GO
INSERT INTO tbProduto(NomeProduto, CategoriaId, StatusProduto, PrecoProduto) Values ('Capa Motorola One Action', 3,1, 20)
GO
INSERT INTO tbProduto(NomeProduto, CategoriaId, StatusProduto, PrecoProduto) Values ('Capa Motorola One Vision', 3,1, 20)
GO
INSERT INTO tbProduto(NomeProduto, CategoriaId, StatusProduto, PrecoProduto) Values ('Capa Motorola One ', 3,1, 20)
GO
INSERT INTO tbProduto(NomeProduto, CategoriaId, StatusProduto, PrecoProduto) Values ('Moletom', 7,1, 20)
GO
INSERT INTO tbProduto(NomeProduto, CategoriaId, StatusProduto, PrecoProduto) Values ('Blusa', 7,1, 20)
GO
SELECT * FROM tbProduto
GO
CREATE TABLE DBO.tbProdutoFinal(/**/
    CodigoProdutoFinal		INT             IDENTITY    PRIMARY KEY not null,
	CategoriaId				int,
	CodigoProduto			int,
	IdArte					int,
    NomeProdutoFinal		VARCHAR(80),
	DescricaoProd			Varchar(80),
    --QuantMinimaEstoque	int,
    StatusProdutoFinal		BIT,
	PrecoProdutoFinal		Decimal(10,2),
    --QuantMaximaEstoque	int

	--CONSTRAINT FK_tbFornecedor_Produto FOREIGN KEY (FornecedorID) REFERENCES dbo.tbFornecedor (FornecedorId),
	CONSTRAINT FK_tbCategoria_ProdutoFinal FOREIGN KEY (CategoriaID) REFERENCES dbo.tbCategoria (CategoriaId),
	CONSTRAINT FK_tbArte_tbProdutoFinal	  FOREIGN KEY (IdArte) REFERENCES dbo.tbArte(IdArte),
	CONSTRAINT FK_tbProduto_tbProdutoFinal	  FOREIGN KEY (CodigoProduto) REFERENCES dbo.tbProduto(CodigoProduto)
)
go
SELECT * FROM tbProdutoFinal
GO
INSERT tbProdutoFinal(CategoriaId, CodigoProduto, idARTE, NomeProdutoFinal, DescricaoProd, PrecoProdutoFinal) VALUES (1, 1, 1, Null, Null, null)
GO
INSERT tbProdutoFinal(CategoriaId, CodigoProduto, IdArte, NomeProdutoFinal, DescricaoProd, PrecoProdutoFinal) VALUES (3, 3 , 1, 'Capa de Celular S10 Elefante_Rosa', 'Centralizado', 30)
GO
INSERT tbProdutoFinal(CategoriaId, CodigoProduto, IdArte, NomeProdutoFinal, DescricaoProd, PrecoProdutoFinal) VALUES (1, 1, 2, 'Camisa Branca Jao', 'Lateral', 30)
GO
INSERT tbProdutoFinal(CategoriaId, CodigoProduto, IdArte, NomeProdutoFinal, DescricaoProd, PrecoProdutoFinal) VALUES (2, 2, 1, 'Caneca Elefante_Rosa', 'Azul Marinho', 20)
GO
INSERT tbProdutoFinal(CategoriaId, CodigoProduto, IdArte, NomeProdutoFinal, DescricaoProd, PrecoProdutoFinal) VALUES (2, 2, 2, 'Caneca Jao', 'Times New Roman', 35)
GO
INSERT tbProdutoFinal(CategoriaId, CodigoProduto, IdArte, NomeProdutoFinal, DescricaoProd, PrecoProdutoFinal) VALUES (3, 3, 2, 'Capa de Celular S10 Jao', 'Centralizado', 35)
GO
INSERT tbProdutoFinal(CategoriaId, CodigoProduto, IdArte, NomeProdutoFinal, DescricaoProd, PrecoProdutoFinal) VALUES (4, 4, 1, 'Capa de Celular Motorola G5s Elefante Rosa', 'Centralizado', 25)
GO
INSERT tbProdutoFinal(CategoriaId, CodigoProduto, IdArte, NomeProdutoFinal, DescricaoProd, PrecoProdutoFinal) VALUES (4, 4, 2, 'Capa de Celular Motorola G5s Jao', 'Centralizado', 30)
GO
INSERT tbProdutoFinal(CategoriaId, CodigoProduto,IdArte, NomeProdutoFinal, DescricaoProd, PrecoProdutoFinal) VALUES (5, 5, 1, 'Banner Elefante_Rosa', 'Centralizado', 110)
GO
INSERT tbProdutoFinal(CategoriaId, CodigoProduto, IdArte, NomeProdutoFinal, DescricaoProd, PrecoProdutoFinal) VALUES (6, 6, 1, 'Adesivo Elefante_Rosa', 'Centralizado', 30)
GO
INSERT tbProdutoFinal(CategoriaId, CodigoProduto, IdArte, NomeProdutoFinal, DescricaoProd, PrecoProdutoFinal) VALUES (6, 6, 2, 'Adesivo Jao', 'Centralizado', 35)
GO
/*UPDATE tbProduto
SET 

NomeProduto = (SELECT tbCategoria.Descricao + ' ESTAMPA ' + tbarte.NomeArte FROM tbCategoria
INNER JOIN tbProduto ON tbCategoria.CategoriaID = tbProduto.CategoriaId
INNER JOIN tbARTE ON tbARTE.idARTE = tbProduto.idARTE 
WHERE tbCategoria.CategoriaId = 1 AND tbARTE.idARTE = 1),

PrecoProduto = (SELECT tbCategoria.PrecoCategoria + tbArte.precoARTE FROM tbCategoria
INNER JOIN tbProduto ON tbCategoria.CategoriaID = tbProduto.CategoriaId
INNER JOIN tbARTE ON tbARTE.idARTE = tbProduto.idARTE 
WHERE tbCategoria.CategoriaId = 1 AND tbARTE.idARTE = 1)

WHERE CodigoProduto = 1
GO*/
insert into tbUsuario(NomeUsuario,StatusUsuario) values ('ANTONIO',1)
go
insert into tbUsuario(NomeUsuario,StatusUsuario) values ('ANA',1)
go


CREATE TABLE DBO.tbVendedor(
    CodigoVendedor		INT          PRIMARY KEY   IDENTITY    not null,
    NomeVendedor		VARCHAR(50)						        not null,
    StatusVendedor		BIT,	
	CodigoFunc			int,

	CONSTRAINT FK_tbFunc_tbVendedor FOREIGN KEY (CodigoFunc) REFERENCES dbo.tbFuncionario (CodigoFunc)
 )
go
INSERT INTO tbVendedor(NomeVendedor, StatusVendedor, CodigoFunc) Values ('João', 1, 1)
GO
INSERT INTO tbVendedor(NomeVendedor, StatusVendedor, CodigoFunc) Values ('Breno', 1, 2)
GO
INSERT INTO tbVendedor(NomeVendedor, StatusVendedor, CodigoFunc) Values ('Marianny', 0, 3)
GO
SELECT * FROM tbVendedor
GO
CREATE TABLE dbo.tbFormasDePagamento(/**/
	CodigoPagamento		INT			PRIMARY KEY		IDENTITY	not null,
	DescricaoPagamento	Varchar(50) not null,
	StatusPagamento		Bit

)
GO
INSERT INTO tbFormasDePagamento(DescricaoPagamento, StatusPagamento) VALUES ('Dinheiro', 1)
Go
INSERT INTO tbFormasDePagamento(DescricaoPagamento, StatusPagamento) VALUES ('Cartao Credito', 1)
Go
INSERT INTO tbFormasDePagamento(DescricaoPagamento, StatusPagamento) VALUES ('Cartao Debito', 1)
GO
INSERT INTO tbFormasDePagamento(DescricaoPagamento, StatusPagamento) VALUES ('Dinheiro e Cartao de Debito', 1)
Go
insert into tbVendedor(NomeVendedor,StatusVendedor) values ('ANTONIO',1)
go
insert into tbVendedor(NomeVendedor,StatusVendedor) values ('ANA',1)
go
insert into tbVendedor(NomeVendedor,StatusVendedor) values ('LUCIA',1)
go
insert into tbVendedor(NomeVendedor,StatusVendedor) values ('ZILDA',1)
GO
SELECT * FROM tbNivelAcesso
GO
--drop TABLE DBO.tbParametrosPagamento
--go

CREATE TABLE DBO.tbParametrosPagamento(/**/
    CodigoParametroPagamento                   INT          IDENTITY        not null,
    NumeroMinimoParcelasSemJurosCarnet         INT,
    NumeroMaximoParcelasCarnet                 INT,
    TaxaJurosParcelasCarnet                    DECIMAL(5,3),
    ValorParcelaMinimaCarnet                   DECIMAL(7,3),
    NumeroParcelasCartaoCreditoSemJuros        INT,
    NumeroMaximoParcelasCartaoCredito          INT,
    TaxaJurosParcelasCartaoCredito             DECIMAL(5,3),
    ValorParcelaMinimaPagamentoCartaoCredito   DECIMAL(7,2),
    DataAtualizacaoParametrosPagamento         DATETIME,
    StatusParametroPagamento                   BIT
 )
go

insert into tbParametrosPagamento VALUES (3, 10, 1.999, 149.99, 5, 12, 3.55, 199.99, GETDATE(), 1);
GO
CREATE TABLE dbo.tbPedido(/**/
	CodigoPedido	INT IDENTITY  PRIMARY KEY not null,
	Descricao		Varchar(80),
	Quantidade		Int,
	PrecoTotal		decimal(9,2),
	CodigoProdutoFinal	Int,

	CONSTRAINT FK_tbProdutoFinal_Pedido FOREIGN KEY (CodigoProdutoFinal) REFERENCES dbo.tbProdutoFinal (CodigoProdutoFinal),
)
GO
INSERT INTO dbo.tbPedido (Descricao, Quantidade, PrecoTotal, CodigoProdutoFinal) VALUES ('Presente', 1, (SELECT PrecoProdutoFinal FROM tbProdutoFinal WHERE CodigoProdutoFinal = 1), 1)
GO
INSERT INTO dbo.tbPedido (Descricao, Quantidade, PrecoTotal, CodigoProdutoFinal) VALUES ('Natal', 1, (SELECT PrecoProdutoFinal FROM tbProdutoFinal WHERE CodigoProdutoFinal = 3), 3)
GO
INSERT INTO dbo.tbPedido (Descricao, Quantidade, PrecoTotal, CodigoProdutoFinal) VALUES ('Dia das Mães', 1, (SELECT PrecoProdutoFinal FROM tbProdutoFinal WHERE CodigoProdutoFinal = 2), 2)
GO
INSERT INTO dbo.tbPedido (Descricao, Quantidade, PrecoTotal, CodigoProdutoFinal) VALUES ('Parabéns', 1, (SELECT PrecoProdutoFinal FROM tbProdutoFinal WHERE CodigoProdutoFinal = 4), 4)
GO
SELECT pe.CodigoPedido, pe.Descricao, pe.Quantidade, pe.PrecoTotal, p.CodigoProduto, p.NomeProdutoFinal, p.PrecoProdutoFinal, prod.CodigoProduto, prod.NomeProduto, prod.PrecoProduto, arte.NomeArte, arte.PrecoArte, arte.arquivoArte FROM tbPedido pe
JOIN tbProdutoFinal p
on pe.CodigoProdutoFinal = p.CodigoProdutoFinal
JOIN tbProduto prod
on p.CodigoProduto = prod.CodigoProduto
JOIN tbArte arte
on p.IdArte = arte.IdArte
GO
CREATE TABLE dbo.tbVenda(/**/
	CodigoVenda		INT		IDENTITY	PRIMARY KEY not null,
	CodigoPedido	INT,
	CodigoCliente	INT,
	CodigoFunc		INT, 
    PrecoTotal		Decimal(9,2),
	Troco			Decimal(9,2),
	DataVenda		Datetime,

	CONSTRAINT FK_tbCliente_Venda FOREIGN KEY (CodigoCliente) REFERENCES dbo.tbCliente (CodigoCliente),
	CONSTRAINT FK_tbPedido_Venda FOREIGN KEY (CodigoPedido) REFERENCES dbo.tbPedido (CodigoPedido),
	CONSTRAINT FK_tbFuncionario_Venda FOREIGN KEY (CodigoFunc) REFERENCES dbo.tbFuncionario (CodigoFunc)
)
Go
SELECT * FROM tbVenda 
GO
INSERT INTO tbVenda (CodigoCliente, CodigoPedido, CodigoFunc, PrecoTotal, DataVenda)	VALUES	(3, 1, 1, 50.50, '22/08/2019')
GO
INSERT INTO tbVenda (CodigoCliente, CodigoPedido, CodigoFunc, PrecoTotal, DataVenda)	VALUES	(3, 1, 1, 150.50, '22/08/2019')
GO
INSERT INTO tbVenda (CodigoCliente, CodigoPedido, CodigoFunc, PrecoTotal, DataVenda)	VALUES	(2, 2, 3, 100.00,'21/08/2019')
GO
INSERT INTO tbVenda (CodigoCliente, CodigoPedido, CodigoFunc, PrecoTotal, DataVenda)	VALUES	(1, 3, 2, 180.50,'19/08/2019')
GO
SELECT SUM(PrecoTotal) FROM tbVenda WHERE DataVenda BETWEEN '19/08/2019' AND '22/08/2019'
GO
CREATE TABLE dbo.tbItem_Venda(/**/
	CodigoItemVenda			INT		IDENTITY	PRIMARY KEY,
	CodigoVenda				INT,
	CodigoProduto			INT,
	CodigoArte				INT,
	Quantidade				INT,
	PrecoTotal				Decimal(9,2),

	CONSTRAINT FK_tbProduto_item_Venda FOREIGN KEY (CodigoProduto) REFERENCES dbo.tbProduto (CodigoProduto),
	CONSTRAINT FK_tbArte_item_Venda FOREIGN KEY (CodigoArte) REFERENCES dbo.tbArte (IdArte),
	CONSTRAINT FK_tbVenda_item_Venda FOREIGN KEY (CodigoVenda) REFERENCES dbo.tbVenda (CodigoVenda)
)
GO
INSERT INTO tbItem_Venda(CodigoVenda, CodigoProduto, PrecoTotal) VALUES	(1, 2, (SELECT CodigoProduto FROM tbProduto WHERE CodigoProduto = 2))
GO
INSERT INTO tbItem_Venda(CodigoVenda, CodigoProduto, PrecoTotal) VALUES	(1, 4, (SELECT CodigoProduto FROM tbProduto WHERE CodigoProduto = 4))
GO
INSERT INTO tbItem_Venda(CodigoVenda, CodigoProduto, PrecoTotal) VALUES	(1, 3, (SELECT CodigoProduto FROM tbProduto WHERE CodigoProduto = 3))
GO
INSERT INTO tbItem_Venda(CodigoVenda, CodigoProduto, PrecoTotal) VALUES	(1, 1, (SELECT CodigoProduto FROM tbProduto WHERE CodigoProduto = 1))
GO
SELECT * FROM tbItem_Venda
GO 
SELECT * FROM tbProdutoFinal
SELECT SUM(PrecoTotal) FROM tbItem_Venda
GO
SELECT p.CodigoProduto ,p.NomeProduto, p.PrecoProduto, a.IdArte, a.NomeArte, a.PrecoArte FROM tbItem_Venda iv
Join tbProduto p
on iv.CodigoProduto = p.CodigoProduto
JOIN tbArte a
on iv.CodigoArte = a.IdArte WHERE iv.CodigoVenda = 4
GO
SELECT v.CodigoVenda, f.NomeFuncionario, f.CodigoFunc, c.NomeCliente, c.CodigoCliente, ca.DescricaoCategoria, arte.NomeArte, arte.PrecoArte, ped.Descricao, ped.PrecoTotal FROM tbVenda v
Join tbFuncionario f
on v.CodigoFunc = f.CodigoFunc
Join tbCliente c
on v.CodigoCliente = c.CodigoCliente
Join tbItem_Venda iv
on v.CodigoVenda = iv.CodigoVenda
Join tbProduto p
on iv.CodigoProduto = p.CodigoProduto
Join tbCategoria ca
on p.CategoriaId = ca.CategoriaID
Join tbPedido ped
on ped.CodigoProdutoFinal = p.CodigoProduto
Join tbArte arte
on iv.CodigoArte = arte.IdArte
GO
CREATE TABLE dbo.tbFormaDeVenda(/**/
	CodigoFormaVenda	INT		IDENTITY	PRIMARY	KEY	not null,
	CodigoPagamento		INT,
	CodigoVenda			INT,

	CONSTRAINT FK_tbFormaDePagamento_FormaDeVenda FOREIGN KEY (CodigoPagamento) REFERENCES dbo.tbFormasDePagamento (CodigoPagamento),
	CONSTRAINT FK_tbVenda_FormaDeVenda FOREIGN KEY (CodigoVenda) REFERENCES dbo.tbVenda (CodigoVenda)
)
go
--INSERT INTO tbTipoTitulo (DescricaoTitulo, StatusTitulo) VALUES('Luz', 1)
--GO
--INSERT INTO tbTipoTitulo (DescricaoTitulo, StatusTitulo) VALUES('Água', 1)
--GO
--INSERT INTO tbTipoTitulo (DescricaoTitulo, StatusTitulo) VALUES('Gás', 1)
--GO
--INSERT INTO tbTipoTitulo (DescricaoTitulo, StatusTitulo) VALUES('Televendas', 1)
--GO
--INSERT INTO tbTipoTitulo (DescricaoTitulo, StatusTitulo) VALUES('Telefone', 1)
--GO
--INSERT INTO tbTipoTitulo (DescricaoTitulo, StatusTitulo) VALUES('Funcionários', 1)
--GO
--INSERT INTO tbTipoTitulo (DescricaoTitulo, StatusTitulo) VALUES('Saneamento', 1)
--GO
--INSERT INTO tbTipoTitulo (DescricaoTitulo, StatusTitulo) VALUES('Vivo', 1)
--GO
--INSERT INTO tbPeriodo(DescricaoPeriodo, ValorPeriodo, SinalPeriodo, StatusPeriodo)
--VALUES ('Dois Anos', 2, 'A', 1)
--GO
--INSERT INTO tbPeriodo(DescricaoPeriodo, ValorPeriodo, SinalPeriodo, StatusPeriodo)
--VALUES ('Cinco Anos', 5, 'A', 1)
--GO
--INSERT INTO tbPeriodo(DescricaoPeriodo, ValorPeriodo, SinalPeriodo, StatusPeriodo)
--VALUES ('Três Semanas', 3, 'S', 1)
--GO
--INSERT INTO tbPeriodo(DescricaoPeriodo, ValorPeriodo, SinalPeriodo, StatusPeriodo)
--VALUES ('Dois Mêses', 2, 'M', 1)
--GO
--INSERT INTO tbPeriodo(DescricaoPeriodo, ValorPeriodo, SinalPeriodo, StatusPeriodo)
--VALUES ('Cinco Anos', 5, 'A', 1)
--GO
--INSERT INTO tbPeriodo(DescricaoPeriodo, ValorPeriodo, SinalPeriodo, StatusPeriodo)
--VALUES ('Doze Anos', 12, 'A', 1)
--GO
--INSERT INTO tbPeriodo(DescricaoPeriodo, ValorPeriodo, SinalPeriodo, StatusPeriodo)
--VALUES ('30 Dias', 30, 'D', 0)
--GO
--INSERT INTO tbLancamento(CodigoTitulo, DataVencimento, ValorTitulo, StatusPagTitulo, DataPagamento, ValorPagamento, CodigoUsuario)
--VALUES (1, '12/10/2018', 1200.00, 1, '12/10/2018', 1200.00, 1)
--GO
--INSERT INTO tbLancamento(CodigoTitulo, DataVencimento, ValorTitulo, StatusPagTitulo, DataPagamento, ValorPagamento, CodigoUsuario)
--VALUES (3, '22/11/2018', 1550.00, 1, '01/12/2018', 1550.00, 1)
--GO
--INSERT INTO tbLancamento(CodigoTitulo, DataVencimento, ValorTitulo, StatusPagTitulo, DataPagamento, ValorPagamento, CodigoUsuario)
--VALUES (3, '22/11/2018', 550.00, 1, '01/01/2019', 750.00, 1)
--GO
--INSERT INTO tbLancamento(CodigoTitulo, DataVencimento, ValorTitulo, StatusPagTitulo, DataPagamento, ValorPagamento, CodigoUsuario)
--VALUES (3, '05/08/2018', 350.00, 1, '13/09/2018', 420.00, 1)
--GO
--INSERT INTO tbLancamento(CodigoTitulo, DataVencimento, ValorTitulo, StatusPagTitulo, DataPagamento, ValorPagamento, CodigoUsuario)
--VALUES (3, '07/12/2018', 420.00, 1, '22/12/2018', 420.00, 1)
--GO
--INSERT INTO tbLancamento(CodigoTitulo, DataVencimento, ValorTitulo, StatusPagTitulo, DataPagamento, ValorPagamento, CodigoUsuario)
--VALUES (1, '19/01/2019', 1000.00, 1, '12/02/2019', 1200.00, 1)
--GO
--INSERT INTO tbLancamento(CodigoTitulo, DataVencimento, ValorTitulo, StatusPagTitulo, DataPagamento, ValorPagamento, CodigoUsuario)
--VALUES (2, '15/12/2018', 1350.00, 0, '22/12/2018', 1350.00, 1)
--GO
--INSERT INTO tbLancamento(CodigoTitulo, DataVencimento, ValorTitulo, StatusPagTitulo, DataPagamento, ValorPagamento, CodigoUsuario)
--VALUES (2, '21/12/2018', 1350.00, 0, '19/12/2018', 1350.00, 1)
--GO
--SELECT sum(ValorTitulo) from tblancamento WHERE StatusPagTitulo = 1 AND (DataVencimento BETWEEN '05/08/2018' and '19/12/2018')
--select * from tbParametrosPagamento 
--go