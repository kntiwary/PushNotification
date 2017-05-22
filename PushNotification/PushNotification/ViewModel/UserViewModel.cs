using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PushNotification.ViewModel
{
    public class UserViewModel : INotifyPropertyChanged
    {
        public string Name { get; set; }

        private string password { get; set; }

        public string Password
        {

            get { return password; }

            set
            {
                password = value;
                OnPropertyChanged();
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
