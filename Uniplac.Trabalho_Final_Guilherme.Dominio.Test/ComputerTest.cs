using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio;
using Dominio.Exceptions;

namespace Uniplac.Trabalho_Final_Guilherme.Dominio.Test
{
    [TestClass]
    public class ComputerTest
    {
        [TestMethod]
        public void Should_Create_Computer_Valid()
        {
            Computer computer = new Computer("Model GC", "DELL", TypeComputerEnum.Notebook);
            Assert.AreEqual("Model GC: DELL", computer.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void Should_Create_Computer_Invalid_Model()
        {
            Computer computer = new Computer(null, "DELL", TypeComputerEnum.Notebook);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void Should_Create_Computer_Invalid_Brand()
        {
            Computer computer = new Computer("Model GC", null, TypeComputerEnum.Notebook);
        }
    }
}
