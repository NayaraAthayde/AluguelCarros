using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AluguelCarros.Dominio.Entidades;
using AluguelCarros.Infra.Dados.Contexto;
using AluguelCarros.Infra.Dados.Repositorios;

namespace AluguelCarros.Web.Controllers
{
    public class AluguelController : Controller
    {
        private static AluguelCarrosContexto _contexto = new AluguelCarrosContexto();
        private readonly AluguelRepositorio _repositorio = new AluguelRepositorio(_contexto);


        // GET: Aluguel
        public ActionResult Index()
        {
            return View(_repositorio.BuscarTodos());
        }

        // GET: Aluguel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluguel aluguel = _repositorio.BuscarPorId((int)id);
            if (aluguel == null)
            {
                return HttpNotFound();
            }
            return View(aluguel);
        }

        // GET: Aluguel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Aluguel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Dias")] Aluguel aluguel)
        {
            if (ModelState.IsValid)
            {
                _repositorio.Adicionar(aluguel);
                return RedirectToAction("Index");
            }

            return View(aluguel);
        }

        // GET: Aluguel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluguel aluguel = _repositorio.BuscarPorId((int)id);
            if (aluguel == null)
            {
                return HttpNotFound();
            }
            return View(aluguel);
        }

        // POST: Aluguel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Dias")] Aluguel aluguel)
        {
            if (ModelState.IsValid)
            {
                _repositorio.Editar(aluguel);
                return RedirectToAction("Index");
            }
            return View(aluguel);
        }

        // GET: Aluguel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluguel aluguel = _repositorio.BuscarPorId((int)id);
            if (aluguel == null)
            {
                return HttpNotFound();
            }
            return View(aluguel);
        }

        // POST: Aluguel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aluguel aluguel = _repositorio.BuscarPorId(id);
            _repositorio.Deletar(aluguel);
            return RedirectToAction("Index");
        }
    }
}
