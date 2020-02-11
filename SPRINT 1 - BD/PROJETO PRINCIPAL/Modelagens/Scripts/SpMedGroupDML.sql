use SpMedGroupDB_Tarde;
go
insert into TipoUsuario values ('Administrador'),('Medico'),('Paciente');

insert into StatusConsulta values ('Realizada'),('Agendada'),('Cancelada');

insert into Usuario (Nome, Email, Senha, TipoUsuarioId) values 
('Roberto Possarle', 'possarle@email.com','possarle123', 2),
('Helena Strada', 'strada@email.com', 'strada123', 2),
('Alexandre', 'alexandre@email.com', 'alexandre123', 1);

insert into AreaSaudeEspecialidade values ('Pediatria'),('Oftalmo'),('Proctologia');

insert into Clinica (Endereco,NomeFantasia,RazaoSocial,CNPJ,HoraFuncionamentoInicio,HoraFuncionamentoFim) values
('Avenida Barão de Limeira, 539','SpMedGroup','SpMedicalGroup','7274827382','08:00:00','18:00:00');

insert into Medico (CRM,UsuarioId,AreaSaudeEspecialidadeId,ClinicaId) values
('666666666',1,1,1),('777777777',2,2,1);

insert into ProntuarioPaciente (RG,CPF,Endereco,DataNascimento,Telefone,UsuarioId) values
('67765212', '27788738912', 'Rua Pixinguinha', '27-04-1970', '40028922', 3);


insert into Consulta (DataConsulta, Descricao,MedicoId,ProntuarioPacienteId,ClinicaId,StatusConsultaId) values
('06/01/2020  10:00:00','Pé na cova',1,1,1,3);