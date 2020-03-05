create table Estoque(
IdEstoque		int				identity(1,1),
Nome			nvarchar(100)   not null,

primary key(IdEstoque)
)

create table Produto(
IdProduto		int				identity(1,1),
Nome			nvarchar(100)	not null,
Preco			decimal(18,2)	not null,
Quantidade		int				not null,
IdEstoque		int				not null,

primary key(IdProduto),
foreign key(IdEstoque) references Estoque(IdEstoque)
)