using EmpleadosClient.Models;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpleadosClient.Controllers
{
    public class SubAreaController : Controller
    {
        private string SessionToken = "_token";
        // GET: SubAreaController
        public ActionResult Index()
        {
            string Token = HttpContext.Session.GetString(SessionToken);
            if (Token == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var result = new SubAreaDAL().SelectSubArea(Token);
                return View(result.ToList());
            };
        }

        // GET: SubAreaController/Details/5
        public ActionResult Details(int id)
        {
            string Token = HttpContext.Session.GetString(SessionToken);
            if (Token == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var result = new SubAreaDAL().SelectSubAreaBy_Id(id, Token);
                return View(result);
            };
        }

        // GET: SubAreaController/Create
        public ActionResult Create()
        {
            string Token = HttpContext.Session.GetString(SessionToken);
            if (Token == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                ViewBag.AreaList = new AreaDAL().SelectArea(Token);
                return View();
            }
        }

        // POST: SubAreaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubArea collection)
        {
            string Token = HttpContext.Session.GetString(SessionToken);
            if (Token == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                new SubAreaDAL().InsertSubArea(collection, Token);
                return RedirectToAction("Index");
            }
        }

        // GET: SubAreaController/Edit/5
        public ActionResult Edit(int id)
        {
            string Token = HttpContext.Session.GetString(SessionToken);
            if (Token == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.AreaList = new AreaDAL().SelectArea(Token);
                var result = new SubAreaDAL().SelectSubAreaBy_Id(id, Token);
                return View(result);
            }
        }

        // POST: SubAreaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( SubArea area)
        {
            string Token = HttpContext.Session.GetString(SessionToken);
            if (Token == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                new SubAreaDAL().UpdateSubArea(area, Token);
                return RedirectToAction("Index");
            }
        }

        // GET: SubAreaController/Delete/5
        public ActionResult Delete(int id)
        {
            string Token = HttpContext.Session.GetString(SessionToken);
            if (Token == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                new SubAreaDAL().DeleteSubArea(id, Token);
                return RedirectToAction("Index");
            }
        }

    }
}
