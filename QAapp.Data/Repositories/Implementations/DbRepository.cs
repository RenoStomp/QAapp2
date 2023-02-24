using QAapp.Data.Model.Common;
using QAapp.Data.Repositories.Interfaces;
using QAapp.Data.SqlServer;

namespace QAapp.Data.Repositories.Implementations
{
    public class DbRepository<T> : IRepository<T>
        where T : BaseEntity
    {
        protected readonly AppDbContext Ctx;

        public DbRepository(AppDbContext ctx)
        {
            Ctx = ctx;
        }
        public T Create(T entity)
        {
            var table = Ctx.Set<T>();
            if (table == null) return null;

            table.Add(entity);
            Ctx.SaveChanges();
            return entity;
        }

        public void Delete(T entity)
        {
            var table = Ctx.Set<T>();
            if (table == null) return;

            table.Remove(entity);
            Ctx.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var table = Ctx.Set<T>();
            if (table == null) return;

            var entity = ReadById(id);
            table.Remove(entity);
            Ctx.SaveChanges();
        }

        public bool IsExists(int id)
        {
            return Ctx.Set<T>().Any(entity => entity.ID.Equals(id));
        }

        public List<T> ReadAll()
        {
            var table = Ctx.Set<T>();
            if (table == null) return null;
            
            var list = table.ToList();
            return list;
        }

        public T ReadById(int id)
        {
            var table = Ctx.Set<T>();
            if (table == null) return null;
            
            var entity = table.FirstOrDefault(en => en.ID.Equals(id));
            return entity;
        }

        public T Update(T entity)
        {
            var table = Ctx.Set<T>();
            if (table == null) return null;
            
            table.Update(entity);
            Ctx.SaveChanges();
            return entity;
        }
    }
}
