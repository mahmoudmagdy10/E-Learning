using Amazon.BL.Models;

namespace Amazon.BL.Interface
{
    public interface ICategoryRep
    {
        IEnumerable<CategoryVM> GetAll();
        //BrandVM Get(int id);
        //void Add(BrandVM item);
        //void Update(BrandVM item);
        //void Delete(BrandVM item);
    }
}
