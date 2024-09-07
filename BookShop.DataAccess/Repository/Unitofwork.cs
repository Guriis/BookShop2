using BookShop.DataAccess.Repository.IRepository;
using BookShop2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccess.Repository
{
    public class Unitofwork : IUnitofwork
    {
        private readonly ApplicationDbContext _context;
        public Unitofwork(ApplicationDbContext context)
        {
            _context = context;
            Category = new CategoryRepository(context);
            Covertype = new CovertypeRepository(context);
        }

        public ICategoryRepository Category { private set; get; }

        public ICovertypeRepository Covertype { private set; get; }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
