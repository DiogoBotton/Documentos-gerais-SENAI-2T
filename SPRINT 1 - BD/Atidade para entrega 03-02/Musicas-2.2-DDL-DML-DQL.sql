create database Optus_Tarde;
go
use Musicas_Tarde;

create table Estilos (
	Id int primary key identity(1,1),
	Nome varchar(50)
);
insert Estilos (Nome) values ('Indie');
insert Estilos (Nome) values ('Rock');
insert Estilos (Nome) values ('Folk');
insert Estilos (Nome) values ('Rock Progressivo');
insert Estilos values ('Metal');
insert Estilos values('MPB');


select * from Estilos;

create table Artistas (
	Id int primary key identity (1,1),
	Nome varchar(50),
	EstiloId INT foreign key references Estilos(Id)
);
insert Artistas (Nome, EstiloId) values ('Legião Urbana', 2),('Pink Floyd', 4), ('UFO', 2);
insert Artistas (Nome, EstiloId) values ('Metallica', 5);


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

--DML extras do exercício

update Artistas set EstiloId = 6 where Nome = 'Legião Urbana';

--DQL extras do exercício
select a.Nome, e.Nome from Artistas as a join Estilos as E on a.EstiloId = e.Id;