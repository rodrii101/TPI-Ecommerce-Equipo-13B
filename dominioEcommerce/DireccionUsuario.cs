using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominioEcommerce
{
    public class DireccionUsuario
    {
        public int Id { get; set; }
        public string Calle { get; set; }
        public int Altura { get; set; }
        public string Piso { get; set; }
        public string Departamento { get; set; }
        public string Localidad { get; set; }
        public string CodigoPostal { get; set; }
        public string Observacion { get; set; }

        public bool Estado { get; set; }
    }
}
