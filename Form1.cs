using MandelbrotSet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
  public partial class Form1 : Form
  {

    private static SolidBrush b = new SolidBrush(Color.Black);

    public Form1()
    {
      InitializeComponent();

    }

    public Graphics getGraphics()
    {
      return this.CreateGraphics();
    }

    private async void Form1_Paint(object sender, PaintEventArgs e)
    {
      var g = e.Graphics;
      var iterations = 50;

      for (int x = 0; x < this.Width; x++)
      {
        for (int y = 0; y < this.Height; y++)
        {
         var result = await Mandelbrot.CalcMandelForPoint(x, y, Width, Height, iterations);

          b.Color = ColorRenderer.getSmoothedColor(result.Item2, result.Item3, result.Item4, iterations);

          g.FillRectangle(b, x, y, 1, 1);
        }
      }
    }
  }
}
