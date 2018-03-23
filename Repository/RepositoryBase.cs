using Contracts;
using Entities;
using System;
using System.Collections.Generic;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext { get; set; }

        public RepositoryBase(RepositoryContext repositoryContext) {
            RepositoryContext = repositoryContext;
        }
        public IEnumerable<T> GetAll()
        {
            return RepositoryContext.Set<T>();
        }

        public void Save(IList<T> list)
        {
            RepositoryContext.AddRange(list);
            RepositoryContext.SaveChanges();            
        }
    }
}
