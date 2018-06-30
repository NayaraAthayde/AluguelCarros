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
    public class ClienteRepositorioTeste
    {
        private AluguelCarrosContexto _contextoTeste;
        private ClienteRepositorio _repositorio;
        private Cliente _clienteTest;

        [TestInitialize]
        public void Inicializador()
        {
            Database.SetInitializer(new InializadorBanco<AluguelCarrosContexto>());

            _contextoTeste = new AluguelCarrosContexto();

            _repositorio = new ClienteRepositorio(_contextoTeste);

            _clienteTest = ConstrutorObjeto.CriarCliente();

            _contextoTeste.Database.Initialize(true);
        }

        [TestMethod]
        public void Deveria_adicionar_um_novo_cliente()
        {
            _repositorio.Adicionar(_clienteTest);

            var todosClientes = _contextoTeste.Clientes.ToList();

            Assert.AreEqual(2, todosClientes.Count);
        }

        [TestMethod]
        public void Deveria_editar_um_cliente()
        {
            var clienteEditado = _contextoTeste.Clientes.Find(1);
            clienteEditado.PrimeiroNome = "qq";
            
            _repositorio.Editar(clienteEditado);

            var clienteBuscado = _contextoTeste.Clientes.Find(1);

            Assert.AreEqual("qq", clienteBuscado.PrimeiroNome);
        }

        [TestMethod]
        public void Deveria_deletar_um_cliente()
        {
            var cliente = ConstrutorObjeto.CriarCliente();
            _repositorio.Adicionar(cliente);

            var clienteDeletado = _contextoTeste.Clientes.Find(2);
            
            _repositorio.Deletar(clienteDeletado);
            
            var todosClientes = _contextoTeste.Clientes.ToList();

            Assert.AreEqual(1, todosClientes.Count);
        }

        [TestMethod]
        public void Deveria_buscar_cliente_por_id()
        {

            var clienteBuscado = _repositorio.BuscarPorId(1);
            
            Assert.IsNotNull(clienteBuscado);
        }

        [TestMethod]
        public void Deveria_buscar_todos_os_clientes()
        {
            var clienteBuscado = _repositorio.BuscarTodos();

            Assert.IsNotNull(clienteBuscado);
        }

        [TestMethod]
        public void Deveria_buscar_cliente_por_nome()
        {
            var clienteBuscado = _repositorio.BuscarPorNome("Nayara");

            Assert.IsNotNull(clienteBuscado);
        }
    }
}
