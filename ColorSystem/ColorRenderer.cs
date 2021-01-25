using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing;
using MandelbrotSet.ColorSystem;
using System.Diagnostics;
using WindowsFormsApp1;
using System.Threading;

namespace MandelbrotSet
{
  class ColorRenderer
  {
    public static async void DrawColorOnScreenAsync(List<Tuple<bool, int, double, double, int, int>> p, int maxIteration, Form1 form)
    {


      //var tasks = new List<Task>();
      //foreach (var p1 in p)
      //{
      //  tasks.Add(Task.Run(() =>
      //    form.PaintPixel(p1.Item5, p1.Item6, new SolidBrush(GetRGBColor(p1, maxIteration)))));

      //}


      //await Task.WhenAll(tasks);
    }


    public static async Task<List<Tuple<int, int, Color>>> ColoredPixel(List<Tuple<bool, int, double, double, int, int>> p, int maxIteration)
    {
      var tasks = new List<Task<Tuple<int, int, Color>>>();
      foreach (var p1 in p)
      {
        tasks.Add(Task.Run(() =>
         Tuple.Create(p1.Item5, p1.Item6, GetRGBColor(p1, maxIteration))
         ));
      }


      var res = await Task.WhenAll(tasks);
      return res.ToList();
    }


    private static Color GetRGBColor(Tuple<bool, int, double, double, int, int> point, int maxIteration)
    {
      var color = (point.Item2 * (360 / 5) / 4) + 200;

      if (color > 360) color -= 360;
      else if (color < 0) color += 360;

      return point.Item2 < maxIteration ? ColorConversion.HsvToRgb(color, 1, 1) : Color.Black;
    }

  }
}
