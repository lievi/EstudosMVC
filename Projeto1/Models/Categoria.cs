using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto1.Models
{
    public class Categoria
    {
        public long CategoriaID { get; set; }
        public string Nome { get; set; }

        public Categoria(long categoriaID, string nome)
        {
            this.CategoriaID = categoriaID;
            this.Nome = nome;
        }
    }
}