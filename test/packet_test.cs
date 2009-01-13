using System;
using System.Collections.Generic;
using System.Text;
using NSpec.Framework;

namespace FightinZigbees
{
  [Context]
  public class PacketTest
  {
    [Specification]
    public void input_lacking_start_delimiter_should_throw_exception()
    {
      MethodThatThrows mtt = delegate()
      {
        byte[] packet = new byte[1];
        FightinZigbees.Packet.parse(packet);
      };

      Specify.ThrownBy(mtt).ShouldBeOfType(typeof(Exception));
    }
  }
}
