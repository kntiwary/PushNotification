using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushNotification.Model
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string UserNameField { get; set; }
        public string PasswordField { get; set; }
        public string Otp { get; set; }
        
    }
        
}
