using System;
using System.Collections.Generic;
using Client.Interfaces;
using Client.Models;

namespace Client.Services;

public class SalesOrderService : ISalesOrderService
{
    private readonly string _connectionString = string.Empty;
    public SalesOrderService()
    {
        _connectionString = "Data Source=runstore.db";
    }
    public List<SalesOrder> ListAll()
    {
        return [];
    }
}
