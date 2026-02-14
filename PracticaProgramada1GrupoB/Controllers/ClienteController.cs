using Microsoft.AspNetCore.Mvc;
using PracticaProgramada1GrupoB_BLL.Dtos;
using PracticaProgramada1GrupoB_BLL.Servicios.Cliente;
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
            var response = await _clienteServicio.ObtenerClientesAsync();
            var lista = response.esCorrecto ? response.Data : new List<ClienteDto>();
            return View(lista);
        }

        //Devuelve la lista de clientes en JSON para que DataTables (AJAX) pueda llenar la tabla.
        [HttpGet]
        public async Task<IActionResult> ObtenerClientes()
        {
            var response = await _clienteServicio.ObtenerClientesAsync();
            if (response.esCorrecto)
            {
                return Json(response.Data);
            }
            return Json(new List<ClienteDto>());
        }

        public async Task<IActionResult> AgregarCliente(ClienteDto cliente)
        {
            if (ModelState.IsValid)
            {
                await _clienteServicio.AgregarClienteAsync(cliente);
                return RedirectToAction("ObtenerClientes");
            }
            return View(cliente);
        }

        public async Task<IActionResult> ActualizarCliente(int id)
        {
            var response = await _clienteServicio.ObtenerClientePorIdAsync(id);
            if (response.esCorrecto)
            {
                return View(response.Data);
            }
            else
            {
                ViewBag.ErrorMessage = response.mensaje;
                return RedirectToAction("ObtenerClientes");
            }
        }

        public async Task<IActionResult> EliminarCliente(int id)
        {
            await _clienteServicio.EliminarClienteAsync(id);
            return RedirectToAction("ObtenerClientes");
        }
    }
}
