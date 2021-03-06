﻿using AluguelCarros.Dominio.Entidades;
using AluguelCarros.Infra.Dados.Contexto;
using AluguelCarros.Infra.Dados.Repositorios;
using System;
using System.Net;
using System.Web.Mvc;

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
                using (var dbTransact = _contexto.Database.BeginTransaction())
                {
                    try
                    {
                        _repositorio.Adicionar(cliente);
                        dbTransact.Commit();
                    }
                    catch (Exception)
                    {
                        dbTransact.Rollback();
                    }
                }                
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
            var client = _repositorio.BuscarPorId((int)cliente.Id);
            client.PrimeiroNome = cliente.PrimeiroNome;
            client.Sobrenome = cliente.Sobrenome;
            client.Telefone = cliente.Telefone;
            client.Endereco.Bairro = cliente.Endereco.Bairro;
            client.Endereco.Cep = cliente.Endereco.Cep;
            client.Endereco.Complemento = cliente.Endereco.Complemento;
            client.Endereco.Localidade = cliente.Endereco.Localidade;
            client.Endereco.Logradouro = cliente.Endereco.Logradouro;
            client.Endereco.Numero = cliente.Endereco.Numero;
            client.Endereco.Uf = cliente.Endereco.Uf;

            if (ModelState.IsValid)
            {
                using (var dbTransact = _contexto.Database.BeginTransaction())
                {
                    try
                    {
                        _repositorio.Editar(client);

                        dbTransact.Commit();
                    }
                    catch (Exception)
                    {
                        dbTransact.Rollback();
                    }
                }                
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
            using (var dbTransact = _contexto.Database.BeginTransaction())
            {
                try
                {
                    Cliente cliente = _repositorio.BuscarPorId(id);
                    _repositorio.Deletar(cliente);

                    dbTransact.Commit();
                }
                catch (Exception)
                {
                    dbTransact.Rollback();
                }
            }
            return RedirectToAction("Index");
        }
    }
}
