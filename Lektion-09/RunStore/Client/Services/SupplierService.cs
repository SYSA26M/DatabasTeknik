using System;
using System.Collections.Generic;
using Client.Interfaces;
using Client.Models;
using MongoDB.Driver;

namespace Client.Services;

public class SupplierService : BaseService, ISupplierService
{
    public Supplier Find(int id)
    {
        throw new NotImplementedException();
    }

    public Supplier FindByName(string name)
    {
        try
        {
            throw new NotImplementedException();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public List<Supplier> ListAll()
    {
        try
        {
            List<Supplier> suppliers = [];

            var client = new MongoClient(ConnectionString);
            var collection = client.GetDatabase("RunStore").GetCollection<Supplier>("suppliers");
            var filter = Builders<Supplier>.Filter.Empty;

            suppliers = collection.Find(filter).ToList();

            return suppliers;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
