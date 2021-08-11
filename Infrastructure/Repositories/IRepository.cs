using System.Collections.Generic;

namespace MaterialWebAPI.Infrastructure.Repositories
{
    public interface IRepository<T>
    {
        void Create(T element);

        void Update(string id, T replaceElement);

        void Delete(string id);

        public T Select(string id);

        public IEnumerable<T> SelectAll();
    }
}