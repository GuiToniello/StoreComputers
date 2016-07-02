using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Uniplac.Trabalho_Final_Guilherme.Infraestrutura.Repositories;
using Dominio.Contracts;

namespace Uniplac.Trabalho_Final_Guilherme.Aplicacao
{
    public class ComputerService : IComputerService
    {
        private IComputerRepository _repository;
        private IPostRepository _postRepository;


        public ComputerService(IComputerRepository repository, IPostRepository postRepository)
        {
            _repository = repository;
            _postRepository = postRepository;
        }

        public Post Create(Computer computer)
        {
            _repository.Create(computer);
            // Ao cadastrar um computador, é criado um post no twitter
            Post post = new Post(computer);
            _postRepository.SaveOrUpdate(post);
            return post;
        }

        public void Delete(Computer computer)
        {
            _repository.Delete(computer);
        }

        public Computer Read(int id)
        {
           return _repository.Read(id);
        }

        public List<Computer> ReadAll()
        {
            return _repository.ReadAll();
        }

        public Computer Update(Computer computer)
        {
            return _repository.Update(computer);
        }
    }
}
