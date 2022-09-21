using System;
using System.Diagnostics;
using System.Windows.Input;

namespace TemplateTricks.WinUI;

// From CommunityToolkit https://github.com/CommunityToolkit/WindowsCommunityToolkit/blob/main/Microsoft.Toolkit.Uwp.SampleApp/Common/DelegateCommand.cs

public class DelegateCommand : ICommand
{
    private readonly Action commandExecuteAction;

    private readonly Func<bool> commandCanExecute;

    /// <summary>
    /// Initializes a new instance of the <see cref="DelegateCommand"/> class.
    /// </summary>
    /// <param name="execute">
    /// The action to execute when called.
    /// </param>
    /// <param name="canExecute">
    /// The function to call to determine if the command can execute the action.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if the execute action is null.
    /// </exception>
    public DelegateCommand(Action execute, Func<bool> canExecute = null)
    {
        if (execute == null)
        {
            throw new ArgumentNullException(nameof(execute));
        }

        commandExecuteAction = execute;
        commandCanExecute = canExecute ?? (() => true);
    }

    /// <summary>
    /// Occurs when changes occur that affect whether or not the command should execute.
    /// </summary>
    public event EventHandler CanExecuteChanged;

    /// <summary>
    /// Defines the method that determines whether the command can execute in its current state.
    /// </summary>
    /// <param name="parameter">
    /// The parameter used by the command.
    /// </param>
    /// <returns>
    /// Returns a value indicating whether this command can be executed.
    /// </returns>
    public bool CanExecute(object parameter = null)
    {
        try
        {
            return commandCanExecute();
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Defines the method to be called when the command is invoked.
    /// </summary>
    /// <param name="parameter">
    /// The parameter used by the command.
    /// </param>
    public void Execute(object parameter)
    {
        if (!CanExecute(parameter))
        {
            return;
        }

        try
        {
            commandExecuteAction();
        }
        catch
        {
            Debugger.Break();
        }
    }

    public void RaiseCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}