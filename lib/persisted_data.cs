using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FightinZigbees
{
  /// <summary>
  /// This class will load a file of the format
  /// 
  /// PrimaryKeyCount NodeCount OrientationCount
  /// [0 0 0] <# of values> v1 v2 ... vn
  /// [0 0 1] <# of values> v1 v2 ... vn
  ///      .
  ///      .
  /// [0 0 n] <# of values> v1 v2 ... vn
  /// [0 1 0] <# of values> v1 v2 ... vn
  ///      .
  ///    . .
  /// [0 n n] <# of values> v1 v2 ... vn
  /// [1 0 0] <# of values> v1 v2 ... vn
  ///      .
  ///    . .
  ///  . . .
  /// [PrimaryKey-1 NodeCount-1 OrientationCount-1] <# of values> Values
  /// </summary>
  public abstract class PersistedData<KeyT, ValueT>
  {
    public PersistedData(FileStream stream)
    {
      if (stream != null)
        parser = new InputStreamParser(stream);
    }

    public List<ValueT>[,,] load()
    {
      List<ValueT>[,,] values;
      uint primary_key_count, node_count, orientation_count, value_count;
      uint primary_key, node, orientation;
      primary_key_count = read_key_count();
      node_count        = parser.read_uint();
      orientation_count = parser.read_uint();
      
      values = new List<ValueT>[primary_key_count, node_count, orientation_count];

      for (uint i = 0, n = primary_key_count * node_count * orientation_count; i < n; ++i)
      {
        parser.read_char(); // [
        primary_key = read_key();
        node = parser.read_uint();
        orientation = parser.read_uint();
        parser.read_char(); // ]

        parser.read_char(); // <
        value_count = parser.read_uint();
        parser.read_char(); // >
        
        if(values[primary_key,node,orientation] == null) 
        {
          values[primary_key, node, orientation] = new List<ValueT>();
        }

        for (int j = 0; j < value_count; j++)
        {
          values[primary_key, node, orientation].Add(read_value());
        }
      }
      return values;
    }

    public string to_string(Location primary_key, uint node, uint orientation, List<ValueT> values) 
    {
      return "[" + write_location(primary_key) + " " + node + " " + orientation + "] <" + values.Count + "> " + write_values(values);
    }
    public void write(List<ValueT>[, ,] location_data, StreamWriter f_out)
    {
      uint primary_key_count, node_count, orientation_count, value_count;
      primary_key_count = (uint)location_data.GetLength(0);
      node_count = (uint)location_data.GetLength(1);
      orientation_count = (uint)location_data.GetLength(2);

      f_out.WriteLine( primary_key_count + " " + node_count + " " + orientation_count);
      for (uint i = 0, n = primary_key_count; i < n; ++i)
      {
        for (uint j = 0, m = node_count; j < m; ++j)
        {
          for (uint k = 0, o = orientation_count; k < o; ++k)
          {
            if (location_data[i, j, k] == null)
            {
              location_data[i, j, k] = new List<ValueT>();
            }
            value_count = (uint)location_data[i, j, k].Count;
            f_out.WriteLine("[" + write_key(i) + " " + j + " " + k + "] <" + value_count + "> " + write_values(location_data[i, j, k]));

          }
        }
      }
      return;
    }


    abstract protected uint read_key();
    abstract protected ValueT read_value();
    abstract protected string write_key(uint primary_key);
    abstract protected string write_values(List<ValueT> values);
    abstract protected uint read_key_count();

    protected Location read_location()
    {
      uint x, y;
      x = parser.read_uint();
      parser.read_char(); // ,
      y = parser.read_uint();
      return new Location((int)x, (int)y);
    }

    protected uint read_signal_strength()
    {
      return parser.read_uint();
    }

    protected string write_location(Location location)
    {
      return location.x + "," + location.y;
    }

    protected string write_signal_strength(uint signal_strength)
    {
      return signal_strength.ToString();
    }

    protected InputStreamParser parser;
  }
}
