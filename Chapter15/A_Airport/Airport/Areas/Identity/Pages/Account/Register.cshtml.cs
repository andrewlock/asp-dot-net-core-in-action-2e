using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Airport.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace Airport.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public SelectListItem[] FrequentFlyerClasses { get; } =
            {
                new SelectListItem{Text = "Gold", Value = "Gold"},
                new SelectListItem{Text = "Silver", Value = "Silver"},
                new SelectListItem{Text = "Bronze", Value = "Bronze"},
            };

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Display(Name = "Employee Number")]
            public string EmployeeNumber { get; set; }

            [Display(Name = "Boarding Pass Number")]
            public string BoardingPassNumber { get; set; }

            [Display(Name = "Date of Birth")]
            [DataType(DataType.Date)]
            public DateTime? DateOfBirth { get; set; }

            [Display(Name = "Is banned from Lounge?")]
            public bool IsBannedFromLounge { get; set; }

            [Display(Name = "FrequentFlyerClass")]
            public string FrequentFlyerClass { get; set; }
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
                var user = new IdentityUser { UserName = Input.Email, Email = Input.Email };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    await AddClaims(user);
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
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

        private async Task AddClaims(IdentityUser user)
        {
            if (Input.DateOfBirth.HasValue)
            {
                var newClaim = new Claim(ClaimTypes.DateOfBirth, Input.DateOfBirth.Value.ToString("yyyy-MM-dd"), ClaimValueTypes.Date);
                await _userManager.AddClaimAsync(user, newClaim);
            }
            if (!string.IsNullOrEmpty(Input.BoardingPassNumber))
            {
                var newClaim = new Claim(Claims.BoardingPassNumber, Input.BoardingPassNumber);
                await _userManager.AddClaimAsync(user, newClaim);
            }
            if (!string.IsNullOrEmpty(Input.EmployeeNumber))
            {
                var newClaim = new Claim(Claims.EmployeeNumber, Input.EmployeeNumber);
                await _userManager.AddClaimAsync(user, newClaim);
            }
            if (!string.IsNullOrEmpty(Input.FrequentFlyerClass))
            {
                var newClaim = new Claim(Claims.FrequentFlyerClass, Input.FrequentFlyerClass);
                await _userManager.AddClaimAsync(user, newClaim);
            }
            if (Input.IsBannedFromLounge)
            {
                var newClaim = new Claim(Claims.IsBannedFromLounge, "true");
                await _userManager.AddClaimAsync(user, newClaim);
            }
        }
    }
}
