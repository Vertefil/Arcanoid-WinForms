﻿namespace WinFormsGame
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            timer1 = new System.Windows.Forms.Timer(components);
            panel1 = new Panel();
            label1 = new Label();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Location = new Point(433, 155);
            panel1.Name = "panel1";
            panel1.Size = new Size(130, 116);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            panel1.MouseClick += panel1_MouseClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(460, 274);
            label1.Name = "label1";
            label1.Size = new Size(70, 15);
            label1.TabIndex = 1;
            label1.Text = "Click on Me";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(584, 661);
            Controls.Add(label1);
            Controls.Add(panel1);
            DoubleBuffered = true;
            Name = "Form1";
            Text = "MainGame";
            Paint += OnPaint;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private Panel panel1;
        private Label label1;
    }
}