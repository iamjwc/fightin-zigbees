using System;
using System.Collections.Generic;
using System.Text;

namespace FightinZigbees
{
  public class BroadcastXbee
  {
    public BroadcastXbee()
    {
      _working = false;
    }

    public Location location
    {
      get { return this._loc; }
      set { this._loc = value; }
    }

    public int id
    {
      get { return this._id;}
      set { this._id = value;}
    }

    public bool working
    {
      get { return this._working; }
      set { this._working = value; }
    }
    protected bool _working;
    protected Location _loc;
    protected int _id;
  }
}
