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
    public class MotherboardRepository : IMotherboardRepository
    {
        private StoreContext _context;

        public MotherboardRepository()
        {
            _context = new StoreContext();
        }

        public void Create(Motherboard motherboard)
        {
            _context.Motherboards.Add(motherboard);
            _context.SaveChanges();
        }

        public void Delete(Motherboard motherboard)
        {
            motherboard = _context.Motherboards.Find(motherboard.Id);
            _context.Motherboards.Remove(motherboard);
            _context.SaveChanges();
        }

        public Motherboard Read(int id)
        {
            return _context.Motherboards.Find(id);
        }

        public List<Motherboard> ReadAll()
        {
            return _context.Motherboards.ToList();
        }

        public Motherboard Update(Motherboard motherboard)
        {
            var entry = _context.Entry<Motherboard>(motherboard);
            entry.State = EntityState.Modified;
            _context.SaveChanges();
            return motherboard;
        }
    }
}
