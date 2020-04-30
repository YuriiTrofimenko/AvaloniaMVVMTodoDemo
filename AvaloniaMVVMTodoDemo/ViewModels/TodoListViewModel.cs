using AvaloniaMVVMTodoDemo.Models;
using DynamicData;
using DynamicData.Binding;
using ReactiveUI.Legacy;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AvaloniaMVVMTodoDemo.ViewModels
{
    public class TodoListViewModel : ViewModelBase
    {

        public TodoListViewModel(IEnumerable<TodoItem> items)
        {
            // Items = new ReactiveList<TodoItem>(items);
            // CheckedItems = 
            Items = new ObservableCollection<TodoItem>(items);

            CheckedItems = new ObservableCollection<TodoItem>(
                Items.Where((todoItem) => todoItem.IsChecked)
            );

            foreach (var item in Items)
            {
                item.Changed.Subscribe((model)=> {
                    CheckedItems.Clear();
                    CheckedItems.AddRange(Items.Where((todoItem) => todoItem.IsChecked));
                });
            }
        }
        // public ReactiveList<TodoItem> Items { get; }
        public ObservableCollection<TodoItem> Items { get; }

        public ObservableCollection<TodoItem> CheckedItems { get; }
    }
}
