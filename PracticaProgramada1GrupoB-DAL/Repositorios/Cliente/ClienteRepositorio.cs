using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PracticaProgramada1GrupoB_DAL.Repositorios.Cliente
{
    public class ClienteRepositorio : IClienteRepositorio
    {

        private List<Entidades.Cliente> clientes = new List<Entidades.Cliente>()
        {
            new Entidades.Cliente() { Id = 1, Nombre = "Juan", Apellido = "Perez", CorreoElectronico = "juanperez@email.com", Telefono = "12345678" }
        };

        public void ActualizarCliente(Entidades.Cliente cliente)
        {
            if (cliente == null) throw new ArgumentNullException(nameof(cliente));

            var existente = clientes.FirstOrDefault(c => c.Id == cliente.Id);
            if (existente == null)
                throw new InvalidOperationException($"Cliente con Id {cliente.Id} no encontrado.");

            //Actualiza propiedades
            existente.Nombre = cliente.Nombre;
            existente.Apellido = cliente.Apellido;
            existente.CorreoElectronico = cliente.CorreoElectronico;
            existente.Telefono = cliente.Telefono;
        }

        public void AgregarCliente(Entidades.Cliente cliente)
        {
            if (cliente == null) throw new ArgumentNullException(nameof(cliente));

            //Asigna un Id nuevo secuencial
            var nextId = clientes.Any() ? clientes.Max(c => c.Id) + 1 : 1;
            cliente.Id = nextId;
            clientes.Add(cliente);
        }

        public void EliminarCliente(int id)
        {
            var removedCount = clientes.RemoveAll(c => c.Id == id);
            if (removedCount == 0)
                throw new InvalidOperationException($"Cliente con Id {id} no encontrado.");
        }

        public Entidades.Cliente ObtenerClientePorId(int id)
        {
            return clientes.FirstOrDefault(c => c.Id == id)
                ?? throw new InvalidOperationException($"Cliente con Id {id} no encontrado.");
        }

        public List<Entidades.Cliente> ObtenerClientes()
        {
            //Devuelve una copia para evitar modificación externa de la colección interna
            return clientes.ToList();
        }
    }
}
