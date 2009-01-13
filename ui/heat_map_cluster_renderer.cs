using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace FightinZigbees
{
  public class HeatMapClusterRenderer : ClusterRenderer
  {
    public HeatMapClusterRenderer(Graphics g, Grid grid) : base(g, grid) { }

    public override void draw(List<Cluster> clusters)
    {
      for (int i = 0; i < clusters.Count; ++i)
      {
        PointF pf = this.grid.scale_to_screen_coords(clusters[i].location);
        HeatMapGridPoint h = new HeatMapGridPoint(this._grid, new Point((int)pf.X, (int)pf.Y), clusters[i].intensity);
        h.draw(g);
      }
    }

  }
}
