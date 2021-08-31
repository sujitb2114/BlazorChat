using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorMLSA.Server.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlazorMLSA.Server.Pages
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        public LogoutModel(SignInManager<ApplicationUser> _signInManager)
        {
            signInManager = _signInManager;
        }
        public async Task<ActionResult> OnPostAsync()
        {
            await signInManager.SignOutAsync();
            return Redirect("/");
        }
    }
}