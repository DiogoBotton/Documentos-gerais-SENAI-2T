--Selecionar albuns do mesmo artista
select Nome, DataLancamento from Albuns where ArtistaId = 1;

--Selecionar albuns Lançados na mesma dataasd
select Nome, DataLancamento from Albuns where DataLancamento like '%1992-03-27%';
--ou
select A.Nome, AR.Nome from Albuns as A join Artistas as AR on a.ArtistaId = ar.Id; 

--Selecionar Artistas de mesmo estilo musical
create procedure GetArtistaPorEstilo
@EstiloId int
as
select * from Artistas where EstiloId = @EstiloId;

execute GetArtistaPorEstilo 2;

--Selecionar album e artistas, data mais recente para o mais antigo.
select A.Nome, AR.Nome, A.DataLancamento from Albuns as A join Artistas as AR on a.ArtistaId = ar.Id order by DataLancamento desc;