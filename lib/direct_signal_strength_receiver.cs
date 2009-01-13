using System;
using System.Collections.Generic;
using System.Text;

namespace FightinZigbees
{
  public class DirectSignalStrengthReceiver : SignalStrengthReceiver
  {
    public DirectSignalStrengthReceiver(Xbee xb) : base(xb){}

    public override List<uint>[] get_signal_strengths(float time, int max_num_sig_str)
    {
      DateTime start_time = DateTime.Now;
      TimeSpan duration;
      List<uint>[] signal_strengths = new List<uint>[Constant.NUM_NODES];
      int doneCnt = 0;

      for (int i = 0; i < Constant.NUM_NODES; i++)
      {
        signal_strengths[i] = new List<uint>();
      }

      do
      {
        doneCnt = 0;
        Packet packet = xb.read_packet();
        uint address = packet.get_address();
        byte sig_str = packet.get_signal_strength();

        //Ensures that the received address and signal strength is in bounds.
        if ((address >= Constant.NODE_1_ADDR && address <= Constant.NODE_7_ADDR) &&
            (sig_str >= Constant.MIN_SIG_STR && sig_str <= Constant.MAX_SIG_STR))
        {
          uint nodeIndex = packet.get_address() % Constant.NODE_1_ADDR;

          if (signal_strengths[nodeIndex].Count < Constant.MAX_NUM_OF_SIG_STR)
          {
            signal_strengths[nodeIndex].Add(packet.get_signal_strength());
          }
        }
        DateTime finish_time = DateTime.Now;
        duration = finish_time - start_time;

        for(int i = 0; i < Constant.NUM_NODES; i++)
        {
          if(signal_strengths[i].Count >= 100)
          {
            doneCnt++;
          }
        }

      } while(duration.TotalSeconds < time && doneCnt < Constant.NUM_NODES);

      return signal_strengths;
    }
  }
}
