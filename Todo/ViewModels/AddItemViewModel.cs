using System.Reactive;
using Avalonia.Controls;
using Avalonia.Interactivity;
using ReactiveUI;
using Todo.Models;

namespace Todo.ViewModels
{
    class AddItemViewModel : ViewModelBase
    {
        string description;
        public string Description
        {
            get => description;
            set => this.RaiseAndSetIfChanged(ref description, value);
        }

        public AddItemViewModel()
        {

            var okEnabled = this.WhenAnyValue(
                x => x.Description,
                x => !string.IsNullOrWhiteSpace(x));

            Ok = ReactiveCommand.Create(
                () => new TodoItem { Description = Description },
                okEnabled);

            Cancel = ReactiveCommand.Create(() => { });

            Print = ReactiveCommand.Create<string>(WriteNumber);
        }

        public void WriteNumber(string number)
        {
            Description += number;
        }

        public ReactiveCommand<string, Unit> Print { get; }
        public ReactiveCommand<Unit, TodoItem> Ok { get; }
        public ReactiveCommand<Unit, Unit> Cancel { get; }
    }
}