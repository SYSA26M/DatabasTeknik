using System;
using System.Collections.Generic;
using Client.Interfaces;
using Client.Models;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Client.Services;

public class ProductService : IProductService
{
    private readonly string _connectionString = string.Empty;
    public ProductService()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        _connectionString = config.GetConnectionString("pgsql")!;
    }
    public void Add(Product product)
    {
        try
        {
            var sqlInsertString = "INSERT INTO Products(itemNumber,name,imageurl,description,price)";
            sqlInsertString += $"VALUES('{product.ItemNumber}','{product.Name}','https://res.cloudinary.com/softtech-dev/image/upload/v1786556530/shoe-3_qbzcwy.jpg','Test',{product.Price});";

            using NpgsqlConnection connection = new(_connectionString);
            using NpgsqlCommand command = connection.CreateCommand();
            command.CommandText = sqlInsertString;
            connection.Open();
            command.ExecuteNonQuery();
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

            using NpgsqlConnection connection = new(_connectionString);
            using NpgsqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT p.id, itemnumber,p.name,description,price,s.name FROM products AS p INNER JOIN suppliers AS s ON p.supplier_id = s.id";
            connection.Open();
            using NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                products.Add(CreateProduct(reader));
            }

            return products;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    private Product CreateProduct(NpgsqlDataReader reader)
    {
        return new Product()
        {
            Id = reader.GetInt32(0),
            ItemNumber = reader.GetString(1),
            Name = reader.GetString(2),
            Description = reader.IsDBNull(3) ? "Saknas" : reader.GetString(3),
            Price = (int)reader.GetFloat(4),
            SupplierName = reader.GetString(5)
        };
    }
}
