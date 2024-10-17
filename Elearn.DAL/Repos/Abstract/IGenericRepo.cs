using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elearn.DAL.Repos.Abstract
{
    public interface IGenericRepo<Tmodel>
    {
        IEnumerable<Tmodel> GetAll();
        void Create(Tmodel Entity);
        void Update(Tmodel Entity);
        void Delete(int id);
        Tmodel GetById(int id);
        int? SaveChanges();
    }
}
