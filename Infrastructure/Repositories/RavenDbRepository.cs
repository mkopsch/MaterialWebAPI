using System;
using System.Collections.Generic;
using System.Linq;
using MaterialWebAPI.Infrastructure.Context;

namespace MaterialWebAPI.Infrastructure.Repositories
{
    public class RavenDbRepository<T> : IRepository<T>
    {
        private readonly IRavenDbContext _context;

        public RavenDbRepository(IRavenDbContext context)
        {
            _context = context;
        }

        public void Create(T element)
        {
            
            try
            {
                using var session = _context.store.OpenSession();

                session.Store(element);

                session.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex.Message, ex.InnerException);
            }

        }

        public void Update(string id, T replaceElement)
        {
            
            try
            {
                using var session = _context.store.OpenSession();

                var element = Select(id);

                element = replaceElement;

                session.Store(element);

                session.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex.Message, ex.InnerException);
            }

        }

        public void Delete(string id)
        {
            try
            {
                using var session = _context.store.OpenSession();

                var element = session.Load<T>(id);

                session.Delete(element);

                session.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex.Message, ex.InnerException);
            }
        }

        public T Select(string id)
        {
            try
            {
                using var session = _context.store.OpenSession();

                var element = session.Load<T>(id);

                return element;
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex.Message, ex.InnerException);
            }
        }

        public IEnumerable<T> SelectAll()
        {
            try
            {

                using var session = _context.store.OpenSession();

                var elements = session
                    .Query<T>()
                    .ToList();

                return elements;
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex.Message, ex.InnerException);
            }
        }
    }
}