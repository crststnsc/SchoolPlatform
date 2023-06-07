using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolPlatform.ViewModels.Commands
{
    public class RelayCommand : ICommand
    {
        private Action commandTask;
        private Func<bool> canExecuteTask;

        public RelayCommand(Action workToDo)
            : this(workToDo, DefaultCanExecute)
        {
            commandTask = workToDo;
        }

        public RelayCommand(Action workToDo, Func<bool> canExecute)
        {
            commandTask = workToDo;
            canExecuteTask = canExecute;
        }

        private static bool DefaultCanExecute()
        {
            return true;
        }

        public bool CanExecute(object parameter)
        {
            return canExecuteTask();
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public void Execute(object parameter)
        {
            commandTask();
        }
    }
}
