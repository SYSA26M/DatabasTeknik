using System;
using System.Collections.Generic;
using Client.Models;

namespace Client.Interfaces;

public interface ISalesOrderService
{
    List<SalesOrder> ListAll();
}
