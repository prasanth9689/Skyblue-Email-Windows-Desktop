using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skyblue_Email_Windows_Desktop
{
    public partial class Splash : Form
    {
        private System.Windows.Forms.Timer splashTimer;
        public Splash()
        {
            InitializeComponent();

            splashTimer = new System.Windows.Forms.Timer();
            splashTimer.Interval = 1000; // 3 seconds
            splashTimer.Tick += SplashTimer_Tick;
            splashTimer.Start();
        }
        private void SplashTimer_Tick(object sender, EventArgs e)
        {
            splashTimer.Stop();

            SessionStorage.LoadSession();

            bool checkAlreadyLogged = UserSession.Instance.IsLoggedIn;

            if (checkAlreadyLogged && !UserSession.Instance.IsSessionExpired())
            {
                MessageBox.Show("Session found. Opening Home.");
                Application.Run(new Home());
            }
            else
            {
                MessageBox.Show("No session found. Opening Login.");
                Application.Run(new Form1());
            }


            //bool checkAleardyLogged = UserSession.Instance.IsLoggedIn;

            //if (checkAleardyLogged)
            //{
            //    MessageBox.Show("session found. open home");
            //}
            //else {
            //    MessageBox.Show("session no found. open login");
            //}


            //if (UserSession.Instance.IsLoggedIn)
            //{
            //    Home home = new Home();
            //    home.Show();
            //    this.Hide();
            //    // return;
            //}
            //else
            //{
            //    Form1 form1 = new Form1();
            //    form1.Show();
            //    this.Hide();
            //}
        }
    }
}
