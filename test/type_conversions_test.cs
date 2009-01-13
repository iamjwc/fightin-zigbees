using System;
using System.Collections.Generic;
using System.Text;
using NSpec.Framework;

namespace FightinZigbees
{
  [Context]
  public class TypeConversionsTest
  {
    [Specification]
    public void bytes_to_uint()
    {
      for (uint i = 0; i <= 0xFF; ++i)
        Specify.That(TypeConversions.bytes_to_uint(0x00, (byte)i)).ShouldEqual(i);

      for (uint i = 0, j = 0; i <= 0xFF00; i += 0x0100, j += 1)
        Specify.That(TypeConversions.bytes_to_uint((byte)j, 0x00)).ShouldEqual(i);
    }
  }
}
