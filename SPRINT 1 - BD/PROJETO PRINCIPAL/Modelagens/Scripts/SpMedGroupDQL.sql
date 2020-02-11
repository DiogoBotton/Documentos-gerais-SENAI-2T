use SpMedGroupDB_Tarde;
go

--Relacionar Consultas com prontuarios, prontuarios com medicos, medicos com AreaSaudaEspecialidade
select c.DataConsulta, ase.Titulo, datediff (year, pp.DataNascimento, getdate()) [IdadePaciente] from ProntuarioPaciente as pp 
join Consulta as C on C.ProntuarioPacienteId = pp.Id
join Medico as M on c.MedicoId = m.Id
join AreaSaudeEspecialidade as ase on m.AreaSaudeEspecialidadeId = ase.Id;

--Relacionar Medico com Clinicas
select cli.RazaoSocial, u.Nome from Medico as m
join Clinica as cli on m.ClinicaId = cli.Id
join Usuario as u on u.Id = m.UsuarioId;