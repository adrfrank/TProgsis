using Actividad01.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Actividad01.Data
{
    public class FileRepositoryFactory<T>:IRepositoryFactory<T> where T:RepositoryEntity
    {
        public IRepository<T> CreateRepository()
        {
            return new FileRepository<T>();
        }
    }
}
