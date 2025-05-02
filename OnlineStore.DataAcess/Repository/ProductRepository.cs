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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) :base(db) 
        {
            _db = db;  
        }

        public void Update(Product obj)
        {
            _db.Products.Update(obj);
        }
    }
}
