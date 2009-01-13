using System;
using System.Collections.Generic;
using System.Text;

namespace FightinZigbees
{
  /// <summary>
  /// Represents a collection of locations that make up a cluster.
  /// </summary>
  public class Cluster
  {
    public Cluster()
    {
      this.location_is_up_to_date = false;
      this.location = new Location(-1, -1);
      this._locations = new List<Location>();
    }

    public void add_location(Location l)
    {
      this._locations.Add(l);
      this.location_is_up_to_date = false;
    }

    public float intensity
    {
      get { return this._intensity; }
      set { this._intensity = (value > 1) ? 1 : value; }
    }

    public Location location
    {
      get { return calculate_location(); }
      set { this._location = value; }
    }

    public double probability
    {
      get {return _probability;}
      set {this._probability = value;}
    }

    public List<Location> locations
    {
      get { return this._locations; }
      set { this._locations = value; }
    }

    public int size
    {
      get { return this.locations.Count; }
    }

    public List<Location> convex_hull()
    {
      bool found = false;
      //Find lowest point;
      Location lowest = this._locations[0];
      List<Location> copy = new List<Location>();
      for (int i = 0; i < this._locations.Count; ++i)
      {
        for(int j = 0; j < copy.Count; j++)
        {
          if (copy[j].Equals(this._locations[i]))
            found = true;
        }
        if(!found)
          copy.Add(this._locations[i].dup());
        found = false;

        if (this._locations[i].y < lowest.y)
          lowest = this._locations[i];
      }
      if (copy.Count < 3)
        throw new Exception("Convex Hull cannot be made from less than 3 distinct points");

      LocationComparerByAngle comparer = new LocationComparerByAngle();
      comparer.compare_clockwise = true;
      comparer.compare_with = lowest;
      
      copy.Remove(lowest);
      copy.Sort(comparer);

      // GUTS
      List<Location> stack = new List<Location>();
      stack.Add(lowest);
      stack.Add(copy[0]);
      stack.Add(copy[1]);

      Location l0, l1, l2;
      for (int i = 2; i < copy.Count; ++i)
      {
        l0 = stack[stack.Count - 2];
        l1 = stack[stack.Count - 1];
        l2 = copy[i];

        float ang_between = l1.angle_between(l0, l2);
        while (ang_between > Math.PI || ang_between <= 0)
        {
          // Removes last item
          stack.RemoveAt(stack.Count - 1);

          l0 = stack[stack.Count - 2];
          l1 = stack[stack.Count - 1];
          ang_between = l1.angle_between(l0, l2);
        }

        stack.Add(l2);
      }

      if (stack.Count == 3 && stack[1].angle_between(stack[0], copy[2]) == Math.PI)
        throw new Exception("Convex Hull cannot be made if all points are on a line.");

      return stack;
    }

    protected Location calculate_location()
    {
      if(this._locations.Count == 0)
        throw new Exception("Must have at least one point in the cluster to get the location");

      if(!this.location_is_up_to_date)
      {
        float x = 0, y = 0;
        for(int i = 0; i < this._locations.Count; ++i)
        {
          x += this._locations[i].x;
          y += this._locations[i].y;
        }

        this._location.x = x / this._locations.Count;
        this._location.y = y / this._locations.Count;
        this.location_is_up_to_date = true;
      }

      return this._location;
    }

    protected bool location_is_up_to_date;
    protected float _intensity;
    protected Location _location;
    protected List<Location> _locations;
    protected double _probability;
  }

  public class ClusterIntensityComparer : IComparer<Cluster>
  {
    // Sorts in reverse order
    public int Compare(Cluster x, Cluster y)
    {
      return -1 * x.intensity.CompareTo(y.intensity);
    }
  }

  public class ClusterProbabilityComparer : IComparer<Cluster>
  {
    // Sorts in reverse order
    public int Compare(Cluster x, Cluster y)
    {
      return -1*x.probability.CompareTo(y.probability);
    }
  }
}
