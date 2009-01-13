using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using NSpec.Framework;
 

namespace FightinZigbees
{
  [Context]
  public class FormatterTest
  {
    [Specification]
    public void collected_data_to_final_data()
    {
      //run_test("test_data_1/");
      run_test("expected_output_1.txt");
    }
    protected void run_test(string expected_output) {
      // Essentially runs formatter program directly in test
      //string path = "../../../bin/Release/";
      string[] args = new string[0];
      Formatter.Main(args);

      FileStream expected_data_stream = new FileStream("fixtures/persisted_data_by_position/" + expected_output, FileMode.Open, FileAccess.Read);
      FileStream actual_data_stream = new FileStream("fixtures/persisted_data_by_position/generated_data_by_signal_strength.txt", FileMode.Open, FileAccess.Read);
      PersistedDataBySignalStrength expected = new PersistedDataBySignalStrength(expected_data_stream);
      PersistedDataBySignalStrength actual = new PersistedDataBySignalStrength(actual_data_stream);
      List<Location>[, ,] expected_data = expected.load();
      List<Location>[, ,] actual_data = actual.load();
      expected_data_stream.Close();
      actual_data_stream.Close();
      Specify.That(to_string(actual_data)).ShouldEqual(to_string(expected_data));
    }
    public string to_string(List<Location>[, ,] data)
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
    }
  }
}
