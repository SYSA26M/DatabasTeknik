using System;
using System.Collections.Generic;
using System.Xml;
using Client.Interfaces;
using Client.Models;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Client.Services;

public class SupplierService : BaseService, ISupplierService
{
    public Supplier Find(int id)
    {
        throw new NotImplementedException();
    }

    public Supplier FindByName(string name)
    {
        try
        {
            using NpgsqlConnection connection = new(ConnectionString);
            using NpgsqlCommand command = connection.CreateCommand();
            command.CommandText = @$"SELECT id, name FROM suppliers
                                        WHERE LOWER(name)='{name.ToLower()}'";
            // Öppna anslutningen
            connection.Open();

            using NpgsqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                return new Supplier { Id = reader.GetInt32(0), Name = reader.GetString(1) };
            }

            throw new Exception("Kunde inte hitta leverantören");

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public List<Supplier> ListAll()
    {
        try
        {
            List<Supplier> suppliers = [];

            using NpgsqlConnection connection = new(ConnectionString);
            using NpgsqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT id, name FROM suppliers;";
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
