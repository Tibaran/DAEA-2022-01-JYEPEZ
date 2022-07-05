using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using lab14.Models;

namespace lab14.Controllers
{
    public class CategoriesController : Controller
    {
        #region
        private NORTHWNDEntities _contexto;

        public NORTHWNDEntities Contexto
        {
            set { _contexto = value;  }
            get
            {
                if(_contexto == null)
                {
                    _contexto = new NORTHWNDEntities();
                }
                return _contexto;
            }
        }
        #endregion
        // GET: Categories
        public ActionResult Index()
        {
            return View(Contexto.Categories.ToList());
        }

        // GET: /Categories/Details/5
        public ActionResult Details(int id)
        {
            var productosPorcategoria = from p in Contexto.Products
                                        orderby p.ProductName ascending
                                        where p.CategoryID == id
                                        select p;
            return View(productosPorcategoria.ToList());
        }

        // GET: /Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Categories/Create
        [HttpPost]
        public ActionResult Create(Category nuevaCategiria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Contexto.Categories.Add(nuevaCategiria);
                    Contexto.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(nuevaCategiria);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category categoriaEditar = Contexto.Categories.Find(id);

            if(categoriaEditar == null)
            {
                return HttpNotFound();
            }

            return View(categoriaEditar);
        }

        [HttpPost]
        public ActionResult Edit(Category categoriaEditar)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Contexto.Entry(categoriaEditar).State = System.Data.Entity.EntityState.Modified;
                    Contexto.SaveChanges();

                    return RedirectToAction("Index");
                }

                return View(categoriaEditar);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Category CategoriaEliminar = Contexto.Categories.Find(id);

            if (CategoriaEliminar == null)
                return HttpNotFound();

            return View(CategoriaEliminar);
        }
        
        [HttpPost]
        public ActionResult Delete(int? id, Category Categoria1)
        {
            try
            {
                Category CategoriaEliminar = new Category();
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    CategoriaEliminar = Contexto.Categories.Find(id);

                    if (CategoriaEliminar == null)
                        return HttpNotFound();

                    Contexto.Categories.Remove(CategoriaEliminar);
                    Contexto.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(CategoriaEliminar);
            }
            catch
            {
                return View();
            }
        }
    }
}