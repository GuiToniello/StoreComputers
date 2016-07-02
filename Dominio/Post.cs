using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Post
    {
        public long PostId { get; set; }

        public string PostMessage { get; set; }

        public DateTime PostDate { get; set; }

        public Post()
        {

        }

        public Post(string postMessage)
        {
            this.PostMessage = postMessage;
        }

        public Post(Computer computer)
        {
            var type = "";
            switch (computer.Type)
            {
                case TypeComputerEnum.Desktop:
                    type = "Desktop";
                    break;
                case TypeComputerEnum.Hybrid:
                    type = "Híbrido";
                    break;
                case TypeComputerEnum.Notebook:
                    type = "Notebook";
                    break;
            };
            this.PostMessage = String.Format("Novo {0}: {1} - {2}", type, computer.Model, computer.Brand);
        }
    }
}
