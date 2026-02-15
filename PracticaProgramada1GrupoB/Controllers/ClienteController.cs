using Microsoft.AspNetCore.Mvc;
using PracticaProgramada1GrupoB_BLL.Dtos;
using PracticaProgramada1GrupoB_BLL.Servicios.Cliente;
using PracticaProgramada1GrupoB_DAL.Entidades;
using PracticaProgramada1GrupoB_DAL.Repositorios.Cliente;

namespace PracticaProgramada1GrupoB.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteServicio _clienteServicio;

        public ClienteController(IClienteServicio clienteServicio)
        {
            _clienteServicio = clienteServicio;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerClientes()
        {
            var response = await _clienteServicio.ObtenerClientesAsync();
            return Json(response);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerClientePorId(int id)
        {
            var response = await _clienteServicio.ObtenerClientePorIdAsync(id);
            return Json(response);
        }

        public async Task<IActionResult> AgregarCliente(ClienteDto cliente)
        {
            var response = await _clienteServicio.AgregarClienteAsync(cliente);
            return Json(response);
        }

        public async Task<IActionResult> ActualizarCliente(ClienteDto cliente)
        {
            var response = await _clienteServicio.ActualizarClienteAsync(cliente);
            return Json(response);
        }

        public async Task<IActionResult> EliminarCliente(int id)
        {
            var response = await _clienteServicio.EliminarClienteAsync(id);
            return Json(response);
        }
    }
}
