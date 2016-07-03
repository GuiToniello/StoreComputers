using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniplac.Trabalho_Final_Guilherme.Aplicacao
{
    public interface IMotherboardService
    {
        Post Create(Motherboard motherboard);

        Motherboard Read(int id);

        List<Motherboard> ReadAll();

        Motherboard Update(Motherboard motherboard);

        void Delete(Motherboard motherboard);
    }
}
