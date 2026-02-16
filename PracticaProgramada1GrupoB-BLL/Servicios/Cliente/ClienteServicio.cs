using AutoMapper;
using PracticaProgramada1GrupoB_BLL.Dtos;
using PracticaProgramada1GrupoB_DAL.Repositorios.Cliente;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<CustomResponse<List<ClienteDto>>> ObtenerClientesAsync()
        {
            var response = new CustomResponse<List<ClienteDto>>();
            response.Data = _mapper.Map<List<ClienteDto>>(_clienteRepositorio.ObtenerClientes());
            return response;
        }

        public async Task<CustomResponse<ClienteDto>> ObtenerClientePorIdAsync(int id)
        {
            var response = new CustomResponse<ClienteDto>();

            var carro = _clienteRepositorio.ObtenerClientePorId(id);

            if (carro is null)
            {
                response.esCorrecto = false;
                response.mensaje = "El cliente no existe, debe ingresarlo en el modulo de registro..."; 
                response.codigoStatus = 404; // Not Found
                return response;
            }


            response.Data = _mapper.Map<ClienteDto>(_clienteRepositorio.ObtenerClientePorId(id));
            return response;
        }

        public async Task<CustomResponse<ClienteDto>> AgregarClienteAsync(ClienteDto clienteDto)
        {
            var response = new CustomResponse<ClienteDto>();

            //Validaciones
            if (clienteDto is null)
            {
                response.esCorrecto = false;
                response.mensaje = "El cliente no puede ser nulo.";
                response.codigoStatus = 400; // Bad Request
                return response;
            }

            //Proceso
            var clienteGuardar = _mapper.Map<PracticaProgramada1GrupoB_DAL.Entidades.Cliente>(clienteDto);
             _clienteRepositorio.AgregarCliente(clienteGuardar);

            return response;
        }

        public async Task<CustomResponse<ClienteDto>> ActualizarClienteAsync(ClienteDto clienteDto)
        {
            var response = new CustomResponse<ClienteDto>();

            if (clienteDto is null) //Validaciones
            {
                response.esCorrecto = false;
                response.mensaje = "El cliente no puede ser nulo.";
                response.codigoStatus = 400; // Bad Request
                return await Task.FromResult(response);
            }
            //Proceso
            var clienteActualiza = _mapper.Map<PracticaProgramada1GrupoB_DAL.Entidades.Cliente>(clienteDto);
            _clienteRepositorio.ActualizarCliente(clienteActualiza);

                return response;

        }

        public async Task<CustomResponse<ClienteDto>> EliminarClienteAsync(int id)
        {
            var response = new CustomResponse<ClienteDto>();

            //Validaciones
            if (id is 0)
            {
                response.esCorrecto = false;
                response.mensaje = "El cliente no puede ser nulo.";
                response.codigoStatus = 400; // Bad Request
                return response;
            }


            //Proceso   
            _clienteRepositorio.EliminarCliente(id);
            return response;
        }
    }
}
