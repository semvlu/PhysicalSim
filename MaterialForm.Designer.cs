namespace Mid
{
    partial class MaterialForm
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
            this.btn_AL = new System.Windows.Forms.Button();
            this.btn_FE = new System.Windows.Forms.Button();
            this.btn_PB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_AL
            // 
            this.btn_AL.Location = new System.Drawing.Point(31, 57);
            this.btn_AL.Name = "btn_AL";
            this.btn_AL.Size = new System.Drawing.Size(48, 51);
            this.btn_AL.TabIndex = 0;
            this.btn_AL.Text = "鋁";
            this.btn_AL.UseVisualStyleBackColor = true;
            this.btn_AL.Click += new System.EventHandler(this.btn_AL_Click);
            // 
            // btn_FE
            // 
            this.btn_FE.Location = new System.Drawing.Point(147, 58);
            this.btn_FE.Name = "btn_FE";
            this.btn_FE.Size = new System.Drawing.Size(48, 51);
            this.btn_FE.TabIndex = 1;
            this.btn_FE.Text = "鐵";
            this.btn_FE.UseVisualStyleBackColor = true;
            this.btn_FE.Click += new System.EventHandler(this.btn_FE_Click);
            // 
            // btn_PB
            // 
            this.btn_PB.Location = new System.Drawing.Point(247, 58);
            this.btn_PB.Name = "btn_PB";
            this.btn_PB.Size = new System.Drawing.Size(48, 51);
            this.btn_PB.TabIndex = 2;
            this.btn_PB.Text = "鉛";
            this.btn_PB.UseVisualStyleBackColor = true;
            this.btn_PB.Click += new System.EventHandler(this.btn_PB_Click);
            // 
            // MaterialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 166);
            this.Controls.Add(this.btn_PB);
            this.Controls.Add(this.btn_FE);
            this.Controls.Add(this.btn_AL);
            this.Name = "MaterialForm";
            this.Text = "MaterialForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_AL;
        private System.Windows.Forms.Button btn_FE;
        private System.Windows.Forms.Button btn_PB;
    }
}