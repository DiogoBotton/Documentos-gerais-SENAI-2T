create database Optus_Tarde;

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
	Nome varchar(50)
);
insert Artistas (Nome) values ('Legião Urbana');
insert Artistas (Nome) values ('Pink Floyd');
insert Artistas (Nome) values ('UFO');


select * from Artistas;

create table Albuns (
	Id int primary key identity (1,1),
	Nome varchar(50),
	ArtistaId int foreign key references Artistas(Id),
);

insert Albuns (Nome, ArtistaId) values ('As Quatro Estações', 1);
insert Albuns (Nome, ArtistaId) values ('The Dark Side of the Moon', 2);
insert Albuns (Nome, ArtistaId) values ('Phenomenon', 3);

select * from Albuns;

--delete Albuns where Id = 1;

create table AlbumEstilos(
	Id int primary key identity(1,1),
	AlbumId int foreign key references Albuns(Id),
	EstiloId int foreign key references Estilos(Id)
);

insert AlbumEstilos (AlbumId, EstiloId) values (1,1);
insert AlbumEstilos (AlbumId, EstiloId) values (2,4);
insert AlbumEstilos (AlbumId, EstiloId) values (3,1);
insert AlbumEstilos (AlbumId, EstiloId) values (3,1);

select * from AlbumEstilos;

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