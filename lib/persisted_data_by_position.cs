using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace FightinZigbees
{
  public class PersistedDataByPosition : PersistedData<Location, uint>
  {
    public PersistedDataByPosition(FileStream stream): base(stream){}

    public Location position_index_to_location(uint position)
    {
      uint y_position = position % max_y;
      uint x_position = (position - y_position)/max_y;
      return new Location(x_position, y_position);
    }
    protected override uint read_key()
    {
      Location loc = base.read_location();
      return (uint)(loc.x * max_y) + (uint)loc.y;
    }

    protected override uint read_value()
    {
      return base.read_signal_strength();
    }

    protected override string write_key(uint primary_key)
    {
      return base.write_location(position_index_to_location(primary_key));
    }

    protected override string write_values(List<uint> values)
    {
      string values_list = "";
      for (int i = 0; i < values.Count; ++i)
      {
        values_list += base.write_signal_strength(values[i]) + " ";
      }
      return values_list;
    }

    protected override uint read_key_count()
    {
      Location loc = base.read_location();
      max_x = (uint)loc.x;
      max_y = (uint)loc.y;
      return max_x * max_y;
    }

    protected uint max_x;
    protected uint max_y;
  }
}
