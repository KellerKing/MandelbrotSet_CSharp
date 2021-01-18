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
    public static async Task DrawColorOnScreenAsync(List<Tuple<bool, int, double, double, int, int>> p, int maxIteration, Form1 form)
    {

      var b = new SolidBrush(Color.Black);


      //p.ForEach(p1 =>
      //{
      // // Debug.Print($"X:{p1.Item5} | Y: {p1.Item6}");
      //  b.Color = GetRGBColor(p1, maxIteration);
      //  form.PaintPixel(p1.Item5, p1.Item6, b);
      // // g.FillRectangle(b, p1.Item5, p1.Item6, 1, 1);
      //});

      //Parallel.ForEach(p, async (p1)  =>
      //{
      //  b.Color = await Task.Run(() => GetRGBColor(p1, maxIteration));
      //  form.PaintPixel(p1.Item5, p1.Item6, b);
      //});

      var tasks = new List<Task>();
      foreach (var p1 in p)
      {
        tasks.Add(Task.Run(() =>
          form.PaintPixel(p1.Item5, p1.Item6, new SolidBrush(GetRGBColor(p1, maxIteration)))));
        
      }


      await Task.WhenAll(tasks);
      // return iterator < maxIterations ? ColorConversion.HsvToRgb(color, 1, 1) : Color.Black;

      //var index = Math.Min(iterator, ColorPallete.pallete.Length -1);
      //return ColorPallete.pallete[index];
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
