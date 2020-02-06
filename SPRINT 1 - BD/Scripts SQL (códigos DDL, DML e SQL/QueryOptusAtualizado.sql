create database Optus_Tarde;
go
use Optus_Tarde;

create table Estilos (
	Id int primary key identity(1,1),
	Nome varchar(50)
);
insert Estilos (Nome) values ('Indie');
insert Estilos (Nome) values ('Rock');
insert Estilos (Nome) values ('Folk');
insert Estilos (Nome) values ('Rock Progressivo');


select * from Estilos;

create table Artistas (
	Id int primary key identity (1,1),
	Nome varchar(50),
	EstiloId INT foreign key references Estilos(Id)
);
insert Artistas (Nome, EstiloId) values ('Legião Urbana', 1),('Pink Floyd', 4), ('UFO', 2);
insert Artistas (Nome, EstiloId) values ('Metallica', 2);
--insert Artistas (Nome) values ('UFO');


select * from Artistas;

create table Albuns (
	Id int primary key identity (1,1),
	Nome varchar(50),
	QtdMinutos INT,
	Visualizacoes INT,
	Localizacao varchar(50),
	DataLancamento date,
	EstiloId int foreign key references Estilos(Id),
	ArtistaId int foreign key references Artistas(Id)
);

insert Albuns values ('As Quatro Estações', 50, 45, 'RJ','27-09-2000',2,1),('The Dark Side of the Moon', 30,48, 'UK','28-07-1978',4,2),('Phenomenon', 25,67,'USA','06-05-1980',2,3);
insert Albuns values ('Dois', 25, 54, 'RJ','27-03-1992',2,1);
insert Albuns values ('V', 22, 58, 'RJ','27-03-1992',2,1);
--insert Albuns (Nome, ArtistaId) values ('Phenomenon', 3);

select * from Albuns;

--delete Albuns where Id = 1;

--Excluir todos os registros de uma tabela (apenas funciona se a entidade não for referenciada em outra tabela)
truncate table Albuns;

--create table AlbumEstilos(
--	Id int primary key identity(1,1),
--	AlbumId int foreign key references Albuns(Id),
--	EstiloId int foreign key references Estilos(Id)
--);

--insert AlbumEstilos (AlbumId, EstiloId) values (1,1);
--insert AlbumEstilos (AlbumId, EstiloId) values (2,4);
--insert AlbumEstilos (AlbumId, EstiloId) values (3,1);
--insert AlbumEstilos (AlbumId, EstiloId) values (3,1);

--select * from AlbumEstilos;

--delete AlbumEstilos where AlbumId = 2;

create table Musicas (
	Id int primary key identity(1,1),
	Nome varchar(50),
	AlbumId int foreign key references Albuns(Id)
);

create table TipoUsuario(
	Id int primary key identity(1,1),
	Descricao varchar(50)
);
insert TipoUsuario values ('Comum');
insert TipoUsuario values ('Administrador');

create table Usuarios(
	Id int primary key identity(1,1),
	Nome varchar(50),
	TipoUsuarioId int foreign key references TipoUsuario(Id)
);
insert Usuarios (Nome, TipoUsuarioId) values ('Saulo', 2);
insert Usuarios (Nome, TipoUsuarioId) values ('Carol', 1);

select Nome from Albuns where ArtistaId = 1;
