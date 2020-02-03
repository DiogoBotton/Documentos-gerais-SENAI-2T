select * from Camisas;

Select * from Marcas;

select * from Tamanhos;

select * from Cores;

select M.Marca from Camisas as C join Marcas as M on C.MarcaId = M.Id;

select M.Marca, Cor.NomeCor from Camisas as C join Marcas as M on C.MarcaId = M.Id join Cores as Cor on C.MarcaId = Cor.Id;

select M.Marca, T.Tamanho from Camisas as C join Marcas as M on C.MarcaId = M.Id join Tamanhos as T on C.TamanhoId = T.Id;