using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace FightinZigbees
{
  public abstract class GridPoint
  {
    public GridPoint(Grid grid, Point point)
    {
      this._grid = grid;
      this._point = point;
    }

    public abstract void draw(Graphics g);

    protected Grid _grid;
    protected Point _point;
  }
}
