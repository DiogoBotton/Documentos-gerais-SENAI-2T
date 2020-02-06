use Optus_Tarde;
--After e For visualmente fazem a mesma coisa.

--AFTER especifica que o acionador DML � acionado apenas quando todas 
--as opera��es especificadas na instru��o SQL de acionamento foram executadas com �xito.

--After (Depois) CRIANDO UM TRIGGER
create trigger TRG_Optus_INSERT on Usuarios
after insert
as
select * from inserted;

--FOR (Executa junto com o m�todo DML)
create trigger TRG_Optus_UPDATE on Usuarios
for update
as
select u.Nome, tu.Descricao from Usuarios as U join TipoUsuario as TU on u.TipoUsuarioId = tu.Id
insert into HistoricoUsuarios values (getdate());

update Usuarios set TipoUsuarioId = 2 where Id = 3;




--DELETANDO UM TRIGGER
drop trigger TRG_Optus_INSERT;
drop trigger TRG_Optus_UPDATE;

--Tabelas Tempor�rias



--TESTES
insert Usuarios values ('Danilera',1);

select * from Usuarios;


insert into Usuarios values ('Pandolfinho',1);

truncate table Usuarios;

create table HistoricoUsuarios (
	Id int primary key identity,
	DataModificacao Date
);

select * from HistoricoUsuarios;



