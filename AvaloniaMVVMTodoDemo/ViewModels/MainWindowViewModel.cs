using AvaloniaMVVMTodoDemo.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvaloniaMVVMTodoDemo.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel(Database db)
        {
            List = new TodoListViewModel(db.GetItems());
        }

        public TodoListViewModel List { get; }
    }
}
