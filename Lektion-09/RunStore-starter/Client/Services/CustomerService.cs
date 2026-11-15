using System;
using System.Collections.Generic;
using System.Text;
using Client.Interfaces;
using Client.Models;
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

            return customers;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
