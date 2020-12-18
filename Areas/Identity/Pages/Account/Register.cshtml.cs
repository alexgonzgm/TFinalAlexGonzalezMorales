using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using TFinalAlexGonzalezMorales.Models;
using TFinalAlexGonzalezMorales.Utilities;

namespace TFinalAlexGonzalezMorales.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Contraseña")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirmar contraseña")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            public int DNI { get; set; }
            public string Nombre { get; set; }
            public int Edad { get; set; }
            [Display(Name = "Dirección")]
            public string Direccion { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser {
                    UserName = Input.Email,
                    Email = Input.Email,
                    DNI = Input.DNI , 
                    Nombre = Input.Nombre , 
                    Edad = Input.Edad , 
                    Direccion = Input.Direccion,
                    EmailConfirmed = true
                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    //Aqui validamos si los roles existen si no se crean 
                    if (!await _roleManager.RoleExistsAsync(Roles.Secretaria))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(Roles.Secretaria));
                        await _roleManager.CreateAsync(new IdentityRole(Roles.Profesor));
                        await _roleManager.CreateAsync(new IdentityRole(Roles.Alumno));
                    }
                    //Obtener el rol seleccionado 
                    string rol = Request.Form["radioRole"].ToString();
                    //Validamos si el rol seleccionado es Secretaria y si lo es lo agregamos
                    if (rol == Roles.Secretaria)
                    {
                        await _userManager.AddToRoleAsync(user , Roles.Secretaria);
                    }
                    else if (rol == Roles.Profesor)
                    {
                        await _userManager.AddToRoleAsync(user, Roles.Profesor);
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, Roles.Alumno);
                    }
                    _logger.LogInformation("Usuario creado con exito.");

                    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    //var callbackUrl = Url.Page(
                    //    "/Account/ConfirmEmail",
                    //    pageHandler: null,
                    //    values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                    //    protocol: Request.Scheme);

                    //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    //if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    //{
                    //    return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    //}
                    //else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
