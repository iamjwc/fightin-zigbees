using System;
using System.Collections.Generic;
using System.Text;
using NSpec.Framework;

namespace FightinZigbees
{
  [Context]
  public class ClusterTest
  {
    [Specification]
    public void cluster_add_location_test()
    {
      Cluster clust = new Cluster();

      for (int i = 0; i < 5; i++)
      {
        Location loc = new Location(2, i);
        clust.add_location(loc);

        Specify.That(clust.locations[i].x).ShouldEqual(2);
        Specify.That(clust.locations[i].y).ShouldEqual(i);
        Specify.That(clust.locations[i].Equals(loc)).ShouldBeTrue();
      }
    }

    [Specification]
    public void cluster_fuck_intensity_test()
    {
      Cluster clust = new Cluster();

      clust.intensity = 69.234f;
      Specify.That(clust.intensity).ShouldEqual(1);

      for(float i = 0.05f; i < 20; i = i * 1.69f)
      {
        clust.intensity = i;
        if (i < 1)
          Specify.That(clust.intensity).ShouldEqual(i);
        else
          Specify.That(clust.intensity).ShouldEqual(1);
      }
    }

    [Specification]
    public void calculate_location_test()
    {
      Location[] loc = new Location[4];

      loc[0] = new Location(3, 2);
      loc[1] = new Location(3, 3);
      loc[2] = new Location(3, 4);
      loc[3] = new Location(2, 3);

      Cluster clust = new Cluster();
      clust.add_location(loc[0]);
      clust.add_location(loc[1]);
      clust.add_location(loc[2]);
      clust.add_location(loc[3]);

      Location loc2 = clust.location;

      Specify.That(loc2.x).ShouldEqual((float)11/4);
      Specify.That(loc2.y).ShouldEqual((float)12/4);
    }

    [Specification]
    public void convex_hull_test()
    {
      Location[] loc = new Location[7];
      Cluster clust = new Cluster();
      List<Location> expected = new List<Location>();

      loc[0] = new Location(3, 2);
      loc[1] = new Location(3, 3);
      loc[2] = new Location(3, 4);
      loc[3] = new Location(2, 3);
      loc[4] = new Location(2, 1);
      loc[5] = new Location(1, 2);
      loc[6] = new Location(1, 4);
            
      clust.add_location(loc[0]);
      clust.add_location(loc[1]);
      clust.add_location(loc[2]);
      clust.add_location(loc[3]);
      clust.add_location(loc[4]);
      clust.add_location(loc[5]);
      clust.add_location(loc[6]);

      expected.Add(loc[4]);
      expected.Add(loc[5]);
      expected.Add(loc[6]);
      expected.Add(loc[2]);
      expected.Add(loc[1]);
      expected.Add(loc[0]);

      List<Location> ch = clust.convex_hull();

      for(int i = 0; i < 4; i++)
      {
       Specify.That(ch[i].Equals(expected[i])).ShouldBeTrue();
      }
    }

    [Specification]
    public void second_convex_hull_test()
    {
      Cluster clust = new Cluster();
      List<Location> expected = new List<Location>();
      Location[] loc = new Location[]
      {
        new Location(2, 0),
        new Location(0, 2),
        new Location(2, 4),
        new Location(2, 1),
        new Location(2, 2),
        new Location(4, 2)
      };

      clust.add_location(loc[0]);
      clust.add_location(loc[1]);
      clust.add_location(loc[2]);
      clust.add_location(loc[3]);
      clust.add_location(loc[4]);
      clust.add_location(loc[5]);

      expected.Add(loc[0]);
      expected.Add(loc[1]);
      expected.Add(loc[3]);
      expected.Add(loc[5]);

      List<Location> ch = clust.convex_hull();

      for (int i = 0; i < 4; i++)
      {
        Specify.That(ch[i]).ShouldEqual(expected[i]);
      }
    }

  }
}
