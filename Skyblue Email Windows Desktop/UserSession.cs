using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skyblue_Email_Windows_Desktop
{

    using System;

    public class UserSession
    {
        private static UserSession _instance;
        public static UserSession Instance => _instance ??= new UserSession();

        public bool IsLoggedIn { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public DateTime LoginTime { get; private set; }
        public int SessionTimeoutMinutes { get; set; } = 2;

        private UserSession() { }

        public void StartSession(string username, string password)
        {
            Username = username;
            Password = password;
            IsLoggedIn = true;
            LoginTime = DateTime.Now;

            SessionStorage.SaveSession(this);
        }

        public void EndSession()
        {
            IsLoggedIn = false;
            Username = null;
            Password = null;

            SessionStorage.DeleteSessionFile();
        }

        public bool IsSessionExpired()
        {
            return IsLoggedIn && DateTime.Now > LoginTime.AddMinutes(SessionTimeoutMinutes);
        }

        public TimeSpan GetRemainingTime()
        {
            return LoginTime.AddMinutes(SessionTimeoutMinutes) - DateTime.Now;
        }

        public void LoadFrom(UserSessionData data)
        {
            Username = data.Username;
            Password = data.Password;
            LoginTime = data.LoginTime;
            IsLoggedIn = true;
        }
    }


}
