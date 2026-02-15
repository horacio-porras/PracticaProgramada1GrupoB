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
