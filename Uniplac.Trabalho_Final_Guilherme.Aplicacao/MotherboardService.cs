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
    public class MotherboardService : IMotherboardService
    {
        private IMotherboardRepository _repository;
        private IPostRepository _postRepository;


        public MotherboardService(IMotherboardRepository repository, IPostRepository postRepository)
        {
            _repository = repository;
            _postRepository = postRepository;
        }

        public Post Create(Motherboard computer)
        {
            _repository.Create(computer);
            // Ao cadastrar um computador, é criado um post no twitter
            Post post = new Post(computer);
            _postRepository.SaveOrUpdate(post);
            return post;
        }

        public void Delete(Motherboard computer)
        {
            _repository.Delete(computer);
        }

        public Motherboard Read(int id)
        {
           return _repository.Read(id);
        }

        public List<Motherboard> ReadAll()
        {
            return _repository.ReadAll();
        }

        public Motherboard Update(Motherboard computer)
        {
            return _repository.Update(computer);
        }
    }
}
