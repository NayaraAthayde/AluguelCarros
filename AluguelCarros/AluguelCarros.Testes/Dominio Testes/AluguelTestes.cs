using AluguelCarros.Dominio.Entidades;
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
    public class AluguelTestes
    {
        private Aluguel _aluguel;

        [TestInitialize]
        public void Inicializador()
        {
            _aluguel = ConstrutorObjeto.CriarAluguel();
        }
        [TestMethod]
        public void Aluguel_deve_ter_cliente()
        {
            Assert.IsNotNull(_aluguel.Cliente);
        }
        [TestMethod]
        public void Aluguel_deve_ter_carro()
        {
            Assert.IsNotNull(_aluguel.Carro);
        }
        [TestMethod]
        public void Aluguel_deve_ter_dias_de_aluguel()
        {
            Assert.AreEqual(2, _aluguel.Dias);
        }
        [TestMethod]
        public void Aluguel_deve_calcular_valorTotal()
        {
            Assert.AreEqual(3000, _aluguel.ValorTotal);
        }
    }
}
