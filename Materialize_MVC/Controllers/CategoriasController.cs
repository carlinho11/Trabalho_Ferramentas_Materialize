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
    public class CategoriasController : Controller
    {
        private EFContext context = new EFContext(); //Uso da classe context para acessar as entidades
        //Get para gerar o Index
        public ActionResult Index()
        {
            return View(context.Categorias.OrderBy(c => c.Nome));
        }
        //Post para Creat
        [HttpPost]
        public ActionResult Create(string nome)
        {
            Categoria categoria = new Categoria();
            categoria.Nome = nome;
            context.Categorias.Add(categoria);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        //Post para Edit
        [HttpPost]
        public ActionResult Edit(long id, string nome) 
        {
            Categoria categoria = context.Categorias.Find(id);
            categoria.Nome = nome;
            context.Entry(categoria).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        //Post para Delete
        [HttpPost]
        public ActionResult Delete(long id) 
        {
            Categoria categoria = context.Categorias.Find(id);
            context.Categorias.Remove(categoria);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}