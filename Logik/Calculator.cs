using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandelbrotSet
{
  public class Calculator
  {
    public static Tuple<bool, int, double, double, int, int> IsGegenUnendlich(int n, Tuple<double, double> c, int xPos, int yPos)
    {
      var i = 0;
      var zReal = 0.0;
      var zIm = 0.0;

      while (i < n && zReal * zReal + zIm * zIm <= 4)
      {
        var complexNumberZ = AddComplexNumber(QuadriereComplexNumber(Tuple.Create(zReal, zIm)), c);
        zReal = complexNumberZ.Item1;
        zIm = complexNumberZ.Item2;

        i++;
      }

      return n > i ? Tuple.Create(true, i, zReal, zIm, xPos,yPos) : Tuple.Create(false, i, zReal, zIm, xPos, yPos);
    }


    private static Tuple<double, double> AddComplexNumber(Tuple<double, double> complexNumberA, Tuple<double, double> complexNumberB)
    {
      return Tuple.Create(
        complexNumberA.Item1 + complexNumberB.Item1,
        complexNumberA.Item2 + complexNumberB.Item2
        );
    }

    private static Tuple<double, double> QuadriereComplexNumber(Tuple<double, double> complexNumber)
    {
      return Tuple.Create(
        (complexNumber.Item1 * complexNumber.Item1) - (complexNumber.Item2 * complexNumber.Item2),
        complexNumber.Item1 * complexNumber.Item2 * 2
        );
    }

    public static Tuple<double, double> LogOfComplexNumber(Tuple<double, double> complexNumber)
    {
      var real = 0.5 * Math.Log(complexNumber.Item1 * complexNumber.Item1 + complexNumber.Item2 * complexNumber.Item2);
      var imaginary = Math.Atan(complexNumber.Item1 / complexNumber.Item2);

      return Tuple.Create(real, imaginary);
    }

    public static Tuple<double, double> AbsOfComplexNumber(Tuple<double, double> complexNumber)
    {
      return Tuple.Create(Math.Abs(complexNumber.Item1), Math.Abs(complexNumber.Item2));
    }
  }
}
