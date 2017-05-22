using System;

using Android.App;
using Android.Content;
using Xamarin.Forms;

[assembly: Dependency(typeof(PushNotification.Droid.NotifyServAndroid))]
namespace PushNotification.Droid
{
    public class NotifyServAndroid : INotifyServ
    {
        public void MyLocalNotification(string title, string text)
        {
            // Instantiate the builder and set notification elements:
            Notification.Builder builder = new Notification.Builder(Android.App.Application.Context)
                                               .SetContentTitle(title).SetContentText(text)
            .SetSmallIcon(Resource.Drawable.icon);

            // Build the notification:
            Notification notification = builder.Build();

            // Get the notification manager:
            NotificationManager notificationManager =
            Android.App.Application.Context.GetSystemService(Context.NotificationService) as NotificationManager;

            // Publish the notification:
            const int notificationId = 0;
            notificationManager.Notify(notificationId, notification);

            //builder.SetWhen(time.Millisecond);



        }
    }
}