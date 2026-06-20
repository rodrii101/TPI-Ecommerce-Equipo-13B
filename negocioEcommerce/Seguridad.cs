using dominioEcommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce
{
    public static class Seguridad
    {
        public static bool SesionActiva(object user)
        {
            Usuario usuarioIngresado = user != null ? (Usuario)user : null;
            if (usuarioIngresado != null && usuarioIngresado.Id != 0)
                return true;
            else
                return false;
        } 
    }
}