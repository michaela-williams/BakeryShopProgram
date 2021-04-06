using System;
using System.Collections.Generic;

namespace BakeryShop
{
    public class Order
    {
        public long OrderNumber { get; private set; }
        public string CustomerName { get; private set; }
        public (Item, int)[] OrderedItems { get; private set; }
        public double SalesTotal { get; private set; }

        // Indicates when the order is complete, as indicated by user
        public bool TakingOrder { get; private set; }

        // To store items as they are entered in by the user
        // After the order is recorded, this list is converted to an array
        // and this list is deleted
        private List<(Item, int)> OrderedItemsList { get; set; }

        public Order(long orderNumber, string customerName)
        {
            OrderNumber = orderNumber;
            CustomerName = customerName;
            TakingOrder = true;
            OrderedItemsList = new List<(Item, int)>();
            SalesTotal = 0;
        }

        public void AddItem(Item item, int quanitity)
        {
            OrderedItemsList.Add((item, quanitity));

            // Update SalesTotal
            SalesTotal += item.Price * quanitity;
        }

        public void MarkOrderComplete()
        {
            OrderedItems = OrderedItemsList.ToArray();
            OrderedItemsList = null;
            TakingOrder = false;
        }

    }
}
