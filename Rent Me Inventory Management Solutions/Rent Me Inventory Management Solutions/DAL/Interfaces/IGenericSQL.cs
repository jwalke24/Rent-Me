using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_Me_Inventory_Management_Solutions.DAL.Interfaces
{
    interface IGenericSQL
    {
        DataSet ExecuteQuery(string x);
    }
}
