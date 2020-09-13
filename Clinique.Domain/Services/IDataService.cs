using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Clinique.Domain.Services
{
    public interface IDataService<T>
    {
        public Task<T> Create(T entity);

        public Task<IEnumerable<T>> GetAll();

        public Task<T> Get(int id);

        public Task<T> Update(int id, T entity);

        public Task<bool> Delete(int id);
    }
}
