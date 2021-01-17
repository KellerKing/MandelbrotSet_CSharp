﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


namespace MandelbrotSet
{
  class ColorRenderer
  {
    public static Color getSmoothedColor(int iterator, double zReal, double zIm, int maxIterations)
    {
      var smoothColor = iterator - Math.Log(Ma)

      //var index = Math.Min(iterator, ColorPallete.pallete.Length -1);
      //return ColorPallete.pallete[index];
    }


    public static int[] HslToRgb(float hue, float saturation, float luminance)
    {
      if (saturation == 0)
        return new int[3] { (int)luminance * 255, (int)luminance * 255, (int)luminance * 255 };

      var temp1 = luminance >= 0.5 ?
        luminance + saturation - luminance * saturation :
        luminance * (1.0f + saturation);

      var temp2 = 2 * luminance - temp1;

      var convertedHue = hue / 360;

      var r_ = ColorTest(InColorRange(convertedHue + 0.333f), temp1, temp2);
      var g_ = ColorTest(InColorRange(convertedHue), temp1, temp2);
      var b_ = ColorTest(InColorRange(convertedHue) - 0.333f, temp1, temp2);

      return new int[3] { (int)r_, (int)g_, (int)b_ }; //TODO: Runden statt abscheinden
    }

    private static float InColorRange(float color)
    {
      return color < 0 ?
        color + 1 :
        color > 1 ?
          color - 1 :
          color;
    }

    private static float ColorTest(float color, float temp1, float temp2)
    {
      return 6f * color < 1 ?
        temp2 + (temp1 - temp2) * 6f * color :
        2f * color < 1 ?
          color :
          3f * color < 2 ?
            temp2 + (temp1 - temp2) * (0.666f - color) * 6f :
            temp2;
    }


    public static int[] RgbToHsl(int r, int g, int b)
    {
      var r_ = r / 255f;
      var g_ = g / 255f;
      var b_ = b / 255f;

      var max = Math.Max(Math.Max(r_, b_), g_);
      var min = Math.Min(Math.Min(r_, b_), g_);
      var delta = max - min;

      var luminance = (max + min) / 2;

      var saturation = delta == 0 ?
        0 :
          luminance < 0.5 ?
          (max - min) / (max + min) :
          (max - min) / (2 - max - min);


      var hue = (max == r_ ?
        (g_ - b_) / (max - min) :
        max == g_ ?
          2.0 + (b_ - r_) / (max - min) :
          4.0 + (r_ - g_) / (max - min)) * 60;


      return new int[3] { (int)hue, (int)saturation, (int)luminance };

    }



  }
}
