create database Camisas_Manha;
go

use Camisas_Manha;
--CREATE
create table Cores (
	Id int primary key identity,
	NomeCor varchar(50)
);

create table Tamanhos (
	Id int primary key identity,
	Tamanho varchar(50)
);

create table Marcas (
	Id int primary key identity,
	Marca varchar(50)
);

create table Camisas (
	Id int primary key identity,
	CorId int foreign key references Cores(Id),
	TamanhoId int foreign key references Tamanhos(Id),
	MarcaId int foreign key references Marcas(Id)
);

--ALTER (realmente foi necessário pois esqueci... :)
alter table Camisas
Add MarcaId int foreign key references Marcas(Id);