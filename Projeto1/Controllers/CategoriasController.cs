﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto1.Models;
using System.Data.Entity;
using Projeto1.Contexts;
using System.Net;

namespace Projeto1.Controllers
{
    public class CategoriasController : Controller
    {
        private EFContext context = new EFContext();

        // GET: Categorias
        public ActionResult Index()
        {
            return View(context.Categorias.OrderBy(c => c.Nome));
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            //Adicionando a categoria na lista
            context.Categorias.Add(categoria);
            context.SaveChanges();
            return RedirectToAction("Index");

            /*//Pegando o id do valor máximo da lista + 1 
            categoria.CategoriaID = categorias.Select(m => m.CategoriaID).Max() + 1;
            */
        }

        //GET: Edit
        public ActionResult Edit(long? id)
        {
            /*//Retorna a View com o ID passado (ID é achado na lista com LINQ)
            return View(categorias.Where(m => m.CategoriaID == id).First());*/
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Tenta achar o fabricante
            Categoria categoria = context.Categorias.Find(id);
            if (categoria == null)
            {
                //Se não, dá um erro
                return HttpNotFound();
            }
            return View(categoria);
        }

        //POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                context.Entry(categoria).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        //GET: Details
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Tenta achar o fabricante
            Categoria categoria = context.Categorias.Find(id);
            if (categoria == null)
            {
                //Se não, dá um erro
                return HttpNotFound();
            }
            return View(categoria);
        }

        //GET: Delete
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Tenta achar o fabricante
            Categoria categoria = context.Categorias.Find(id);
            if (categoria == null)
            {
                //Se não, dá um erro
                return HttpNotFound();
            }
            return View(categoria);
        }

        //POST: Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Categoria categoria = context.Categorias.Find(id);
            context.Categorias.Remove(categoria);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}