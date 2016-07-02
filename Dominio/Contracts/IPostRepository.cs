using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Contracts
{
    public interface IPostRepository
    {
        Post SaveOrUpdate(Post post);
        Post Get(long id);
        IEnumerable<Post> GetAll();
    }
}
