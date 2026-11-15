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

            return products;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
