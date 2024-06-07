using Amazon.DAL.Entity;
using ConsoleApp1.Entities;
using System;
using System.Collections.Generic;

public class Products
{
    public int Id { get; set; }
    public string _id { get; set; }
    public int RatingsQuantity { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string ImageCover { get; set; }
    public int CategoryId { get; set; }
    public Categories Category { get; set; }
    public int BrandId { get; set; }
    public Brands Brand { get; set; }
    public ICollection<Images> Images { get; set; }
    public double RatingsAverage { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public int CartId { get; set; }
    public ICollection<CartProduct> CartProducts { get; set; }

}

