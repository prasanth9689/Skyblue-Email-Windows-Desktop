using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using Org.BouncyCastle.Asn1.X509;
using Skyblue_Email_Windows_Desktop.Properties;

namespace Skyblue_Email_Windows_Desktop
{
    public partial class Home : Form
    {
        Panel contentPanel = new Panel();

        static bool isLoggedIn = false;
        static DateTime loginTime;
        static int sessionTimeoutMinutes = 2;

        public Home()
        {
            InitializeComponent();



            this.WindowState = FormWindowState.Maximized;
            createLeftNav();
            autoSizeLayout();
            setupSearchLayout();
            
        }

        private void setupSearchLayout()
        {
            panel2.Location = new Point(this.ClientSize.Width - panel2.Width, 20);

            // Optional: keep it there when form resizes
            this.Resize += (s, e) =>
            {
                panel2.Location = new Point(this.ClientSize.Width - panel2.Width, 0);
            };
        }

        private void loadHome()
        {
            contentPanel.Controls.Clear();
            var homeControl = new HomeControl();

            homeControl.Size = new Size(267, this.ClientSize.Height);
            this.Resize += (s, e) =>
            {
                homeControl.Height = this.ClientSize.Height;
            };

            //     homeControl.Width = this.ClientSize.Width;
            int screenWidth = Screen.FromControl(this).WorkingArea.Width;
            homeControl.Width = screenWidth - 300;
            contentPanel.Controls.Add(homeControl);
        }

        private void autoSizeLayout()
        {
            // Left side nav bar
            panel1.Size = new Size(267, this.ClientSize.Height);
            this.Resize += (s, e) =>
            {
                panel1.Height = this.ClientSize.Height;
            };
        }

        private void createLeftNav()
        {
            addLeftNavButtons();
            loadContentPanel();

        }

        private void loadContentPanel()
        {
            contentPanel.Dock = DockStyle.Fill;
            this.Controls.Add(contentPanel);
           
        }

