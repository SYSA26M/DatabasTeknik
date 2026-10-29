using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Client.Models;
using Client.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class AddProductViewModel : ViewModelBase
{
    [ObservableProperty]
    public partial string ItemNumber { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string ProductName { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string Supplier { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string Price { get; set; } = string.Empty;
    [ObservableProperty]
    public partial ObservableCollection<Supplier> Suppliers { get; set; } = [];
    [ObservableProperty]
    public partial Supplier SelectedSupplier { get; set; } = new();

    public AddProductViewModel()
    {
        PageTitle = "Ny Produkt";
        // var supplierService = new SupplierService();
        // var  suppliers = supplierService.ListAll();
        // var suppliers = new SupplierService().ListAll();
        // Suppliers = new ObservableCollection<Supplier>(suppliers);
        Suppliers = new ObservableCollection<Supplier>(new SupplierService().ListAll());
    }

    [RelayCommand]
    private void Add()
    {
        try
        {
            // Glöm inte att validera fälten!!!
            var product = new Product
            {
                ItemNumber = ItemNumber,
                Name = ProductName,
                SupplierName = Supplier,
                Price = int.Parse(Price)
            };

            var service = new ProductService();
            service.Add(product);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
