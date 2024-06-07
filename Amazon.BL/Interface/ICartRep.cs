using Amazon.BL.Models;
using Amazon.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.BL.Interface
{
    public interface ICartRep
    {
        void AddItem(int productId, int quantity);
        void RemoveItem(int productId, int quantity);
        Cart GetCart();
        decimal GetTotalPrice();
    }
}
