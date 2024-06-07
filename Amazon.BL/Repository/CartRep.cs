using Amazon.BL.Interface;
using Amazon.BL.Models;
using Amazon.DAL.Data;
using Amazon.DAL.Entity;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.BL.Repository
{
    public class CartRep : ICartRep
    {
        private readonly AmazonContext _context;
        private readonly IMapper _mapper;

        public CartRep(AmazonContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void AddItem(int productId, int quantity)
        {
            try
            {
                var item = _context.Products.Find(productId);

                var cart = _context.Carts.Include(c => c.CartProducts).FirstOrDefault();
                if (cart == null)
                {
                    cart = new Cart();
                    _context.Carts.Add(cart);
                }

                var cartItem = _context.CartProduct.FirstOrDefault(cI => cI.Product.Id == productId);
                if(cartItem != null)
                {
                    cartItem.Quantity += quantity;
                    cartItem.TotalPrice = item.Price * cartItem.Quantity;
                }
                else
                {
                    cartItem = new CartProduct { Product = item, Quantity = quantity, CartId = cart.Id, TotalPrice = item.Price};
                    _context.CartProduct.Add(cartItem);
                }

                _context.SaveChanges();

            }
            catch
            {
                Console.WriteLine("Failed To Add To Cart");
            }
        }

        public Cart GetCart()
        {
            var cart = _context.Carts.Include(c => c.CartProducts).ThenInclude(c => c.Product).FirstOrDefault();
            return cart;

            //var cartItemsVM = _mapper.Map<List<cartVM>>(cartItems);
            //return cartItems;
            //var cart = _context.Carts
            //        .Include(c => c.CartProducts)
            //        .ThenInclude(cp => cp.Product)
            //        .Where(c => c.Id == cartId).ToList();


        }

        public decimal GetTotalPrice()
        {
            var cart = _context.CartProduct.Sum(p => p.TotalPrice);
            return cart;
        }

        public void RemoveItem(int itemId , int quantity)
        {
            var itemExistance = _context.CartProduct.FirstOrDefault(i => i.Product.Id == itemId);
            if(quantity != 0)
            {
                if (itemExistance != null)
                {
                    if (itemExistance.Quantity <= 1)
                        _context.CartProduct.Remove(itemExistance);

                    itemExistance.Quantity -= 1;
                }
            }
            else
            {
                _context.CartProduct.Remove(itemExistance);
            }
            _context.SaveChanges();
        }
    }
}
