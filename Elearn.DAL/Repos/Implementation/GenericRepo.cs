using Elearn.DAL.Context;
using Elearn.DAL.Repos.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elearn.DAL.Repos.Implementation
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly ElearnContext _context;
        public GenericRepo(ElearnContext context) 
        {
            _context = context;
        }

        public void Create(T Entity)
        {
            _context.Set<T>().Add(Entity);
          
        }

        public void Delete(int id)
        {
            var course = _context.Set<T>().Find(id);
            if (course != null)
            {
                _context.Set<T>().Remove(course);
                _context.SaveChanges();
            }
        }

        public IEnumerable<T> GetAll()
        {
           return _context.Set<T>().AsEnumerable();
    
        }

        public T GetById(int id)
        {
           return _context.Set<T>().Find(id);
        }

        public int? SaveChanges()
        {
           return _context.SaveChanges();
        }

        public void Update(T Entity)
        {
            _context.Set<T>().Update(Entity);
        }
    }
}
