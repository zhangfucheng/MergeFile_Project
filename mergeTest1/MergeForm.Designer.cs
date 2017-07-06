namespace mergeFile
{
    partial class MergeForm
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
            this.filepath1 = new System.Windows.Forms.Button();
            this.filepath2 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.merge = new System.Windows.Forms.Button();
            this.filePath1Text = new System.Windows.Forms.TextBox();
            this.filePath1Label = new System.Windows.Forms.Label();
            this.filePath2Label = new System.Windows.Forms.Label();
            this.filePath2Text = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // filepath1
            // 
            this.filepath1.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.filepath1.Location = new System.Drawing.Point(466, 58);
            this.filepath1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.filepath1.Name = "filepath1";
            this.filepath1.Size = new System.Drawing.Size(93, 30);
            this.filepath1.TabIndex = 0;
            this.filepath1.Text = "选择";
            this.filepath1.UseVisualStyleBackColor = true;
            this.filepath1.Click += new System.EventHandler(this.filepath1_Click);
            // 
            // filepath2
            // 
            this.filepath2.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.filepath2.Location = new System.Drawing.Point(466, 119);
            this.filepath2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.filepath2.Name = "filepath2";
            this.filepath2.Size = new System.Drawing.Size(93, 31);
            this.filepath2.TabIndex = 1;
            this.filepath2.Text = "选择";
            this.filepath2.UseVisualStyleBackColor = true;
            this.filepath2.Click += new System.EventHandler(this.filepath2_Click);
            // 
            // merge
            // 
            this.merge.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.merge.Location = new System.Drawing.Point(263, 240);
            this.merge.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.merge.Name = "merge";
            this.merge.Size = new System.Drawing.Size(75, 39);
            this.merge.TabIndex = 2;
            this.merge.Text = "合并";
            this.merge.UseVisualStyleBackColor = true;
            this.merge.Click += new System.EventHandler(this.merge_Click);
            // 
            // filePath1Text
            // 
            this.filePath1Text.BackColor = System.Drawing.SystemColors.Window;
            this.filePath1Text.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filePath1Text.Font = new System.Drawing.Font("SimSun", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.filePath1Text.Location = new System.Drawing.Point(124, 58);
            this.filePath1Text.Name = "filePath1Text";
            this.filePath1Text.Size = new System.Drawing.Size(336, 27);
            this.filePath1Text.TabIndex = 3;
            // 
            // filePath1Label
            // 
            this.filePath1Label.AutoSize = true;
            this.filePath1Label.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.filePath1Label.Location = new System.Drawing.Point(49, 61);
            this.filePath1Label.Name = "filePath1Label";
            this.filePath1Label.Size = new System.Drawing.Size(69, 20);
            this.filePath1Label.TabIndex = 4;
            this.filePath1Label.Text = "文件1:";
            // 
            // filePath2Label
            // 
            this.filePath2Label.AutoSize = true;
            this.filePath2Label.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.filePath2Label.Location = new System.Drawing.Point(49, 124);
            this.filePath2Label.Name = "filePath2Label";
            this.filePath2Label.Size = new System.Drawing.Size(69, 20);
            this.filePath2Label.TabIndex = 5;
            this.filePath2Label.Text = "文件2:";
            // 
            // filePath2Text
            // 
            this.filePath2Text.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filePath2Text.Font = new System.Drawing.Font("SimSun", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.filePath2Text.Location = new System.Drawing.Point(124, 120);
            this.filePath2Text.Name = "filePath2Text";
            this.filePath2Text.Size = new System.Drawing.Size(336, 27);
            this.filePath2Text.TabIndex = 6;
            // 
            // MergeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(620, 341);
            this.Controls.Add(this.filePath2Text);
            this.Controls.Add(this.filePath2Label);
            this.Controls.Add(this.filePath1Label);
            this.Controls.Add(this.filePath1Text);
            this.Controls.Add(this.merge);
            this.Controls.Add(this.filepath2);
            this.Controls.Add(this.filepath1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MergeForm";
            this.RightToLeftLayout = true;
            this.Text = "Merge";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button filepath1;
        private System.Windows.Forms.Button filepath2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button merge;
        private System.Windows.Forms.TextBox filePath1Text;
        private System.Windows.Forms.Label filePath1Label;
        private System.Windows.Forms.Label filePath2Label;
        private System.Windows.Forms.TextBox filePath2Text;
    }
}

