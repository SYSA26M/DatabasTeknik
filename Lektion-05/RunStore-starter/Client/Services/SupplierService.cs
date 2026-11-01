using System;
using System.Collections.Generic;
using System.Xml;
using Client.Interfaces;
using Client.Models;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Client.Services;

public class SupplierService : ISupplierService
{
    private readonly string _connectionString = string.Empty;

    public SupplierService()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        _connectionString = config.GetConnectionString("pgsql")!;
    }

    public Supplier Find(int id)
    {
        throw new NotImplementedException();
    }

    public List<Supplier> ListAll()
    {
        try
        {
            List<Supplier> suppliers = [];

            using NpgsqlConnection connection = new(_connectionString);
            using NpgsqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT supplier_id, name FROM suppliers;";
            // Öppna anslutningen
            connection.Open();

            using NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                suppliers.Add(new Supplier() { Id = reader.GetInt32(0), Name = reader.GetString(1) });
            }

            return suppliers;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
