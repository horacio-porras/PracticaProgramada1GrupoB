using AutoMapper;
using PracticaProgramada1GrupoB_BLL.Dtos;
using PracticaProgramada1GrupoB_DAL.Repositorios.Cliente;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticaProgramada1GrupoB_BLL.Servicios.Cliente
{
    public class ClienteServicio : IClienteServicio
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IMapper _mapper;

        public ClienteServicio(IClienteRepositorio clienteRepositorio, IMapper mapper)
        {
            _clienteRepositorio = clienteRepositorio;
            _mapper = mapper;
        }

        public Task<CustomResponse<ClienteDto>> ActualizarClienteAsync(ClienteDto clienteDto)
        {
            throw new NotImplementedException();
        }

        public Task<CustomResponse<ClienteDto>> AgregarClienteAsync(ClienteDto clienteDto)
        {
            throw new NotImplementedException();
        }

        public Task<CustomResponse<ClienteDto>> EliminarClienteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CustomResponse<ClienteDto>> ObtenerClientePorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CustomResponse<List<ClienteDto>>> ObtenerClientesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
