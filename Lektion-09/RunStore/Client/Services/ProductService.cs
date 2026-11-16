using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using Npgsql;

namespace Client.Services;

public class ProductService : BaseService, IProductService
{
    ISupplierService _supplierService;

    public ProductService()
    {
        _supplierService = new SupplierService();
    }

    public void Add(Product product)
    {
        try
        {
            var client = new MongoClient(ConnectionString);
            var collection = client.GetDatabase("RunStore").GetCollection<Product>("products");
            collection.InsertOne(product);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void Delete(ObjectId id)
    {
        try
        {
            var client = new MongoClient(ConnectionString);
            var collection = client.GetDatabase("RunStore").GetCollection<Product>("products");
            var filter = Builders<Product>.Filter.Eq(c => c.Id, id);
            var result = collection.DeleteOne(filter);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public Product Find(ObjectId id)
    {
        try
        {
            var client = new MongoClient(ConnectionString);
            var collection = client.GetDatabase("RunStore").GetCollection<Product>("products");
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

            var client = new MongoClient(ConnectionString);
            var collection = client.GetDatabase("RunStore").GetCollection<Product>("products");
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
