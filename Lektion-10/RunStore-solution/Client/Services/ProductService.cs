using System;
using System.Collections.Generic;
using Client.Interfaces;
using Client.Models;
using MongoDB.Driver;

namespace Client.Services;

public class ProductService : MongoDBBase<Product>, IProductService
{
    public void Add(Product product)
    {
        try
        {
            var collection = GetCollection("RunStore", "products");
            collection.InsertOne(product);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void Delete(string id)
    {
        try
        {
            var collection = GetCollection("RunStore", "products");
            var filter = Builders<Product>.Filter.Eq(c => c.Id, id);
            var result = collection.DeleteOne(filter);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public Product Find(string id)
    {
        try
        {
            var collection = GetCollection("RunStore", "products");
            var filter = Builders<Product>.Filter.Eq(c => c.Id, id);
            var result = collection.Find(filter).FirstOrDefault();

            if (result is not null) return result;

            throw new Exception("Hittade ingen produkt");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }

    public List<Product> ListAll()
    {
        try
        {
            List<Product> products = [];

            var collection = GetCollection("RunStore", "products");
            var filter = Builders<Product>.Filter.Empty;

            products = collection.Find(filter).ToList();

            return products;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
