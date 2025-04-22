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

namespace Skyblue_Email_Windows_Desktop
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Test_Load(object sender, EventArgs e)
        {
            panel1.Paint += Panel1_Paint;

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            int shadowWidth = 2;

            Rectangle shadowRect = new Rectangle(panel.Width - shadowWidth, 0, shadowWidth, panel.Height);

            using (LinearGradientBrush brush = new LinearGradientBrush(
                shadowRect,
                Color.FromArgb(100, Color.Gray), // darker on the right
                Color.Transparent,                // fades to transparent
                LinearGradientMode.Horizontal))
            {
                e.Graphics.FillRectangle(brush, shadowRect);
            }
        }

    }
}
