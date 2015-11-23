using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rent_Me_Inventory_Management_Solutions.DAL.Interfaces;
using Rent_Me_Inventory_Management_Solutions.DAL.Repositories;
using Rent_Me_Inventory_Management_Solutions.Model;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;

namespace Rent_Me_Inventory_Management_Solutions.Controller
{
    class ReturnTransactionController
    {
        private IRepository<ReturnTransaction> returnRepo;
        private IRepository<ReturnTransactionItem> returnItemRepo;  
        public ReturnTransactionController()
        {
            this.returnRepo = new ReturnTransactionRepository();
            this.returnItemRepo = new ReturnTransactionItemRepository();
        }

        public void ReturnItems(IList<PurchaseTransaction_Item> theItems, LoginSession theSession)
        {
            IList<ReturnTransactionItem> newItems = this.convertItemsToReturnItems(theItems);

            ReturnTransaction theTransaction = new ReturnTransaction
            {
                Employee_id = theSession.Id.ToString(),
                returnTime = DateTime.Now
            };

            var id = this.returnRepo.AddOne(theTransaction);

            foreach (var returnTransactionItem in newItems)
            {
                returnTransactionItem.ReturnTransactionId = id;
            }

            try
            {
                this.returnItemRepo.AddList(newItems);
            }
            catch (Exception)
            {
                this.DeleteTransaction(newItems, id);
            }
        }

        private void DeleteTransaction(IList<ReturnTransactionItem> newItems, string id)
        {
            foreach (var returnTransactionItem in newItems)
            {
                try
                {
                    this.returnItemRepo.Delete(returnTransactionItem);
                }
                catch
                {
                    //Ignore
                }
            }


            try
            {
                this.returnRepo.DeleteById(id);
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private IList<ReturnTransactionItem> convertItemsToReturnItems(IList<PurchaseTransaction_Item> theItems)
        {
            List<ReturnTransactionItem> newItems = new List<ReturnTransactionItem>();

            foreach (var purchaseTransactionItem in theItems)
            {
                ReturnTransactionItem newItem = new ReturnTransactionItem
                {
                    FurnitureID = purchaseTransactionItem.FurnitureId,
                    PurchaseTransactionID = purchaseTransactionItem.PurchaseTransactionId,
                    Quantity = purchaseTransactionItem.Quantity
                };
                newItems.Add(newItem);
            }

            return newItems;
        }
    }
}
