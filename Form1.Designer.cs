
namespace WindowsFormsApp1
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
      this.btn_Mandelbrot = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // btn_Mandelbrot
      // 
      this.btn_Mandelbrot.Location = new System.Drawing.Point(12, 12);
      this.btn_Mandelbrot.Name = "btn_Mandelbrot";
      this.btn_Mandelbrot.Size = new System.Drawing.Size(94, 29);
      this.btn_Mandelbrot.TabIndex = 0;
      this.btn_Mandelbrot.Text = "start";
      this.btn_Mandelbrot.UseVisualStyleBackColor = true;
      this.btn_Mandelbrot.Click += new System.EventHandler(this.btn_Mandelbrot_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1262, 673);
      this.Controls.Add(this.btn_Mandelbrot);
      this.DoubleBuffered = true;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Margin = new System.Windows.Forms.Padding(2);
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Mandelbrot Visualizer";
      this.Shown += new System.EventHandler(this.Form1_Shown);
      this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btn_Mandelbrot;
  }
}

