using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Ports;

namespace FightinZigbees
{
  class Program
  {
    static void Main(string[] args)
    {
      Xbee xb = new Xbee();
      xb.open();
      xb.enter_api_mode();

      int[] valid_signals = new int[Constant.NUM_NODES + 1];
      for (int i = 0; i < 10000; i++)
      {
        Packet packet = xb.read_packet();
        uint address = packet.get_address();
        Console.WriteLine("{0}, {1}", (address % Constant.NODE_1_ADDR), packet.get_message_length());
        if ((address >= Constant.NODE_1_ADDR) && (address <= Constant.NODE_7_ADDR + 1))
        {
          valid_signals[address % Constant.NODE_1_ADDR]++;
        }
      }

      if(valid_signals[8] > 0)
        Console.WriteLine("Worked");
      else 
        Console.WriteLine("Did not work");

      //DataCompiler comp = new DataCompiler();
      //comp.create_empty_text_files_for_positions_not_tested();

      //string[] test;
      //test = SerialPort.GetPortNames();
      //for(int i = 0; i < test.Length; i++)
      //{
      //  if(String.Compare(test[i], "COM3") != 0)
      //    Console.WriteLine("{0}", test[i]);
      //}

      //run_test();
      //run_test("test_data_2/");
    }
    static void run_test()
    {
      // Essentially runs formatter program directly in test
      string[] args = new string[0];
      Formatter.Main(args);

      FileStream expected_data_stream = new FileStream("fixtures/persisted_data_by_position/expected_output_2.txt", FileMode.Open, FileAccess.Read);
      FileStream actual_data_stream = new FileStream("fixtures/persisted_data_by_position/generated_data_by_signal_strength.txt", FileMode.Open, FileAccess.Read);
      PersistedDataBySignalStrength expected = new PersistedDataBySignalStrength(expected_data_stream);
      PersistedDataBySignalStrength actual = new PersistedDataBySignalStrength(actual_data_stream);
      List<Location>[, ,] expected_data = expected.load();
      List<Location>[, ,] actual_data = actual.load();
      expected_data_stream.Close();
      actual_data_stream.Close();

      string a = to_string(actual_data);
      string b = to_string(expected_data);
      if (a == b)
      {
        Console.WriteLine("correct!");
      }
      else
      {
        Console.WriteLine("incorrect!");
      }
    }
  
    static string to_string(List<Location>[, ,] data)
    {
      string data_string = "";
      for (int i = 0, m = data.GetLength(0); i < m; ++i)
      {
        for (int j = 0, n = data.GetLength(1); j < n; ++j)
        {
          for (int k = 0, o = data.GetLength(2); k < o; ++k)
          {
            //if (data[i, j, k] == null)
            //{
            //  data[i, j, k] = new List<Location>();
            //}
            for (int l = 0, p = data[i, j, k].Count; l < p; ++l)
            {
              data_string += data[i, j, k][l].x + "," + data[i, j, k][l].y + " ";
            }
          }
        }
      }
      return data_string;
    
    
      /***SCRIPT FOR PARSING INTO INDIVIDUAL FILES, PLEASE KEEP FOR NOW ***/
      /*string line;
      FileStream f_in = new FileStream("consolidated_by_pos.txt", FileMode.Open, FileAccess.Read);
      StreamReader s_in = new StreamReader(f_in);
      s_in.ReadLine();
      for (int i = 0; i < 5; ++i)
      {
        for (int j = 0; j < 5; ++j)
        {
          FileStream f_out = new FileStream("../../../test/fixtures/collected_data/Position_" + i + "_" + j + "_Orientation" + "_" + "0" + ".txt", FileMode.Create, FileAccess.Write);
          StreamWriter s_out = new StreamWriter(f_out);
          s_out.WriteLine("1,1 4 1");
          for (int k = 0; k < 4; ++k)
          {
            line = s_in.ReadLine();
            s_out.WriteLine(line);
          }
          s_out.Close();
          f_out.Close();
        }
      }
      s_in.Close();
      f_in.Close();*/
    }
  }
}
