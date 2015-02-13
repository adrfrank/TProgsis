using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Actividad01.Data;

namespace Actividad01.UI
{
    public interface IEntityWindow
    {
        void LoadItems() ;

         RepositoryEntity CreateItem();

         RepositoryEntity EditItem();
    }
}
