using Demo.Models;
using Demo.Models.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    public class LoginController : Controller
    {
        private readonly IDB _repositorio;

        public LoginController(IDB repositorio)
        {
            _repositorio = repositorio;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Login","Login");
        }

        public IActionResult Login()
        {
            if (_repositorio.RepositorioUsuario.existeUsuario(HttpContext.Session.GetString("usuario"), HttpContext.Session.GetString("pass")))
                return RedirectToAction("Index", "Paciente");
            else
            {
                return View();
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("usuario");
            HttpContext.Session.Remove("pass");
            return RedirectToAction("Login", "Login");
        }

        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {
            if (_repositorio.RepositorioUsuario.existeUsuario(usuario.UsuarioNombre, usuario.UsuarioPass)){
                HttpContext.Session.SetString("usuario", usuario.UsuarioNombre);
                HttpContext.Session.SetString("pass", usuario.UsuarioPass);
                return RedirectToAction("Index", "Paciente");
            }
            return View();
        }
    }
}
