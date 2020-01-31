--Selecionar todos os autores
]select * from  Autores;

--Selecionar todos os generos
select * from Generos;

--Selecionar Todos os livros

select * from Livros;

--Selecionar os livros e seus respectivos autores

select Au.NomeAutor, Li.Titulo from Livros as Li join Autores as Au on li.IdAutor = au.IdAutor;

--Selecionar os livros e respectivos gêneros
select li.Titulo, Ge.Nome from Livros as Li join Generos as Ge on li.IdGenero = ge.IdGenero;

-- Selecionar os livros e respectivos autores e generos.
select Li.Titulo [TITULO], Au.NomeAutor [NomeAutor], Ge.Nome [GENERO] from Livros as Li 
join Autores as au on li.IdAutor = Au.IdAutor 
join Generos as Ge on li.IdGenero = ge.IdGenero;