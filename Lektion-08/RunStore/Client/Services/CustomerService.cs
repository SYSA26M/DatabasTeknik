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
            var sb = new StringBuilder();
            sb.Append("SELECT firstname, lastname, email, addressline, postalcode, city ");
            sb.Append("FROM customers AS c INNER JOIN customeraddresses AS ca ON c.id = ca.customer_id ");
            sb.Append("INNER JOIN addresses AS a ON ca.address_id = a.id ");
            sb.Append("INNER JOIN postalcodes AS p ON a.postalcode_id = p.id ");
            sb.Append("INNER JOIN cities AS cty ON p.city_id = cty.id;");
            // "SELECT firstname, lastname, email, addressline, postalcode, city FROM customers AS c INNER JOIN customeraddresses AS ca ON c.id = ca.customer_id INNER JOIN addresses AS a ON ca.address_id = a.id INNER JOIN postalcodes AS p ON a.postalcode_id = p.id INNER JOIN cities AS cty ON p.city_id = cty.id;";
            using NpgsqlConnection connection = new(ConnectionString);
            using NpgsqlCommand command = connection.CreateCommand();
            command.CommandText = sb.ToString();
            connection.Open();
            using NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                customers.Add(CreateCustomer(reader));
            }

            return customers;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    private Customer CreateCustomer(NpgsqlDataReader reader)
    {
        return new Customer
        {
            FirstName = reader.GetString(0),
            LastName = reader.GetString(1),
            Email = reader.GetString(2),
            AddressLine = reader.GetString(3),
            PostalCode = reader.GetString(4),
            City = reader.GetString(5)
        };
    }
}
