using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using NSpec.Framework;

namespace FightinZigbees
{
  [Context]
  public class ClustererTest
  {
    [Specification]
    public void controlled_clusterer_test()
    {
      PersistedDataBySignalStrength d = new PersistedDataBySignalStrength(new FileStream("fixtures/clusterer/training_data.txt", FileMode.Open, FileAccess.Read));

      List<Location>[, ,] locations = d.load();

      Location[] expected_clusters1 = 
        { l(0,2), l(0,2), l(1,2), l(1,2),
          l(0,2), l(0,2), l(1,2), l(1,2), l(2,2), l(2,2), l(2,2), l(2,2),
          l(2,0), l(2,0), l(2,1), l(2,1),
          l(2,0), l(2,0), l(2,1), l(2,1), l(2,2), l(2,2), l(2,2), l(2,2),
          l(1,2), l(1,2), l(2,1), l(2,1), l(2,2), l(2,2), l(2,2), l(2,2), l(2,3), l(2,3), l(3,2), l(3,2),
          l(2,2), l(2,2), l(2,2), l(2,2), l(2,3), l(2,3), l(2,4), l(2,4),
          l(2,3), l(2,3), l(2,4), l(2,4),
          l(2,2), l(2,2), l(2,2), l(2,2), l(3,2), l(3,2), l(4,2), l(4,2),
          l(3,2), l(3,2), l(4,2), l(4,2)
        };
      uint[] sig_strs1 = { 2, 2, 2, 2 };

      Location[] expected_clusters2 =
        {
          l(0,0), l(0,0), l(0,1), l(1,0),
          l(0,0), l(0,0), l(0,1), l(0,2),
          l(0,1), l(0,2), l(0,3),
          l(0,2), l(0,3), l(0,4), l(0,4),
          l(0,3), l(0,4), l(0,4), l(1,4), l(1,4),
          l(0,0), l(0,0), l(1,0), l(2,0),
          l(0,4), l(0,4), l(1,4), l(1,4), l(2,4), l(2,4),
          l(1,0), l(2,0), l(3,0),
          l(1,4), l(1,4), l(2,4), l(2,4), l(3,4), l(3,4),
          l(2,0), l(3,0), l(4,0), l(4,0),
          l(2,4), l(2,4), l(3,4), l(3,4), l(4,4), l(4,4), l(4,4), l(4,4),
          l(3,0), l(4,0), l(4,0), l(4,1), l(4,1),
          l(4,0), l(4,0), l(4,1), l(4,1), l(4,2), l(4,2),
          l(4,1), l(4,1), l(4,2), l(4,2), l(4,3), l(4,3),
          l(4,2), l(4,2), l(4,3), l(4,3), l(4,4), l(4,4), l(4,4), l(4,4),
          l(3,4), l(3,4), l(4,3), l(4,3), l(4,4), l(4,4), l(4,4), l(4,4)
        };
      uint[] sig_strs2 = { 4, 4, 4, 0 };

      Location[] expected_clusters3 =
        {
          l(0,0),
          l(0,4),
          l(4,0),
          l(4,4)
        };
      uint[] sig_strs3 = { 0, 0, 0, 0 };

      Location[] expected_clusters4 =
        {
          l(0,0), l(0,4), l(4,0),
          l(0,0), l(0,4), l(4,4),
          l(0,0), l(4,0), l(4,4),
          l(0,4), l(4,0), l(4,4)
        };
      uint[] sig_strs4 = { 0, 0, 0, 0 };

      Location[] expected_clusters5 =
        {
          l(0,2), l(0,3), l(1,2),
          l(0,2), l(0,3), l(1,3),
          l(0,2), l(1,2), l(1,3), l(2,2), l(2,2),
          l(0,3), l(1,2), l(1,3), l(1,4),
          l(1,3), l(1,4),
          l(2,0), l(2,0), l(2,1), l(2,1),
          l(2,0), l(2,0), l(2,1), l(2,1), l(2,2), l(2,2),
          l(1,2), l(2,1), l(2,1), l(2,2), l(2,2), l(3,2),
          l(2,2), l(2,2), l(3,2), l(3,3), l(4,2),
          l(3,2), l(3,3), l(3,4), l(4,3),
          l(3,3), l(3,4),
          l(3,2), l(4,2), l(4,3),
          l(3,3), l(4,2), l(4,3)
        };
      uint[] sig_strs5 = { 2, 1, 2, 1 };

      List<Location> expected_clusters = new List<Location>();
      
      expected_clusters.AddRange(expected_clusters1);
      run_test_on(sig_strs1, expected_clusters, locations, 1);
      expected_clusters.Clear();

      expected_clusters.AddRange(expected_clusters2);
      run_test_on(sig_strs2, expected_clusters, locations, 1);
      expected_clusters.Clear();

      expected_clusters.AddRange(expected_clusters3);
      run_test_on(sig_strs3, expected_clusters, locations, 1);
      expected_clusters.Clear();

      expected_clusters.AddRange(expected_clusters4);
      run_test_on(sig_strs4, expected_clusters, locations, 4);
      expected_clusters.Clear();

      expected_clusters.AddRange(expected_clusters5);
      run_test_on(sig_strs5, expected_clusters, locations, 1);
      expected_clusters.Clear();
    }

    private void run_test_on(uint[] sig_strs, List<Location> expected_clusters, List<Location>[, ,] locations, int dist_from_cent) 
    {
      ArrayBasedLocations loc = new ArrayBasedLocations(locations);
      List<Location> pos_locs = new List<Location>();
      bool expected_matches_actual = true;

      for (int i = 0; i < sig_strs.Length; ++i)
      {
          pos_locs.AddRange(loc.get_locations(i, Orientation.North, sig_strs[i]));
      }
      pos_locs.Sort();

      List<Cluster> actual_clusters = Clusterer.cluster(pos_locs, dist_from_cent);
      
      int total_locations = 0;
      for (int i = 0; i < actual_clusters.Count; ++i)
      {
        total_locations += actual_clusters[i].locations.Count;
      }

     
      if (expected_clusters.Count != total_locations)
      {
        expected_matches_actual = false;
      }
      else
      {
        int count = 0;
        //System.Console.WriteLine("\nTest: num_signal_strengths = " + sig_strs.Length + ", dist_from_center = " + dist_from_cent);
        for (int i = 0; i < actual_clusters.Count; ++i)
        {
          //System.Console.WriteLine("");
          for (int j = 0; j < actual_clusters[i].locations.Count; ++j)
          {
            // Uncomment the 5 commented out lines of code to debug test case.  Prints "Actual Value(Expected Value)".
            //System.Console.Write(actual_clusters[i].locations[j].x + "," + actual_clusters[i].locations[j].y);
            //System.Console.Write("(" + expected_clusters[count].x + "," + expected_clusters[count].y + ") ");
            expected_matches_actual &= (actual_clusters[i].locations[j].Equals(expected_clusters[count]));
            count++;
          }
          //System.Console.WriteLine("");
        }
      }

        Specify.That(expected_matches_actual).ShouldBeTrue();
      }
  
    private Location l(float x, float y) 
    {
      return new Location(x, y);
    }
  }
}
