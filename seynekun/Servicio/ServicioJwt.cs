using Entity;

namespace seynekun.Servicio
{
    public class ServicioJwt
    {
        private readonly AppSettings _appSettings;
        public ServicioJwt(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public LoginViewModel GenerarToken(Usuario usuario)
        {
            if(usuario == null)
                return null;
            
            var usuarioResponse = new LoginViewModel(){
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                NombreUsuario = usuario.NombreUsuario
                };
            
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name, usuario.NombreUsuario.ToString(),
                    new Claim(ClaimTypes.Email, usuario.Email.ToString(),
                    new Claim(ClaimTypes.NumeroTelefono, usuario.NumeroTelefono.ToString(),
                    new Claim(ClaimTypes.Role, "Rol1",
                    new Claim(ClaimTypes.Role, "Rol2"
                    )
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            usuarioResponse.Token = tokenHandler.WriteToken(token);

            return usuarioResponse;
        }
    }
}
