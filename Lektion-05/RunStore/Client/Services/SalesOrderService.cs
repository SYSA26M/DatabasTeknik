using System;
using System.Collections.Generic;
using Client.Interfaces;
using Client.Models;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Client.Services;

public class SalesOrderService : ISalesOrderService
{
    private readonly string _connectionString = string.Empty;
    public SalesOrderService()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        _connectionString = config.GetConnectionString("pgsql")!;
    }
    public List<SalesOrder> ListAll()
    {
        try
        {
            List<SalesOrder> orders = [];
            string sqlString = @"SELECT 
                so.id,
                ordernumber,
                orderdate,
                firstname, 
                lastname,
                email,
                a.addressline, 
                pc.postalcode,
                cty.city,
                SUM(oi.quantity * oi.price) AS ordervalue
            FROM orderitems AS oi INNER JOIN salesorder as so
                ON oi.order_id = so.id INNER JOIN customers as c 
                ON so.customer_id = c.id INNER JOIN products as p 
                ON oi.product_id = p.id INNER JOIN customeraddresses as ca 
                ON c.id = ca.customer_id INNER JOIN addresses as a 
                ON ca.address_id = a.id INNER JOIN postalcodes as pc 
                ON a.postalcode_id = pc.id INNER JOIN cities as cty 
                ON pc.city_id = cty.id INNER JOIN suppliers as s
                ON p.supplier_id = s.id INNER JOIN addresstypes as at
                ON ca.addresstype_id = at.id
            GROUP BY so.id,ordernumber,orderdate, firstname, lastname, email, addressline, postalcode, city;";


            using NpgsqlConnection connection = new(_connectionString);
            using NpgsqlCommand command = connection.CreateCommand();
            command.CommandText = sqlString;
            connection.Open();
            using NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                var customer = new Customer
                {
                    FirstName = reader.GetString(3),
                    LastName = reader.GetString(4),
                    Email = reader.GetString(5),
                    AddressLine = reader.GetString(6),
                    PostalCode = reader.GetString(7),
                    City = reader.GetString(8)
                };
                var salesorder = new SalesOrder
                {
                    Id = reader.GetInt32(0),
                    OrderNumber = reader.GetGuid(1).ToString(),
                    OrderDate = reader.GetDateTime(2),
                    Customer = customer,
                    OrderValue = reader.GetDecimal(9)
                };

                orders.Add(salesorder);
            }
            return orders;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
