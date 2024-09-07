using BookShop.DataAccess.Repository.IRepository;
using BookShop.Models.ViewModels;
using BookShop2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>,ICategoryRepository
    {
         private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context): base(context)
        {
            _context = context;
        }
    }
}
