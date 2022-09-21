using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace TemplateTricks.WinUI;

public class MainViewModel
{
    private ObservableCollection<Product> productsList;

    public MainViewModel()
    {
        MyCommand = new DelegateCommand((() =>
        {
            Debug.WriteLine("-- EditUserCommand Executed --");
        }));
    }

    public ObservableCollection<Product> ProductsList => productsList ??= new ObservableCollection<Product>(ProductsGenerator.GetData(50));

    public ICommand MyCommand { get; set; }
}