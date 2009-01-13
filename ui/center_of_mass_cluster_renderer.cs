using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace FightinZigbees
{
  public class CenterOfMassClusterRenderer : ClusterRenderer
  {
    public CenterOfMassClusterRenderer(Graphics g, Grid grid) : base(g, grid) { }

    public override void draw(List<Cluster> clusters)
    {
      for (int i = 0; i < clusters.Count; ++i)
      {
        //I took out the cluster.intensity because it made the white dots huge.
        float radius = this.grid.cell_width / 2; // 5 + 20;// *cluster.intensity;
        PointF p = this._grid.scale_to_screen_coords(clusters[i].location);

        Location mouse = this._grid.scale_to_grid_coords(this._grid.mouse);
        float distance_from_mouse = clusters[i].location.distance_from(mouse);
        float opacity = 0;
        if (distance_from_mouse <= 1)
          opacity = 1 - distance_from_mouse;

        radius *= opacity;

        Color color = Color.FromArgb((int)(opacity * 255), Color.Gainsboro);

        this.g.FillEllipse(new SolidBrush(color), p.X - radius, p.Y - radius, radius * 2, radius * 2);
        //HeatMapGridPoint grid_point = new HeatMapGridPoint(this.grid, new Point((int) p.X, (int) p.Y), opacity);
        //grid_point.draw(this.g);
      }
    }

  }
}
