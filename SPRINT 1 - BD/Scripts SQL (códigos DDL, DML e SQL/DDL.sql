create database AluguelCarroDB;

create table Marcas (
	Id int primary key identity(1,1) not null,
	Nome varchar(50)
);
create table Clientes (
	Id int primary key identity(1,1),
	Nome varchar(50)
);

create table Modelos (
	Id int primary key identity(1,1) not null,
	Nome varchar(50),
	MarcaId int foreign key references Marcas(Id)
);

create table Veiculos (
	Id int primary key identity(1,1) not null,
	Placa varchar(50),
	ModeloId int foreign key references Modelos(Id)
);


create table Alugueis (
	Id int primary key identity(1,1),
	ClienteId int foreign key references Clientes(Id),
	VeiculoId int foreign key references Veiculos(Id)
);

alter table Alugueis
add DataInicio date;

alter table Alugueis
add DataExpira date;


--Remover coluna de uma tabela
alter table Alugueis
drop column DataInicio;

--Fazer as FOREIGN KEY depois dos atributos nativos da tabela.