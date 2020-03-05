using AutoMapper;
using Projeto.BLL;
using Projeto.Entities;
using Projeto.Services.Models.Estoque;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Projeto.Services.Controllers
{
    [RoutePrefix ("api/Estoque")]
    public class EstoqueController : ApiController
    {
        private EstoqueBusiness business;

        public EstoqueController()
        {
            business = new EstoqueBusiness();
        }

        [HttpPost]
        public HttpResponseMessage Post(EstoqueCadastroViewModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var estoque = Mapper.Map<Estoque>(model);
                    business.Cadastrar(estoque);

                    return Request.CreateResponse(HttpStatusCode.OK, "Estoque cadastrado com sucesso.");
                }
                catch(Exception e)
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
        public HttpResponseMessage Put(EstoqueEdicaoViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    business.Atualizar(Mapper.Map<Estoque>(model));

                    return Request.CreateResponse(HttpStatusCode.OK, "Estoque atualizado com sucesso.");
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

                return Request.CreateResponse(HttpStatusCode.OK, "Estoque excluido com sucesso.");
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var lista = business.ConsultarTodos();
                var model = Mapper.Map<List<EstoqueConsultaViewModel>>(lista);

                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
            catch(Exception e)
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
                var model = Mapper.Map<Estoque>(estoque);

                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
