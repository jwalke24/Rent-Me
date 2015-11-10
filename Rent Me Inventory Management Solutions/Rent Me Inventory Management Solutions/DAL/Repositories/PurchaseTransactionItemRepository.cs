using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Rent_Me_Inventory_Management_Solutions.DAL.Interfaces;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;

namespace Rent_Me_Inventory_Management_Solutions.DAL.Repositories
{
    class PurchaseTransactionItemRepository : IPurchaseTransactionItemRepository
    {
        private readonly string CONNECTION_STRING;

        public PurchaseTransactionItemRepository()
        {
            this.CONNECTION_STRING = DBConnection.GetConnectionString();
        }

        public string AddOne(PurchaseTransaction_Item item)
        {
            throw new NotImplementedException();
        }

        public void AddList(IList<PurchaseTransaction_Item> theList)
        {
            if (theList == null)
            {
                throw new ArgumentNullException();
            }

            const string statement =
                "INSERT INTO PurchaseTransaction_Item (leaseTime, quantity, Furniture_id, PurchaseTransaction_id)" +
                " VALUES (@LeaseTime, @Quantity, @FurnitureID, @PurchaseTransactionID)";

            var connection = new MySqlConnection(this.CONNECTION_STRING);

            using (var command = new MySqlCommand(statement))
            {
                command.Connection = connection;

                try
                {
                    command.Parameters.Add("@LeaseTime", MySqlDbType.Int32);
                    command.Parameters.Add("@Quantity", MySqlDbType.Int32);
                    command.Parameters.Add("@FurnitureID", MySqlDbType.Int32);
                    command.Parameters.Add("@PurchaseTransactionID", MySqlDbType.Int32);

                    command.Connection.Open();

                    foreach (var item in theList)
                    {
                        command.Parameters["@LeaseTime"].Value = item.LeaseTime;
                        command.Parameters["@Quantity"].Value = item.Quantity;
                        command.Parameters["@FurnitureID"].Value = int.Parse(item.FurnitureID);
                        command.Parameters["@PurchaseTransactionID"].Value = int.Parse(item.PurchaseTransactionID);
                        command.ExecuteNonQuery();
                    }

                }
                finally
                {
                    command.Connection.Close();
                }
            }
        }

        public IList<PurchaseTransaction_Item> GetAll()
        {
            throw new NotImplementedException();
        }

        public PurchaseTransaction_Item GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        public void Delete(PurchaseTransaction_Item item)
        {
            throw new NotImplementedException();
        }

        public void UpdateByID(PurchaseTransaction_Item item)
        {
            throw new NotImplementedException();
        }
    }
}
