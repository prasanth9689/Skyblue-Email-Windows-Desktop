namespace Skyblue_Email_Windows_Desktop
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            // Application.Run(new Splash());

            SessionStorage.LoadSession();

            bool checkAlreadyLogged = UserSession.Instance.IsLoggedIn;

            if (checkAlreadyLogged && !UserSession.Instance.IsSessionExpired())
            {
                MessageBox.Show("Session found. Opening Home.");
                Application.Run(new Home());
            }
            else
            {
                //  MessageBox.Show("No session found. Opening Login.");
                  Application.Run(new Form1());


              // Application.Run(new HomeMaterialForm());
            }
        }
    }
}