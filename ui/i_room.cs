using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace FightinZigbees
{
  public interface IRoom
  {
    bool is_within(Location loc);
    void draw(Graphics g, PointF point, Size size);
    Grid grid { get; set; }
  }
}
