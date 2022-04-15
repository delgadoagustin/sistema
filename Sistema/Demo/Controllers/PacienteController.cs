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
    public class PacienteController : Controller
    {
        private readonly IDB _repositorio;

        public PacienteController(IDB repositorio)
        {
            _repositorio = repositorio;
        }

        // GET: PacienteController
        public ActionResult Index()
        {
            if (_repositorio.RepositorioUsuario.existeUsuario(HttpContext.Session.GetString("usuario"), HttpContext.Session.GetString("pass")))
            {
                List<Paciente> lista = _repositorio.RepositorioPaciente.ListarPacientes();
                return View(lista);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
                
        }

        // GET: PacienteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PacienteController/Create
        public ActionResult Create()
        {
            if (_repositorio.RepositorioUsuario.existeUsuario(HttpContext.Session.GetString("usuario"), HttpContext.Session.GetString("pass")))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
                
        }

        // POST: PacienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Paciente paciente)
        {
            try
            {
                _repositorio.RepositorioPaciente.AgregarPaciente(paciente);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PacienteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PacienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PacienteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PacienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
