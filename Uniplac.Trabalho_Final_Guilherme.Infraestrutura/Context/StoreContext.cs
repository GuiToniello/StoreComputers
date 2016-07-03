using Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniplac.Trabalho_Final_Guilherme.Infraestrutura.Context
{
    public class StoreContext : DbContext
    {
        public StoreContext() : base("StoreDB")
        {

        }

        public DbSet<Motherboard> Motherboards { get; set; }
    }
}
