using EmpleadosClient.Models;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using X.PagedList;

namespace EmpleadosClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private string SessionToken = "_token";
        const int pageSize = 9;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? page,string filtro )
        {
            int pageNumber = (page ?? 1);
            string Token = HttpContext.Session.GetString(SessionToken);
            if (Token == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                var result = new EmpleadoDAL().SelectEmpleados(filtro:filtro, token: Token);
                return View(result.ToList().ToPagedList(pageNumber,pageSize));
            }
        }

        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return View(usuario);
            }
            var result = new UsuarioDAL().Login(usuario);
            if (!String.IsNullOrEmpty(result.token))
            {
                HttpContext.Session.SetString(SessionToken, result.token);
                return RedirectToAction("Index");
            }
            else
            {
                return View(usuario);
            }
        }
        public IActionResult AgregarEmpleado()
        {
            string Token = HttpContext.Session.GetString(SessionToken);
            if (Token == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.AreaList = new AreaDAL().SelectArea(Token);
                ViewBag.TipoDocumentoList = new TipoDocumentoDAL().SelectTipoDocumento(Token);
                return View();
            }
        }
        [HttpPost]
        public IActionResult AgregarEmpleado(Empleado empleado)
        {
            string Token = HttpContext.Session.GetString(SessionToken);
            if (Token == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                new EmpleadoDAL().InsertEmpleado(empleado, Token);
                return RedirectToAction("Index");
            }
        }
        public IActionResult EditarEmpleado(int id)
        {
            string Token = HttpContext.Session.GetString(SessionToken);
            if (Token == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                var result = new EmpleadoDAL().SelectEmpleadosBy_Id(id, Token);
                ViewBag.AreaList = new AreaDAL().SelectArea(Token);
                ViewBag.TipoDocumentoList = new TipoDocumentoDAL().SelectTipoDocumento(Token);
                return View(result);
            }
        }
        [HttpPost]
        public IActionResult EditarEmpleado(Empleado empleado)
        {
            string Token = HttpContext.Session.GetString(SessionToken);
            if (Token == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                new EmpleadoDAL().UpdateEmpleado(empleado, Token);
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public IActionResult DetalleEmpleado(int id)
        {
            string Token = HttpContext.Session.GetString(SessionToken);
            if (Token == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                var result = new EmpleadoDAL().SelectEmpleadosBy_Id(id, Token);
                return View(result);
            }
        }
        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            string Token = HttpContext.Session.GetString(SessionToken);
            if (Token == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                new EmpleadoDAL().DeleteEmpleado(id, Token);
                return RedirectToAction("Index");
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Login()
        {
            string Token = HttpContext.Session.GetString(SessionToken);
            if (!String.IsNullOrEmpty(Token))
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
