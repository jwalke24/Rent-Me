using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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

        public void AddPurchaseTransaction(PurchaseTransaction transaction, BindingList<PurchaseTransaction_Item> items)
        {
            string id = this.purchaseRepository.AddOne(transaction);

            foreach (var item in items)
            {
                item.PurchaseTransactionID = id;
            }

            this.purchaseItemRepository.AddList(items);
        }
    }
}
