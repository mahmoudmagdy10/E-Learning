using Amazon.BL.Interface;
using Amazon.BL.Models;
using Amazon.DAL.Data;
using AutoMapper;
using ConsoleApp1.Entities;

namespace Amazon.BL.Repository
{
    public class BrandRep : IBrandRep
    {
        private readonly AmazonContext context;
        private readonly IMapper mapper;

        public BrandRep(AmazonContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public void Add(BrandVM item)
        {
            try
            {
                var data = mapper.Map<Brands>(item);
                context.Set<Brands>().Add(data);
                context.SaveChanges();

            }
            catch
            {
                Console.WriteLine("Faild");
            }
        }

        public void Delete(BrandVM item)
        {
            try
            {
                var data = mapper.Map<Brands>(item);
                context.Set<Brands>().Remove(data);
                context.SaveChanges();

            }
            catch
            {
                Console.WriteLine("Faild");
            }

        }

        public BrandVM Get(int id)
        {
            try
            {
                var data = context.Set<Brands>().Find(id);
                var brand = mapper.Map<BrandVM>(data);
                return brand;

            }
            catch
            {
                return null;

            }
        }

        public IEnumerable<BrandVM> GetAll()
        {
            try
            {
                var data = context.Set<Brands>().ToList();
                var brands = mapper.Map<List<BrandVM>>(data);
                return brands;

            }
            catch
            {
                return null;

            }
        }

        public void Update(BrandVM item)
        {
            try
            {
                var data = mapper.Map<Brands>(item);
                context.Set<Brands>().Update(data);
                context.SaveChanges();
            }
            catch
            {
                Console.WriteLine("Faild");

            }
        }
    }
}
