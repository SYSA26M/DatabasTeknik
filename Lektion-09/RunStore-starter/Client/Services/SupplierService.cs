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
            throw new NotImplementedException();
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

            return suppliers;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
