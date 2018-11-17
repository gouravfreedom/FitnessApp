using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace DFS.ViewModels
{
    public class CalenderViewModel : INotifyPropertyChanged
    {
        private DateTime? _date;
        public DateTime? Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                RaisePropertyChanged(nameof(Date));
            }
        }

        private ObservableCollection<XamForms.Controls.SpecialDate> attendances;
        public ObservableCollection<XamForms.Controls.SpecialDate> Attendances
        {
            get { return attendances; }
            set { attendances = value; RaisePropertyChanged(nameof(Attendances)); }
        }

        public ICommand DateChosen
        {
            get
            {
                return new Command((obj) => {
                    System.Diagnostics.Debug.WriteLine(obj as DateTime?);
                    MessagingCenter.Send<CalenderViewModel>(this, "DateSelected");
                });
            }
        } 

        public CalenderViewModel()
        {
            //SelectedDate = DateTime.Now;
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
