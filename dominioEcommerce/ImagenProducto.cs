using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace dominioEcommerce
{
    public class ImagenProducto
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public string ImagenURL { get; set; }
        public bool EsPrincipal { get; set; }
    }
}
