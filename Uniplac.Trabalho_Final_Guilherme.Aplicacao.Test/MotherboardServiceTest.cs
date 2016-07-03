using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Dominio.Contracts;
using Dominio;

namespace Uniplac.Trabalho_Final_Guilherme.Aplicacao.Test
{
    [TestClass]
    public class MotherboardServiceTest
    {

        private Mock<IMotherboardRepository> _mockRepository;
        private Mock<IPostRepository> _mockPostRepository;


        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IMotherboardRepository>();
            _mockPostRepository = new Mock<IPostRepository>();

        }

        [TestMethod]
        public void Create_Motherboard_Service_Test()
        {
            Motherboard computer = new Motherboard("Model DC", "Intel", TypeMotherboardEnum.Notebook);
            IMotherboardService service = new MotherboardService(_mockRepository.Object, _mockPostRepository.Object);
            Post post = service.Create(computer);
            _mockRepository.Verify(repo => repo.Create(computer));
            _mockPostRepository.Verify(repo => repo.SaveOrUpdate(post));

        }


        [TestMethod]
        public void Delete_Motherboard_Service_Test()
        {
            Motherboard computer = new Motherboard("Model DC", "Intel", TypeMotherboardEnum.Notebook);
            IMotherboardService service = new MotherboardService(_mockRepository.Object, _mockPostRepository.Object);
            service.Delete(computer);
            _mockRepository.Verify(repo => repo.Delete(computer));
        }

        [TestMethod]
        public void Update_Motherboard_Service_Test()
        {
            Motherboard computer = new Motherboard("Model DC", "Intel", TypeMotherboardEnum.Notebook);
            IMotherboardService service = new MotherboardService(_mockRepository.Object, _mockPostRepository.Object);
            service.Update(computer);
            _mockRepository.Verify(repo => repo.Update(computer));
        }

        [TestMethod]
        public void Read_Motherboard_Service_Test()
        {
            IMotherboardService service = new MotherboardService(_mockRepository.Object, _mockPostRepository.Object);
            service.Read(1);
            _mockRepository.Verify(repo => repo.Read(1));
        }

        [TestMethod]
        public void ReadAll_Motherboard_Service_Test()
        {
            IMotherboardService service = new MotherboardService(_mockRepository.Object, _mockPostRepository.Object);
            service.ReadAll();
            _mockRepository.Verify(repo => repo.ReadAll());
        }
    }
}
