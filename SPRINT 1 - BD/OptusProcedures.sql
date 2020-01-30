use Optus_Tarde;

--Busca Albuns por Estilo (erro no select)
create procedure BuscaAlbumEstilo
@EstiloId int
as
select * from AlbumEstilos as AbmEtl, Albuns as Abm where AbmEtl.EstiloId = @EstiloId and Abm.Id = AbmEtl.AlbumId;
--Selecione todos de AlbunsTitulos onde AlbumId seja igual ao EstiloId(parametro) E AlbumId seja igual à AlbumId[...]
--[...] Da tabela AlbumTitulos.

drop procedure BuscaAlbumEstilo;

execute BuscaAlbumEstilo 4;

--Atualiza o Titulo de um album
create procedure UpdateAlbumTitulo
@Titulo varchar(50), @AlbumId int
as
update Albuns set Nome = @Titulo where Id = @AlbumId;

execute UpdateAlbumTitulo 'As Quatro Estações',1;

--Deleta um album
create procedure DeleteAlbumId
@AlbumId int
as
delete from Albuns where Id = @AlbumId;

execute DeleteAlbumId 3;

