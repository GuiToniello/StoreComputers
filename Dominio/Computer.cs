using Dominio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Computer
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public string Brand { get; set; }

        public TypeComputerEnum Type { get; set; }


        public Computer()
        {

        }

        public Computer(string model, string brand, TypeComputerEnum type)
        {
            if (string.IsNullOrEmpty(model))
                throw new BusinessException("The model not to be empty");
            if (string.IsNullOrEmpty(brand))
                throw new BusinessException("The brand not to be empty");
            this.Model = model;
            this.Brand = brand;
            this.Type = type;
        }

        public override string ToString()
        {
            return String.Format("{0}: {1}", this.Model, this.Brand);
        }
    }
}
