using System;
using System.Linq;
using Datos;
using Entity;

namespace Logica
{
    public class ServicioUsuario
    {
        private readonly SeynekunContext _context;
        public ServicioUsuario(SeynekunContext context)
        {
            _context = context;
        }

        public Usuario ValidarUsuario(string nombreUsuario, string contrasena)
        {
            try
            {
                return _context.Usuarios.FirstOrDefault(u => u.NombreUsuario == nombreUsuario && u.Contrasena == contrasena && (u.Estado == "Activo" || u.Estado == "Modificado"));
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
