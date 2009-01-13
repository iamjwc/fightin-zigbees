using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace FightinZigbees
{
  public class ConvexHullClusterRenderer : ClusterRenderer
  {
    public ConvexHullClusterRenderer(Graphics g, Grid grid) : base(g, grid) { }

    public override void draw(List<Cluster> clusters)
    {
      Color hull_color = Color.LightSteelBlue;
      Color c = Color.FromArgb(125, hull_color.R, hull_color.G, hull_color.B );
      Brush b = new SolidBrush(c);
      c = Color.FromArgb(255, c.R, c.G, c.B);
      Pen pen = new Pen(c, 3);
      pen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
      for (int i = 0; i < clusters.Count; ++i)
      {
        try
        {
          List<Location> ch = clusters[i].convex_hull();
          PointF[] cluster_points = new PointF[ch.Count];
          for (int j = 0; j < ch.Count; ++j)
          {
            cluster_points[j] = this.grid.scale_to_screen_coords(ch[j]);
          }

          // TODO: Shadow idea?
          /*g.TranslateTransform(1, 1);
          g.DrawPolygon(new Pen(Color.Black, 3), cluster_points);
          g.TranslateTransform(-1, -1);*/

          g.FillPolygon(b, cluster_points);
          g.DrawPolygon(pen, cluster_points);
        }
        catch (Exception) { }
      }
    }
  }
}
