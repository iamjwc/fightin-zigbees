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
  public class PersistedTextFile : IPersistedData
  {
    public PersistedTextFile(FileStream stream)
    {
      parser = new InputStreamParser(stream);
    }

    public Location[,,][] load()
    {
      Location[,,][] locations;
      uint signal_strength_count, node_count, orientation_count, locations_count;
      uint signal_str, node, orientation;
      uint x, y;

      signal_strength_count = parser.read_uint();
      node_count            = parser.read_uint();
      orientation_count     = parser.read_uint();

      locations = new Location[signal_strength_count, node_count, orientation_count][];

      for (uint i = 0, n = signal_strength_count * node_count * orientation_count; i < n; ++i)
      {
        parser.read_char(); // [
        signal_str = parser.read_uint();
        node = parser.read_uint();
        orientation = parser.read_uint();
        parser.read_char(); // ]

        parser.read_char(); // <
        locations_count = parser.read_uint();
        parser.read_char(); // >

        locations[signal_str, node, orientation] = new Location[locations_count];
        for (int j = 0; j < locations_count; j++)
        {
          x = parser.read_uint();
          parser.read_char(); // ,
          y = parser.read_uint();

          locations[signal_str, node, orientation][j] = new Location((int)x, (int)y);
        }
      }
      return locations;
    }

    InputStreamParser parser;
  }
}
