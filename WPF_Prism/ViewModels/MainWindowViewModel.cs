using Prism.Commands;
using Prism.Mvvm;
using WPF_Prism.Core.Commands;

namespace WPF_Prism.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private CompositeCommand _saveAllCommand;
        public CompositeCommand SaveAllCommand
        {
            get { return _saveAllCommand; }
            set { SetProperty(ref _saveAllCommand, value); }
        }

        public MainWindowViewModel(IApplicationCommands applicationCommands)
        {
            SaveAllCommand = applicationCommands.SaveAllCommand;
        }
    }
}
