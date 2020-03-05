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
    public class EstoqueRepository
    {
        private SqlConnection conn;
        private string connectionString;
        
        public EstoqueRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["projeto"].ConnectionString;
        }

        public void Insert(Estoque estoque)
        {
            var query = $@" insert into Estoque(Nome)
                            values(@Nome)";
            using (conn = new SqlConnection(connectionString))
            {
                conn.Execute(query, estoque);
            }
        }

        public void Update(Estoque estoque)
        {
            var query = $@" update Estoque set Nome = @Nome
                            where IdEstoque = @IdEstoque";
            using (conn = new SqlConnection(connectionString))
            {
                conn.Execute(query, estoque);
            }
        }

        public void Delete(int id)
        {
            var query = $@" delete from Estoque
                            where IdEstoque = @IdEstoque";
            using (conn = new SqlConnection(connectionString))
            {
                conn.Execute(query, new { IdEstoque = id });
            }
        }

        public List<Estoque> SelectAll()
        {
            var query = $@" Select * from Estoque";
            using (conn = new SqlConnection(connectionString))
            {
                return conn.Query<Estoque>(query).ToList();
            }
        }

        public Estoque SelectById(int id)
        {
            var query = $@" select * from Estoque
                            where IdEstoque = @IdEstoque";
            using (conn = new SqlConnection(connectionString))
            {
                return conn.QuerySingleOrDefault<Estoque>(query, new { IdEstoque = id });
            }
        }
    }
}
