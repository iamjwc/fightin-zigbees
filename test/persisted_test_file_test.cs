using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using NSpec.Framework;

namespace FightinZigbees
{
  [Context]
  class PersistedTestFileTest
  {
    [Specification]
    public void file_format_test()
    {
      FileStream s9 = new FileStream("fixtures/persisted_text_file/file_format.txt", FileMode.Open, FileAccess.Read);
      PersistedDataBySignalStrength p9 = new PersistedDataBySignalStrength(s9);

      List<Location>[, ,] expected_loc;
      List<Location>[, ,] actual_loc;

      expected_loc = new List<Location>[1, 1, 1];
      expected_loc[0, 0, 0] = new List<Location>();
      expected_loc[0, 0, 0].Add(new Location(1, 1));
      expected_loc[0, 0, 0].Add(new Location(1, 2));

      actual_loc = p9.load();

      Specify.That(actual_loc[0, 0, 0][0]).ShouldEqual(expected_loc[0, 0, 0][0]);
      Specify.That(actual_loc[0, 0, 0][1]).ShouldEqual(expected_loc[0, 0, 0][1]);
    }
  }
}
