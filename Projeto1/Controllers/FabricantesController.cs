using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto1.Contexts;
using Projeto1.Models;
using System.Net;
using System.Data.Entity;

namespace Projeto1.Controllers
{
    public class FabricantesController : Controller
    {
        //Instanciando um um contexto do EF
        private EFContext contex = new EFContext();

        // GET: Fabricantes
        public ActionResult Index()
        {
            return View(contex.Fabricantes.OrderBy(c => c.Nome));
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fabricante fabricante)
        {
            contex.Fabricantes.Add(fabricante);
            contex.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET: Edit
        public ActionResult Edit (long? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Tenta achar o fabricante
            Fabricante fabricante = contex.Fabricantes.Find(id);
            if(fabricante == null)
            {
                //Se não, dá um erro
                return HttpNotFound();
            }
            return View(fabricante);
        }

        //POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fabricante fabricante)
        {
            if(ModelState.IsValid)
            {
                contex.Entry(fabricante).State = EntityState.Modified;
                contex.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fabricante);
        }

        //GET: Details
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Tenta achar o fabricante
            Fabricante fabricante = contex.Fabricantes.Find(id);
            if (fabricante == null)
            {
                //Se não, dá um erro
                return HttpNotFound();
            }
            return View(fabricante);
        }

        //GET: Delete
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Tenta achar o fabricante
            Fabricante fabricante = contex.Fabricantes.Find(id);
            if (fabricante == null)
            {
                //Se não, dá um erro
                return HttpNotFound();
            }
            return View(fabricante);
        }

        //POST: Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Fabricante fabricante = contex.Fabricantes.Find(id);
            contex.Fabricantes.Remove(fabricante);
            contex.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}