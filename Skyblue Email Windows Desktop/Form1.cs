using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Skyblue_Email_Windows_Desktop
{
    public partial class Form1 : Form
    {


        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizedBounds = Screen.GetWorkingArea(this);
            this.TopLevel = true;
            this.TopMost = false;
            this.ShowInTaskbar = true;

            //this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;
            this.Visible = true;


            this.WindowState = FormWindowState.Maximized;
            Panel titleBar = new Panel();
            titleBar.Dock = DockStyle.Top;
            titleBar.Height = 50;
            titleBar.BackColor = Color.FromArgb(224, 224, 224); // dark theme
            titleBar.MouseDown += TitleBar_MouseDown;
            this.Controls.Add(titleBar);

            Button btnClose = new Button();
            btnClose.Text = "✕"; // or "X"
            btnClose.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.BackColor = Color.FromArgb(41, 113, 252);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Size = new Size(40, 50);
            btnClose.Location = new Point(this.Width - 40, 0);
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.Click += (s, e) => this.Close();
            titleBar.Controls.Add(btnClose);

            Button btnMinimize = new Button();
            btnMinimize.Text = "―"; // or "_"
            btnMinimize.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnMinimize.ForeColor = Color.White;
            btnMinimize.BackColor = Color.FromArgb(41, 113, 252);
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.Size = new Size(40, 50);
            btnMinimize.Location = new Point(this.Width - 120, 0);
            btnMinimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMinimize.Click += (s, e) => this.WindowState = FormWindowState.Minimized;
            titleBar.Controls.Add(btnMinimize);

            Button btnMaximize = new Button();
            btnMaximize.Text = "🗖"; // Unicode for maximize or use an icon
            btnMaximize.ForeColor = Color.White;
            btnMaximize.BackColor = Color.FromArgb(41, 113, 252);
            btnMaximize.FlatStyle = FlatStyle.Flat;
            btnMaximize.FlatAppearance.BorderSize = 0;
            btnMaximize.Size = new Size(40, 50);
            btnMaximize.Location = new Point(this.Width - 80, 0);
            btnMaximize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMaximize.Click += BtnMaximize_Click;
            titleBar.Controls.Add(btnMaximize);

            btnClose.MouseEnter += (s, e) => btnClose.BackColor = Color.Red;
            btnClose.MouseLeave += (s, e) => btnClose.BackColor = Color.FromArgb(50, 50, 50);

            // To get screen width and height
            int workWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int workHeight = Screen.PrimaryScreen.WorkingArea.Height;

            Console.WriteLine($"Working Area Width: {workWidth}, Height: {workHeight}");

            textBox1.Left = (workHeight - textBox1.Width) / 2;
            textBox2.Left = (workHeight - textBox2.Width) / 2;
            button1.Left = (workHeight - button1.Width) / 2;
            pictureBox1.Left = (workHeight - pictureBox1.Width) / 2;

            textBox1.Top = (workHeight - textBox1.Height) / 2;
            textBox2.Top = (workHeight + 150 - textBox2.Height) / 2;
            button1.Top = (workHeight + 300 - button1.Height) / 2;
            pictureBox1.Top = (workHeight - pictureBox1.Height) / 2;

            // To hide split container center line and disable the splitter appearance and movement.
            splitContainer1.SplitterWidth = 1; // Reduce the thickness
            splitContainer1.IsSplitterFixed = true; // Prevent dragging
            splitContainer1.BackColor = splitContainer1.Panel1.BackColor; // Match background

        }

        private void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void BtnMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void MakeDraggable(Control control)
        {
            control.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(this.Handle, 0xA1, 0x2, 0);
                }
            };
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Enter email");
                textBox1.Focus();
                return;
            }

            if (!IsValidEmail(textBox1.Text))
            {
                MessageBox.Show("Please enter a valid email address.");
                textBox1.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Enter password");
                textBox2.Focus();
                return;
            }

            login();
        }

        private async void login()
        {
            MessageBox.Show("Please wait login");
            await PostDataAsync();
        }

        public class MyData
        {
            public string Acc { get; set; }
            public int Age { get; set; }
        }


        private async Task PostDataAsync()
        {
            var data = new MyData
            {
                Acc = "login",
                Age = 30
            };

            using (HttpClient client = new HttpClient())
            {
                string json = JsonSerializer.Serialize(data); // Serialize object to JSON
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("https://skyblue.co.in/mail/mail.php", content);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Success! Response: " + responseContent);
                }
                else
                {
                    MessageBox.Show("Error: " + response.StatusCode);
                }
            }
        }


        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
    }
}
