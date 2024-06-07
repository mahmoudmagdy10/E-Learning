using Amazon.BL.Interface;
using Amazon.BL.Models;
using Amazon.DAL.Data;
using AutoMapper;
using ConsoleApp1.Entities;

namespace Amazon.BL.Repository
{
    public class CategoryRep : ICategoryRep
    {
        private readonly AmazonContext context;
        private readonly IMapper mapper;

        public CategoryRep(AmazonContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IEnumerable<CategoryVM> GetAll()
        {
            try
            {
                var data = context.Set<Categories>().ToList();
                var Category = mapper.Map<List<CategoryVM>>(data);
                return Category;

            }
            catch
            {
                return null;

            }
        }
    }
}
