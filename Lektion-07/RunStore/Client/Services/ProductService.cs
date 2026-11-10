using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;
using Npgsql;

namespace Client.Services;

public class ProductService : BaseService, IProductService
{
    ISupplierService _supplierService;

    public ProductService()
    {
        _supplierService = new SupplierService();
    }

    public void Add(Product product)
    {
        try
        {
            var sqlInsertString = @$"INSERT INTO Products(itemNumber,name,imageurl,description,price,supplier_id, category_id) 
                                VALUES('{product.ItemNumber}',
                                '{product.Name}','https://res.cloudinary.com/softtech-dev/image/upload/v1786556530/shoe-3_qbzcwy.jpg',
                                'Test',{product.Price},
                                {product.Supplier.Id},
                                2);";

            using NpgsqlConnection connection = new(ConnectionString);
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

            using NpgsqlConnection connection = new(ConnectionString);
            using NpgsqlCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT 
                                    p.id, 
                                    itemnumber,
                                    p.name,
                                    description,
                                    price,
                                    s.name 
                                FROM products AS p INNER JOIN suppliers AS s ON p.supplier_id = s.id";
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
        var supplier = _supplierService.FindByName(reader.GetString(5));
        return new Product()
        {
            Id = reader.GetInt32(0),
            ItemNumber = reader.GetString(1),
            Name = reader.GetString(2),
            Description = reader.IsDBNull(3) ? "Saknas" : reader.GetString(3),
            Price = (int)reader.GetFloat(4),
            Supplier = supplier
        };
    }
}
