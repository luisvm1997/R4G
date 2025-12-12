// Con licencia para la .NET Foundation bajo uno o más acuerdos.
// La .NET Foundation te concede licencia para este archivo bajo la licencia MIT.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using R4G.App.Models;

namespace R4G.App.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ResendEmailConfirmationModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;

        public ResendEmailConfirmationModel(UserManager<ApplicationUser> userManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
        }

        /// <summary>
        ///     Esta API admite la infraestructura predeterminada de UI de ASP.NET Core Identity y no está pensada para usarse
        ///     directamente desde tu código. Esta API puede cambiar o eliminarse en versiones futuras.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     Esta API admite la infraestructura predeterminada de UI de ASP.NET Core Identity y no está pensada para usarse
        ///     directamente desde tu código. Esta API puede cambiar o eliminarse en versiones futuras.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     Esta API admite la infraestructura predeterminada de UI de ASP.NET Core Identity y no está pensada para usarse
            ///     directamente desde tu código. Esta API puede cambiar o eliminarse en versiones futuras.
            /// </summary>
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.FindByEmailAsync(Input.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Correo de verificación enviado. Revisa tu email.");
                return Page();
            }

            var userId = await _userManager.GetUserIdAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { userId = userId, code = code },
                protocol: Request.Scheme);
            await _emailSender.SendEmailAsync(
                Input.Email,
                "Confirm your email",
                $"Confirma tu cuenta haciendo clic <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>aquí</a>.");

            ModelState.AddModelError(string.Empty, "Correo de verificación enviado. Revisa tu email.");
            return Page();
        }
    }
}
