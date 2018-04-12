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
    public class FabricantesController : Controller
    {
        private EFContext context = new EFContext(); //uso da classe context para acessar as entidades
        //Get para gerar o Index                                             
        public ActionResult Index()
        {
            return View(context.Fabricantes.OrderBy(c => c.Nome));
        }
        //Post para Creat
        [HttpPost]
        public ActionResult Create(string nome)
        {
            Fabricante fabricante = new Fabricante();
            fabricante.Nome = nome;
            context.Fabricantes.Add(fabricante);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        //Post para Edit
        [HttpPost]
        public ActionResult Edit(long id, string nome)
        {
            Fabricante fabricante = context.Fabricantes.Find(id);
            fabricante.Nome = nome;
            context.Entry(fabricante).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        //Post para Delete
        [HttpPost]
        public ActionResult Delete(long id)
        {
            Fabricante fabricante = context.Fabricantes.Find(id);
            context.Fabricantes.Remove(fabricante);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}