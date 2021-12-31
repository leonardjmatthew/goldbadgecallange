using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafe.Repository
{
   public class MenuItemRepository
   {
        private List<MenuItem> _orders = new List<MenuItem>();
       
        //Add
        public void AddOrder(MenuItem _order)
        {
            
            _orders.Add(_order);
        }

        public MenuItem GetItemById(int orderid)
        {
           foreach(MenuItem _item in _orders)
           {
                if(_item.MealNumb == orderid)
                {
                    return _item;
                }
           }
            return null;
        }

        //Delete
        public bool RemoveOrder(MenuItem _order)
        {
             int initialCount = _orders.Count;

            _orders.Remove(_order);

            if (initialCount > _orders.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //See all orders
        public List<MenuItem> ListOrders()
        {
            return _orders;
        }

   }
}
