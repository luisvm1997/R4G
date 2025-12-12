// Con licencia para la .NET Foundation bajo uno o más acuerdos.
// La .NET Foundation te concede licencia para este archivo bajo la licencia MIT.
#nullable disable

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using R4G.App.Models;

namespace R4G.App.Areas.Identity.Pages.Account.Manage
{
    public class TwoFactorAuthenticationModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<TwoFactorAuthenticationModel> _logger;

        public TwoFactorAuthenticationModel(
            UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILogger<TwoFactorAuthenticationModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        /// <summary>
        ///     Esta API admite la infraestructura predeterminada de UI de ASP.NET Core Identity y no está pensada para usarse
        ///     directamente desde tu código. Esta API puede cambiar o eliminarse en versiones futuras.
        /// </summary>
        public bool HasAuthenticator { get; set; }

        /// <summary>
        ///     Esta API admite la infraestructura predeterminada de UI de ASP.NET Core Identity y no está pensada para usarse
        ///     directamente desde tu código. Esta API puede cambiar o eliminarse en versiones futuras.
        /// </summary>
        public int RecoveryCodesLeft { get; set; }

        /// <summary>
        ///     Esta API admite la infraestructura predeterminada de UI de ASP.NET Core Identity y no está pensada para usarse
        ///     directamente desde tu código. Esta API puede cambiar o eliminarse en versiones futuras.
        /// </summary>
        [BindProperty]
        public bool Is2faEnabled { get; set; }

        /// <summary>
        ///     Esta API admite la infraestructura predeterminada de UI de ASP.NET Core Identity y no está pensada para usarse
        ///     directamente desde tu código. Esta API puede cambiar o eliminarse en versiones futuras.
        /// </summary>
        public bool IsMachineRemembered { get; set; }

        /// <summary>
        ///     Esta API admite la infraestructura predeterminada de UI de ASP.NET Core Identity y no está pensada para usarse
        ///     directamente desde tu código. Esta API puede cambiar o eliminarse en versiones futuras.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            HasAuthenticator = await _userManager.GetAuthenticatorKeyAsync(user) != null;
            Is2faEnabled = await _userManager.GetTwoFactorEnabledAsync(user);
            IsMachineRemembered = await _signInManager.IsTwoFactorClientRememberedAsync(user);
            RecoveryCodesLeft = await _userManager.CountRecoveryCodesAsync(user);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await _signInManager.ForgetTwoFactorClientAsync();
            StatusMessage = "The current browser has been forgotten. When you login again from this browser you will be prompted for your 2fa code.";
            return RedirectToPage();
        }
    }
}
