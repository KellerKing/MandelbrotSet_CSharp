using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandelbrotSet
{
  class Mandelbrot
  {
    

    private static double MapPxielToKoordinatenSystem(double value, double oldMin, double oldMax, double newMin, double newMax)
    {
      return ((value - oldMin) * (newMax - newMin) / (oldMax - oldMin)) + newMin; 
    }




    public static async Task<Tuple<bool, int, double, double>> CalcMandelForPoint(int x, int y, int windowWidth, int windowHeight, int n)
    {
      double lowerBoundsScalaX = -2.5;
      double upperBoundsScalaX = 1.5;

      double lowerBoundsScalaY = -1;
      double upperBoundsScalaY = 1.25;

      var cReal = MapPxielToKoordinatenSystem(x, 0, windowWidth, lowerBoundsScalaX, upperBoundsScalaX);
      var cIm = MapPxielToKoordinatenSystem(y, 0, windowHeight, lowerBoundsScalaY, upperBoundsScalaY);

      return Calculator.IsGegenUnendlich(n, Tuple.Create(cReal, cIm));
      //Zn = Z^2 + c
      //Z0 = 0 --> Z1 = c 

      //C = Komplexe Zahl (Reele Zahl + I Imaginäre Zahl) I = sqrt(-1) | I^2 = -1
    }
    
  }
}
