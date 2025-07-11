using System.Collections.Generic;
using System.Threading.Tasks;

namespace EAD.Interfaces
{
    public interface ISqlRepository<T> where T : class
    {
        void Add(T obj);

        void Delete(T obj);

        Task<List<T>> GetAll();

        Task<T> GetById(int id);

        void Update(T obj);
    }
}