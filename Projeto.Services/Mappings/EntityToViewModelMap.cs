using AutoMapper;
using Projeto.Entities;
using Projeto.Services.Models.Estoque;
using Projeto.Services.Models.Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Services.Mappings
{
    public class EntityToViewModelMap : Profile
    {
        public EntityToViewModelMap()
        {
            CreateMap<Estoque, EstoqueConsultaViewModel>();

            CreateMap<Produto, ProdutoConsultaViewModel>();
        }
    }
}