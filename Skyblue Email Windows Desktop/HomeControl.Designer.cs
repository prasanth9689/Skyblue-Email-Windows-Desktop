namespace Skyblue_Email_Windows_Desktop
{
    partial class HomeControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listView1 = new ListView();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Activation = ItemActivation.OneClick;
            listView1.BackColor = SystemColors.MenuHighlight;
            listView1.BorderStyle = BorderStyle.None;
            listView1.Font = new Font("Arial Narrow", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            listView1.FullRowSelect = true;
            listView1.HotTracking = true;
            listView1.HoverSelection = true;
            listView1.Location = new Point(20, 20);
            listView1.Name = "listView1";
            listView1.Size = new Size(263, 195);
            listView1.TabIndex = 0;
            listView1.TileSize = new Size(10, 10);
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.Visible = false;
            // 
            // HomeControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.White;
            BorderStyle = BorderStyle.Fixed3D;
            Controls.Add(listView1);
            DoubleBuffered = true;
            Location = new Point(300, 100);
            Name = "HomeControl";
            Size = new Size(1402, 688);
            ResumeLayout(false);
        }

        #endregion

        private ListView listView1;
    }
}
