using System;
using System.Collections.Generic;
using System.Text;

namespace PracticaProgramada1GrupoB_DAL.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
    }
}
