create database SpMedGroupDB_Tarde;

go
--Adquirir idade.
--select floor (datediff (year, '27-09-2000',getdate()));
use SpMedGroupDB_Tarde;

create table Clinica(
	Id int primary key identity not null,
	Endereco varchar(255),
	NomeFantasia varchar(255),
	RazaoSocial varchar(255),
	CNPJ varchar(255),
	HoraFuncionamentoInicio time,
	HoraFuncionamentoFim time,
);

create table TipoUsuario (
	Id int primary key identity not null,
	Titulo varchar(255) not null unique,
);

create table Usuario (
	Id int primary key identity not null,
	Nome varchar(255)not null,
	Email varchar(255)not null unique,
	Senha varchar(255)not null,
	TipoUsuarioId int foreign key references TipoUsuario(Id) not null
);

create table ProntuarioPaciente(
	Id int primary key identity not null,
	RG varchar(255) unique,
	CPF varchar(255) unique,
	Endereco varchar(255),
	DataNascimento varchar(255),
	Telefone varchar(255),
	UsuarioId int foreign key references Usuario(Id) not null
);

create table AreaSaudeEspecialidade (
	Id int primary key identity,
	Titulo varchar(255) not null unique	
);

create table Medico (
	Id int primary key identity,
	CRM varchar(255) unique,
	UsuarioId int foreign key references Usuario(Id)not null,
	AreaSaudeEspecialidadeId int foreign key references AreaSaudeEspecialidade(Id) not null
);
alter table Medico
add ClinicaId int foreign key references Clinica(Id);

create table StatusConsulta (
	Id int primary key identity,
	Titulo varchar(255) not null unique
);

create table Consulta (
	Id int primary key identity,
	DataConsulta datetime,
	Descricao varchar(255),
	MedicoId int foreign key references Medico(Id)not null,
	ProntuarioPacienteId int foreign key references ProntuarioPaciente(Id)not null,
	ClinicaId int foreign key references Clinica(Id)not null
);
alter table Consulta
add StatusConsultaId int foreign key references StatusConsulta(Id) not null;

--Procedure que retorna a idade APENAS dos pacientes
create procedure IdadePaciente
@PacienteId int
as
select u.Nome [NomePaciente], datediff (year, pp.DataNascimento, getdate()) [IdadePaciente] from ProntuarioPaciente as pp
join Usuario as u on pp.UsuarioId = u.Id where u.Id = @PacienteId;

execute IdadePaciente 3;