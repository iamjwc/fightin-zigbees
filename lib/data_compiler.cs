using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FightinZigbees
{
  public class DataCompiler
  {
    public void create_empty_text_files_for_positions_not_tested(DirectoryInfo dir_info)
    {
      //j = Y value
      for (uint j = 0; j <= 33; j++)
      {
        //k = X value
        for (uint k = 0; k <= 39; k++)
        {
          Location loc = new Location(k, j);
          //l = orientation
          string collected_data_path = "";
          for (uint l = 0; l < Constant.NUM_ORIENTATIONS; l++)
          {
            uint orientation = l;
            collected_data_path = "data/collected_data/Position_";
            collected_data_path += k.ToString();
            collected_data_path += "_";
            collected_data_path += j.ToString();
            collected_data_path += "_Orientation_";
            collected_data_path += l.ToString();
            collected_data_path += ".txt";
            //Opens file to print to.

            try
            {
              FileStream f_out = new FileStream(collected_data_path, FileMode.CreateNew, FileAccess.Write);

              //Creates a right with the file stream above.
              StreamWriter s_out = new StreamWriter(f_out);
              //Gives me access to the to_string function
              PersistedDataByPosition d = new PersistedDataByPosition(null);
              s_out.WriteLine("1,1 8 1");
              List<uint> list = new List<uint>();
              for (uint m = 0; m < Constant.NUM_NODES; m++)
                s_out.WriteLine(d.to_string(loc, m, orientation, list));

              s_out.Close();
              f_out.Close();
            }
            catch(IOException)
            {
              
            }
          }
        }
      }
    }
    public void compile_by_position_data_into_one_file(DirectoryInfo dir_info)
    {
      FileInfo[] files = dir_info.GetFiles(Constant.FILE_NAME_FORMAT);
      FileStream f_out = new FileStream(Constant.CONSOLIDATED_FILE, FileMode.Create, FileAccess.Write);
      StreamWriter s_out = new StreamWriter(f_out);
      s_out.WriteLine(Constant.ROOM_WIDTH + "," + Constant.ROOM_HEIGHT + " " + Constant.NUM_NODES + " " + Constant.NUM_ORIENTATIONS);
      foreach (FileInfo by_position_data_file in files)
      {
        FileStream f_in = new FileStream(dir_info.FullName + "/" + by_position_data_file.Name, FileMode.Open, FileAccess.Read);
        StreamReader s_in = new StreamReader(f_in);
        s_in.ReadLine();
        while (!s_in.EndOfStream)
        {
          s_out.WriteLine(s_in.ReadLine());
        }
        s_in.Close();
        f_in.Close();
      }
      s_out.Close();
      f_out.Close();
    }

    public void by_position_to_by_signal_strength(string by_position_data_file, List<Location>[, ,] transformed_data)
    {
      MinMax min_max_signal_strength;
      uint position_count, node_count, orientation_count;
      MinMaxSignalStrength min_max = new MinMaxSignalStrength();
      PersistedDataByPosition data_in = new PersistedDataByPosition(new FileStream(by_position_data_file, FileMode.Open, FileAccess.Read));
      List<uint>[, ,] loaded_data = data_in.load();
      position_count = (uint)loaded_data.GetLength(0);
      node_count = (uint)loaded_data.GetLength(1);
      orientation_count = (uint)loaded_data.GetLength(2);
      
      for (uint position_index = 0; position_index < position_count; ++position_index)
      {
        for (uint node = 0; node < node_count; ++node)
        {
          for (uint orientation = 0; orientation < orientation_count; ++orientation)
          {
            min_max_signal_strength = min_max.calculate_min_max_signal_strength(loaded_data[position_index, node, orientation]);
            for (uint signal_strength = min_max_signal_strength.min; signal_strength <= min_max_signal_strength.max; ++signal_strength)
            {
              if (transformed_data[signal_strength, node, orientation] == null)
              {
                transformed_data[signal_strength, node, orientation] = new List<Location>();
              }
              transformed_data[signal_strength, node, orientation].Add(data_in.position_index_to_location(position_index));
              transformed_data[signal_strength, node, orientation].Sort();
            }
          }
        }
      }
    }
  }
}
