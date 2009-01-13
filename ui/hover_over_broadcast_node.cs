using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace FightinZigbees
{
  public class HoverOverBroadcastNode
  {
    public HoverOverBroadcastNode(Graphics g, Grid grid)
    {
      this.g = g;
      this.grid = grid;

      this.g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
      this.g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
    }

    public void draw(Point mouse, BroadcastXbee xb)
    {
      Location mouse_l = this.grid.scale_to_grid_coords(mouse);

      Font f = new Font(FontFamily.GenericSansSerif, 10);

      string location = string.Format("Location: {0}, {1}", xb.location.x, xb.location.y);
      string id = string.Format("ID: 0xC{0}", xb.id);

      SizeF string_size = this.g.MeasureString(location, f);

      int width = (int)string_size.Width + 10;
      int height = 36;

      PointF xb_point = this.grid.scale_to_screen_coords(xb.location);

      Pen pen = new Pen(Color.Black, 3);

      Point start_point = new Point((int)xb_point.X + 10, (int)xb_point.Y - height - 10);
      if (xb_point.X >= grid.size.Width - width - 10)
        start_point.X = (int)xb_point.X - width - 10;
      if (xb_point.Y <= height + 20)
        start_point.Y = (int)xb_point.Y + 10;

      this.g.DrawRectangle(pen, start_point.X, start_point.Y, width, height);
      this.g.FillRectangle(Brushes.BlanchedAlmond, start_point.X, start_point.Y, width, height);

      Point tail_start_point = start_point;
      int x_point_1 = tail_start_point.X;
      int x_point_2 = tail_start_point.X + 10;
      int y_point_1 = tail_start_point.Y;
      int y_point_2 = tail_start_point.Y + height;

      if (xb_point.X >= grid.size.Width - width - 10)
      {
        x_point_1 += width;
        x_point_2 += width - 20;
      }
      if (xb_point.Y <= height + 20)
      {
        x_point_1 = tail_start_point.X + 10;
        x_point_2 = tail_start_point.X;
      }
      Point[] tail = new Point[]
      {
        new Point((int)xb_point.X, (int)xb_point.Y),
        new Point(x_point_1, y_point_1),
        new Point(x_point_2, y_point_2)
      };

      pen = new Pen(Color.Black, 2);

      this.g.FillPolygon(Brushes.BlanchedAlmond, tail);
      this.g.DrawLine(pen, tail[0], tail[1]);
      this.g.DrawLine(pen, tail[0], tail[2]);


      this.g.DrawString(id, f, Brushes.DarkOrange, new Point(start_point.X + 5, start_point.Y + 5));
      this.g.DrawString(location, f, Brushes.DarkOrange, new Point(start_point.X + 5, start_point.Y + 16));

    }

    protected Graphics g;
    protected Grid grid;
  }
}
