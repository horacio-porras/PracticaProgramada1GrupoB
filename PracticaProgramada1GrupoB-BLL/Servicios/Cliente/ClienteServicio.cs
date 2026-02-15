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
            try
            {
                var entidades = _clienteRepositorio.ObtenerClientes();
                var dtos = _mapper.Map<List<ClienteDto>>(entidades);
                return await Task.FromResult(new CustomResponse<List<ClienteDto>>
                {
                    esCorrecto = true,
                    mensaje = "Lista de clientes obtenida correctamente.",
                    Data = dtos,
                    codigoStatus = 200
                });
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new CustomResponse<List<ClienteDto>>
                {
                    esCorrecto = false,
                    mensaje = $"Error al obtener clientes: {ex.Message}",
                    Data = null,
                    codigoStatus = 500
                });
            }
        }

        public async Task<CustomResponse<ClienteDto>> ObtenerClientePorIdAsync(int id)
        {
            try
            {
                var entidad = _clienteRepositorio.ObtenerClientePorId(id);
                if (entidad == null)
                {
                    return await Task.FromResult(new CustomResponse<ClienteDto>
                    {
                        esCorrecto = false,
                        mensaje = "Cliente no encontrado.",
                        Data = null,
                        codigoStatus = 404
                    });
                }

                var dto = _mapper.Map<ClienteDto>(entidad);
                return await Task.FromResult(new CustomResponse<ClienteDto>
                {
                    esCorrecto = true,
                    mensaje = "Cliente obtenido correctamente.",
                    Data = dto,
                    codigoStatus = 200
                });
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new CustomResponse<ClienteDto>
                {
                    esCorrecto = false,
                    mensaje = $"Error al obtener cliente: {ex.Message}",
                    Data = null,
                    codigoStatus = 500
                });
            }
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
            try
            {
                var existente = _clienteRepositorio.ObtenerClientePorId(id);
                if (existente == null)
                {
                    return await Task.FromResult(new CustomResponse<ClienteDto>
                    {
                        esCorrecto = false,
                        mensaje = "Cliente no encontrado.",
                        Data = null,
                        codigoStatus = 404
                    });
                }

                var dtoAEliminar = _mapper.Map<ClienteDto>(existente);
                _clienteRepositorio.EliminarCliente(id);

                return await Task.FromResult(new CustomResponse<ClienteDto>
                {
                    esCorrecto = true,
                    mensaje = "Cliente eliminado correctamente.",
                    Data = dtoAEliminar,
                    codigoStatus = 200
                });
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new CustomResponse<ClienteDto>
                {
                    esCorrecto = false,
                    mensaje = $"Error al eliminar cliente: {ex.Message}",
                    Data = null,
                    codigoStatus = 500
                });
            }
        }
    }
}
