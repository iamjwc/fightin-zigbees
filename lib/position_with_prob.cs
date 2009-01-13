using System;
using System.Collections.Generic;
using System.Text;

namespace FightinZigbees
{
  public class PositionWithProb
  {
    public PositionWithProb(Location loc, double prob)
    {
      _loc = new Location(loc.x, loc.y);
      this._probability = prob;
    }

    public Location location
    {
      get { return this._loc;}
    }

    public double probability
    {
      get { return this._probability; }
    }

    protected Location _loc;
    protected double _probability;
  }

  public class PositionWithProbComparer : IComparer<PositionWithProb>
  {
    public PositionWithProbComparer()
    {
    }

    public int Compare(PositionWithProb prob_1, PositionWithProb prob_2)
    {
      if (prob_1.probability > prob_2.probability)
        return -1;
      else if (prob_1.probability < prob_2.probability)
        return 1;
      else
        return 0;
    }
  }
}
