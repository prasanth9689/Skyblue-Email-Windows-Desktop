using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Security;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using MaterialSkin;
using MaterialSkin.Controls;
using static Skyblue_Email_Windows_Desktop.Form1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Skyblue_Email_Windows_Desktop
{
    public partial class HomeControl : UserControl
    {
        public HomeControl()
        {
            InitializeComponent();

            //listView1.Size = new Size(267, this.ClientSize.Height);
            //this.Resize += (s, e) =>
            //{
            //    listView1.Height = this.ClientSize.Height;
            //};
            //listView1.Width = this.ClientSize.Width;
          
            HomeMaterialForm frm = new HomeMaterialForm();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Visible = true;
            frm.Dock = DockStyle.Fill;
            
            this.Controls.Add(frm);
        }

    //      public void EmbedForm(HomeMaterialForm frm) {
    //    frm.TopLevel = false;
    //    frm.FormBorderStyle = FormBorderStyle.None;
    //    frm.Visible = true;
    //    frm.Dock = DockStyle.Fill;   // optional
    //    this.Controls.Add(frm);
    //}

        private async void loadHome()
        {
            //await InboxAsync();
        }

        private async Task InboxAsync()
        {
            //string username = UserSession.Instance.Username;
            //string password = UserSession.Instance.Password;

            //var data = new MyData
            //{
            //    acc = "get_inbox",
            //    email = username,
            //    password = password
            //};

            //using (HttpClient client = new HttpClient())
            //{
            //    string json = JsonSerializer.Serialize(data); // Serialize object to JSON
            //    var content = new StringContent(json, Encoding.UTF8, "application/json");

            //    HttpResponseMessage response = await client.PostAsync("https://skyblue.co.in/mail/mail.php", content);

            //    if (response.IsSuccessStatusCode)
            //    {
            //        string responseContent = await response.Content.ReadAsStringAsync();
            //        //  MessageBox.Show("Success! Response: " + responseContent);

            //        MyData myData = JsonSerializer.Deserialize<MyData>(responseContent);

            //        JObject obj = JObject.Parse(responseContent);

            //        string status = (string)obj["status"];

            //        if (status.Equals("true"))
            //        {
            //            listView1.Clear();
                        
            //            listView1.View = View.Details;
                      
            //            listView1.CheckBoxes = true;

            //            listView1.HeaderStyle = ColumnHeaderStyle.None;
                        
            //            listView1.Columns.Add("", -2);

            //            foreach (var prop in obj.Properties())
            //            {
            //                if (int.TryParse(prop.Name, out _))
            //                {
            //                    string fromName = (string)prop.Value["from"];
            //                    Console.WriteLine($"From: {fromName}");
            //                    listView1.Items.Add(fromName);
            //                }
            //            }
            //        }
            //        }
            //    else
            //    {
            //        MessageBox.Show("Error: " + response.StatusCode);

            //    }

            //}
        }

    }
}
