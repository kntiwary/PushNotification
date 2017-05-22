using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PushNotification
{
    public interface INotifyServ
    {
        void MyLocalNotification(string title, string text);
    }
}
