using ApiUsuarios.Application.Models;
using ApiUsuarios.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Application.Mappings
{
    public class ModelToEntityMap
    {
        public class ModeltoEntityMap : Profile
        {
            public ModeltoEntityMap()
            {
                //CriarContaPostModel => Usuario
                CreateMap<CriarContaPostModel, Usuario>()
                    .AfterMap((model, entity) =>
                    {
                        entity.IdUsuario = Guid.NewGuid();
                        entity.DataHoraCriacao = DateTime.Now;
                    });
            }
        }


    }
}
