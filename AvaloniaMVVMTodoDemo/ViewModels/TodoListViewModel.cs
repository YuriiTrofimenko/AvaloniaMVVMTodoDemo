using AvaloniaMVVMTodoDemo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AvaloniaMVVMTodoDemo.ViewModels
{
    public class TodoListViewModel : ViewModelBase
    {
        public TodoListViewModel(IEnumerable<TodoItem> items)
        {
            Items = new ObservableCollection<TodoItem>(items);
        }

        public ObservableCollection<TodoItem> Items { get; }

        public override string ToString()
        {
            string result = "";
            foreach (var item in Items)
            {
                result += item.Description + " ";
            }
            return result;
        }
    }
}
