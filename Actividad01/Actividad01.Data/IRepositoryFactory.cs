using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Actividad01.Data
{
    public interface IRepositoryFactory<T> where T : RepositoryEntity
    {
        IRepository<T> CreateRepository();
    }
}
