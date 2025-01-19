using MarketApp.DAL.Context;
using MarketApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp.DAL.Repository
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;

        public EfRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public T Add(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();//Çağırılması gerekir.
            return entity;
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();

        }

        public T? FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);

        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }

        public T? GetById(int id)
        {
            return _context.Set<T>().Find(id);
            //2. Yol -> return _context.Find<T>(id);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
