using System;
using System.Collections.Generic;
using System.Text;

namespace PracticaProgramada1GrupoB_BLL.Dtos
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
    }
}
