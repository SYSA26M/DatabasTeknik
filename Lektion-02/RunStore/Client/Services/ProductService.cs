using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Avalonia.Metadata;
using Client.Interfaces;
using Client.Models;
using Microsoft.Data.Sqlite;

namespace Client.Services;

public class ProductService : IProductService
{
    private readonly string _connectionString = string.Empty;
    public ProductService()
    {
        _connectionString = "Data Source=runstore.db";
    }
    public void Add(Product product)
    {
        try
        {
            var sqlInsertString = "INSERT INTO Products(id,itemNumber,name,imageUrl,description,supplier,price)";
            sqlInsertString += $"VALUES('{product.Id}','{product.ItemNumber}','{product.Name}','Saknas','Test','{product.SupplierName}',{product.Price});";

            using SqliteConnection connection = new(_connectionString);
            using SqliteCommand command = connection.CreateCommand();
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

            using SqliteConnection connection = new(_connectionString);
            using SqliteCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Products";
            connection.Open();

            using SqliteDataReader reader = command.ExecuteReader();

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

    private Product CreateProduct(SqliteDataReader reader)
    {
        return new Product()
        {
            Id = reader.GetString(0),
            ItemNumber = reader.GetString(1),
            Name = reader.GetString(2),
            ImageUrl = reader.GetString(3),
            Description = reader.GetString(4),
            SupplierName = reader.GetString(5),
            Price = reader.GetInt32(6)
        };
    }
}
