using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniplac.Trabalho_Final_Guilherme.Aplicacao
{
    public interface IComputerService
    {
        Post Create(Computer computer);

        Computer Read(int id);

        List<Computer> ReadAll();

        Computer Update(Computer computer);

        void Delete(Computer computer);
    }
}
