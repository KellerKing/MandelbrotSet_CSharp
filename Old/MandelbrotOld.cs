using MandelbrotSet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
  class MandelbrotOld
  {
    public static int maxN { get; set; } = 50;
    public static double BereichReeleZahlen { get; set; } = 3.5;
    public static double BereichImaginaer { get; set; } = 2;
    public static double mittelReel { get; set; } = -0.75;
    public static double mittelImaginaer { get; set; } = 0;

    //static Func<int, int, KomplexeZahl, bool> IsGegenUnendlich1 = (n, counter, letzeZahl) =>
    //{
    //  if (Math.Pow(letzeZahl.ReeleZahl, 2) + Math.Pow(letzeZahl.ImaginaereZahl, 2) > 4 || counter > n)
    //    return true;
    //  else
    //    return IsGegenUnendlich(n, counter++, letzeZahl with //TODO: Machen
    //    {
    //      ImaginaereZahl = 1,
    //      ReeleZahl = 1
    //    });
    //};

    private static double GetCurrentPositionXAchse(double pixelX, double windowWidth) => pixelX / windowWidth;
    private static double GetCurrentPositionYAchse(double pixelY, double windowHeight) => pixelY / windowHeight;
    private static double CalcMandelbrotReeleZahl(double initialReeleZahl, double currentReeleZahl, double currentImaginaereZahl) => Math.Pow(currentReeleZahl, 2) - Math.Pow(currentImaginaereZahl, 2) + initialReeleZahl;
    private static double CalcMandelbrotImaginaereZahl(double initialImaginaereZahl, double currentReeleZahl, double currentImaginaereZahl) => currentReeleZahl * 2 * currentImaginaereZahl + initialImaginaereZahl;

    private static double Map(double value, double currentRangeMin, double currentRangeMax, double outMin, double outMax)
    {
      return (value - currentRangeMin) * (outMax - outMin) / (currentRangeMax - currentRangeMin) + outMin;
    }




    private static bool IsGegenUnendlich(int n, int counter, double intialReeleZahl, double intinalImaginaereZahl, KomplexeZahl letzeZahl) //Schwarz wenn iterator = n aber Formel kleiner 4
    {
      if (Math.Pow(letzeZahl.ReeleZahl, 2) + Math.Pow(letzeZahl.ImaginaereZahl, 2) > 4) return true;
      else if (counter > n) return false;
      else
        return IsGegenUnendlich(n, ++counter, intialReeleZahl, intinalImaginaereZahl, letzeZahl with //TODO: Machen
        {
          ImaginaereZahl = CalcMandelbrotImaginaereZahl(intinalImaginaereZahl, letzeZahl.ReeleZahl, letzeZahl.ImaginaereZahl),
          ReeleZahl = CalcMandelbrotReeleZahl(intialReeleZahl, letzeZahl.ReeleZahl, letzeZahl.ImaginaereZahl)
        });
    }


    public static MandelbrotResultDTO MandelbrotBerechnenNeu(double x, double y, Tuple<int, int> windowSize)
    {

      var lowerBound = -2;
      var upperBound = 3.5;

      var a = Map(x,0, windowSize.Item1, lowerBound, upperBound);
      var b = Map(y,0, windowSize.Item2, lowerBound, upperBound);

      var aInitial = a;
      var bInitial = b;




      return new MandelbrotResultDTO
      {
        Color = IsGegenUnendlich(30, 0, aInitial, bInitial, new KomplexeZahl(0, 0)) ? Color.Empty : Color.Black,
        Location = new Point((int)x, (int)y)
      };

    }

    static Func<int, int> testAdd(int x) => y => x * y;






    public static async Task MandelbrotBerechnen(double windowWidth, double windowHeight, Graphics g)
    {

      var brushRed = new SolidBrush(Color.Red);
      var brushBl = new SolidBrush(Color.Black);


      for (int x = 0; x < windowWidth; x++)
      {
        for (int y = 0; y < windowHeight; y++)
        {



          double interator = 0;
          double xPercentage = 0;
          double yPercentage = 0;
          double cRealerTeil = 0;
          double cImaginaererTeil = 0;

          double zReal = 0;
          double zImaginär = 0;


          xPercentage = GetCurrentPositionXAchse(x, windowWidth);
          yPercentage = GetCurrentPositionYAchse(y, windowHeight);

          cRealerTeil = xPercentage * BereichReeleZahlen + mittelReel - BereichReeleZahlen / 2;
          cImaginaererTeil = yPercentage * BereichImaginaer + mittelImaginaer - BereichImaginaer / 2;



          while (interator < maxN && zReal * zReal + zImaginär * zImaginär <= 4)
          {

            var tmp = Math.Pow(zReal, 2) - Math.Pow(zImaginär, 2) + cRealerTeil;
            zImaginär = 2 * zReal * zImaginär + cImaginaererTeil;
            zReal = tmp;

            interator++;

          }

          if (interator >= maxN) //maxN - 1 ?????
          {
            g.FillRectangle(brushBl, (float)x, (float)y, 1, 1);
          }
          //else
          //{
          //  g.FillRectangle(brushRed, (float)x, (float)y, 1, 1);
          //}
        }
      }
    }
  }
}
