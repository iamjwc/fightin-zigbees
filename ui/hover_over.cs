using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace FightinZigbees
{
  public class HoverOver
  {
    public HoverOver(Graphics g, Grid grid)
    {
      this.g = g;
      this.grid = grid;

      this.g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
      this.g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
    }

    public void draw(Point mouse, Cluster cluster)
    {
      Location mouse_l = this.grid.scale_to_grid_coords(mouse);

      Font f = new Font(FontFamily.GenericSansSerif, 10);

      string probability = string.Format("Probability: {0:#0.00}%", cluster.probability * 100);
      string intensity   = string.Format("Intensity: {0:#0.00}%", cluster.intensity * 100);
      string position = string.Format("X: {0:#0.00}, Y: {1:#0.00}", cluster.location.x, cluster.location.y);

      SizeF string_size = this.g.MeasureString(probability, f);

      int width = (int)string_size.Width + 10;
      int height = 47;

      PointF cluster_point = this.grid.scale_to_screen_coords(cluster.location);
      
      Pen pen = new Pen(Color.Black, 3);

      Point start_point = new Point((int)cluster_point.X + 10, (int)cluster_point.Y - height - 10);
      if (cluster_point.X >= grid.size.Width - width - 5)
      {
        start_point.X = (int)cluster_point.X - width - 10;
      }
      if (cluster_point.Y <= height + 30)
      {
        start_point.Y = (int)cluster_point.Y + 10;
      }

      this.g.DrawRectangle(pen, start_point.X, start_point.Y, width, height);
      this.g.FillRectangle(Brushes.BlanchedAlmond, start_point.X, start_point.Y, width, height);

      Point tail_start_point = start_point;
      int x_point_1 = tail_start_point.X;
      int x_point_2 = tail_start_point.X + 10;
      int y_point_1 = tail_start_point.Y;
      int y_point_2 = tail_start_point.Y + height;

      if (cluster_point.X >= grid.size.Width - width - 5)
      {
        x_point_1 += width;
        x_point_2 += width - 20;
      }
      if (cluster_point.Y <= height + 30)
      {
        x_point_1 = tail_start_point.X + 10;
        x_point_2 = tail_start_point.X;
      }
      Point[] tail = new Point[]
      {
        new Point((int)cluster_point.X, (int)cluster_point.Y),
        new Point(x_point_1, y_point_1),
        new Point(x_point_2, y_point_2)
      };

      pen = new Pen(Color.Black, 2);

      this.g.FillPolygon(Brushes.BlanchedAlmond, tail);
      this.g.DrawLine(pen, tail[0], tail[1]);
      this.g.DrawLine(pen, tail[0], tail[2]);

      this.g.DrawString(position, f, Brushes.DarkOrange, new Point(start_point.X + 5, start_point.Y + 5));
      this.g.DrawString(probability, f, Brushes.DarkOrange, new Point(start_point.X + 5, start_point.Y + 16));
      this.g.DrawString(intensity, f, Brushes.DarkOrange, new Point(start_point.X + 5, start_point.Y + 27));

    }

    protected Graphics g;
    protected Grid grid;
  }
}
