using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    interface IDataOperation<T>
    {
        void Insert(T obj);
        bool Delete(int id);
        void Update(T obj);
        
        
    }
}
