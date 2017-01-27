using AgendaClean.Models;
using System.Collections.Generic;

namespace AgendaClean.Repository
{
    public abstract class Repository<T> where T : IEntity
    {
        protected readonly AgendaContext _context = new AgendaContext();

        public abstract void Add(T entity);
        public abstract void Remove(T entity);
        public abstract void Update(T entity);
        public abstract T Find(string id);
        public abstract ICollection<T> FindAll();

    }
}
