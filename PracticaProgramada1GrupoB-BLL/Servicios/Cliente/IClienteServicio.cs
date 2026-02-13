using PracticaProgramada1GrupoB_BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticaProgramada1GrupoB_BLL.Servicios.Cliente
{
    public interface IClienteServicio
    {
        Task<CustomResponse<List<ClienteDto>>> ObtenerClientesAsync();

        Task<CustomResponse<ClienteDto>> ObtenerClientePorIdAsync(int id);

        Task<CustomResponse<ClienteDto>> AgregarClienteAsync(ClienteDto clienteDto);

        Task<CustomResponse<ClienteDto>> ActualizarClienteAsync(ClienteDto clienteDto);

        Task<CustomResponse<ClienteDto>> EliminarClienteAsync(int id);
    }
}
