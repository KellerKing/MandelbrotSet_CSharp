using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1;

namespace MandelbrotSet
{
  class Controller
  {
    private Form1 app1;


    double lowerBoundsScalaX = -2.5;
    double upperBoundsScalaX = 1.5;

    double lowerBoundsScalaY = -1;
    double upperBoundsScalaY = 1.25;

    int n = 50;

    Task<List<Tuple<int, int, Color>>> calculatedPixels;

    public Controller(Form1 form)
    {
      app1 = form;
      ConnectEvents();
      CalculatePixels();
    }

    private void ConnectEvents()
    {
      app1.MouseScrolled += MouseScrolled;
      app1.mandelbrotStart += CreateMandelbrot;
    }

    private async void CalculatePixels()
    {
      var points = await BerechneMandelbrotAsync();
      calculatedPixels = ColorRenderer.ColoredPixel(points, n);
    }

    private async void CreateMandelbrot()
    {

      while (calculatedPixels is null || !calculatedPixels.IsCompleted) 
      {

      } 

      app1.PaintPixel(calculatedPixels.Result);
    }

    private void MouseScrolled(int delta)
    {
      Debug.Print(delta.ToString());
    }

    private async Task<List<Tuple<bool, int, double, double, int, int>>> BerechneMandelbrotAsync() => await MandelbrotBerechner.GetBerechnetePoints(app1.BitmapResolution()[0], app1.BitmapResolution()[1],
                                                          lowerBoundsScalaX, upperBoundsScalaX,
                                                          lowerBoundsScalaY, upperBoundsScalaY, n);//var splittedPoints = Helper.SegmentCalculatedNumbers(//  await MandelbrotBerechner.GetBerechnetePoints(app1.Width, app1.Height,//                                           lowerBoundsScalaX, upperBoundsScalaX,//                                           lowerBoundsScalaY, upperBoundsScalaY, n), Environment.ProcessorCount);//splittedPoints.ForEach(async p  => await ColorRenderer.DrawColorOnScreenAsync(p, n, app1));//ColorRenderer.DrawColorOnScreenAsync(points, n, app1);


  }
}
