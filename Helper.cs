using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandelbrotSet
{
  class Helper
  {
    public static Tuple<int, int>[] GetPixelsAsArray(int w, int h)
    {

      var output = new Tuple<int, int>[w * h];

      for (int x = 0; x < w; x++)
      {
        for (int y = 0; y < h; y++)
        {
          output[x * y] = Tuple.Create(x, y);
        }
      }
      return output;
    }
  }
}
