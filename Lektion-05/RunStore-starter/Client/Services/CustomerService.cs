using System;
using System.Collections.Generic;
using Client.Interfaces;
using Client.Models;
using Client.Views;

namespace Client.Services;

public class CustomerService : ICustomerService
{
    private readonly string _connectionString = string.Empty;
    public CustomerService()
    {
        _connectionString = "Data Source=runstore.db";
    }

    public void Add(Customer customer)
    {
        throw new NotImplementedException();
    }

    public List<Customer> ListAll()
    {
        try
        {
            List<Customer> customers = [];
            return customers;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
