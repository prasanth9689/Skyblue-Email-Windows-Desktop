using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Skyblue_Email_Windows_Desktop
{
    public static class SessionStorage
    {
        private static string filePath = "session.json";

        public static void SaveSession(UserSession session)
        {
            var data = new UserSessionData
            {
                Username = session.Username,
                Password = session.Password,
                LoginTime = session.LoginTime
            };

            var json = JsonSerializer.Serialize(data);
            File.WriteAllText(filePath, json);
        }

        public static bool LoadSession()
        {
            if (!File.Exists(filePath)) return false;

            try
            {
                string json = File.ReadAllText(filePath);
                var data = JsonSerializer.Deserialize<UserSessionData>(json);

                if (data != null)
                {
                    UserSession.Instance.LoadFrom(data);
                    return true;
                }
            }
            catch { }

            return false;
        }

        public static void DeleteSessionFile()
        {
            if (File.Exists(filePath))
                File.Delete(filePath);
        }
    }
}
