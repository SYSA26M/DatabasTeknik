using System;
using System.Collections.Generic;
using Client.Interfaces;
using Client.Models;
using Client.Views;
using Microsoft.Data.Sqlite;

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

            // 1. Sätta en anslutning till databasen...
            using SqliteConnection connection = new(_connectionString);
            // using var connection = new SqliteConnection(_connectionString);
            // using SqliteConnection connection = new SqliteConnection(_connectionString);

            // 2. Skapa ett Command objekt för frågan vi ska ställa...
            using SqliteCommand command = connection.CreateCommand();
            // 3. Skapa frågan...
            command.CommandText = "SELECT * FROM Customers";

            // 4. Öppna anslutningen till databasen...
            connection.Open();

            // 5. Skicka frågan till databasen...
            using SqliteDataReader reader = command.ExecuteReader();

            // 6. Iterera över eventuellt data i datareader objektet...
            while (reader.Read())
            {
                // 7. Skapa ett nytt Customer objekt och placera det i listan customers...
                customers.Add(CreateCustomer(reader));
            }
            return customers;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    private Customer CreateCustomer(SqliteDataReader reader)
    {
        return new Customer()
        {
            Id = reader.GetString(0),
            FirstName = reader.GetString(1),
            LastName = reader.GetString(2),
            Email = reader.GetString(3),
            Phone = Convert.IsDBNull(reader[4]) ? "Saknas" : reader.GetString(4)
        };
    }
}
