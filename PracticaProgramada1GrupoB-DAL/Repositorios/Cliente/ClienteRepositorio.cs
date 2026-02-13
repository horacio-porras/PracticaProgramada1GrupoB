using System;
using System.Collections.Generic;
using System.Text;

namespace PracticaProgramada1GrupoB_DAL.Repositorios.Cliente
{
    public class ClienteRepositorio : IClienteRepositorio
    {

        public List<Entidades.Cliente> clientes = new List<Entidades.Cliente>()
        {
            new Entidades.Cliente() { Id = 1, Nombre = "Juan", Apellido = "Perez", CorreoElectronico = "juanperez@email.com", Telefono = "12345678" }
        };

        public void ActualizarCliente(Entidades.Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void AgregarCliente(Entidades.Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void EliminarCliente(int id)
        {
            throw new NotImplementedException();
        }

        public Entidades.Cliente ObtenerClientePorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Entidades.Cliente> ObtenerClientes()
        {
            throw new NotImplementedException();
        }
    }
}
