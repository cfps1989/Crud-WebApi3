using Projeto.Entities;
using ProjetoDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.BLL
{
    public class ProdutoBusiness
    {
        private ProdutoRepository repository;

        public ProdutoBusiness()
        {
            repository = new ProdutoRepository();
        }

        public void Cadastrar(Produto produto)
        {
            repository.Insert(produto);
        }

        public void Atualizar(Produto produto)
        {
            repository.Update(produto);
        }

        public void Excluir(int id)
        {
            repository.Delete(id);
        }

        public List<Produto> ConsultarTodos()
        {
            return repository.SelectAll();
        }

        public Produto ConsultarPorId(int id)
        {
            return repository.SelectById(id);
        }
    }
}
