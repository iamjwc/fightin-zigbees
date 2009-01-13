using System;
using System.Collections.Generic;
using System.Text;

namespace FightinZigbees
{
  public class MinMaxSignalStrength
  {
    public MinMax calculate_min_max_signal_strength(List<uint> signal_strengths)
    {
      MinMax min_max = new MinMax(0, 0);
      if (signal_strengths == null || signal_strengths.Count == 0)
      {
        min_max.min = Constant.MAX_SIG_STR;
        return min_max;
      }
      int min, max;
      uint num_signal_strengths = (uint)signal_strengths.Count;
      uint sum = sum_uint_list(signal_strengths);
      double average = divide(sum, num_signal_strengths);
      double standard_deviation = std_dev(average, signal_strengths);
      min = (int)Math.Round(average - standard_deviation);
      max = (int)Math.Round(average + standard_deviation);
      if (max > Constant.MAX_SIG_STR)
      {
        min_max.max = Constant.MAX_SIG_STR;
      }
      else
      {
        min_max.max = (uint)max;
      }
      if (min < Constant.MIN_SIG_STR)
      {
        min_max.min = Constant.MIN_SIG_STR;
      }
      else
      {
        min_max.min = (uint)min;
      }

      return min_max;
    }

    public uint sum_uint_list(List<uint> signal_strengths)
    {
      uint sum = 0;
      if (signal_strengths == null)
      {
        return 0;
      }
      for (int i = 0; i < signal_strengths.Count; ++i)
      {
        if (signal_strengths[i] < 0)
        {
          throw (new Exception("Negative Signal Strength in Data!"));
        }
        sum += signal_strengths[i];
      }
      return sum;
    }

    public double divide(double sum, uint num_values)
    {
      if (num_values < 0)
      {
        throw (new Exception("Divide by Zero!"));
      }
      return sum / num_values;
    }

    public double std_dev(double average, List<uint> values)
    {
      double total_variance = 0;
      if (values == null)
      {
        return 0;
      }
      uint num_values = (uint)values.Count;
      for (int i = 0; i < num_values; ++i)
      {
        total_variance += Math.Pow(values[i] - average, 2);
      }
      return Math.Sqrt(divide(total_variance, num_values));
    }
  }

  public class MinMax
  {
    public uint min, max;
    public MinMax(uint min, uint max)
    {
      this.min = min;
      this.max = max;
    }
    public override string ToString()
    {
      return this.min + "," + this.max;
    }
  }
}
