using System;
using System.Collections.Generic;
using System.Text;

namespace FightinZigbees
{
  public class Clusterer
  {
    /// <summary>
    /// Method finds all of the clusters within a given distance.
    /// </summary>
    /// <param name="locations">Array of all of the XY coordinates
    /// for a certain signal strength. MUST be sorted.</param>
    /// <param name="max_distance">Size of cluster.</param>
    /// <returns>A list of clusters.</returns>
    public static List<Cluster> cluster(List<Location> locations, float max_distance)
    {
      if (locations.Count <= 0)
        throw new Exception("List cannot be empty!");
      Cluster[] clusters = new Cluster[locations.Count];

      Location prev = locations[0];
      for (int i = 1; i < locations.Count; ++i)
      {
        if (locations[i].CompareTo(prev) == -1)
          throw (new Exception("Locations must be sorted."));
        prev = locations[i];
      }

      // TODO: It may be possible to optimize by eliminating redundant / duplicate checks
      // TODO: optimization to max bound?
      for(int i = 0; i < locations.Count; ++i)
        clusters[i] = new Cluster();

      prev = new Location(-1, -1);
      for(int i = 0; i < locations.Count; ++i)
      {        
        clusters[i].add_location(locations[i]); // Add itself to list
        for(int j = i + 1; j < locations.Count; ++j)
        {
          if (locations[i].distance_from(locations[j]) <= max_distance)
          {
            clusters[i].add_location(locations[j]);
            clusters[j].add_location(locations[i]);
          }
        }

        //if (locations.Count > 0)
        //{
        //  clusters[i].probability = ((double)clusters[i].size / (double)locations.Count);
        //}
        //else
        //  clusters[i].probability = 0;

        if (locations[i].CompareTo(prev) == 0)
          clusters[i] = null;

        prev = locations[i];
      }

      double totalPoints = 0;
      for(int i = 0; i < clusters.Length; i++)
      {
        if(clusters[i] != null)
          totalPoints += (double)clusters[i].size;
      }

      for(int i = 0; i < clusters.Length; i++)
      {
        if(clusters[i] != null)
          clusters[i].probability = ((double) clusters[i].size/totalPoints);
      }

      List<Cluster> copy = new List<Cluster>();
      for(int i = 0; i < clusters.Length; ++i)
      {
        if(clusters[i] != null)
        {
          clusters[i].intensity = (float)clusters[i].locations.Count / locations.Count;
          copy.Add(clusters[i]);
        }
      }
      return copy;
    }
  }
}
