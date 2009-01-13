using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FightinZigbees
{
  public partial class DataCollection : Form
  {
    private SignalStrengthReceiver sig_strength_receiver;
    protected string test_data_path;
    protected Xbee xb;

    public DataCollection()
    {
      InitializeComponent();
    }

    private void btn_start_collecting_Click(object sender, EventArgs e)
    {
      xb.open();

      if (xb.get_valid_signal_strengths()[Constant.NUM_NODES] > 0)
      {
        sig_strength_receiver = new RelaySignalStrengthReceiver(xb);
      }
      else
      {
        sig_strength_receiver = new DirectSignalStrengthReceiver(xb);
      }
      
      test_data_path = "../../../formatter/bin/release/data/collected_data/Position_";
      test_data_path += nud_x_coord.Value;
      test_data_path += "_";
      test_data_path += nud_y_coord.Value;
      test_data_path += "_Orientation_";
      test_data_path += lst_orientation.SelectedIndex.ToString();
      test_data_path += ".txt";

      for (int i = 0; i < Constant.NUM_NODES; ++i)
      {
        Control[] nodeLabel = this.Controls.Find("lbl_node_" + (i + 1) + "_status", false);
        nodeLabel[0].Text = "Incomplete";
        nodeLabel[0].ForeColor = Color.Maroon;
      }

      Location loc = new Location((float)nud_x_coord.Value, (float)nud_y_coord.Value);
      uint orientation = (uint)lst_orientation.SelectedIndex;

      //Gets a list of signal strengths.  The indices in this array represent the Node ID in which
      //the signal strengths came.
      List<uint>[] signal_strengths = new List<uint>[Constant.NUM_NODES];
      signal_strengths = sig_strength_receiver.get_signal_strengths(Constant.TIME_SPAN, Constant.MAX_NUM_OF_SIG_STR);
      xb.close();
      for(int i = 0; i < signal_strengths.Length; i++)
      {
        if(signal_strengths[i].Count <= 0)
        {
          string error_message = "Node " + i + " is not broadcasting!";
          throw new Exception(error_message);
        }
      }

      //Opens file to print to.
      FileStream f_out = new FileStream(test_data_path, FileMode.Create, FileAccess.Write);
      //Creates a right with the file stream above.
      StreamWriter s_out = new StreamWriter(f_out);
      //Gives me access to the to_string function
      PersistedDataByPosition  d = new PersistedDataByPosition(null);
      
      //Prints to a file
      //first line's values are counts.
      //(x,y), (numNodes), (numOrientations) for one run
      s_out.WriteLine("1,1 8 1");
      for (uint i = 0; i < Constant.NUM_NODES; i++)
        s_out.WriteLine(d.to_string(loc, i, orientation, signal_strengths[i]));

      lst_orientation.SetSelected((lst_orientation.SelectedIndex + 1) % 4, true);
      if (lst_orientation.SelectedIndex == 0)
      {
        nud_x_coord.Value = (nud_x_coord.Value + 1);
        if (nud_x_coord.Value == 0)
        {
          nud_y_coord.Value = (nud_y_coord.Value + 1);
        }
      }
      s_out.Close();
    }

    private void data_collection_Load(object sender, EventArgs e)
    {
      lst_orientation.SetSelected(0, true);

      xb = new Xbee();
      xb.open();
      xb.enter_api_mode();
      xb.close();
    }

    private void nud_coord_ValueChanged(object sender, EventArgs e)
    {
      NumericUpDown nud = (NumericUpDown)sender;

      int max_val = (nud == nud_y_coord) ? Constant.ROOM_HEIGHT - 1 : Constant.ROOM_WIDTH - 1;

      nud.Value = nud.Value % (max_val + 1);
    }
  }
}