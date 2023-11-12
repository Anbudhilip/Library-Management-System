
namespace LIBRARY_MANAGEMENT_SYSTEM
{
    partial class Exercise1
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
            this.components = new System.ComponentModel.Container();
            this.pie = new CircularProgressBar.CircularProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pie
            // 
            this.pie.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.pie.AnimationSpeed = 500;
            this.pie.BackColor = System.Drawing.Color.White;
            this.pie.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold);
            this.pie.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pie.InnerColor = System.Drawing.Color.White;
            this.pie.InnerMargin = 2;
            this.pie.InnerWidth = -1;
            this.pie.Location = new System.Drawing.Point(209, 92);
            this.pie.MarqueeAnimationSpeed = 2000;
            this.pie.Name = "pie";
            this.pie.OuterColor = System.Drawing.Color.Gray;
            this.pie.OuterMargin = -25;
            this.pie.OuterWidth = 26;
            this.pie.ProgressColor = System.Drawing.Color.Aquamarine;
            this.pie.ProgressWidth = 18;
            this.pie.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pie.Size = new System.Drawing.Size(320, 320);
            this.pie.StartAngle = 270;
            this.pie.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pie.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.pie.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.pie.SubscriptText = "";
            this.pie.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.pie.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.pie.SuperscriptText = "°C";
            this.pie.TabIndex = 0;
            this.pie.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.pie.Click += new System.EventHandler(this.pie_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Algerian", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(141, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(497, 30);
            this.label5.TabIndex = 35;
            this.label5.Text = "ANNA LIBRARY MANAGEMENT SYSTEM";
            // 
            // Exercise1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pie);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Exercise1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exercise1";
            this.Load += new System.EventHandler(this.Exercise1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CircularProgressBar.CircularProgressBar pie;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label5;
    }
}