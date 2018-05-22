namespace POS_Fusion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label2 = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtpath = new System.Windows.Forms.TextBox();
            this.move_all_right = new System.Windows.Forms.Button();
            this.move_one_right = new System.Windows.Forms.Button();
            this.move_one_left = new System.Windows.Forms.Button();
            this.move_all_left = new System.Windows.Forms.Button();
            this.list2 = new System.Windows.Forms.ListBox();
            this.list1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Book", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(111, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(391, 34);
            this.label2.TabIndex = 19;
            this.label2.Text = "Etat VoluCompteurs et Sondes";
            // 
            // btn_save
            // 
            this.btn_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_save.AutoSize = true;
            this.btn_save.BackColor = System.Drawing.Color.Transparent;
            this.btn_save.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_save.BackgroundImage")));
            this.btn_save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_save.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.Location = new System.Drawing.Point(577, 422);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(48, 41);
            this.btn_save.TabIndex = 18;
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click_1);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Book", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(12, 433);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 23);
            this.label1.TabIndex = 17;
            this.label1.Text = "Chemin :";
            // 
            // txtpath
            // 
            this.txtpath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtpath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpath.ForeColor = System.Drawing.Color.Black;
            this.txtpath.Location = new System.Drawing.Point(93, 433);
            this.txtpath.Name = "txtpath";
            this.txtpath.Size = new System.Drawing.Size(462, 22);
            this.txtpath.TabIndex = 16;
            // 
            // move_all_right
            // 
            this.move_all_right.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.move_all_right.AutoSize = true;
            this.move_all_right.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.move_all_right.Location = new System.Drawing.Point(297, 161);
            this.move_all_right.Name = "move_all_right";
            this.move_all_right.Size = new System.Drawing.Size(45, 29);
            this.move_all_right.TabIndex = 15;
            this.move_all_right.Text = ">>";
            this.move_all_right.UseVisualStyleBackColor = true;
            this.move_all_right.Click += new System.EventHandler(this.move_all_right_Click);
            // 
            // move_one_right
            // 
            this.move_one_right.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.move_one_right.AutoSize = true;
            this.move_one_right.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.move_one_right.Location = new System.Drawing.Point(297, 210);
            this.move_one_right.Name = "move_one_right";
            this.move_one_right.Size = new System.Drawing.Size(45, 29);
            this.move_one_right.TabIndex = 14;
            this.move_one_right.Text = ">";
            this.move_one_right.UseVisualStyleBackColor = true;
            this.move_one_right.Click += new System.EventHandler(this.move_one_right_Click);
            // 
            // move_one_left
            // 
            this.move_one_left.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.move_one_left.AutoSize = true;
            this.move_one_left.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.move_one_left.Location = new System.Drawing.Point(297, 260);
            this.move_one_left.Name = "move_one_left";
            this.move_one_left.Size = new System.Drawing.Size(45, 29);
            this.move_one_left.TabIndex = 13;
            this.move_one_left.Text = "<";
            this.move_one_left.UseVisualStyleBackColor = true;
            this.move_one_left.Click += new System.EventHandler(this.move_one_left_Click);
            // 
            // move_all_left
            // 
            this.move_all_left.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.move_all_left.AutoSize = true;
            this.move_all_left.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.move_all_left.Location = new System.Drawing.Point(297, 311);
            this.move_all_left.Name = "move_all_left";
            this.move_all_left.Size = new System.Drawing.Size(45, 29);
            this.move_all_left.TabIndex = 12;
            this.move_all_left.Text = "<<";
            this.move_all_left.UseVisualStyleBackColor = true;
            this.move_all_left.Click += new System.EventHandler(this.move_all_left_Click);
            // 
            // list2
            // 
            this.list2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.list2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.list2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list2.FormattingEnabled = true;
            this.list2.ItemHeight = 16;
            this.list2.Location = new System.Drawing.Point(352, 84);
            this.list2.Name = "list2";
            this.list2.Size = new System.Drawing.Size(272, 322);
            this.list2.TabIndex = 11;
            // 
            // list1
            // 
            this.list1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.list1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.list1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list1.FormattingEnabled = true;
            this.list1.ItemHeight = 16;
            this.list1.Location = new System.Drawing.Point(12, 84);
            this.list1.Name = "list1";
            this.list1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.list1.Size = new System.Drawing.Size(274, 322);
            this.list1.Sorted = true;
            this.list1.TabIndex = 10;
            this.list1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(636, 472);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtpath);
            this.Controls.Add(this.move_all_right);
            this.Controls.Add(this.move_one_right);
            this.Controls.Add(this.move_one_left);
            this.Controls.Add(this.move_all_left);
            this.Controls.Add(this.list2);
            this.Controls.Add(this.list1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(652, 510);
            this.MinimumSize = new System.Drawing.Size(652, 510);
            this.Name = "Form1";
            this.Text = "Etat VoluCompteurs et Sondes";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtpath;
        private System.Windows.Forms.Button move_all_right;
        private System.Windows.Forms.Button move_one_right;
        private System.Windows.Forms.Button move_one_left;
        private System.Windows.Forms.Button move_all_left;
        private System.Windows.Forms.ListBox list2;
        private System.Windows.Forms.ListBox list1;
    }
}

