using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.DAL.Entity
{
    public class CartProduct
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int CartId { get; set; }
        public decimal TotalPrice{ get; set; }
        public Products Product { get; set; }
    }
}
