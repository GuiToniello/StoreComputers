using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using Uniplac.Trabalho_Final_Guilherme.Infraestrutura.Context;
using Dominio;
using Uniplac.Trabalho_Final_Guilherme.Infraestrutura.Repositories;
using System.Collections.Generic;

namespace Uniplac.Trabalho_Final.Infraestrutura.Test
{
    [TestClass]
    public class MotherboardRepositoryTest
    {
        private StoreContext _context;
        private MotherboardRepository _repository;

        [TestInitialize]
        public void Initialize()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<StoreContext>());
            _context = new StoreContext();
            _context.Database.Initialize(true);
            _repository = new MotherboardRepository();
        }

        [TestMethod]
        public void Should_Create_And_Save_A_Motherboard()
        {
            Motherboard motherboard = new Motherboard("Modelo DC", "DELL", TypeMotherboardEnum.Notebook);
            _repository.Create(motherboard);
            Motherboard motherboardTest = _context.Motherboards.Find(motherboard.Id);
            Assert.IsNotNull(motherboardTest);
        }

        [TestMethod]
        public void Should_Delete_A_Motherboard()
        {
            // Create Motherboard
            Motherboard motherboard = new Motherboard("Modelo DC", "DELL", TypeMotherboardEnum.Notebook);
            _context.Motherboards.Add(motherboard);
            _context.SaveChanges();
            // Delete with repository and update context
            _repository.Delete(motherboard);
            _context.Entry(motherboard).Reload();
            //Test
            Motherboard motherboardTest = _context.Motherboards.Find(motherboard.Id);
            Assert.IsNull(motherboardTest);
        }

        [TestMethod]
        public void Should_Update_A_Motherboard()
        {
            // Create Motherboard
            Motherboard motherboard = new Motherboard("Modelo DC", "Intel", TypeMotherboardEnum.Notebook);
            _context.Motherboards.Add(motherboard);
            _context.SaveChanges();
            // Delete with repository and update context
            motherboard.Model = "Model AB";
            _repository.Update(motherboard);
            _context.Entry(motherboard).Reload();
            //Test
            Motherboard motherboardTest = _context.Motherboards.Find(motherboard.Id);
            Assert.AreEqual("Model AB", motherboardTest.Model);
        }

        [TestMethod]
        public void Should_Find_A_Motherboard()
        {
            // Create Motherboard
            Motherboard motherboard = new Motherboard("Modelo DC", "Intel", TypeMotherboardEnum.Notebook);
            _context.Motherboards.Add(motherboard);
            _context.SaveChanges();
            //Test
            Motherboard motherboardTest = _repository.Read(motherboard.Id);
            Assert.AreEqual(motherboard.Id, motherboardTest.Id);
        }

        [TestMethod]
        public void Should_Find_All_Motherboards()
        {
            // Create Motherboard
            Motherboard motherboard = new Motherboard("Modelo DC", "Intel", TypeMotherboardEnum.Notebook);
            _context.Motherboards.Add(motherboard);
            _context.SaveChanges();
            //Test
            List<Motherboard> motherboardsListTest = _repository.ReadAll();
            Assert.AreEqual(1, motherboardsListTest.Count);
        }
    }
}
