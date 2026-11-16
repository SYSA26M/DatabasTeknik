using System;
using System.Collections.Generic;
using System.Text;
using Client.Interfaces;
using Client.Models;
using MongoDB.Driver;
using Npgsql;

namespace Client.Services;

public class CustomerService : BaseService, ICustomerService
{
    public void Add(Customer customer)
    {
        throw new NotImplementedException();
    }

    public List<Customer> ListAll()
    {
        try
        {
            List<Customer> customers = [];

            // Skapa en referens till en ny instans av MongoClient och skicka med anslutningssträngen...
            var client = new MongoClient(ConnectionString);
            // Hämta hem collection customers
            var collection = client.GetDatabase("RunStore").GetCollection<Customer>("customers");
            // Skapa ett filter för att hämta alla kunder
            // db.customers.find()
            var filter = Builders<Customer>.Filter.Empty;

            customers = collection.Find(filter).ToList();

            return customers;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
