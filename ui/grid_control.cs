using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FightinZigbees
{
  public partial class GridControl : UserControl
  {
    public GridControl()
    {
      InitializeComponent();
      grid = new Grid(5, 5);
      grid.location = new PointF(0, 0);
      grid.size = this.Size;
    }

    public int x_cell_count
    {
      get { return this.grid.x_cell_count; }
      set { this.grid.x_cell_count = value; Invalidate(); }
    }

    public int y_cell_count
    {
      get { return this.grid.y_cell_count; }
      set { this.grid.y_cell_count = value; Invalidate(); }
    }

    protected override void OnResize(EventArgs e)
    {
      grid.size = this.Size;
      base.OnResize(e);
    }

    protected override void OnPaint(PaintEventArgs pe)
    {
      Graphics g = pe.Graphics;
      grid.draw(g);
    }

    protected Grid grid;
  }
}
