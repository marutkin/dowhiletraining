using DoWhileTrain.Contracts;
using DoWhileTrain.Models;
using System.Collections.Generic;

namespace DoWhileTrain.Repository
{
    public abstract class BaseRepository<T> : IBaseContract<T>
    {
        protected DwtDbContext _context;

        public BaseRepository(DwtDbContext context)
        {
            _context = context;
        }

        public abstract T Create(T trainingType);
        public abstract void Delete(int id);
        public abstract List<T> Get(string ownerId);
        public abstract T Update(int id, T trainingType);
    }
}