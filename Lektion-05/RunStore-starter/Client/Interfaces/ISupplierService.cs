using System;
using System.Collections.Generic;
using Client.Models;

namespace Client.Interfaces;

public interface ISupplierService
{
    List<Supplier> ListAll();
    Supplier Find(int id);
}
