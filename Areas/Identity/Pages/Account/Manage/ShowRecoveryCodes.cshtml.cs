// Con licencia para la .NET Foundation bajo uno o más acuerdos.
// La .NET Foundation te concede licencia para este archivo bajo la licencia MIT.
#nullable disable

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using R4G.App.Models;

namespace R4G.App.Areas.Identity.Pages.Account.Manage
{
    /// <summary>
    ///     Esta API admite la infraestructura predeterminada de UI de ASP.NET Core Identity y no está pensada para usarse
    ///     directamente desde tu código. Esta API puede cambiar o eliminarse en versiones futuras.
    /// </summary>
    public class ShowRecoveryCodesModel : PageModel
    {
        /// <summary>
        ///     Esta API admite la infraestructura predeterminada de UI de ASP.NET Core Identity y no está pensada para usarse
        ///     directamente desde tu código. Esta API puede cambiar o eliminarse en versiones futuras.
        /// </summary>
        [TempData]
        public string[] RecoveryCodes { get; set; }

        /// <summary>
        ///     Esta API admite la infraestructura predeterminada de UI de ASP.NET Core Identity y no está pensada para usarse
        ///     directamente desde tu código. Esta API puede cambiar o eliminarse en versiones futuras.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     Esta API admite la infraestructura predeterminada de UI de ASP.NET Core Identity y no está pensada para usarse
        ///     directamente desde tu código. Esta API puede cambiar o eliminarse en versiones futuras.
        /// </summary>
        public IActionResult OnGet()
        {
            if (RecoveryCodes == null || RecoveryCodes.Length == 0)
            {
                return RedirectToPage("./TwoFactorAuthentication");
            }

            return Page();
        }
    }
}
