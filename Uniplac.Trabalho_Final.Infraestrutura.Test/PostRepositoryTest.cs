using Dominio;
using Infraestrutura.Data.Twitter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniplac.Trabalho_Final.Infraestrutura.Test
{
    [TestClass]
    public class PostRepositoryTest
    {
        private PostRepository _repository;


        [TestInitialize]
        public void Initialize()
        {
            _repository = new PostRepository();
        }

        [TestMethod]
        public void Should_Create_Post_Test()
        {
            Post post = new Post("Post Create Test " + new Random().Next());
            _repository.SaveOrUpdate(post);
            Assert.IsTrue(post.PostId > 0);
        }

        public void Should_Get_Post_Test()
        {
            List<Post> posts = _repository.GetAll().ToList();
            var postId = posts.FirstOrDefault().PostId ; // Colocar Id de um post
            Post post = _repository.Get(postId);
            Assert.IsNotNull(post);
        }

        public void Should_Get_All_Posts_Test()
        {
            List<Post> posts = _repository.GetAll().ToList();
            Assert.IsNotNull(posts);
            Assert.IsTrue(posts.Count > 0);
        }
    }
}
