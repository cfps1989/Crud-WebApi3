using Projeto.Entities;
using ProjetoDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.BLL
{
    public class EstoqueBusiness
    {
        private EstoqueRepository repository;

        public EstoqueBusiness()
        {
            repository = new EstoqueRepository();
        }

        public void Cadastrar(Estoque estoque)
        {
            repository.Insert(estoque);
        }

        public void Atualizar(Estoque estoque)
        {
            repository.Update(estoque);
        }

        public void Excluir(int id)
        {
            repository.Delete(id);
        }

        public List<Estoque> ConsultarTodos()
        {
            return repository.SelectAll();
        }

        public Estoque ConsultarPorId(int id)
        {
            return repository.SelectById(id);
        }
    }
}
