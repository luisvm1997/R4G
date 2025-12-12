// Con licencia para la .NET Foundation bajo uno o más acuerdos.
// La .NET Foundation te concede licencia para este archivo bajo la licencia MIT.
#nullable disable

using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace R4G.App.Areas.Identity.Pages
{
    /// <summary>
    ///     Esta API admite la infraestructura predeterminada de UI de ASP.NET Core Identity y no está pensada para usarse
    ///     directamente desde tu código. Esta API puede cambiar o eliminarse en versiones futuras.
    /// </summary>
    [AllowAnonymous]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorModel : PageModel
    {
        /// <summary>
        ///     Esta API admite la infraestructura predeterminada de UI de ASP.NET Core Identity y no está pensada para usarse
        ///     directamente desde tu código. Esta API puede cambiar o eliminarse en versiones futuras.
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        ///     Esta API admite la infraestructura predeterminada de UI de ASP.NET Core Identity y no está pensada para usarse
        ///     directamente desde tu código. Esta API puede cambiar o eliminarse en versiones futuras.
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        /// <summary>
        ///     Esta API admite la infraestructura predeterminada de UI de ASP.NET Core Identity y no está pensada para usarse
        ///     directamente desde tu código. Esta API puede cambiar o eliminarse en versiones futuras.
        /// </summary>
        public void OnGet()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}
