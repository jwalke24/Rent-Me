using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Rent_Me_Inventory_Management_Solutions.DAL.Interfaces;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;

namespace Rent_Me_Inventory_Management_Solutions.DAL.Repositories
{
    class ReturnTransactionItemRepository : IRepository<ReturnTransactionItem>
    {
        private readonly string CONNECTION_STRING;

        public ReturnTransactionItemRepository()
        {
            this.CONNECTION_STRING = DbConnection.GetConnectionString();
        }

        public string AddOne(ReturnTransactionItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            const string statement =
                "INSERT INTO ReturnTransaction_Item (quantity, PurchaseTransaction_Item_Furniture_id, PurchaseTransaction_Item_PurchaseTransaction_id, ReturnTransaction_id)" +
                " VALUES (@quantity, @furnitureID, @purchaseID, @returnID)";

            var connection = new MySqlConnection(this.CONNECTION_STRING);
            string id = "";
            using (var command = new MySqlCommand(statement))
            {
                command.Connection = connection;

                try
                {
                    command.Parameters.AddWithValue("@quantity", item.Quantity);
                    command.Parameters.AddWithValue("@furnitureID", item.FurnitureID);
                    command.Parameters.AddWithValue("@purchaseID", item.PurchaseTransactionID);
                    command.Parameters.AddWithValue("@returnID", item.ReturnTransactionId);

                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    id = command.LastInsertedId.ToString();
                    command.Connection.Close();

                }
                finally
                {
                    command.Connection.Close();
                }
            }

            return id;
        }

        public void AddList(IList<ReturnTransactionItem> theList)
        {

            if (theList == null)
            {
                throw new ArgumentNullException("The list is null in rtiRepo");
            }

            foreach (var returnTransactionItem in theList)
            {
                this.AddOne(returnTransactionItem);
            }
        }

        public IList<ReturnTransactionItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public ReturnTransactionItem GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        public void Delete(ReturnTransactionItem item)
        {
            throw new NotImplementedException();
        }

        public void UpdateById(ReturnTransactionItem item)
        {
            throw new NotImplementedException();
        }
    }
}
