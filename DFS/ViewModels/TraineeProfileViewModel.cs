using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace DFS.ViewModels
{
    public class TraineeProfileViewModel : INotifyPropertyChanged
    {
        private String _traineeName;
        public String TraineeName
        {
            get { return _traineeName; }
            set
            {
                _traineeName = value;
                RaisePropertyChanged(nameof(TraineeName));
            }
        }

        private String _traineeInterest;
        public String TraineeInterest
        {
            get { return _traineeInterest; }
            set
            {
                _traineeInterest = value;
                RaisePropertyChanged(nameof(TraineeInterest));
            }
        }

        private String _traineeGoals;

        public TraineeProfileViewModel()
        {
            Models.LoginResponse.SyncLoginResponse syncLoginResponse = App.DatabaseManager.SyncLoginResponse("Trainee");

            TraineeName = syncLoginResponse.Name;
            TraineeGoals = syncLoginResponse.Email;
            TraineeInterest = syncLoginResponse.Speciality;

        }

        public String TraineeGoals
        {
            get { return _traineeGoals; }
            set
            {
                _traineeGoals = value;
                RaisePropertyChanged(nameof(TraineeGoals));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
