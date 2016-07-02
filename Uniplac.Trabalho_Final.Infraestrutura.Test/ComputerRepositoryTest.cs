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
    public class ComputerRepositoryTest
    {
        private StoreContext _context;
        private ComputerRepository _repository;

        [TestInitialize]
        public void Initialize()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<StoreContext>());
            _context = new StoreContext();
            _context.Database.Initialize(true);
            _repository = new ComputerRepository();
        }

        [TestMethod]
        public void Should_Create_And_Save_A_Computer()
        {
            Computer computer = new Computer("Modelo DC", "DELL", TypeComputerEnum.Notebook);
            _repository.Create(computer);
            Computer computerTest = _context.Computers.Find(computer.Id);
            Assert.IsNotNull(computerTest);
        }

        [TestMethod]
        public void Should_Delete_A_Computer()
        {
            // Create Computer
            Computer computer = new Computer("Modelo DC", "DELL", TypeComputerEnum.Notebook);
            _context.Computers.Add(computer);
            _context.SaveChanges();
            // Delete with repository and update context
            _repository.Delete(computer);
            _context.Entry(computer).Reload();
            //Test
            Computer computerTest = _context.Computers.Find(computer.Id);
            Assert.IsNull(computerTest);
        }

        [TestMethod]
        public void Should_Update_A_Computer()
        {
            // Create Computer
            Computer computer = new Computer("Modelo DC", "DELL", TypeComputerEnum.Notebook);
            _context.Computers.Add(computer);
            _context.SaveChanges();
            // Delete with repository and update context
            computer.Model = "Model AB";
            _repository.Update(computer);
            _context.Entry(computer).Reload();
            //Test
            Computer computerTest = _context.Computers.Find(computer.Id);
            Assert.AreEqual("Model AB", computerTest.Model);
        }

        [TestMethod]
        public void Should_Find_A_Computer()
        {
            // Create Computer
            Computer computer = new Computer("Modelo DC", "DELL", TypeComputerEnum.Notebook);
            _context.Computers.Add(computer);
            _context.SaveChanges();
            //Test
            Computer computerTest = _repository.Read(computer.Id);
            Assert.AreEqual(computer.Id, computerTest.Id);
        }

        [TestMethod]
        public void Should_Find_All_Computers()
        {
            // Create Computer
            Computer computer = new Computer("Modelo DC", "DELL", TypeComputerEnum.Notebook);
            _context.Computers.Add(computer);
            _context.SaveChanges();
            //Test
            List<Computer> computersListTest = _repository.ReadAll();
            Assert.AreEqual(1, computersListTest.Count);
        }
    }
}
