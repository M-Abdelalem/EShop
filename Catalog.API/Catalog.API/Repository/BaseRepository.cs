using Catalog.API.Entities;
using Catalog.API.IRepository;
using MongoDB.Driver;

namespace Catalog.API.Repository
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly IMongoContext Context;
        protected IMongoCollection<T> DbSet;

        protected BaseRepository(IMongoContext context)
        {
            Context = context;

            DbSet = Context.GetCollection<T>(typeof(T).Name);
        }

        public virtual void Add(T obj)
        {
            //DbSet.InsertOne(obj);
            Context.AddCommand(() => DbSet.InsertOneAsync(obj));
        }

        public virtual async Task<T> GetById(Guid id)
        {
            var data = await DbSet.FindAsync(Builders<T>.Filter.Eq("_id", id));
            return data.SingleOrDefault();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            var all = await DbSet.FindAsync(Builders<T>.Filter.Empty);
            return all.ToList();
        }

        public virtual void Update(T obj)
        {
            Context.AddCommand(() => DbSet.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", obj.Id), obj));
        }

        public virtual void Remove(Guid id)
        {
            Context.AddCommand(() => DbSet.DeleteOneAsync(Builders<T>.Filter.Eq("_id", id)));
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
