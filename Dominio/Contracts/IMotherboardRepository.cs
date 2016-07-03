using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Contracts
{
    public interface IMotherboardRepository
    {
        void Create(Motherboard motherboard);

        Motherboard Read(int id);

        List<Motherboard> ReadAll();

        Motherboard Update(Motherboard motherboard);

        void Delete(Motherboard motherboard);  
    }
}
