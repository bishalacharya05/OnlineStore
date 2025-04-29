using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.DataAcess.Data;
using OnlineStore.DataAcess.Repository.IRepository;
using OnlineStore.Models;

namespace OnlineStore.DataAcess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) :base(db) 
        {
            _db = db;  
        }

        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
