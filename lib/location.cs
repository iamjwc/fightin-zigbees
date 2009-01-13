using System;
using System.Collections.Generic;
using System.Text;

namespace FightinZigbees
{
  public class Location : IComparable
  {
    public float x, y;

    public Location(float x, float y)
    {
      this.x = x;
      this.y = y;
    }

    public float distance_from(Location loc2)
    {
      float x_dist = this.x - loc2.x;
      float y_dist = this.y - loc2.y;
      double dist = Math.Sqrt( Math.Pow(x_dist, 2) + Math.Pow(y_dist, 2) );
      return (float)dist;
    }

    /// <summary>
    /// Finds the angle between two points counter clockwise.
    /// </summary>
    /// <param name="l1"></param>
    /// <param name="l2"></param>
    /// <returns></returns>
    public float angle_between(Location l1, Location l2)
    {
      float x1 = l1.x - this.x;
      float y1 = l1.y - this.y;
      float x2 = l2.x - this.x;
      float y2 = l2.y - this.y;
      bool point1_in_lower_half = y1 < 0;
      bool point2_in_lower_half = y2 < 0;

      float angle1 = (float)Math.Atan2(y1, x1);
      float angle2 = (float)Math.Atan2(y2, x2);

      if(point1_in_lower_half)
        angle1 += (float)(2 * Math.PI);
      if (point2_in_lower_half)
        angle2 += (float)(2 * Math.PI);

      float angle = angle2 - angle1;
      if (angle < 0)
        angle += 2*(float)Math.PI;

      return angle;
    }

    /// <summary>
    /// Duplicates the current Location.
    /// </summary>
    /// <returns></returns>
    public Location dup()
    {
      return new Location(this.x, this.y);
    }

    public override string ToString()
    {
      return String.Format("{0}, {1}", this.x, this.y);
    }

    public override bool Equals(object rhs)
    {
      Location loc = (Location)rhs;
      return this.x == loc.x && this.y == loc.y;
    }

    public int CompareTo(object obj)
    {
      Location rhs = (Location)obj;

      if (this.x < rhs.x)
        return -1;
      else if (this.x > rhs.x)
        return 1;
      else if (this.y < rhs.y)
        return -1;
      else if (this.y > rhs.y)
        return 1;
      else
        return 0;
    }
  }
  
  public class LocationComparerByAngle : IComparer<Location>
  {
    public LocationComparerByAngle()
    {
      this._compare_clockwise = false;
    }

    public Location compare_with
    {
      get { return this._compare_with; }
      set
      {
        this._compare_with = value;
        this.relative_location = new Location(value.x+1, value.y);
      }
    }

    public bool compare_clockwise
    {
      get { return this._compare_clockwise; }
      set { this._compare_clockwise = value; }
    }

    public int Compare(Location x, Location y)
    {
      float angle1 = _compare_with.angle_between(relative_location, x);
      float angle2 = _compare_with.angle_between(relative_location, y);

      int multiplier = (_compare_clockwise) ? -1 : 1;

      if (angle1 < angle2)
        return -1 * multiplier;
      else if (angle1 > angle2)
        return 1 * multiplier;
      else
        return 0;
    }


    protected bool _compare_clockwise;
    protected Location _compare_with;
    protected Location relative_location;
  }
}
