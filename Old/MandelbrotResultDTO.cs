using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandelbrotSet
{
  public record MandelbrotResultDTO
  {
    public Point Location { get; init; }
    public System.Drawing.Color Color { get; init; }
  }
}
