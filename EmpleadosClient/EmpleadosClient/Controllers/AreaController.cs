using EmpleadosClient.Models;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EmpleadosClient.Controllers
{
    public class AreaController : Controller
    {
        private string SessionToken = "_token";
        // GET: AreaController
        public ActionResult Index()
        {
            string Token = HttpContext.Session.GetString(SessionToken);
            if (Token == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var result = new AreaDAL().SelectArea(Token);
                return View(result.ToList());
            };
        }

        // GET: AreaController/Details/5
        public ActionResult Details(int id)
        {
            string Token = HttpContext.Session.GetString(SessionToken);
            if (Token == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var result = new AreaDAL().SelectAreaBy_Id(id, Token);
                return View(result);
            };
        }

        // GET: AreaController/Create
        public ActionResult Create()
        {
            string Token = HttpContext.Session.GetString(SessionToken);
            if (Token == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                return View();
            }
        }

        // POST: AreaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Area collection)
        {
            string Token = HttpContext.Session.GetString(SessionToken);
            if (Token == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                new AreaDAL().InsertArea(collection, Token);
                return RedirectToAction("Index");
            }
        }

        // GET: AreaController/Edit/5
        public ActionResult Edit(int id)
        {
            string Token = HttpContext.Session.GetString(SessionToken);
            if (Token == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                var result = new AreaDAL().SelectAreaBy_Id(id, Token);
                return View(result);
            }
        }

        // POST: AreaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Area area)
        {
            string Token = HttpContext.Session.GetString(SessionToken);
            if (Token == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                new AreaDAL().UpdateArea(area, Token);
                return RedirectToAction("Index");
            }
        }

        // GET: AreaController/Delete/5
        public ActionResult Delete(int id)
        {
            string Token = HttpContext.Session.GetString(SessionToken);
            if (Token == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                new AreaDAL().DeleteArea(id, Token);
                return RedirectToAction("Index");
            }
        }


    }
}
