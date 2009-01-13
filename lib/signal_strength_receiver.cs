using System;
using System.Collections.Generic;
using System.Text;

namespace FightinZigbees
{
  public abstract class SignalStrengthReceiver
  {
    protected Xbee xb;

    public SignalStrengthReceiver(Xbee xb)
    {
      this.xb = xb;
    }

    public uint[] get_avg_signal_strength(float time, int max_num_sig_str)
    {
      List<uint>[] l;

      uint[] avg_signal_strengths = new uint[Constant.NUM_NODES];

      l = get_signal_strengths(time, max_num_sig_str);
      uint temp = 0;

      for (int i = 0; i < l.Length; i++)
      {
        for (int j = 0; j < l[i].Count; j++)
        {
          temp += l[i][j];
        }
        if (l[i].Count < 1)
          avg_signal_strengths[i] = 0;
        else
          avg_signal_strengths[i] = temp / (uint)l[i].Count;
        temp = 0;
      }
      return avg_signal_strengths;
    }

    public abstract List<uint>[] get_signal_strengths(float time, int max_num_sig_str);
  }
}
