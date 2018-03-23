using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> GetAll();
        void Save(IList<T> list);
    }
}
