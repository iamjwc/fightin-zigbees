using System;
using System.Collections.Generic;
using System.Text;
using NSpec.Framework;

namespace FightinZigbees
{
  [Context]
  public class ArrayBasedLocationsTest
  {
    [Specification]
    public void will_test_construtor()
    {
      uint primary_key_count = 1;
      uint node_count = 1;
      uint orientation_count = 1;
      uint value_cnt = 6;

      List<Location>[, ,] locations = new List<Location>[primary_key_count,node_count,orientation_count];

      locations[0, 0, 0] = new List<Location>();
      for(int i = 0; i < value_cnt; i++)
      {
        locations[0, 0, 0].Add(new Location(1, i));
      }

      ILocations loc = new ArrayBasedLocations(locations);

      for (int i = 0; i < value_cnt; i++)
      {
        Specify.That(loc.get_locations(0, 0, 0)[i].Equals(locations[0,0,0][i])).ShouldBeTrue();
      }
    }

    [Specification]
    public void will_get_locations()
    {

    }
  }
}
