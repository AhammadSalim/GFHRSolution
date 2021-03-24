using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using GFHRSolution.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using GFHRSolution.Data;

namespace GFHRSolution.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ResetPasswordModel : PageModel
    {
        private readonly UserManager<GFHRSolutionUser> _userManager;
        private readonly GFHRIdentityContext _db;

        public ResetPasswordModel(UserManager<GFHRSolutionUser> userManager,GFHRIdentityContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            //[Required]
            //[EmailAddress]
            //public string Email { get; set; }
            [Required]
            public string UserName { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            public string Code { get; set; }
        }

        public IActionResult OnGet(string code = null)
        {
            //if (code == null)
            //{
            //    return BadRequest("A code must be supplied for password reset.");
            //}
            //else
            //{
            //    Input = new InputModel
            //    {
            //        Code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code))
            //    };
            //    return Page();
            //}
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string code)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var user = _db.Users.Where(u => u.UserName.Equals(Input.UserName)).Single();
            //var user = await _userManager.FindByEmailAsync(Input.Email);
            await _userManager.RemovePasswordAsync(user);
            await _userManager.AddPasswordAsync(user, Input.ConfirmPassword);

            return Page();
        }
    }
}
