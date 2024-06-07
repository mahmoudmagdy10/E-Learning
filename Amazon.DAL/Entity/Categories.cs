using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entities
{
    public class Categories
    {
        public int Id { get; set; }
        public string _id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Image { get; set; }
        public ICollection<Products> Products { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }

}
