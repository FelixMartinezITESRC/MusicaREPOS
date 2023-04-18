using Microsoft.EntityFrameworkCore;
using MusicaApi.Data;

namespace MusicaApi.Repositories
{
    public class Repository<T> where T: class
    {
        private readonly Sistem21MusicaContext Context;
        public Repository(Sistem21MusicaContext context)
        {
            this.Context = context;
        }
        public DbSet<T> GetAll()
        {
            return Context.Set<T>();
        }
        public T? Get(object id)
        {
            return Context.Find<T>(id);
        }
        public void Insert(T entity)
        {
            Context.Add(entity);
            Context.SaveChanges();
        }
        public void Update(T entity)
        {
            Context.Update(entity);
            Context.SaveChanges();
        }
        public void Delete(T entity)
        {
            Context.Remove(entity);
            Context.SaveChanges();
        }
    }
}
