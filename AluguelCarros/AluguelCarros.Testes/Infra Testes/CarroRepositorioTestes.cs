using AluguelCarros.Dominio.Entidades;
using AluguelCarros.Infra.Dados.Contexto;
using AluguelCarros.Infra.Dados.Repositorios;
using AluguelCarros.Testes.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluguelCarros.Testes.Infra_Testes
{
    [TestClass]
    public class CarroRepositorioTestes
    {
        private AluguelCarrosContexto _contextoTeste;
        private CarroRepositorio _repositorio;
        private Carro _carro;

        [TestInitialize]
        public void Inicializador()
        {
            Database.SetInitializer(new InializadorBanco<AluguelCarrosContexto>());

            _contextoTeste = new AluguelCarrosContexto();

            _repositorio = new CarroRepositorio(_contextoTeste);

            _carro = ConstrutorObjeto.CriarCarro();

            _contextoTeste.Database.Initialize(true);
        }

        [TestMethod]
        public void Deveria_adicionar_um_novo_carro()
        {
            _repositorio.Adicionar(_carro);

            var todosCarros = _contextoTeste.Carros.ToList();

            Assert.AreEqual(2, todosCarros.Count);
        }

        [TestMethod]
        public void Deveria_editar_um_carro()
        {
            var carroEditado = _contextoTeste.Carros.Find(1);
            carroEditado.Modelo = "Civic 2014";

            _repositorio.Editar(carroEditado);

            var carroBuscado = _contextoTeste.Carros.Find(1);

            Assert.AreEqual("Civic 2014", carroBuscado.Modelo);
        }

        [TestMethod]
        public void Deveria_deletar_um_carro()
        {
            var carro = ConstrutorObjeto.CriarCarro();
            _repositorio.Adicionar(carro);

            var carroDeletado = _contextoTeste.Carros.Find(2);

            _repositorio.Deletar(carroDeletado);

            var todosCarros = _contextoTeste.Carros.ToList();

            Assert.AreEqual(1, todosCarros.Count);
        }

        [TestMethod]
        public void Deveria_buscar_carro_por_id()
        {

            var carroBuscado = _repositorio.BuscarPorId(1);

            Assert.IsNotNull(carroBuscado);
        }

        [TestMethod]
        public void Deveria_buscar_todos_os_carros()
        {
            var carroBuscado = _repositorio.BuscarTodos();

            Assert.IsNotNull(carroBuscado);
        }
    }
}
