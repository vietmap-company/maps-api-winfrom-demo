
namespace Vietmap.APIs.Demo
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.button_ChooseStartPoint = new System.Windows.Forms.Button();
            this.textBox_End = new System.Windows.Forms.TextBox();
            this.button_ChooseEndPoint = new System.Windows.Forms.Button();
            this.textBox_Start = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1284, 777);
            this.splitContainer1.SplitterDistance = 428;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.button_ChooseStartPoint);
            this.splitContainer2.Panel1.Controls.Add(this.textBox_End);
            this.splitContainer2.Panel1.Controls.Add(this.button_ChooseEndPoint);
            this.splitContainer2.Panel1.Controls.Add(this.textBox_Start);
            this.splitContainer2.Size = new System.Drawing.Size(428, 777);
            this.splitContainer2.SplitterDistance = 142;
            this.splitContainer2.TabIndex = 0;
            // 
            // button_ChooseStartPoint
            // 
            this.button_ChooseStartPoint.Location = new System.Drawing.Point(267, 29);
            this.button_ChooseStartPoint.Name = "button_ChooseStartPoint";
            this.button_ChooseStartPoint.Size = new System.Drawing.Size(120, 23);
            this.button_ChooseStartPoint.TabIndex = 6;
            this.button_ChooseStartPoint.Text = "ChooseStartPoint";
            this.button_ChooseStartPoint.UseVisualStyleBackColor = true;
            this.button_ChooseStartPoint.Click += new System.EventHandler(this.button_ChooseStartPoint_Click);
            // 
            // textBox_End
            // 
            this.textBox_End.Location = new System.Drawing.Point(96, 61);
            this.textBox_End.Name = "textBox_End";
            this.textBox_End.Size = new System.Drawing.Size(153, 20);
            this.textBox_End.TabIndex = 5;
            // 
            // button_ChooseEndPoint
            // 
            this.button_ChooseEndPoint.Location = new System.Drawing.Point(267, 61);
            this.button_ChooseEndPoint.Name = "button_ChooseEndPoint";
            this.button_ChooseEndPoint.Size = new System.Drawing.Size(120, 23);
            this.button_ChooseEndPoint.TabIndex = 3;
            this.button_ChooseEndPoint.Text = "ChooseEndPoint";
            this.button_ChooseEndPoint.UseVisualStyleBackColor = true;
            this.button_ChooseEndPoint.Click += new System.EventHandler(this.button_ChooseEndPoint_Click);
            // 
            // textBox_Start
            // 
            this.textBox_Start.Location = new System.Drawing.Point(96, 32);
            this.textBox_Start.Name = "textBox_Start";
            this.textBox_Start.Size = new System.Drawing.Size(153, 20);
            this.textBox_Start.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 777);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Vietmap.APIs.Demo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button button_ChooseStartPoint;
        private System.Windows.Forms.TextBox textBox_End;
        private System.Windows.Forms.Button button_ChooseEndPoint;
        private System.Windows.Forms.TextBox textBox_Start;
    }
}

