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
using Skyblue_Email_Windows_Desktop.Properties;

namespace Skyblue_Email_Windows_Desktop
{
    public partial class Home : Form
    {
        //  Panel sidePanel = new Panel();
        Panel contentPanel = new Panel();


        public Home()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            createLeftNav();

            autoSizeLayout();
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
            button3.Click += btnHome_Click;
            button3.FlatAppearance.BorderSize = 0;

            Image draftImage = Properties.Resources.ic_draft;
            Image resizedDraftImage = new Bitmap(draftImage, new Size(30, 30));
            button4.Image = resizedImage;
            button4.TextImageRelation = TextImageRelation.ImageBeforeText;
            button4.ImageAlign = ContentAlignment.MiddleLeft;
            button4.Padding = new Padding(20, 0, 8, 0);
            button4.FlatAppearance.BorderSize = 0;
            button4.Click += btnHome_Click;
            button4.FlatAppearance.BorderSize = 0;

            Image originalImage5 = Properties.Resources.inbox;
            Image resizedImage5 = new Bitmap(originalImage, new Size(30, 30));
            button5.Image = resizedImage;
            button5.TextImageRelation = TextImageRelation.ImageBeforeText;
            button5.ImageAlign = ContentAlignment.MiddleLeft;
            button5.Padding = new Padding(20, 0, 8, 0);
            button5.FlatAppearance.BorderSize = 0;
            button5.Click += btnHome_Click;
            button5.FlatAppearance.BorderSize = 0;

            Image originalImage6 = Properties.Resources.inbox;
            Image resizedImage6 = new Bitmap(originalImage, new Size(30, 30));
            button6.Image = resizedImage;
            button6.TextImageRelation = TextImageRelation.ImageBeforeText;
            button6.ImageAlign = ContentAlignment.MiddleLeft;
            button6.Padding = new Padding(20, 0, 8, 0);
            button6.FlatAppearance.BorderSize = 0;
            button6.Click += btnHome_Click;
            button6.FlatAppearance.BorderSize = 0;

            Image originalImage7 = Properties.Resources.inbox;
            Image resizedImage7 = new Bitmap(originalImage, new Size(30, 30));
            button7.Image = resizedImage;
            button7.TextImageRelation = TextImageRelation.ImageBeforeText;
            button7.ImageAlign = ContentAlignment.MiddleLeft;
            button7.Padding = new Padding(20, 0, 8, 0);
            button7.FlatAppearance.BorderSize = 0;
            button7.Click += btnHome_Click;
            button7.FlatAppearance.BorderSize = 0;

            Image originalImage8 = Properties.Resources.inbox;
            Image resizedImage8 = new Bitmap(originalImage, new Size(30, 30));
            button8.Image = resizedImage;
            button8.TextImageRelation = TextImageRelation.ImageBeforeText;
            button8.ImageAlign = ContentAlignment.MiddleLeft;
            button8.Padding = new Padding(20, 0, 8, 0);
            button8.FlatAppearance.BorderSize = 0;
            button8.Click += btnHome_Click;
            button8.FlatAppearance.BorderSize = 0;

            Image originalImage9 = Properties.Resources.inbox;
            Image resizedImage9 = new Bitmap(originalImage, new Size(30, 30));
            button9.Image = resizedImage;
            button9.TextImageRelation = TextImageRelation.ImageBeforeText;
            button9.ImageAlign = ContentAlignment.MiddleLeft;
            button9.Padding = new Padding(20, 0, 8, 0);
            button9.FlatAppearance.BorderSize = 0;
            button9.Click += btnHome_Click;
            button9.FlatAppearance.BorderSize = 0;

            Image originalImage10 = Properties.Resources.inbox;
            Image resizedImage10 = new Bitmap(originalImage, new Size(30, 30));
            button10.Image = resizedImage;
            button10.TextImageRelation = TextImageRelation.ImageBeforeText;
            button10.ImageAlign = ContentAlignment.MiddleLeft;
            button10.Padding = new Padding(20, 0, 8, 0);
            button10.FlatAppearance.BorderSize = 0;
            button10.Click += btnHome_Click;
            button10.FlatAppearance.BorderSize = 0;

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            var homeControl = new HomeControl();

            homeControl.Size = new Size(267, this.ClientSize.Height);
            this.Resize += (s, e) =>
            {
                homeControl.Height = this.ClientSize.Height;
            };

            homeControl.Width = this.ClientSize.Width;
            contentPanel.Controls.Add(homeControl);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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

//Button btnSend = new Button();
//btnSend.Text = "Send";
//btnSend.Dock = DockStyle.Top;
//btnSend.Height = 50;
//btnSend.FlatStyle = FlatStyle.Flat;
//btnSend.ForeColor = Color.Black;
//btnSend.FlatAppearance.BorderSize = 0;

//Button btnDraft = new Button();
//btnDraft.Text = "Draft";
//btnDraft.Dock = DockStyle.Top;
//btnDraft.Height = 50;
//btnDraft.FlatStyle = FlatStyle.Flat;
//btnDraft.ForeColor = Color.Black;
//btnDraft.FlatAppearance.BorderSize = 0;

//Button btnImportant = new Button();
//btnImportant.Text = "Important";
//btnImportant.Dock = DockStyle.Top;
//btnImportant.Height = 50;
//btnImportant.FlatStyle = FlatStyle.Flat;
//btnImportant.ForeColor = Color.Black;
//btnImportant.FlatAppearance.BorderSize = 0;

//Button btnSpam = new Button();
//btnSpam.Text = "Spam";
//btnSpam.Dock = DockStyle.Top;
//btnSpam.Height = 50;
//btnSpam.FlatStyle = FlatStyle.Flat;
//btnSpam.ForeColor = Color.Black;
//btnSpam.FlatAppearance.BorderSize = 0;

//Button btnTrash = new Button();
//btnTrash.Text = "Trash";
//btnTrash.Dock = DockStyle.Top;
//btnTrash.Height = 50;
//btnTrash.FlatStyle = FlatStyle.Flat;
//btnTrash.ForeColor = Color.Black;
//btnTrash.FlatAppearance.BorderSize = 0;

//Button btnCalenar = new Button();
//btnCalenar.Text = "Calenar";
//btnCalenar.Dock = DockStyle.Top;
//btnCalenar.Height = 50;
//btnCalenar.FlatStyle = FlatStyle.Flat;
//btnCalenar.ForeColor = Color.Black;
//btnCalenar.FlatAppearance.BorderSize = 0;

//Button btnSettings = new Button();
//btnSettings.Text = "Settings";
//btnSettings.Dock = DockStyle.Top;
//btnSettings.Height = 50;
//btnSettings.FlatStyle = FlatStyle.Flat;
//btnSettings.ForeColor = Color.Black;
//btnSettings.FlatAppearance.BorderSize = 0;

//Button btnLogout = new Button();
//btnLogout.Text = "Logout";
//btnLogout.Dock = DockStyle.Top;
//btnLogout.Height = 50;
//btnLogout.FlatStyle = FlatStyle.Flat;
//btnLogout.ForeColor = Color.Black;
//btnLogout.FlatAppearance.BorderSize = 0;

//panel1.Controls.Add(btnLogout);
//panel1.Controls.Add(btnSettings);
//panel1.Controls.Add(btnCalenar);
//panel1.Controls.Add(btnTrash);
//panel1.Controls.Add(btnSpam);
//panel1.Controls.Add(btnImportant);
//panel1.Controls.Add(btnDraft);
//panel1.Controls.Add(btnSend);
//panel1.Controls.Add(btnInbox);
