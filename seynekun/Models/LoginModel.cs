using Entity;

namespace seynekun.Models
{
    public class LoginInputModel
    {
        public string Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Tipo { get; set; }
        public string Token { get; set; }
    }

    public class LoginViewModel : LoginInputModel
    {
        public LoginViewModel(Usuario usuario)
        {
            NombreUsuario = usuario.NombreUsuario;
            Contrasena = usuario.Contrasena;
            Nombre = usuario.Nombre;
            Apellido = usuario.Apellido;
            Token = usuario.Token;
            Tipo = usuario.Tipo;
            Id = usuario.Id;
        }
    }
}
