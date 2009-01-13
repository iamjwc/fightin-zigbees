using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace FightinZigbees
{
  public class BasicRoom : Room
  {
    public BasicRoom()
    {
      this.grid = new Grid(ROOM_WIDTH, ROOM_HEIGTH);
      this._grid.location = this._point;
      this._grid.size = this.size;

      broadcast_xbees[0].location = new Location(35.5f, 33);
      broadcast_xbees[1].location = new Location(3, 33);
      broadcast_xbees[2].location = new Location(28.5f, 22.5f);
      broadcast_xbees[3].location = new Location(11.5f, 1);
      broadcast_xbees[4].location = new Location(39, 4.5f);
      broadcast_xbees[5].location = new Location(20, 15.5f);
      broadcast_xbees[6].location = new Location(11, 11);
      broadcast_xbees[7].location = new Location(27.5f, 1);
      for(int i = 0; i < Constant.NUM_NODES; i++)
      {
        broadcast_xbees[i].id = i;
      }
    }

    public override void draw(Graphics g)
    {
      Region reg = g.Clip;
      g.Clip = new Region(new Rectangle(this._point.X, this._point.Y, size.Width, size.Height));

      this._grid.draw_back(g);

      if (this._grid.display_broadcast_nodes)
      {
        for (int i = 0; i < Constant.NUM_NODES; i++)
        {
          PointF p = _grid.scale_to_screen_coords(broadcast_xbees[i].location);
          Point point = new Point();

          point.X = (int)p.X;
          point.Y = (int)p.Y;

          Color color;
          if (broadcast_xbees[i].working)
            color = Color.Green;
          else
            color = Color.Red;
          XbeeGridPoint xgp = new XbeeGridPoint(_grid, point, color);
          xgp.draw(g);
        }
      }

      this._grid.draw(g);
     
      g.Clip = reg;
      this.draw_room(g);
    }

    protected void draw_room(Graphics g)
    {
      Pen p = new Pen(Color.Black,5);
      g.DrawRectangle(p, this._point.X, this._point.Y, this._size.Width, this._size.Height);
    }
    //This is one tile larger than the actual size of the room
    //We did this so that we can draw a wall that will cover 
    //half of this "extra" tile which will give us our half tile that
    //is in the room.
    const int ROOM_WIDTH = 40;
    //Same as above but I added two extra tiles because there is an 
    //extra half tile on both sides of the room
    private const int ROOM_HEIGTH = 35;
  }
}
