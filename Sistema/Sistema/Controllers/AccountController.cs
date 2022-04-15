using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sistema.laboratorio;

namespace Sistema.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> _userManager { get; }

        private SignInManager<AppUser> _signInManager { get; }

        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
    }
}
