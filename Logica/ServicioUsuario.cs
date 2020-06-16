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
                return _context.Usuarios.Where(u => u.NombreUsuario.ToLower() == nombreUsuario.ToLower() && u.Contrasena == contrasena && (u.Estado == "Activo" || u.Estado == "Modificado")).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
