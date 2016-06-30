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
        { new Categoria(1,"Notebooks"),new Categoria(2,"Monitores"),new Categoria(3,"Impressoras"),new Categoria(4,"Mouses"),new Categoria(5,"Desktops")};

        // GET: Categorias
        public ActionResult Index()
        {
            return View(categorias);
        }
    }
}