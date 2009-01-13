using System;
using System.Collections.Generic;
using System.Text;

namespace FightinZigbees
{
  public class TypeConversions
  {
    public static uint bytes_to_uint(byte msb, byte lsb)
    {
      return ((uint)msb << 8) + (uint)lsb;
    }
  }
}
