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
  public partial class UI : Form
  {
    protected List<Cluster> clusters;
    protected List<Location> locations;
    protected ArrayBasedLocations loc;
    protected Room room;
    protected Xbee xb;
    protected Boolean display_north;
    protected Boolean display_east;
    protected Boolean display_south;
    protected Boolean display_west;

    public UI()
    {
      InitializeComponent();
      if (!Constant.TESTING)
      {
        xb = new Xbee();
        xb.open();
        xb.enter_api_mode();
      }

      //Initiates C# built-in double buffering 
      this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
      
      this.Invalidate();
      PersistedDataBySignalStrength d = new PersistedDataBySignalStrength(new FileStream("resources/generated_data_by_signal_strength.txt", FileMode.Open, FileAccess.Read));
      loc = new ArrayBasedLocations(d.load());

      panel1.Visible = false;

      this.room = new BasicRoom();
      this.room.location = new Point(panel1.Location.X, panel1.Location.Y);
      room.size = new Size(panel1.Size.Width, panel1.Size.Height);

      // Initialized displayed orientations
      display_north = true;
      display_east = true;
      display_south = true;
      display_west = true;

      generate_new_location_list_from_signal_strength();
      sld_cluster_radius.set_range(0, 6);
      sld_cluster_radius.value = 1;
      this.clusters = Clusterer.cluster(this.locations, (float)sld_cluster_radius.value);
      sld_num_clusters.set_range(1, clusters.Count);
      sld_num_clusters.value = sld_num_clusters.Maximum;
      lbl_cluster_radius.Text = sld_cluster_radius.value.ToString();
      lbl_num_clusters.Text = sld_num_clusters.value.ToString();

      // Initialize renderer type
      this.room.set_renderer_type(Constant.HEAT_MAP_RENDERER);      
    }

    private void UI_Paint(object sender, PaintEventArgs e)
    {
      room.draw(e.Graphics);
    }

    private void UI_Resize(object sender, EventArgs e)
    {
      room.size = new Size(panel1.Size.Width, panel1.Size.Height);
      room.grid.force_rerender();
      this.Invalidate();
    }

    private void redraw() 
    {
      room.grid.force_rerender();
      this.Invalidate();
    }

    private void calculate_clusters()
    {
      int cluster_radius = this.sld_cluster_radius.value;

      this.clusters = Clusterer.cluster(this.locations, (float)cluster_radius);
      this.sld_num_clusters.set_range(this.sld_num_clusters.Minimum, clusters.Count);
      lbl_num_clusters.Text = sld_num_clusters.value.ToString();
        
      update_num_clusters_to_be_rendered();
    }
    private void update_num_clusters_to_be_rendered() {
      ClusterProbabilityComparer comp = new ClusterProbabilityComparer();
      clusters.Sort(comp);
      room.grid.clear_clusters();
      int num_clusters = this.sld_num_clusters.value;
      for(int i = 0; i < num_clusters; ++i)
      {
        room.grid.add_cluster(clusters[i]);
      }
    }

    private void generate_new_location_list_from_signal_strength()
    {
      SignalStrengthReceiver receiver;
      uint[] avg_signals = new uint[Constant.NUM_NODES];
      List<Location> l = new List<Location>();

      if (!Constant.TESTING)
      {
        if (xb.get_valid_signal_strengths()[Constant.NUM_NODES] > 0)
        {
          receiver = new RelaySignalStrengthReceiver(xb);
        }
        else
        {
          receiver = new DirectSignalStrengthReceiver(xb);
        }

        //Real Code commented out for testing
        avg_signals = receiver.get_avg_signal_strength(2, 200);
        
        for (int i = 0; i < Constant.NUM_NODES; i++)
        {
          if (avg_signals[i] == 0)
            room.broadcast_xbees[i].working = false;
          else
            room.broadcast_xbees[i].working = true;
          room.grid.add_broadcast_node(room.broadcast_xbees[i]);
        }
      
        if (display_north)
        {
          for (int i = 0; i < avg_signals.Length; i++)
            l.AddRange(loc.get_locations(i, Orientation.North, avg_signals[i]));
        }
        if (display_south)
        {
          for (int i = 0; i < avg_signals.Length; i++)
            l.AddRange(loc.get_locations(i, Orientation.South, avg_signals[i]));
        }
        if (display_east)
        {
          for (int i = 0; i < avg_signals.Length; i++)
            l.AddRange(loc.get_locations(i, Orientation.East, avg_signals[i]));
        }
        if (display_west)
        {
          for (int i = 0; i < avg_signals.Length; i++)
            l.AddRange(loc.get_locations(i, Orientation.West, avg_signals[i]));
        }
      }
      else
      {
        //Testing Data
        if (display_north)
        {
          l.AddRange(loc.get_locations(0, Orientation.North, (uint)numericUpDown1.Value));
          l.AddRange(loc.get_locations(1, Orientation.North, (uint)numericUpDown2.Value));
          l.AddRange(loc.get_locations(2, Orientation.North, (uint)numericUpDown3.Value));
          l.AddRange(loc.get_locations(3, Orientation.North, (uint)numericUpDown4.Value));
        }
        if (display_south)
        {
          l.AddRange(loc.get_locations(0, Orientation.South, (uint)numericUpDown1.Value));
          l.AddRange(loc.get_locations(1, Orientation.South, (uint)numericUpDown2.Value));
          l.AddRange(loc.get_locations(2, Orientation.South, (uint)numericUpDown3.Value));
          l.AddRange(loc.get_locations(3, Orientation.South, (uint)numericUpDown4.Value));
        }
        if (display_east)
        {
          l.AddRange(loc.get_locations(0, Orientation.East, (uint)numericUpDown1.Value));
          l.AddRange(loc.get_locations(1, Orientation.East, (uint)numericUpDown2.Value));
          l.AddRange(loc.get_locations(2, Orientation.East, (uint)numericUpDown3.Value));
          l.AddRange(loc.get_locations(3, Orientation.East, (uint)numericUpDown4.Value));
        }
        if (display_west)
        {
          l.AddRange(loc.get_locations(0, Orientation.West, (uint)numericUpDown1.Value));
          l.AddRange(loc.get_locations(1, Orientation.West, (uint)numericUpDown2.Value));
          l.AddRange(loc.get_locations(2, Orientation.West, (uint)numericUpDown3.Value));
          l.AddRange(loc.get_locations(3, Orientation.West, (uint)numericUpDown4.Value));
        }
      }
      l.Sort();

      this.locations = l;
    }

    private void UI_MouseMove(object sender, MouseEventArgs e)
    {
      this.room.grid.hover(e.Location);
      this.Invalidate();
    }

    private void renderer_type_changed(object sender, EventArgs e)
    {
      if (sender == rad_convex_hull)
      {
        room.set_renderer_type(Constant.CONVEX_HULL_RENDERER);
      }
      else if (sender == rad_heat_map)
      {
        room.set_renderer_type(Constant.HEAT_MAP_RENDERER);
      }
      redraw();
    }

    private void slider_scrolled(object sender, EventArgs e)
    {
      if (sender == sld_num_clusters)
      {
        lbl_num_clusters.Text = sld_num_clusters.value.ToString();
        update_num_clusters_to_be_rendered();
      }
      else if (sender == sld_cluster_radius)
      {
        lbl_cluster_radius.Text = sld_cluster_radius.value.ToString();
        calculate_clusters();
      }
      redraw();
    }

    private void slider_scrolling(object sender, EventArgs e)
    {
      if (sender == sld_num_clusters)
      {
        lbl_num_clusters.Text = sld_num_clusters.value.ToString();
      }
      else if (sender == sld_cluster_radius)
      {
        lbl_cluster_radius.Text = sld_cluster_radius.value.ToString();
      }
    }

    private void locate_object_button_click(object sender, EventArgs e)
    {
      generate_new_location_list_from_signal_strength();
      calculate_clusters();
      redraw();
    }

    private void orientation_changed(object sender, EventArgs e)
    {
      if (sender == rad_north_orientation)
      {
        display_east = display_south = display_west = false;
        display_north = true;
      }
      else if (sender == rad_east_orientation)
      {
        display_north = display_south = display_west = false;
        display_east = true;
      }
      else if (sender == rad_south_orientation)
      {
        display_north = display_east = display_west = false;
        display_south = true;
      }
      else if (sender == rad_west_orientation)
      {
        display_north = display_east = display_south = false;
        display_west = true;
      }
      else if (sender == rad_unknown_orientation)
      {
        display_north = display_east = display_south = display_west = true;
      }
      if (((RadioButton)sender).Checked)
      {
        generate_new_location_list_from_signal_strength();
        calculate_clusters();
        redraw();
      }
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
      SignalStrengthReceiver receiver = new DirectSignalStrengthReceiver(xb);
      uint[] avg_signals = new uint[Constant.NUM_NODES];
      if (!Constant.TESTING)
      {
        avg_signals = receiver.get_avg_signal_strength(.5f, 20);
      }

      for (int i = 0; i < Constant.NUM_NODES; i++)
      {
        if (avg_signals[i] == 0)
          room.broadcast_xbees[i].working = false;
        else
          room.broadcast_xbees[i].working = true;
        room.grid.add_broadcast_node(room.broadcast_xbees[i]);
      }
      
      if (chk_broadcast_xbs.Checked)
        room.grid.display_broadcast_nodes = true;
      else
        room.grid.display_broadcast_nodes = false;
      redraw();
    }
  }
}