using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace DFS.ViewModels
{
    public class TrainerListViewModel : INotifyPropertyChanged
    {
        private Boolean _isServiceInProgress;
        public Boolean IsServiceInProgress
        {
            get { return _isServiceInProgress; }
            set
            {
                _isServiceInProgress = value;
                RaisePropertyChanged(nameof(IsServiceInProgress));
            }
        }

        private ObservableCollection<Models.TrainerListModel.Trainee> _listViewData;
        public ObservableCollection<Models.TrainerListModel.Trainee> ListViewData
        {
            get { return _listViewData; }
            set
            {
                _listViewData = value;
                RaisePropertyChanged(nameof(ListViewData));
            }
        }


        public Task Initialization { get; private set; }

        public TrainerListViewModel()
        {
            _isServiceInProgress = true;

            Initialization = InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            var response = await App.TodoManager.FetchTrainerList();

            ListViewData = response.trainee;

            IsServiceInProgress = false;
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
