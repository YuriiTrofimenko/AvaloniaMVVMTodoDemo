using Avalonia;
using AvaloniaMVVMTodoDemo.Models;
using AvaloniaMVVMTodoDemo.Services;
using MessageBox.Avalonia.DTO;
using MessageBox.Avalonia.Enums;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;

namespace AvaloniaMVVMTodoDemo.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        ViewModelBase content;

        public MainWindowViewModel(Database db)
        {
            Content = List = new TodoListViewModel(db.GetItems());
        }

        public ViewModelBase Content
        {
            get => content;
            private set => this.RaiseAndSetIfChanged(ref content, value);
        }

        public TodoListViewModel List { get; }

        public void AddItem()
        {
            // Создаем ViewModel диалога
            var vm = new AddItemViewModel();
            // Настраиваем диалог добавления пункта в список
            Observable.Merge(
                vm.Ok,
                vm.Cancel.Select(_ => (TodoItem)null))
                .Take(1) // Обработчик результата диалога
                .Subscribe(model =>
                {
                    if (model != null)
                    {
                        List.Items.Add(model);
                    }
                    // После того, как диалог закрылся,
                    // устанавливаем в качестве содержимого главного окна
                    // ViewModel списка (хранится в свойстве List)
                    Content = List;
                });
            // Когда кликнули кнопку "Add" -
            // устанавливаем в качестве содержимого главного окна
            // ViewModel диалога (хранится в локальной переменной vm)
            Content = vm;
        }

        public async void DeleteItem() {

            var msBoxStandardWindow =
                MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow(new MessageBoxStandardParams
            {
                ButtonDefinitions = ButtonEnum.OkCancel,
                ContentTitle = "Delete",
                ContentMessage = "Delete the Item?",
                Icon = Icon.Warning,
                Style = Style.Windows
            });
            if (await msBoxStandardWindow.Show() == ButtonResult.Ok)
            {
                //List.Items.
                for (int i = 0; i < List.CheckedItems.Count; i++)
                {
                    List.Items.Remove(List.CheckedItems[i]);
                } 
            }
        }
    }
}
