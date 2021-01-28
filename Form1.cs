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

    private Bitmap bm;
    private Graphics gbm;


    public Action mandelbrotStart;
    public Action<int> MouseScrolled;


    public Form1()
    {
      InitializeComponent();
      this.MouseWheel += Form1_MouseWheel; //TODO: Needs Work


      var bmW = this.Width - 60;
      var bmH = this.Height - 80;
      bm = new Bitmap(bmW, bmH);

      gbm = Graphics.FromImage(bm);
    }

    public async void PaintPixel(List<Tuple<int,int,Color>> p)
    {
      var brush = new SolidBrush(Color.White);
      var ticks = 0;

      p.ForEach(p1 =>
      {
        ticks++;
        brush.Color = p1.Item3;
        gbm.FillRectangle(brush, p1.Item1, p1.Item2, 1, 1);

        if(ticks == 1024)
        {
          Refresh();
          ticks = 0;
        }

      });
      

      //gbm.Clear(Color.White);
    }

    private void Form1_MouseWheel(object sender, MouseEventArgs e)
    {
      MouseScrolled.Invoke(e.Delta);
    }

    private void Form1_Paint(object sender, PaintEventArgs e)
    {
      e.Graphics.DrawImage(bm, 0, 0);
    }

    private void Form1_Shown(object sender, EventArgs e)
    {
      Task.Run(() => new Controller(this));
    }


    private void btn_Mandelbrot_Click(object sender, EventArgs e)
    {
      var start = DateTime.Now;
      mandelbrotStart.Invoke();
      Debug.Print((DateTime.Now - start).ToString());

    }


    public int[] BitmapResolution() => new int[] { bm.Width, bm.Height };
  }
}
