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
    public class ClienteController : Controller
    {
        private static AluguelCarrosContexto _contexto = new AluguelCarrosContexto();
        private readonly ClienteRepositorio _repositorio = new ClienteRepositorio(_contexto);

        // GET: Cliente
        public ActionResult Index()
        {
            return View(_repositorio.BuscarTodos());
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = _repositorio.BuscarPorId((int)id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PrimeiroNome,Sobrenome,Endereco,Telefone")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _repositorio.Adicionar(cliente);
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = _repositorio.BuscarPorId((int)id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PrimeiroNome,Sobrenome,Endereco,Telefone")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _repositorio.Editar(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = _repositorio.BuscarPorId((int)id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = _repositorio.BuscarPorId(id);
            _repositorio.Deletar(cliente);
            return RedirectToAction("Index");
        }
    }
}
