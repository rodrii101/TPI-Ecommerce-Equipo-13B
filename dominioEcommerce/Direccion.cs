using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominioEcommerce
{
    public class Direccion
    {
        public int Id { get; set; }
        public string Calle { get; set; }
        public int Altura { get; set; }
        public string Departamento { get; set; }
        public string Localidad { get; set; }
        public int CodigoPostal { get; set; }
        public string Observacion { get; set; }
    }
}
