using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominioEcommerce
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string DNI { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public List<DireccionUsuario> Direcciones { get; set; } = new List<DireccionUsuario>();
        public TipoUsuario TipoUsuario { get; set; }
        public string ImagenPerfil { get; set; }
        public bool Estado { get; set; }

        public Usuario() { }
        public Usuario(string email, string pass, int tipoUser)
        {
            Email = email;
            Pass = pass;
            TipoUsuario = new TipoUsuario();
            TipoUsuario.IdTipoUsuario = tipoUser;
        }
    }
}
