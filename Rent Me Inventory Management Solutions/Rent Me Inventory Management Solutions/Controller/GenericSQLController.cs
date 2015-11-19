using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rent_Me_Inventory_Management_Solutions.DAL.Interfaces;
using Rent_Me_Inventory_Management_Solutions.DAL.Repositories;

namespace Rent_Me_Inventory_Management_Solutions.Controller
{
    class GenericSQLController
    {
        private IGenericSQL theGenericSql;

        public GenericSQLController()
        {
            this.theGenericSql = new GenericSQL();
        }



        public DataSet ExecuteQuery(string query)
        {
          return this.theGenericSql.ExecuteQuery(query);  
        }
    }
}
