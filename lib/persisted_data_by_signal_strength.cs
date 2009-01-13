using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FightinZigbees
{
  /// <summary>
  /// This class will load a file of the format
  /// 
  /// SignalStrengthCount NodeCount OrientationCount
  /// [0 0 0] <4> x,y x,y x,y x,y
  /// [0 0 1] <3> x,y x,y x,y
  /// [0 0 2] <5> x,y x,y x,y x,y x,y
  ///  . . .
  ///  . .
  ///  .
  /// [SignalStrengthCount-1 NodeCount-1 OrientationCount-1] <5> x,y x,y x,y x,y x,y
  /// </summary>
  public class PersistedDataBySignalStrength : PersistedData<uint, Location>
  {
    public PersistedDataBySignalStrength(FileStream stream) : base(stream)
    {
    }

    protected override uint read_key()
    {
      return base.read_signal_strength();
    }

    protected override Location read_value()
    {
      Location loc = base.read_location();
      return loc;
    }

    protected override string write_key(uint primary_key)
    {
      return base.write_signal_strength(primary_key);
    }

    protected override string write_values(List<Location> values)
    {
      string values_list = "";
      for (int i = 0; i < values.Count; ++i)
      {
        values_list += base.write_location(values[i]) + " ";
      }
      return values_list;
    }

    protected override uint read_key_count()
    {
      return base.parser.read_uint();
    }

  }
}
