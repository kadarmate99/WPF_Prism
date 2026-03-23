namespace ModuleA.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        private int _counter = 0;

        private bool _canExecute = false;
        private string _title = "Hello from ViewAViewModel!";

        public bool CanExecute
        {
            get => _canExecute; 
            set => SetProperty(ref _canExecute, value);
        }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand ClickCommand { get; private set; }

        public ViewAViewModel()
        {
            ClickCommand = new DelegateCommand(Click, CanClick)
                .ObservesProperty(()=> CanExecute);
        }

        private bool CanClick()
        {
            return CanExecute;
        }

        private void Click()
        {
            _counter++;
            Title = $"You clicked me {_counter} times.";

            if (_counter >= 10)
                CanExecute = false;
        }
    }
}
