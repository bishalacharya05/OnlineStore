using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.DataAcess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //Here T is the category
        IEnumerable<T> GetAll(string? includProperties = null);
        T Get(Expression<Func<T,bool>> filter, string? includProperties = null);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);

    }
}
