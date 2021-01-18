using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MandelbrotSet
{
  class MandelbrotBerechner
  {
    public static async Task<List<Tuple<bool, int, double, double, int, int>>> GetBerechnetePoints(int w, int h, double lowerBoundsScalaX, double upperBoundsScalaX, double lowerBoundsScalaY, double upperBoundsScalaY, int n)
    {

      var tasks = new List<Task<Tuple<bool, int, double, double, int, int>>>();
      int x =0;
      int y = 0;

      while (x < w)
      {
        y = 0;
        while ( y < h)
        {
          //y++;
          tasks.Add(Task.Run(() =>
            Mandelbrot.CalcMandelForPoint(x, y++, w, h, n,
            lowerBoundsScalaX, upperBoundsScalaX,
            lowerBoundsScalaY, upperBoundsScalaY)));
          //Debug.Print($"X:{x} | Y: {y}");
        }
        x += 1;
        Thread.Sleep(2);
      }

      var b = await Task.WhenAll(tasks);
      return b.ToList(); 
    }


    //public static async Task<List<Tuple<bool, int, double, double, int, int>>> GetBerechnetePoints(int w, int h, double lowerBoundsScalaX, double upperBoundsScalaX, double lowerBoundsScalaY, double upperBoundsScalaY, int n)
    //{

    //  var tasks = new List<Task<Tuple<bool, int, double, double, int, int>>>();
    //  var otp = new List<Tuple<bool, int, double, double, int, int>>();

    //  Parallel.For(0, w, (x) =>
    //  {
    //    Parallel.For(0, h, (y) =>
    //    {
    //      otp.Add(Mandelbrot.CalcMandelForPoint(x, y, w, h, n,
    //        lowerBoundsScalaX, upperBoundsScalaX,
    //        lowerBoundsScalaY, upperBoundsScalaY));
    //    });
    //  });
    //  return otp;
    //}
  }
}
