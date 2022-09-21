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

Nothign happens. there are on binding errors in the build or runtime output either.
