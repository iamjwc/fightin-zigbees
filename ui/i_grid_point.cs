using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace FightinZigbees
{
  public interface IGridPoint
  {
    void draw(Graphics g, PointF point, Size size);
  }
}
