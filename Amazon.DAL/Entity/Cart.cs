using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.DAL.Entity
{
    public class Cart
    {
        public int Id { get; set; }
        public ICollection<CartProduct> CartProducts { get; set; }
    }
}
