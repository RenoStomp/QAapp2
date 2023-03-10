using QAapp.Data.Model.Common;
using QAapp.Data.Model.Entities;

namespace QAapp.Data.Repositories.Interfaces
{
    public interface IRepository<T>
        where T : BaseEntity
    {

        public T Create(T entity);   // C
        public List<T> ReadAll();    // R
        public T ReadById(int id);   // R
        public List<Order> ReadOrdersByClientId(uint clientId);  // R
        public T Update(T entity);   // U
        public void Delete(T entity);   // D
        public void DeleteById(int id); // D
        public bool IsExists(int id);

    }
}
