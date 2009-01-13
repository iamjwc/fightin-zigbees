using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace FightinZigbees
{
  public class XbeeGridPoint : GridPoint
  {
    public XbeeGridPoint(Grid grid, Point point, Color color) : base(grid, point)
    {
      this._color = color;
    }

    public override void draw(Graphics g)
    {
      //new HeatMapGridPoint(this._grid, this._point, 0.2f).draw(g);
      float radius = this._grid.cell_width / 2;
      g.FillEllipse(new SolidBrush(Color.FromArgb(128,_color)), _point.X - radius, _point.Y - radius, radius * 2, radius * 2);
    }

    protected Color _color;
  }
}
