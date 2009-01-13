using System;
using System.Collections.Generic;
using System.Text;

namespace FightinZigbees
{
  public class ArrayBasedLocations : ILocations
  {
    public uint NodeCount;
    public uint SignalStrengthCount;
    public uint OrientationCount;

    public ArrayBasedLocations(List<Location>[,,] location_data)
    {
      this.SignalStrengthCount = (uint)location_data.GetLength(0);
      this.NodeCount = (uint)location_data.GetLength(1);
      this.OrientationCount = (uint)location_data.GetLength(2);

      this.data = new List<Location>[this.SignalStrengthCount, this.NodeCount, this.OrientationCount];

      for(int i = 0; i < this.SignalStrengthCount; ++i)
      {
        for(int j = 0; j < this.NodeCount; ++j)
        {
          for(int k = 0; k < this.OrientationCount; ++k)
          {
            this.data[i, j, k] = new List<Location>();
            this.data[i,j,k].AddRange(location_data[i,j,k]);
          }
        }
      }
    }

    public List<Location> get_locations(int node_id, Orientation o, uint signal_strength)
    {
      List<Location> locs = new List<Location>();
      locs.AddRange(this.data[signal_strength,node_id,(int)o]);

      return locs;
    }

    protected List<Location>[,,] data;
  }
}
