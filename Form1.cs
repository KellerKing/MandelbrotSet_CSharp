using MandelbrotSet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
  public partial class Form1 : Form
  {

    double lowerBoundsScalaX = -2.5;
    double upperBoundsScalaX = 1.5;

    double lowerBoundsScalaY = -1;
    double upperBoundsScalaY = 1.25;

    public Graphics g { get => this.CreateGraphics(); }

    public Action<int> MouseScrolled;

    private static SolidBrush b = new SolidBrush(Color.Black);

    public Form1()
    {
      InitializeComponent();
      this.MouseWheel += Form1_MouseWheel;
      
    }

    public void PaintPixel(int x, int y, SolidBrush b)
    {
      g.FillRectangle(b, x, y, 1, 1);
    }

    private void Form1_MouseWheel(object sender, MouseEventArgs e)
    {
      //if (e.Delta > 0)
      //{
      //  upperBoundsScalaY *= 0.2;
      //  lowerBoundsScalaY = Math.Abs(lowerBoundsScalaX *= 5);

      //  upperBoundsScalaX *= 0.2;
      //  lowerBoundsScalaX = Math.Abs(lowerBoundsScalaX *= 5);
      //}
      //else
      //{
      //  upperBoundsScalaY *= 5;
      //  lowerBoundsScalaY *= 0.2;
      //}
      //Refresh();
      MouseScrolled.Invoke(e.Delta);
    }

    private async void Form1_Paint(object sender, PaintEventArgs e)
    {
      //var g = e.Graphics;





      //var iterations = 50;


      //for (int x = 0; x < this.Width; x++)
      //{
      //  for (int y = 0; y < this.Height; y++)
      //  {
      //    var result = await Mandelbrot.CalcMandelForPoint(x, y, Width, Height, iterations, lowerBoundsScalaX, upperBoundsScalaX, lowerBoundsScalaY, upperBoundsScalaY);

      //    b.Color = ColorRenderer.getSmoothedColor(result.Item2, result.Item3, result.Item4, iterations);

      //    g.FillRectangle(b, x, y, 1, 1);
      //  }
      //}
    }

    private async void Form1_Shown(object sender, EventArgs e)
    {

      var start = DateTime.Now;

      await Task.Run(() => new Controller(this));


      Debug.Print((DateTime.Now - start).ToString());
    }
  }
}
