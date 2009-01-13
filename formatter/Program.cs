using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FightinZigbees
{
  public class Formatter
  {
    public static void Main(string[] args)
    {
      FileStream f_out = new FileStream(Constant.BY_SIGNAL_STRENGTH_DATA_FILE, FileMode.Create, FileAccess.Write);
      StreamWriter s_out = new StreamWriter(f_out);
      PersistedDataBySignalStrength data_out = new PersistedDataBySignalStrength(null);
      List<Location>[, ,] transformed_data = new List<Location>[Constant.MAX_SIG_STR + 1, Constant.NUM_NODES, Constant.NUM_ORIENTATIONS];
      DataCompiler compiler = new DataCompiler();
      DirectoryInfo dir_inf = new DirectoryInfo(Constant.COLLECTED_DATA_DIRECTORY);
      compiler.create_empty_text_files_for_positions_not_tested(dir_inf);
      compiler.compile_by_position_data_into_one_file(dir_inf);
      compiler.by_position_to_by_signal_strength(Constant.CONSOLIDATED_FILE, transformed_data);
      data_out.write(transformed_data, s_out);
      s_out.Close();
      f_out.Close();
    }
  }
}
