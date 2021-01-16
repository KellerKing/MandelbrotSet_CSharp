using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandelbrotSet
{
  public class Calculator
  {
    public static Tuple<bool, int, double, double> IsGegenUnendlich(int n, Tuple<double, double> c)
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

      return n > i ? Tuple.Create(true, i, zReal, zIm) : Tuple.Create(false, i, zReal, zIm);
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
  }
}
