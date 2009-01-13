using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace FightinZigbees
{
  public abstract class ClusterRenderer
  {
    protected ClusterRenderer(Graphics g, Grid grid)
    {
      this.g = g;
      this.grid = grid;
    }

    /// <summary>
    /// Gets/Sets the grid that we will be drawing on.
    /// </summary>
    public Grid grid
    {
      get { return this._grid; }
      set { this._grid = value; }
    }

    public abstract void draw( List<Cluster> cluster);

    protected Graphics g;
    protected Grid _grid;
  }
}
