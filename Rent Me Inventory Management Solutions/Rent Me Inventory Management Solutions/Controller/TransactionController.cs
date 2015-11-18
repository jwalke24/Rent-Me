using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rent_Me_Inventory_Management_Solutions.DAL.Interfaces;
using Rent_Me_Inventory_Management_Solutions.DAL.Repositories;
using Rent_Me_Inventory_Management_Solutions.Model.Database_Objects;

namespace Rent_Me_Inventory_Management_Solutions.Controller
{
    class TransactionController
    {
        private readonly IPurchaseTransactionRepository purchaseRepository;
        private readonly IPurchaseTransactionItemRepository purchaseItemRepository;

        public TransactionController()
        {
            this.purchaseRepository = new PurchaseTransactionRepository();
            this.purchaseItemRepository = new PurchaseTransactionItemRepository();
        }

        public void AddPurchaseTransaction(PurchaseTransaction transaction)
        {
            
            string id = this.purchaseRepository.AddOne(transaction);
            transaction.ID = id;

            try
            {
                foreach (var item in transaction.Items)
                {
                    item.PurchaseTransactionID = id;
                }

                this.purchaseItemRepository.AddList(transaction.Items);
            }
            catch (Exception)
            {
                this.DeleteChangesFromDatabase(transaction.Items, id);

                throw;
            }
        }

        private void DeleteChangesFromDatabase(List<PurchaseTransaction_Item> items, string id)
        {
            
            //Deletes all the items that were added to the database. 

            foreach (var item in items)
            {
                try
                {
                    this.purchaseItemRepository.Delete(item);
                }
                catch (Exception)
                {
                }
            }
            try
            {
                this.purchaseRepository.DeleteById(id);
            }
            catch (Exception)
            {
                
            }
        }
    }
}
