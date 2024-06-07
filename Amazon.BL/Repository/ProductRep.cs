using Amazon.BL.Interface;
using Amazon.BL.Models;
using Amazon.DAL.Data;
using AutoMapper;
using ConsoleApp1.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.BL.Repository
{
    public class ProductRep : IProductRep
    {
        private readonly AmazonContext context;
        private readonly IMapper mapper;

        public ProductRep(AmazonContext context, IMapper mapper) 
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void Add(ProductVM item)
        {
            try
            {
                var data = mapper.Map<Products>(item);
                context.Set<Products>().Add(data);
                context.SaveChanges();

            }
            catch
            {
                Console.WriteLine("Faild");
            }
        }

        public void Delete(ProductVM item)
        {
            try
            {
                var data = mapper.Map<Products>(item);
                context.Set<Products>().Remove(data);
                context.SaveChanges();

            }
            catch
            {
                Console.WriteLine("Faild");
            }

        }

        public ProductVM Get(int id)
        {
            try
            {
                var data = context.Set<Products>().Include(p => p.Images) // Eager loading children
                                .SingleOrDefault(p => p.Id == id);
                var product = mapper.Map<ProductVM>(data);
                return product;

            }
            catch
            {
                return null;

            }
        }

        public IEnumerable<ProductVM> GetAll()
        {
            try
            {
                var data = context.Set<Products>().Include("Category").Include("Brand").ToList();
                var products = mapper.Map<List<ProductVM>>(data);
                return products;

            }
            catch
            {
                return null;

            }
        }

        public void Update(ProductVM item)
        {
            try
            {
                var data = mapper.Map<Products>(item);
                context.Set<Products>().Update(data);
                context.SaveChanges();
            }
            catch
            {
                Console.WriteLine("Faild");

            }
        }
        //public IEnumerable<ProductVM> Get(Expression<Func<Products, bool>> filter = null)
        //{
        //    try
        //    {
        //        if (filter != null)
        //            return MappingIEnumerableData(GetFilteredData(filter));
        //        return MappingIEnumerableData(GetProduct());
        //    }
        //    catch
        //    {
        //        return EmptyIEnumerableOfPosts();
        //    }
        //}

        //public ProductVM GetById(int id)
        //{
        //    var data = context.Products.Where(a => a.Id == id);
        //    return mapper.Map<ProductVM>(data);
        //}

        //private IEnumerable<ProductVM> EmptyIEnumerableOfPosts()
        //{
        //    return Enumerable.Empty<ProductVM>();
        //}

        //private object GetProduct()
        //{
        //    return context.Products.Include("Category").Select(a => a);
        //}

        //private object GetFilteredData(Expression<Func<Products, bool>> filter)
        //{
        //    return context.Products.Where(filter);
        //}

        //private IEnumerable<ProductVM> MappingIEnumerableData(object value)
        //{
        //    return mapper.Map<IEnumerable<ProductVM>>(value);
        //}
    }
}
