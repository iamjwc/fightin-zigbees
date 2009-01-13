using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace FightinZigbees
{
  public abstract class Room
  {
    public abstract void draw(Graphics g);

    public Room()
    {
      broadcast_xbees = new BroadcastXbee[Constant.NUM_NODES];
      for(int i = 0; i < Constant.NUM_NODES; i++)
      {
        broadcast_xbees[i] = new BroadcastXbee();
      }
    }

    public Size size
    {
      get { return this._size; }
      set
      {
        Size s = value;
        s.Width -= 5;
        s.Height -= 5;
        this._size = this._grid.size = s;
      }
    }

    public Point location
    {
      get { return this._point; }
      set
      {
        Point p = value;
        //p.X += 2;
        //p.Y += 2;
        this._point = this._grid.location = p;
      }
    }

    public Grid grid
    {
      get { return this._grid; }
      set { this._grid = value; }
    }

    public void set_renderer_type(string renderer_type)
    {
      _grid.renderer_type = renderer_type;
    }

    protected Size _size;
    protected Point _point;
    protected Grid _grid;
    public BroadcastXbee[] broadcast_xbees;
  }
}
