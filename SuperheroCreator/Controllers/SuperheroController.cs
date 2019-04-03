using SuperheroCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperheroCreator.Controllers
{
    public class SuperheroController : Controller
    {
        ApplicationDbContext context;
        public SuperheroController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Superhero
        public ActionResult Index()
        {
            var superheroList = context.Superheroes.ToList();
            return View(superheroList);
        }

        // GET: Superhero/Details/5
        public ActionResult Details(int id)
        {
            Superhero superhero = context.Superheroes.Where(s => s.Id.Equals(id)).SingleOrDefault();
            return View(superhero);
        }

        // GET: Superhero/Create
        public ActionResult Create()
        {
            Superhero superhero = new Superhero();
            return View();
        }

        // POST: Superhero/Create
        [HttpPost]
        public ActionResult Create(Superhero superhero)
        {
            try
            {
                // TODO: Add insert logic here
                context.Superheroes.Add(superhero);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Superhero/Edit/5
        public ActionResult Edit(int id)
        {
            Superhero superhero = context.Superheroes.Where(s => s.Id.Equals(id)).SingleOrDefault();
            return View(superhero);
        }

        // POST: Superhero/Edit/5
        [HttpPost]
        public ActionResult Edit(Superhero superhero, int id)
        {
            try
            {
                // TODO: Add update logic here
                Superhero originalSuperhero = context.Superheroes.Where(s => s.Id.Equals(id)).SingleOrDefault();
                originalSuperhero.name = superhero.name;
                originalSuperhero.alterEgo = superhero.alterEgo;
                originalSuperhero.primaryAbility = superhero.primaryAbility;
                originalSuperhero.secondaryAbility = superhero.secondaryAbility;
                originalSuperhero.catchphrase = superhero.catchphrase;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Superhero/Delete/5
        public ActionResult Delete(int id)
        {
            var superhero = context.Superheroes.Where(s => s.Id.Equals(id)).SingleOrDefault();
            return View(superhero);
        }

        // POST: Superhero/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Superhero superhero)
        {
            try
            {
                // TODO: Add delete logic here
                var originalSuperhero = context.Superheroes.Where(s => s.Id.Equals(id)).SingleOrDefault();
                context.Superheroes.Remove(originalSuperhero);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
