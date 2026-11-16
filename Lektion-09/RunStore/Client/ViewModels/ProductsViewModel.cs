using System;
using System.Collections.ObjectModel;
using Client.Interfaces;
using Client.Models;
using Client.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MongoDB.Bson;

namespace Client.ViewModels;

public partial class ProductsViewModel : ViewModelBase
{
    readonly IProductService _service;

    [ObservableProperty]
    public partial ObservableCollection<Product> Products { get; set; } = [];

    public ProductsViewModel()
    {
        PageTitle = "Våra produkter";
        _service = new ProductService();
        LoadProducts();
    }

    private void LoadProducts()
    {
        try
        {
            Products = new ObservableCollection<Product>(_service.ListAll());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    [RelayCommand]
    private void Edit(ObjectId id)
    {
        var product = _service.Find(id);
        Console.WriteLine(product);
    }

    [RelayCommand]
    private void Delete(ObjectId id)
    {
        Console.WriteLine("Tar bort produkt med id: " + id);
        _service.Delete(id);
        LoadProducts();
    }
}
