using System;
using System.Collections.Generic;
using System.Text;


namespace FightinZigbees
{
  public class TrainingSignalStrengths
  {

    protected float standDev;
    protected int[] sigStr;
    protected float avg;
    protected int array_size_cnt;
    protected Location loc;
    protected Orientation orientation;
    protected int node_id;

    public TrainingSignalStrengths(int new_node_id, Location new_loc, Orientation new_orientation)
    {
      loc = new_loc;
      orientation = new_orientation;
      node_id = new_node_id;

      standDev = 0;
      sigStr = new int[0];
      array_size_cnt = 0;
    }

    public void add_sig_str(int newSigStr)
    {
      array_size_cnt++;
      sigStr = new int[array_size_cnt];
      sigStr[array_size_cnt] = newSigStr;
    }

    public void finalize_data()
    {
      avg_sig_strs();
      calc_stand_dev();
    }

    protected void avg_sig_strs()
    {
      for (int i = 0; i < array_size_cnt; i++)
      {
        avg += sigStr[i];
      }
      avg = avg / array_size_cnt;
    }

    protected void calc_stand_dev()
    {
      float SumOfSqrs = 0;

      for (int i = 0; i < array_size_cnt; i++)
      {
        SumOfSqrs += (float)Math.Pow((sigStr[i]- avg), 2);
      }
      standDev = (float)Math.Sqrt(SumOfSqrs / (array_size_cnt - 1));
    }

    public Location get_loc(){return loc;}
    public Orientation get_orienation(){return orientation;}
    public int get_node_id(){return node_id;}
    public int getSigCnt(){return array_size_cnt;}
  }
}
