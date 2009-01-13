using System;
using System.Collections.Generic;
using System.Text;

namespace FightinZigbees
{
  public interface ILocations
  {
    List<Location> get_locations(int node_id, Orientation o, uint signal_strength);
  }
}
