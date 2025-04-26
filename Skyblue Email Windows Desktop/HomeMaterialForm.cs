using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static Skyblue_Email_Windows_Desktop.Form1;

namespace Skyblue_Email_Windows_Desktop
{
    public partial class HomeMaterialForm : MaterialForm
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        public HomeMaterialForm()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            autoResizeListView();

            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(
                Primary.Blue500, Primary.Blue700,
                Primary.Blue100, Accent.LightBlue200,
                TextShade.WHITE);

            loadHome();
        }

        private void materialListView1_Click(object sender, EventArgs e)
        {
            if (materialListView1.SelectedItems.Count > 0)
            {
                var selectedItem = materialListView1.SelectedItems[0];
                string from = selectedItem.Text;
                string subject = selectedItem.SubItems.Count > 1 ? selectedItem.SubItems[1].Text : "";

                MessageBox.Show($"From: {from}\nSubject: {subject}");
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Disable title bar painting by skipping base call
            // base.OnPaint(e); ← Do NOT call this
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private async Task loadHome()
        {
            await InboxAsync();
        }

        private async Task InboxAsync()
        {

            materialListView1.View = View.Details;
            materialListView1.OwnerDraw = false;
            materialListView1.GridLines = true;

            materialListView1.Columns.Add("From", 500);
            materialListView1.Columns.Add("Subject", materialListView1.ClientSize.Width);

            materialListView1.FullRowSelect = true;
            materialListView1.HeaderStyle = ColumnHeaderStyle.None;
            materialListView1.BorderStyle = BorderStyle.None;
            materialListView1.Columns.Add("", materialListView1.ClientSize.Width); // single column, no header
            materialListView1.Click += materialListView1_Click;


            string username = UserSession.Instance.Username;
            string password = UserSession.Instance.Password;

            var data = new MyData
            {
                acc = "get_inbox",
                email = username,
                password = password
            };

            using (HttpClient client = new HttpClient())
            {
                string json = JsonSerializer.Serialize(data); // Serialize object to JSON
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("https://skyblue.co.in/mail/mail.php", content);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    //  MessageBox.Show("Success! Response: " + responseContent);

                    MyData myData = JsonSerializer.Deserialize<MyData>(responseContent);

                    JObject obj = JObject.Parse(responseContent);

                    string status = (string)obj["status"];

                    if (status.Equals("true"))
                    {
                        foreach (var prop in obj.Properties())
                        {
                            if (int.TryParse(prop.Name, out _))
                            {
                                string fromName = (string)prop.Value["from"];
                                string subject = (string)prop.Value["subject"];
                                Console.WriteLine($"From: {fromName}");
                                //    materialListView1.Items.Add(fromName);
                                var item = new ListViewItem(fromName);
                                item.SubItems.Add(subject);
                                materialListView1.Items.Add(item);

                            }
                        }
                        
                    }
                }
                else
                {
                    MessageBox.Show("Error: " + response.StatusCode);
                }
            }
        }


private void autoResizeListView()
        {
            int screenWidth = Screen.FromControl(this).WorkingArea.Width;
            int screenHeight = Screen.FromControl(this).WorkingArea.Height;

            materialListView1.Location = new Point(10, 10);
            materialListView1.Size = new Size(screenWidth - 300, screenHeight - 130);
        }
    }
}