using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio;
using Dominio.Exceptions;

namespace Uniplac.Trabalho_Final_Guilherme.Dominio.Test
{
    [TestClass]
    public class MotherboardTest
    {
        [TestMethod]
        public void Should_Create_Motherboard_Valid()
        {
            Motherboard motherboard = new Motherboard("Model GC", "DELL", TypeMotherboardEnum.Notebook);
            Assert.AreEqual("Model GC: DELL", motherboard.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void Should_Create_Motherboard_Invalid_Model()
        {
            Motherboard computer = new Motherboard(null, "DELL", TypeMotherboardEnum.Notebook);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void Should_Create_Motherboard_Invalid_Brand()
        {
            Motherboard computer = new Motherboard("Model GC", null, TypeMotherboardEnum.Notebook);
        }
    }
}
