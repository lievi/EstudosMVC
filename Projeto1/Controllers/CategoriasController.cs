using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto1.Models;

namespace Projeto1.Controllers
{
    public class CategoriasController : Controller
    {
        public static IList<Categoria> categorias = new List<Categoria>()
        {
          new Categoria { CategoriaID = 1, Nome = "Notebooks"},
          new Categoria() { CategoriaID = 2, Nome = "Monitores"},
          new Categoria() { CategoriaID = 3, Nome = "Impressoras"},
          new Categoria() { CategoriaID = 4, Nome = "Mouses" },
          new Categoria() {CategoriaID = 5, Nome = "Desktops" }
        };

        // GET: Categorias
        public ActionResult Index()
        {
            return View(categorias.OrderBy(c => c.Nome));
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
            categorias.Add(categoria);
            //Pegando o id do valor máximo da lista + 1 
            categoria.CategoriaID = categorias.Select(m => m.CategoriaID).Max() + 1;
            return RedirectToAction("Index");
        }

        //GET: Edit
        public ActionResult Edit(long id)
        {
            //Retorna a View com o ID passado (ID é achado na lista com LINQ)
            return View(categorias.Where(m => m.CategoriaID == id).First());
        }

        //POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            categorias.Remove(categorias.Where(m => m.CategoriaID == categoria.CategoriaID).First());
            categorias.Add(categoria);
            return RedirectToAction("Index");
        }

        //GET: Details
        public ActionResult Details(long id)
        {
            return View(categorias.Where(m => m.CategoriaID == id).First());
        }

        //GET: Delete
        public ActionResult Delete(long id)
        {
            return View(categorias.Where(m => m.CategoriaID == id).First());
        }

        //POST: Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Categoria categoria)
        {
            categorias.Remove(categorias.Where(m => m.CategoriaID == categoria.CategoriaID).First());
            return RedirectToAction("Index");
        }
    }
}