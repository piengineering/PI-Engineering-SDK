namespace PIHidDotName_Csharp_Sample
{
    partial class Form1
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
            this.BtnEnumerate = new System.Windows.Forms.Button();
            this.CboDevices = new System.Windows.Forms.ComboBox();
            this.BtnSlow = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.BtnCallback = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnClear = new System.Windows.Forms.Button();
            this.BtnDefault = new System.Windows.Forms.Button();
            this.LblKeysPressed = new System.Windows.Forms.Label();
            this.LblMouse = new System.Windows.Forms.Label();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnEnumerate
            // 
            this.BtnEnumerate.Location = new System.Drawing.Point(9, 17);
            this.BtnEnumerate.Margin = new System.Windows.Forms.Padding(2);
            this.BtnEnumerate.Name = "BtnEnumerate";
            this.BtnEnumerate.Size = new System.Drawing.Size(98, 20);
            this.BtnEnumerate.TabIndex = 0;
            this.BtnEnumerate.Text = "Enumerate";
            this.BtnEnumerate.UseVisualStyleBackColor = true;
            this.BtnEnumerate.Click += new System.EventHandler(this.BtnEnumerate_Click);
            // 
            // CboDevices
            // 
            this.CboDevices.FormattingEnabled = true;
            this.CboDevices.Location = new System.Drawing.Point(134, 16);
            this.CboDevices.Margin = new System.Windows.Forms.Padding(2);
            this.CboDevices.Name = "CboDevices";
            this.CboDevices.Size = new System.Drawing.Size(230, 21);
            this.CboDevices.TabIndex = 1;
            this.CboDevices.SelectedIndexChanged += new System.EventHandler(this.CboDevices_SelectedIndexChanged);
            // 
            // BtnSlow
            // 
            this.BtnSlow.Location = new System.Drawing.Point(12, 290);
            this.BtnSlow.Margin = new System.Windows.Forms.Padding(2);
            this.BtnSlow.Name = "BtnSlow";
            this.BtnSlow.Size = new System.Drawing.Size(176, 20);
            this.BtnSlow.TabIndex = 2;
            this.BtnSlow.Text = "Slow Mouse Messages";
            this.BtnSlow.UseVisualStyleBackColor = true;
            this.BtnSlow.Click += new System.EventHandler(this.BtnSlow_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(9, 104);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(354, 69);
            this.listBox1.TabIndex = 6;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 342);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(404, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // BtnCallback
            // 
            this.BtnCallback.Location = new System.Drawing.Point(9, 64);
            this.BtnCallback.Margin = new System.Windows.Forms.Padding(2);
            this.BtnCallback.Name = "BtnCallback";
            this.BtnCallback.Size = new System.Drawing.Size(168, 20);
            this.BtnCallback.TabIndex = 10;
            this.BtnCallback.Text = "Setup for Callback";
            this.BtnCallback.UseVisualStyleBackColor = true;
            this.BtnCallback.Click += new System.EventHandler(this.BtnCallback_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 1);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "1. Do this first";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "2. Set for data callback and read data";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 266);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "3. Adjust mouse message timing";
            // 
            // BtnClear
            // 
            this.BtnClear.Location = new System.Drawing.Point(262, 80);
            this.BtnClear.Margin = new System.Windows.Forms.Padding(2);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(98, 20);
            this.BtnClear.TabIndex = 20;
            this.BtnClear.Text = "Clear Listbox";
            this.BtnClear.UseVisualStyleBackColor = true;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // BtnDefault
            // 
            this.BtnDefault.Location = new System.Drawing.Point(192, 290);
            this.BtnDefault.Margin = new System.Windows.Forms.Padding(2);
            this.BtnDefault.Name = "BtnDefault";
            this.BtnDefault.Size = new System.Drawing.Size(184, 20);
            this.BtnDefault.TabIndex = 21;
            this.BtnDefault.Text = "Default Mouse Message Speed";
            this.BtnDefault.UseVisualStyleBackColor = true;
            this.BtnDefault.Click += new System.EventHandler(this.BtnDefault_Click);
            // 
            // LblKeysPressed
            // 
            this.LblKeysPressed.AutoSize = true;
            this.LblKeysPressed.Location = new System.Drawing.Point(10, 187);
            this.LblKeysPressed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblKeysPressed.Name = "LblKeysPressed";
            this.LblKeysPressed.Size = new System.Drawing.Size(70, 13);
            this.LblKeysPressed.TabIndex = 22;
            this.LblKeysPressed.Text = "Keys pressed";
            // 
            // LblMouse
            // 
            this.LblMouse.AutoSize = true;
            this.LblMouse.Location = new System.Drawing.Point(10, 226);
            this.LblMouse.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblMouse.Name = "LblMouse";
            this.LblMouse.Size = new System.Drawing.Size(39, 13);
            this.LblMouse.TabIndex = 23;
            this.LblMouse.Text = "Mouse";
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(315, 187);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(20, 65);
            this.vScrollBar1.TabIndex = 24;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(404, 364);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.LblMouse);
            this.Controls.Add(this.LblKeysPressed);
            this.Controls.Add(this.BtnDefault);
            this.Controls.Add(this.BtnClear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnCallback);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.BtnSlow);
            this.Controls.Add(this.CboDevices);
            this.Controls.Add(this.BtnEnumerate);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "C# PS/2 Host Emulator Sample";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnEnumerate;
        private System.Windows.Forms.ComboBox CboDevices;
        private System.Windows.Forms.Button BtnSlow;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button BtnCallback;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.Button BtnDefault;
        private System.Windows.Forms.Label LblKeysPressed;
        private System.Windows.Forms.Label LblMouse;
        private System.Windows.Forms.VScrollBar vScrollBar1;
    }
}

