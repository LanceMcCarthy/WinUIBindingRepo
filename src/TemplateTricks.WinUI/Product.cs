using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TemplateTricks.WinUI;

public class Product : INotifyPropertyChanged
{
    private int id;
    private string name;
    private double unitPrice;
    private DateTime date;
    private bool discontinued;
    
    public Product(int id, string name, double unitPrice, DateTime date, bool discontinued)
    {
        this.ID = id;
        this.Name = name;
        this.UnitPrice = unitPrice;
        this.Date = date;
        this.Discontinued = discontinued;
    }

    public int ID
    {
        get => this.id;
        set => SetField(ref id, value);
    }

    public string Name
    {
        get => this.name;
        set => SetField(ref name, value);
    }

    public double UnitPrice
    {
        get => this.unitPrice;
        set => SetField(ref unitPrice, value);
    }

    public DateTime Date
    {
        get => this.date;
        set => SetField(ref date, value);
    }

    public bool Discontinued
    {
        get => this.discontinued;
        set => SetField(ref discontinued, value);
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}