using Amazon.BL.Models;

namespace Amazon.BL.Interface
{
    public interface IProductRep
    {
        IEnumerable<ProductVM> GetAll();
        ProductVM Get(int id);
        void Add(ProductVM item);
        void Update(ProductVM item);
        void Delete(ProductVM item);
    }
}
