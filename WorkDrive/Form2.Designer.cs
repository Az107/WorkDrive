namespace app2test
{
    partial class Form2
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.AllowDrop = true;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(10, 350);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView1_DragDrop);
            this.listView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form2_DragEnter);
            this.listView1.DragOver += new System.Windows.Forms.DragEventHandler(this.Form2_DragOver);
            this.listView1.DragLeave += new System.EventHandler(this.Form2_Leave);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            this.listView1.MouseEnter += new System.EventHandler(this.Form2_Enter);
            this.listView1.MouseLeave += new System.EventHandler(this.Form2_Leave);
            this.listView1.MouseHover += new System.EventHandler(this.Form2_Enter);
            // 
            // Form2
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(10, 350);
            this.Controls.Add(this.listView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(100, 50);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form2";
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form2_DragEnter);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.Form2_DragOver);
            this.DragLeave += new System.EventHandler(this.Form2_Leave);
            this.Enter += new System.EventHandler(this.Form2_Enter);
            this.Leave += new System.EventHandler(this.Form2_Leave);
            this.MouseEnter += new System.EventHandler(this.Form2_Enter);
            this.MouseLeave += new System.EventHandler(this.Form2_Leave);
            this.MouseHover += new System.EventHandler(this.Form2_Enter);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
    }
}