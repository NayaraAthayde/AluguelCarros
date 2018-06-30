using System;
using System.Data.Entity;
using System.Linq;
using AluguelCarros.Dominio.Entidades;
using AluguelCarros.Infra.Dados.Contexto;
using AluguelCarros.Infra.Dados.Repositorios;
using AluguelCarros.Testes.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AluguelCarros.Testes.Infra_Testes
{
    [TestClass]
    public class AluguelRepositorioTestes
    {
        private AluguelCarrosContexto _contextoTeste;
        private AluguelRepositorio _repositorio;
        private Aluguel _aluguel;

        [TestInitialize]
        public void Inicializador()
        {
            Database.SetInitializer(new InializadorBanco<AluguelCarrosContexto>());

            _contextoTeste = new AluguelCarrosContexto();

            _repositorio = new AluguelRepositorio(_contextoTeste);

            _aluguel = ConstrutorObjeto.CriarAluguel();

            _contextoTeste.Database.Initialize(true);
        }

        [TestMethod]
        public void Deveria_adicionar_um_novo_aluguel()
        {
            _repositorio.Adicionar(_aluguel);

            var todosAlugueis = _contextoTeste.Aluguel.ToList();

            Assert.AreEqual(2, todosAlugueis.Count);
        }

        [TestMethod]
        public void Deveria_editar_um_aluguel()
        {
            var aluguelEditado = _contextoTeste.Aluguel.Find(1);
            aluguelEditado.Dias = 1;

            _repositorio.Editar(aluguelEditado);

            var aluguelBuscado = _contextoTeste.Aluguel.Find(1);

            Assert.AreEqual(1, aluguelBuscado.Dias);
        }

        [TestMethod]
        public void Deveria_deletar_um_aluguel()
        {
            var aluguel = ConstrutorObjeto.CriarAluguel();
            _repositorio.Adicionar(aluguel);

            var aluguelDeletado = _contextoTeste.Aluguel.Find(2);

            _repositorio.Deletar(aluguelDeletado);

            var todosAlugueis = _contextoTeste.Aluguel.ToList();

            Assert.AreEqual(1, todosAlugueis.Count);
        }

        [TestMethod]
        public void Deveria_buscar_aluguel_por_id()
        {
            var aluguelBuscado = _repositorio.BuscarPorId(1);

            Assert.IsNotNull(aluguelBuscado);
        }

        [TestMethod]
        public void Deveria_buscar_todos_os_aluguels()
        {
            var aluguelBuscado = _repositorio.BuscarTodos();

            Assert.IsNotNull(aluguelBuscado);
        }        
    }
}
