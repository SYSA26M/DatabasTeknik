using System.Collections.ObjectModel;
using Client.Models;
using Client.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Client.ViewModels;

public partial class CustomersViewModel : ViewModelBase
{
    private readonly CustomerService _customerService;

    [ObservableProperty]
    public partial ObservableCollection<Customer> Customers { get; set; } = [];

    public CustomersViewModel()
    {
        PageTitle = "Kunder";
        _customerService = new CustomerService();
        LoadCustomers();
    }

    private void LoadCustomers()
    {
        Customers = new ObservableCollection<Customer>(_customerService.ListAll());
    }
}
