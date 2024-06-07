using Amazon.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.BL.Interface
{
    public interface IBrandRep
    {
        IEnumerable<BrandVM> GetAll();
        BrandVM Get(int id);
        void Add(BrandVM item);
        void Update(BrandVM item);
        void Delete(BrandVM item);
    }
}
