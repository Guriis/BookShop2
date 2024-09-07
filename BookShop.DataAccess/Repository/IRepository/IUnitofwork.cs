using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccess.Repository.IRepository
{
    public interface IUnitofwork
    {
        ICategoryRepository Category { get; }
        ICovertypeRepository Covertype { get; }
        void Save();
    }
}
