insert into Cores values('Roxo'),('Amarelo'),('Azul'),('Laranja'),('Verde');

insert into Tamanhos values ('P'),('M'),('G'),('GG');

insert into Marcas values ('Lacoste'),('Adidas'),('Nike');

insert into Camisas values (1,2,3),(3,2,1),(1,3,2),(2,3,1),(3,1,2);

update Camisas set MarcaId = 3 where Id = 2;
update Camisas set MarcaId = 3 where Id = 3;

delete from Camisas where id = (select MAX(Id) from Camisas);

