using CsvHelper;
using Demo.Models;
using Demo.Models.Entidades;
using Demo.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    public class InformeController : Controller
    {
        private readonly IDB _repositorio;

        public InformeController(IDB repositorio)
        {
            _repositorio = repositorio;
        }
        // GET: InformeController
        [HttpGet]
        public ActionResult Index(string busqueda)
        {
            if (_repositorio.RepositorioUsuario.existeUsuario(HttpContext.Session.GetString("usuario"), HttpContext.Session.GetString("pass")))
            {
                List<Informe> lista = _repositorio.RepositorioInforme.ListarInformes();
                if (!string.IsNullOrEmpty(busqueda))
                {
                    lista = lista.Where(x => x.InformeDetalle.Contains(busqueda)).ToList();
                }
                return View(lista);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
                
        }

        [HttpPost]
        public ActionResult Details(int id)
        {
            Informe informe = _repositorio.RepositorioInforme.ObtenerInformePorID(id);
            return View(informe);
        }

        // GET: InformeController/Create
        public ActionResult Create()
        {
            if (_repositorio.RepositorioUsuario.existeUsuario(HttpContext.Session.GetString("usuario"), HttpContext.Session.GetString("pass")))
            {
                InformeViewModel vm = new(_repositorio.RepositorioUsuario.ListarUsuarios(), _repositorio.RepositorioPaciente.ListarPacientes());
                return View(vm);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }

        }

        // POST: InformeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Informe informe, IFormFile image)
        {
            try
            {
                //using(var stream = System.IO.File.Create(image.))
                string upload = "./images/";
                if (!Directory.Exists(upload))
                {
                    Directory.CreateDirectory(upload);
                }
                string filepath = Path.Combine(upload, image.FileName);
                using(Stream fileStream = new FileStream(filepath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }
                _repositorio.RepositorioInforme.AgregarInforme(informe);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: InformeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InformeController/Edit/5
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

        // POST: InformeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                _repositorio.RepositorioInforme.BorrarInforme(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public ActionResult ExportPDF(int id)
        {
            //Consigo el Informe
            Informe informe = _repositorio.RepositorioInforme.ObtenerInformePorID(id);


            //Formateo PDF
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            PdfDocument document = new PdfDocument(id.ToString());
            document.Info.Title = "Prueba de Informe";

            PdfPage page = document.AddPage();

            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont font = new XFont("Arial", 13, XFontStyle.Regular);

            gfx.DrawString("Informe ID: "+informe.InformeId.ToString(), font, XBrushes.Black,
                new XRect(50, 100, page.Width, page.Height),
                XStringFormats.TopLeft);

            gfx.DrawString("Paciente: " + informe.InformePacienteId.ToString(), font, XBrushes.Black,
                new XRect(50, 120, page.Width, page.Height),
                XStringFormats.TopLeft);

            gfx.DrawString("Medico: " + informe.InformeUsuarioId.ToString(), font, XBrushes.Black,
                new XRect(50, 140, page.Width, page.Height),
                XStringFormats.TopLeft);

            gfx.DrawString("Detalle: " + informe.InformeDetalle, font, XBrushes.Black,
                new XRect(50, 160, page.Width, page.Height),
                XStringFormats.TopLeft);


            //Devuelvo PDF
            using (MemoryStream stream = new MemoryStream())
            {
                document.Save(stream, false);
                document.Close();
                document.Dispose();
                return File(stream.ToArray(), "application/pdf");
            }
        }

        public ActionResult ExportCVS()
        {
            List<Informe> informes = _repositorio.RepositorioInforme.ListarInformes();
            var builder = new StringBuilder("InformeID,InformePacienteID,InformeUsuarioID,Detalles\n");

            foreach(Informe infome in informes)
            {
                string linea = string.Format("{0},{1},{2},{3}", infome.InformeId, infome.InformePacienteId, infome.InformeUsuarioId, infome.InformeDetalle);
                builder.AppendLine(linea);
            }

            using(MemoryStream ms = new())
            {
                using(StreamWriter sw = new StreamWriter(ms))
                {
                    sw.Write(builder.ToString());
                    sw.Flush();
                    return File(ms.ToArray(), "text/csv", "Informes.csv");
                }
            }
            

                
        }
    }
}
