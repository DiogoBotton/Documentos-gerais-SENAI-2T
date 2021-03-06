use Optus_Tarde;

select ar.Nome, a.Nome from Albuns as A join Artistas as AR on a.ArtistaId = ar.Id;

--Busca por compara��o de texto (LIKE)
select Nome from Albuns where Nome like '%quatro%';

--Ordena��o
--Menor para maior
select Nome from Albuns order by Nome;

alter table Albuns 
add qtdMinutos int;

select * from Albuns;

--Maior para menor (com n�meros) Ex: order by [nome-atributo] desc
--select qtdMinutos from Albuns order by DESC qtdMinutos;

--ASC (ordena��o por datas) |  Ex: order by [nome-atributo] asc ou desc
select DataLancamento from Albuns order by DataLancamento asc;

--COUNT (conta todos os registros de uma tabela) Ex: select count(Id) from Albuns;

select sum(id) from Albuns;

select count(id) from Albuns;