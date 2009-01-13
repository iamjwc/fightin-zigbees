using System;
using System.Collections.Generic;
using System.Text;
using NSpec.Framework;

namespace FightinZigbees
{
  [Context]
  public class PersistedDataBySignalStrengthTest
  {    
      [Specification]
      public void file_format_test()
      {
        /*(FileStream s9 = new FileStream("fixtures/persisted_text_file/file_format.txt", FileMode.Open, FileAccess.Read);
        IPersistedData p9 = new PersistedDataBySignalStrength(s9);

        Location[, ,][] expected_loc;
        Location[, ,][] actual_loc;

        expected_loc = new Location[1, 1, 1][];
        expected_loc[0, 0, 0] = new Location[2];
        expected_loc[0, 0, 0][0] = new Location(1, 1);
        expected_loc[0, 0, 0][1] = new Location(1, 2);

        actual_loc = p9.load();

        Specify.That(actual_loc[0, 0, 0][0]).ShouldEqual(expected_loc[0, 0, 0][0]);
        Specify.That(actual_loc[0, 0, 0][1]).ShouldEqual(expected_loc[0, 0, 0][1]);*/
    }
  }
}
