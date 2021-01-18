using System;
using System.Collections.Generic;
using System.Diagnostics;
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

    public Controller(Form1 form)
    {
      app1 = form;
      ConnectEvents();
      BerechneMandelbrot();
    }

    private void ConnectEvents()
    {
      app1.MouseScrolled += MouseScrolled;
    }


    private void MouseScrolled(int delta)
    {
      Debug.Print(delta.ToString());
    }

    private async void BerechneMandelbrot()
    {


      var points = await MandelbrotBerechner.GetBerechnetePoints(app1.Width, app1.Height,
                                                          lowerBoundsScalaX, upperBoundsScalaX,
                                                          lowerBoundsScalaY, upperBoundsScalaY, n);


    ColorRenderer.DrawColorOnScreenAsync(points, n, app1).Wait();


    }


  }
}