        private void addLeftNavButtons()
        {
            // Inbox
            Image originalImage = Properties.Resources.inbox;
            Image resizedImage = new Bitmap(originalImage, new Size(30, 30));
            button2.Image = resizedImage;
            button2.TextImageRelation = TextImageRelation.ImageBeforeText;
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Padding = new Padding(20, 0, 8, 0);
            button2.FlatAppearance.BorderSize = 0;
            button2.Click += btnHome_Click;

            
            Image sentImage = Properties.Resources.ic_sent;
            Image resizedSendImage = new Bitmap(sentImage, new Size(30, 30));
            button3.Image = resizedSendImage;
            button3.TextImageRelation = TextImageRelation.ImageBeforeText;
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.Padding = new Padding(20, 0, 8, 0);
            button3.FlatAppearance.BorderSize = 0;
            button3.Click += btnSent_Click;
            button3.FlatAppearance.BorderSize = 0;

            Image draftImage = Properties.Resources.ic_draft;
            Image resizedDraftImage = new Bitmap(draftImage, new Size(30, 30));
            button4.Image = resizedDraftImage;
            button4.TextImageRelation = TextImageRelation.ImageBeforeText;
            button4.ImageAlign = ContentAlignment.MiddleLeft;
            button4.Padding = new Padding(20, 0, 8, 0);
            button4.FlatAppearance.BorderSize = 0;
            button4.Click += btnHome_Click;
            button4.FlatAppearance.BorderSize = 0;

            Image importantImage = Properties.Resources.ic_important;
            Image resizedimportantImage = new Bitmap(importantImage, new Size(30, 30));
            button5.Image = resizedimportantImage;
            button5.TextImageRelation = TextImageRelation.ImageBeforeText;
            button5.ImageAlign = ContentAlignment.MiddleLeft;
            button5.Padding = new Padding(20, 0, 8, 0);
            button5.FlatAppearance.BorderSize = 0;
            button5.Click += btnHome_Click;
            button5.FlatAppearance.BorderSize = 0;

            Image spamImage = Properties.Resources.ic_spam;
            Image resizedSpamImage = new Bitmap(spamImage, new Size(30, 30));
            button6.Image = resizedSpamImage;
            button6.TextImageRelation = TextImageRelation.ImageBeforeText;
            button6.ImageAlign = ContentAlignment.MiddleLeft;
            button6.Padding = new Padding(20, 0, 8, 0);
            button6.FlatAppearance.BorderSize = 0;
            button6.Click += btnHome_Click;
            button6.FlatAppearance.BorderSize = 0;

            Image trashImage = Properties.Resources.ic_trash;
            Image resizedtrashImage = new Bitmap(trashImage, new Size(30, 30));
            button7.Image = resizedtrashImage;
            button7.TextImageRelation = TextImageRelation.ImageBeforeText;
            button7.ImageAlign = ContentAlignment.MiddleLeft;
            button7.Padding = new Padding(20, 0, 8, 0);
            button7.FlatAppearance.BorderSize = 0;
            button7.Click += btnHome_Click;
            button7.FlatAppearance.BorderSize = 0;

            Image calendarImage = Properties.Resources.ic_calendar;
            Image resizedcalendarImage = new Bitmap(calendarImage, new Size(30, 30));
            button8.Image = resizedcalendarImage;
            button8.TextImageRelation = TextImageRelation.ImageBeforeText;
            button8.ImageAlign = ContentAlignment.MiddleLeft;
            button8.Padding = new Padding(20, 0, 8, 0);
            button8.FlatAppearance.BorderSize = 0;
            button8.Click += btnHome_Click;
            button8.FlatAppearance.BorderSize = 0;

            Image settingsImage = Properties.Resources.ic_settings;
            Image resizedsettingsImage = new Bitmap(settingsImage, new Size(30, 30));
            button9.Image = resizedsettingsImage;
            button9.TextImageRelation = TextImageRelation.ImageBeforeText;
            button9.ImageAlign = ContentAlignment.MiddleLeft;
            button9.Padding = new Padding(20, 0, 8, 0);
            button9.FlatAppearance.BorderSize = 0;
            button9.Click += btnHome_Click;
            button9.FlatAppearance.BorderSize = 0;

            Image logoutImage = Properties.Resources.ic_logout;
            Image resizedlogoutImage = new Bitmap(logoutImage, new Size(30, 30));
            button10.Image = resizedlogoutImage;
            button10.TextImageRelation = TextImageRelation.ImageBeforeText;
            button10.ImageAlign = ContentAlignment.MiddleLeft;
            button10.Padding = new Padding(20, 0, 8, 0);
            button10.FlatAppearance.BorderSize = 0;
            button10.Click += btnLogout_Click;
            button10.FlatAppearance.BorderSize = 0;

            loadHome();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            UserSession.Instance.EndSession();

            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            loadHome();

            //contentPanel.Controls.Clear();
            //var homeControl = new HomeControl();

            //homeControl.Size = new Size(267, this.ClientSize.Height);
            //this.Resize += (s, e) =>
            //{
            //    homeControl.Height = this.ClientSize.Height;
            //};

            //homeControl.Width = this.ClientSize.Width;
            //contentPanel.Controls.Add(homeControl);
        }

        private void btnSent_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            var sentControl = new SentControl();

            sentControl.Location = new Point(300, 100);

            sentControl.Size = new Size(267, this.ClientSize.Height);
            this.Resize += (s, e) =>
            {
                sentControl.Height = this.ClientSize.Height;
            };

            sentControl.Width = this.ClientSize.Width;
            contentPanel.Controls.Add(sentControl);
        }


        private void Home_Load(object sender, EventArgs e)
        {
            panel1.Paint += Panel2_Paint;
        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            int shadowWidth = 2;

            Rectangle shadowRect = new Rectangle(panel.Width - shadowWidth, 0, shadowWidth, panel.Height);

            using (LinearGradientBrush brush = new LinearGradientBrush(
                shadowRect,
                Color.FromArgb(100, Color.Gray), 
                Color.Transparent,               
                LinearGradientMode.Horizontal))
            {
                e.Graphics.FillRectangle(brush, shadowRect);
            }
        }
    }
}

