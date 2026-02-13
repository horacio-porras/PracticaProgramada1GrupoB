using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticaProgramada1GrupoB_BLL
{
    public class MapeoClases : Profile
    {
        public MapeoClases()
        {
            CreateMap< PracticaProgramada1GrupoB_DAL.Entidades.Cliente, Dtos.ClienteDto>().ReverseMap();
        }
    }
}
