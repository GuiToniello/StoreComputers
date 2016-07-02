using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Dominio.Contracts;
using Dominio;

namespace Uniplac.Trabalho_Final_Guilherme.Aplicacao.Test
{
    [TestClass]
    public class ComputerServiceTest
    {

        private Mock<IComputerRepository> _mockRepository;
        private Mock<IPostRepository> _mockPostRepository;


        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IComputerRepository>();
            _mockPostRepository = new Mock<IPostRepository>();

        }

        [TestMethod]
        public void Create_Computer_Service_Test()
        {
            Computer computer = new Computer("Model DC", "DELL", TypeComputerEnum.Notebook);
            IComputerService service = new ComputerService(_mockRepository.Object, _mockPostRepository.Object);
            Post post = service.Create(computer);
            _mockRepository.Verify(repo => repo.Create(computer));
            _mockPostRepository.Verify(repo => repo.SaveOrUpdate(post));

        }


        [TestMethod]
        public void Delete_Computer_Service_Test()
        {
            Computer computer = new Computer("Model DC", "DELL", TypeComputerEnum.Notebook);
            IComputerService service = new ComputerService(_mockRepository.Object, _mockPostRepository.Object);
            service.Delete(computer);
            _mockRepository.Verify(repo => repo.Delete(computer));
        }

        [TestMethod]
        public void Update_Computer_Service_Test()
        {
            Computer computer = new Computer("Model DC", "DELL", TypeComputerEnum.Notebook);
            IComputerService service = new ComputerService(_mockRepository.Object, _mockPostRepository.Object);
            service.Update(computer);
            _mockRepository.Verify(repo => repo.Update(computer));
        }

        [TestMethod]
        public void Read_Computer_Service_Test()
        {
            IComputerService service = new ComputerService(_mockRepository.Object, _mockPostRepository.Object);
            service.Read(1);
            _mockRepository.Verify(repo => repo.Read(1));
        }

        [TestMethod]
        public void ReadAll_Computer_Service_Test()
        {
            IComputerService service = new ComputerService(_mockRepository.Object, _mockPostRepository.Object);
            service.ReadAll();
            _mockRepository.Verify(repo => repo.ReadAll());
        }
    }
}
