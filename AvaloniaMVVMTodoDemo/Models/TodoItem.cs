using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace AvaloniaMVVMTodoDemo.Models
{
    public class TodoItem : ReactiveObject
    {
        private bool isChecked;
        public string Description { get; set; }
        public bool IsChecked {
            get { return isChecked; }
            set
            { this.RaiseAndSetIfChanged(ref this.isChecked, value); }
        }
    }
}
