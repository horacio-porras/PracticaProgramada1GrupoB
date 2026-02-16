using PracticaProgramada1GrupoB_DAL.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticaProgramada1GrupoB_DAL.Repositorios.Cliente
{
    public class ClienteRepositorio : IClienteRepositorio
    {

        private List<Entidades.Cliente> clientes = new List<Entidades.Cliente>()
        {
            new Entidades.Cliente() { Id = 1, Nombre = "Juan", Apellido = "Perez", CorreoElectronico = "juanperez@email.com", Telefono = "12345678" },
            new Entidades.Cliente() { Id = 2, Nombre = "Sonia", Apellido = "Mora", CorreoElectronico = "soniamora@email.com", Telefono = "87654321" }
        };

        public void ActualizarCliente(Entidades.Cliente cliente)
        {

            var index = clientes.FindIndex(c => c.Id == cliente.Id);

            clientes[index].Nombre = cliente.Nombre;
            clientes[index].Apellido = cliente.Apellido;
            clientes[index].CorreoElectronico = cliente.CorreoElectronico;
            clientes[index].Telefono = cliente.Telefono;
        }


        public void AgregarCliente(Entidades.Cliente cliente)
        {
            var newId = clientes.Any() ? clientes.Max(c => c.Id) + 1 : 1;

            clientes.Add(new Entidades.Cliente
            {
                Id = newId,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                CorreoElectronico = cliente.CorreoElectronico,
                Telefono = cliente.Telefono
            });
        }

        public void EliminarCliente(int id)
        {
            var removed = clientes.RemoveAll(c => c.Id == id);
        }

        public Entidades.Cliente ObtenerClientePorId(int id)
        {
            var found = clientes.FirstOrDefault(c => c.Id == id);
            if (found == null) return null;

            // Return a copy to avoid exposing internal list items
            return new Entidades.Cliente
            {
                Id = found.Id,
                Nombre = found.Nombre,
                Apellido = found.Apellido,
                CorreoElectronico = found.CorreoElectronico,
                Telefono = found.Telefono
            };
        }

        public List<Entidades.Cliente> ObtenerClientes()
        {
            return clientes
               .Select(c => new Entidades.Cliente { Id = c.Id, Nombre = c.Nombre, Apellido = c.Apellido, CorreoElectronico = c.CorreoElectronico, Telefono = c.Telefono })
               .ToList();
        }
    }

}

