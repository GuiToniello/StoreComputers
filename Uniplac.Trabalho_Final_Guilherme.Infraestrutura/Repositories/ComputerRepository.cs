using Dominio.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Uniplac.Trabalho_Final_Guilherme.Infraestrutura.Context;
using System.Data.Entity;

namespace Uniplac.Trabalho_Final_Guilherme.Infraestrutura.Repositories
{
    public class ComputerRepository : IComputerRepository
    {
        private StoreContext _context;

        public ComputerRepository()
        {
            _context = new StoreContext();
        }

        public void Create(Computer computer)
        {
            _context.Computers.Add(computer);
            _context.SaveChanges();
        }

        public void Delete(Computer computer)
        {
            computer = _context.Computers.Find(computer.Id);
            _context.Computers.Remove(computer);
            _context.SaveChanges();
        }

        public Computer Read(int id)
        {
            return _context.Computers.Find(id);
        }

        public List<Computer> ReadAll()
        {
            return _context.Computers.ToList();
        }

        public Computer Update(Computer computer)
        {
            var entry = _context.Entry<Computer>(computer);
            entry.State = EntityState.Modified;
            _context.SaveChanges();
            return computer;
        }
    }
}
