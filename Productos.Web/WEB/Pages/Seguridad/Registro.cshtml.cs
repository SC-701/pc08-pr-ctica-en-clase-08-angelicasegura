using Abstracciones.Interfaces.Reglas;
using Abstracciones.Seguridad;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reglas;

namespace WEB.Pages.Seguridad
{
    public class RegistroModel : PageModel
    {
        [BindProperty]
        public Usuario usuario { get; set; } = default!;
        private IConfiguracion _configuracion;

        public RegistroModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            var hash = Autenticacion.GenerarHash(usuario.Password);
            usuario.PasswordHash = Autenticacion.ObtenerHash(hash);
          

            string endpoint = _configuracion.ObtenerMetodo("ApiEndPointsSeguridad", "Registrar");
            var cliente = new HttpClient();
            var usuarioEnviar = new UsuarioBase
            {
                NombreUsuario = usuario.NombreUsuario,
                CorreoElectronico = usuario.CorreoElectronico,
                PasswordHash = usuario.PasswordHash
            };

            var respuesta = await cliente.PostAsJsonAsync(endpoint, usuarioEnviar);
            
           respuesta.EnsureSuccessStatusCode();
            return RedirectToPage("../index");
        }
    }
}
