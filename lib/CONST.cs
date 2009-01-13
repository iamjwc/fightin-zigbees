using System;
using System.Collections.Generic;
using System.Text;

namespace FightinZigbees
{
  public class Constant
  {
    // Min / Max / Set Value Sizes
    public const bool TESTING = false;
    public const int ROOM_WIDTH = 40;
    public const int ROOM_HEIGHT = 34;
    public const uint NODE_1_ADDR = 0x00C0;
    public const uint NODE_7_ADDR = 0x00C7;
    public const int NUM_NODES = 8;
    public const int NUM_ORIENTATIONS = 4;
    public const int MAX_NUM_OF_SIG_STR = 100;
    public const int MAX_SIG_STR = 100;
    public const int MIN_SIG_STR = 0;
    public const int TIME_SPAN = 200;

    // Types
    public const string HEAT_MAP_RENDERER = "heat map";
    public const string CONVEX_HULL_RENDERER = "convex hull";

    // Directories & Files
    public const string BY_SIGNAL_STRENGTH_DATA_FILE = "data/persisted_data_by_position/generated_data_by_signal_strength.txt";
    public const string COLLECTED_DATA_DIRECTORY = "data/collected_data/";
    public const string CONSOLIDATED_FILE = "data/collected_data/consolidated_by_pos_file.txt";

    // Formats
    public const string FILE_NAME_FORMAT = "Position_*_*_Orientation_*.txt";//"consolidated_by_pos_backup.txt";
  }
}
