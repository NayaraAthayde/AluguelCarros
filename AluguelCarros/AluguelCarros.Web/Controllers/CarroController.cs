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
    public class CarroController : Controller
    {
        private static AluguelCarrosContexto _contexto = new AluguelCarrosContexto();
        private readonly CarroRepositorio _repositorio = new CarroRepositorio(_contexto);

        // GET: Carro
        public ActionResult Index()
        {
            return View(_repositorio.BuscarTodos());
        }

        // GET: Carro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro carro = _repositorio.BuscarPorId((int)id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

        // GET: Carro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carro/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Marca,Modelo,Cor,ValorDiario")] Carro carro)
        {
            if (ModelState.IsValid)
            {
                _repositorio.Adicionar(carro);
                return RedirectToAction("Index");
            }

            return View(carro);
        }

        // GET: Carro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro carro = _repositorio.BuscarPorId((int)id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

        // POST: Carro/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Marca,Modelo,Cor,ValorDiario")] Carro carro)
        {
            var car = _repositorio.BuscarPorId((int)carro.Id);
            car.Marca = carro.Marca;
            car.Modelo = carro.Modelo;
            car.Cor = carro.Cor;
            car.ValorDiario = carro.ValorDiario;

            if (ModelState.IsValid)
            {
                _repositorio.Editar(car);
                return RedirectToAction("Index");
            }
            return View(carro);
        }

        // GET: Carro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro carro = _repositorio.BuscarPorId((int)id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

        // POST: Carro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Carro carro = _repositorio.BuscarPorId(id);
            _repositorio.Deletar(carro);
            return RedirectToAction("Index");
        }
    }
}
