using System.Collections.ObjectModel;
using Client.Interfaces;
using Client.Models;
using Client.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Client.ViewModels;

public partial class OrdersViewModel : ViewModelBase
{
    ISalesOrderService _salesOrderService;

    [ObservableProperty]
    public partial ObservableCollection<SalesOrder> Orders { get; set; } = [];

    public OrdersViewModel()
    {
        _salesOrderService = new SalesOrderService();
        PageTitle = "Beställningar";
        LoadOrders();
    }

    private void LoadOrders()
    {
        Orders = new ObservableCollection<SalesOrder>(_salesOrderService.ListAll());
    }
}
