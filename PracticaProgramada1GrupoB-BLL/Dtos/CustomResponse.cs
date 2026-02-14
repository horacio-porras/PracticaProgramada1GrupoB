using System;
using System.Collections.Generic;
using System.Text;

namespace PracticaProgramada1GrupoB_BLL.Dtos
{
    public class CustomResponse<T>
    {
        public bool esCorrecto { get; set; }
        public string mensaje { get; set; }
        public T Data { get; set; }
        public int codigoStatus { get; set; }

        public CustomResponse()
        {
            esCorrecto = true;
            mensaje = string.Empty;
            Data = default(T);
            codigoStatus = 200;
        }
    }
}
