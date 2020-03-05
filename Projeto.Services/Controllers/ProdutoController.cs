using AutoMapper;
using Projeto.BLL;
using Projeto.Entities;
using Projeto.Services.Models.Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Projeto.Services.Controllers
{
    [RoutePrefix("api/Produto")]
    public class ProdutoController : ApiController
    {
        private ProdutoBusiness business;

        public ProdutoController()
        {
            business = new ProdutoBusiness();
        }

        [HttpPost]
        public HttpResponseMessage Post(ProdutoCadastroViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var produto = Mapper.Map<Produto>(model);
                    business.Cadastrar(produto);

                    return Request.CreateResponse(HttpStatusCode.OK, "Produto cadastrado com sucesso.");
                }
                catch (Exception e)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Ocorreram erros de validação");
            }
        }

        [HttpPut]
        public HttpResponseMessage Put(ProdutoEdicaoViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var produto = Mapper.Map<Produto>(model);
                    business.Atualizar(produto);

                    return Request.CreateResponse(HttpStatusCode.OK, "Produto atualizado com sucesso.");
                }
                catch (Exception e)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Ocorreram erros de validação.");
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                business.Excluir(id);

                return Request.CreateResponse(HttpStatusCode.OK, "Produto excluido com sucesso.");
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var listas = business.ConsultarTodos();
                
                var model = Mapper.Map<List<ProdutoConsultaViewModel>>(listas);

                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var estoque = business.ConsultarPorId(id);
                var model = Mapper.Map<ProdutoConsultaViewModel>(estoque);

                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}

