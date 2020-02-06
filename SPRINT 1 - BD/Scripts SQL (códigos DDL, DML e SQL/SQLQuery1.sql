use pclinicsTarde;

create trigger TRG_FOR_INSERT_ATENDIMENTO
on Atendimento
for insert
as
select * from inserted;