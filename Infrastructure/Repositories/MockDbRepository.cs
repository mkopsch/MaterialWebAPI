using System;
using System.Collections.Generic;
using System.Linq;
using MaterialWebAPI.Domain.Entities;
using MaterialWebAPI.Infrastructure.Context;

namespace MaterialWebAPI.Infrastructure.Repositories
{
    public class MockDbRepository : IRepository<Material>
    {

        private readonly IMockDbContext _context;

        public MockDbRepository(IMockDbContext context)
        {
            _context = context;
        }

        public void Create(Material element)
        {
            
            try
            {
                _context.store.Add(element);
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex.Message, ex.InnerException);
            }

        }

        public void Update(string id, Material replaceElement)
        {
            
            try
            {
                var element = Select(id);

                _context.store.Where(c => c.Id.Equals(id)).Select(c => { c.Name = replaceElement.Name; 
                                                                         c.IsVisible = replaceElement.IsVisible;
                                                                         c.TypeOfPhase = replaceElement.TypeOfPhase;
                                                                         c.MaterialFunction = replaceElement.MaterialFunction;
                                                                        return c; }).ToList();
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
                var element = Select(id);

                _context.store.Remove(element);
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex.Message, ex.InnerException);
            }
        }

        public Material Select(string id)
        {
            try
            {
                return _context.store.FirstOrDefault(x => x.Id.Equals(id));
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex.Message, ex.InnerException);
            }
        }

        public IEnumerable<Material> SelectAll()
        {
            try
            {


                var elements = _context.store.ToList();

                return elements;
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex.Message, ex.InnerException);
            }
        }
    }
}