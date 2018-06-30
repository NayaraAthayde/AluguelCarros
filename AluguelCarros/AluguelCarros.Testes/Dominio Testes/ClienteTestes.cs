using System;
using AluguelCarros.Dominio.Entidades;
using AluguelCarros.Dominio.Excecoes;
using AluguelCarros.Testes.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AluguelCarros.Testes.Dominio_Testes
{
    [TestClass]
    public class ClienteTestes
    {
        private Cliente _cliente;

        [TestInitialize]
        public void Inicializador()
        {
            _cliente = ConstrutorObjeto.CriarCliente();
        }

        [TestMethod]
        public void Cliente_deve_ter_primeiro_nome()
        {
            Assert.AreEqual("Nayara", _cliente.PrimeiroNome);
        }

        [TestMethod]
        public void Cliente_deve_ter_sobrenome()
        {
            Assert.AreEqual("Athayde", _cliente.Sobrenome);
        }

        [TestMethod]
        public void Cliente_deve_ter_nome_completo()
        {
            Assert.AreEqual("Nayara Athayde", _cliente.NomeCompleto);
        }
        [TestMethod]
        public void Cliente_deve_ter_endereco_logradouro()
        {
            Assert.AreEqual("Rua Bezerra de Menezes", _cliente.Endereco.Logradouro);
        }
        [TestMethod]
        public void Cliente_deve_ter_endereco_numero()
        {
            Assert.AreEqual("123", _cliente.Endereco.Numero);
        }
        [TestMethod]
        public void Cliente_deve_ter_endereco_bairro()
        {
            Assert.AreEqual("Conta Dinheiro", _cliente.Endereco.Bairro);
        }
        [TestMethod]
        public void Cliente_deve_ter_endereco_localidade()
        {
            Assert.AreEqual("Lages", _cliente.Endereco.Localidade);
        }
        [TestMethod]
        public void Cliente_deve_ter_endereco_uf()
        {
            Assert.AreEqual("SC", _cliente.Endereco.Uf);
        }
        [TestMethod]
        public void Cliente_deve_ter_endereco_cep()
        {
            Assert.AreEqual("88519525", _cliente.Endereco.Cep);
        }
        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Cliente_deve_ter_um_primeiro_nome_valido()
        {
            _cliente.PrimeiroNome = "";

            _cliente.Validar();
        }

        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Cliente_nao_deve_ter_um_sobrenome_valido()
        {
            _cliente.Sobrenome = "";

            _cliente.Validar();
        }

        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Cliente_nao_deve_ter_um_telefone_valido()
        {
            _cliente.Telefone = "";

            _cliente.Validar();
        }

        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Cliente_nao_deve_ter_um_endereco_valido()
        {
            _cliente.Endereco = null;

            _cliente.Validar();
        }
    }
}
