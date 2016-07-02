using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Contracts
{
    public interface IComputerRepository
    {
        void Create(Computer computer);

        Computer Read(int id);

        List<Computer> ReadAll();

        Computer Update(Computer computer);

        void Delete(Computer computer);  
    }
}
