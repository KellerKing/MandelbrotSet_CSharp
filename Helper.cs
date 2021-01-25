using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandelbrotSet
{
  class Helper
  {
    public static List<List<Tuple<bool, int, double, double, int, int>>> SegmentCalculatedNumbers(List<Tuple<bool, int, double, double, int, int>> results, int coreCount)
    {

      var output = new List<List<Tuple<bool, int, double, double, int, int>>>();

      var steps = results.Count / coreCount;

      for (int i = 1; i < results.Count; i+= steps)
      {
        output.Add(results.GetRange(i-1, steps));
      }

      return output;
    }
  }
}
