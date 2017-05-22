using PushNotification.Model;
using PushNotification.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace PushNotification
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public List<User> userList { get; set; }
        public User user = new User();
        public LoginPage()
        {
            
            user.UserNameField = "admin";
            user.PasswordField = "12345";
            var rowaffected = App.database.SaveUserAsync(user);
            InitializeComponent();
            BindingContext = new UserViewModel();
            EntryUserName.Completed += (object sender, EventArgs e) => { EntryPassword.Focus(); };
        }
        private async void login_clicked(object sender, EventArgs e)
        {
            
            userList = await App.database.GetUserAsync();
            User userDetail = userList.FirstOrDefault(x => x.UserNameField == EntryUserName.Text && x.PasswordField == EntryPassword.Text);
            if (userDetail != null)
            {
                if (EntryUserName.Text != userDetail.UserNameField && EntryPassword.Text != userDetail.PasswordField)
                {
                    await DisplayAlert("Login", "Login failed .. Please try again ", "OK");
                }
                else
                {
                    await DisplayAlert("Registrtion", "Login Success ... Enter OTP to Sign In ", "OK");
                    UserNameStack.IsVisible = PasswordStack.IsVisible = LoginButton.IsVisible = false;
                    OtpStack.IsVisible = true;
                    Random generator = new Random();
                    String randomumber = generator.Next(10000, 99999).ToString("D5");
                    userDetail.Otp = randomumber;
                    var rowaffected = await App.database.SaveUserAsync(userDetail);
                    DependencyService.Get<INotifyServ>().MyLocalNotification("Your OTP is", randomumber);
                }
            }
            else
            {
                await DisplayAlert("Login", "Login failed .. Please try again ", "OK");
            }
           
        }
         private async void otpCheck(object sender, EventArgs e)
        {
            userList = await App.database.GetUserAsync();
            User Otp = userList.FirstOrDefault(x => x.UserNameField == EntryUserName.Text && x.PasswordField == EntryPassword.Text);
            if(Otp.Otp == EntryOtp.Text)
            {
                await DisplayAlert("Registrtion", "Sign In  Success ... Welcome Do whatever you want or go to next activty", "OK");
            }
            else
            {
                await DisplayAlert("Login", "Login failed .. Please try again ", "OK");
                UserNameStack.IsVisible = PasswordStack.IsVisible = LoginButton.IsVisible= true;
                OtpStack.IsVisible = false;
            }
        }
        //protected override async void OnAppearing()
        //{

        //}
    }
}