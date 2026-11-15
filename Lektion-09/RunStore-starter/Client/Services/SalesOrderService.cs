using System;
using System.Collections.Generic;
using Client.Interfaces;
using Client.Models;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Client.Services;

public class SalesOrderService : BaseService, ISalesOrderService
{
    public List<SalesOrder> ListAll()
    {
        try
        {
            List<SalesOrder> orders = [];

            return orders;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
