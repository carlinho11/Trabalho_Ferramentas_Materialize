using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Trabalho4_MVC.Models;
using Trabalho4_MVC.Contexts;
using System.Net;

namespace Trabalho4_MVC.Controllers
{
    public class ProdutosController : Controller
    {
        private EFContext context = new EFContext();
        //Get para gerar a Index
        public ActionResult Index()
        {   
            var produtos = context.Produtos.Include(context => context.Categoria).Include(f => f.Fabricante).OrderBy(n => n.Nome);
            ViewBag.Categoria = (List<Categoria>)context.Categorias.OrderBy(c => c.Nome).ToList();
            ViewBag.Fabricante = (List<Fabricante>)context.Fabricantes.OrderBy(c => c.Nome).ToList();
            return View(produtos);
        }
        //Post para Creat
        [HttpPost]
        public ActionResult Create(string nome, long categoria, long fabricante)
        {
            Produto produto = new Produto();
            produto.Nome = nome;
            produto.CategoriaID = categoria;
            produto.FabricanteID = fabricante;
            context.Produtos.Add(produto);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        //Post para Edit
        [HttpPost]
        public ActionResult Edit(long id, string nome, long categoria, long fabricante)
        {
            Produto produto = context.Produtos.Find(id);
            produto.Nome = nome;
            produto.CategoriaID = categoria;
            produto.FabricanteID = fabricante;
            context.Entry(produto).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");

        }
        //Post para Delete
        [HttpPost]
        public ActionResult Delete(long id)
        {
            Produto produto = context.Produtos.Find(id);
            context.Produtos.Remove(produto);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
