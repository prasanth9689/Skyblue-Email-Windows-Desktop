namespace Skyblue_Email_Windows_Desktop
{
    partial class HomeMaterialForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            materialListView1 = new MaterialSkin.Controls.MaterialListView();
            SuspendLayout();
            // 
            // materialListView1
            // 
            materialListView1.Activation = ItemActivation.OneClick;
            materialListView1.AutoSizeTable = false;
            materialListView1.BackColor = Color.FromArgb(255, 255, 255);
            materialListView1.BorderStyle = BorderStyle.None;
            materialListView1.Depth = 0;
            materialListView1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            materialListView1.FullRowSelect = true;
            materialListView1.HotTracking = true;
            materialListView1.HoverSelection = true;
            materialListView1.Location = new Point(6, 68);
            materialListView1.MinimumSize = new Size(200, 100);
            materialListView1.MouseLocation = new Point(-1, -1);
            materialListView1.MouseState = MaterialSkin.MouseState.OUT;
            materialListView1.Name = "materialListView1";
            materialListView1.OwnerDraw = true;
            materialListView1.Size = new Size(1358, 566);
            materialListView1.TabIndex = 0;
            materialListView1.UseCompatibleStateImageBehavior = false;
            materialListView1.View = View.Details;
            // 
            // HomeMaterialForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1380, 653);
            Controls.Add(materialListView1);
            Name = "HomeMaterialForm";
            Text = "Skyblue Mail";
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialListView materialListView1;
    }
}