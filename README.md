# WinUI Binding Repo

## Steps to Reproduce

1. Build and run app, observe MainWindow contains a DataGrid
2. Click any Button in the first column

### Expected Behavior

The viewmodel's `MyCommand` will be invoked and see `"-- EditUserCommand Executed --"` in the debug output window. 

```csharp
MyCommand = new DelegateCommand((() =>
{
   Debug.WriteLine("-- EditUserCommand Executed --");
}));
```

### Observed Behavior

Nothign happens. There are no binding errors in the build or runtime output, ultimately the ElementName binding extension doesn't appear to be working.

### Further Investigation

Review the first DataGridTemplateColumn. The Button's Command binding is using ElementName to change the Source of the DataContext to the view model instead of the row's 'Product' DataContent.
