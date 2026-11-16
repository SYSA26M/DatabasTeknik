using System;
using System.Collections.Generic;
using Client.Models;
using MongoDB.Bson;

namespace Client.Interfaces;

public interface IProductService
{
    List<Product> ListAll();
    void Add(Product product);
    void Delete(ObjectId id);
    Product Find(ObjectId id);
}
