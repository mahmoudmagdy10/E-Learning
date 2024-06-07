using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.DAL.Entity
{
    public class Images
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductId{ get; set; }
        public Products Products{ get; set; }

    }
}
