using Dapper;
using Projeto.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDAL
{
    public class ProdutoRepository
    {
        private SqlConnection conn;
        private string connectionString;

        public ProdutoRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["projeto"].ConnectionString;
        }

        public void Insert(Produto produto)
        {
            var query = $@" insert into Produto(Nome, Preco, Quantidade, IdEstoque)
                            values(@Nome, @Preco, @Quantidade, @IdEstoque)";
            using (conn = new SqlConnection(connectionString))
            {
                conn.Execute(query, produto);
            }
        }

        public void Update(Produto produto)
        {
            var query = $@" update Produto set Nome = @Nome, Preco = @Preco, Quantidade = @Quantidade, IdEstoque = @IdEstoque
                            where IdProduto = @IdProduto";
            using (conn = new SqlConnection(connectionString))
            {
                conn.Execute(query, produto);
            }
        }

        public void Delete(int id)
        {
            var query = $@" delete from Produto
                            where IdProduto = @IdProduto";
            using (conn = new SqlConnection(connectionString))
            {
                conn.Execute(query, new { IdProduto = id });
            }
        }

        public List<Produto> SelectAll()
        {
            var query = $@" select * from Produto p
                            inner join Estoque e on p.IdEstoque = e.IdEstoque";
            using (conn = new SqlConnection(connectionString))
            {
                return conn.Query(query,
                    (Produto p, Estoque e) =>
                    {
                        p.Estoque = e;
                        return p;
                    },
                    splitOn: "IdEstoque")
                    .ToList();
            }
        }

        public Produto SelectById(int id)
        {
            var query = $@" select * from Produto p
                            inner join Estoque e on p.IdEstoque = e.IdEstoque
                            where IdProduto = @IdProduto";
            
            using (conn = new SqlConnection(connectionString))
            {
                return conn.Query(query,
                    (Produto p, Estoque e) =>
                    {
                        p.Estoque = e;
                        return p;
                    },
                    new { IdProduto = id },
                    splitOn: "IdEstoque")
                    .SingleOrDefault();
            }
        }
    }
}
    

