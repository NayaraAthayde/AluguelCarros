using AluguelCarros.Dominio.Entidades;
using AluguelCarros.Dominio.Excecoes;
using AluguelCarros.Testes.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluguelCarros.Testes.Dominio_Testes
{
    [TestClass]
    public class CarroTestes
    {
        private Carro _carro;

        [TestInitialize]
        public void Inicializador()
        {
            _carro = ConstrutorObjeto.CriarCarro();
        }
        [TestMethod]
        public void Carro_deve_ter_marca()
        {
            Assert.AreEqual("Honda", _carro.Marca);
        }
        [TestMethod]
        public void Carro_deve_ter_modelo()
        {
            Assert.AreEqual("Civic 2018", _carro.Modelo);
        }
        [TestMethod]
        public void Carro_deve_ter_cor()
        {
            Assert.AreEqual("Preto", _carro.Cor);
        }
        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Carro_nao_tem_modelo_valido()
        {
            _carro.Modelo = "";

            _carro.Validar();
        }
        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Carro_nao_tem_marca_valida()
        {
            _carro.Marca = "";

            _carro.Validar();
        }
        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Carro_nao_tem_cor_valida()
        {
            _carro.Cor = "";

            _carro.Validar();
        }
        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Carro_nao_tem_valor_valido()
        {
            _carro.ValorDiario = -1500;
            _carro.Validar();
        }
    }
}
