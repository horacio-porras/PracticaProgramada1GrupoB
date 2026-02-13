using System;
using System.Collections.Generic;
using System.Text;

namespace PracticaProgramada1GrupoB_DAL.Repositorios.Cliente
{
    public interface IClienteRepositorio
    {
        List<Entidades.Cliente> ObtenerClientes();
            Entidades.Cliente ObtenerClientePorId(int id);
            void AgregarCliente(Entidades.Cliente cliente);
            void ActualizarCliente(Entidades.Cliente cliente);
            void EliminarCliente(int id);
    }
}
