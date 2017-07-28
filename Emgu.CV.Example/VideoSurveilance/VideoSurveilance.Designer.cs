namespace VideoSurveilance
{
   partial class VideoSurveilance
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
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.imageBox1 = new Emgu.CV.UI.ImageBox();
      this.panel1 = new System.Windows.Forms.Panel();
      this.label1 = new System.Windows.Forms.Label();
      this.splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // splitContainer1
      // 
      this.splitContainer1.Location = new System.Drawing.Point(0, 0);
      this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Size = new System.Drawing.Size(945, 415);
      this.splitContainer1.SplitterDistance = 465;
      this.splitContainer1.SplitterWidth = 5;
      this.splitContainer1.TabIndex = 0;
      // 
      // imageBox1
      // 
      this.imageBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.imageBox1.Location = new System.Drawing.Point(0, 59);
      this.imageBox1.Margin = new System.Windows.Forms.Padding(4);
      this.imageBox1.Name = "imageBox1";
      this.imageBox1.Size = new System.Drawing.Size(1064, 469);
      this.imageBox1.TabIndex = 4;
      this.imageBox1.TabStop = false;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.label1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Margin = new System.Windows.Forms.Padding(4);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(1064, 59);
      this.panel1.TabIndex = 3;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(16, 16);
      this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(101, 17);
      this.label1.TabIndex = 0;
      this.label1.Text = "Camera Frame";
      // 
      // VideoSurveilance
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1064, 528);
      this.Controls.Add(this.imageBox1);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.splitContainer1);
      this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.Name = "VideoSurveilance";
      this.Text = "VideoSurveilance";
      this.splitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.SplitContainer splitContainer1;
    private Emgu.CV.UI.ImageBox imageBox1;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label label1;
  }
}