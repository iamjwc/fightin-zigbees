//This program requires input from the command prompt
//This includes y or n to tell if you know the orientation
//Then North/South/East/West depending on which orientation is
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Ports;

namespace FightinZigbees
{
  class PositionProb
  {
    static void Main(string[] args)
    {
      Boolean display_north = false;
      Boolean display_east = false;
      Boolean display_south = false;
      Boolean display_west = false;

      PersistedDataBySignalStrength d = new PersistedDataBySignalStrength
        (new FileStream("resources/generated_data_by_signal_strength.txt", FileMode.Open, FileAccess.Read));
      ILocations loc = new ArrayBasedLocations(d.load());
      List<Location> locations = new List<Location>();
      List<Location> l = new List<Location>();

      string orientation = "";
      int diameter = -1;
      if(args.Length == 2)
      {
        orientation = args[0];
        try
        {
          diameter = Convert.ToInt32(args[1]);
        }
        catch
        {
          Console.WriteLine(program_usage("A valid cluster radius was not entered."));
          return;
        }
      }
      else
      {
        Console.WriteLine(program_usage("Incorrect number of arguments specified."));
        return;
      }

      // Determine Orientation
        if      (orientation == "North"   || orientation == "north")
          display_north = true;
        else if (orientation == "South"   || orientation == "south")
          display_south = true;
        else if (orientation == "East"    || orientation == "east")
          display_east  = true;
        else if (orientation == "West"    || orientation == "west")
          display_west  = true;
        else if (orientation == "Unknown" || orientation == "unknown") 
        {
          display_north = true;
          display_east  = true;
          display_south = true;
          display_west  = true;
        }
        else
        {
          Console.WriteLine(program_usage("A valid orientation was not entered."));
          return;
        }

      if (!Constant.TESTING)  //Can turn on/off real code and test code
      {
        Xbee xb = new Xbee();
        xb.open();
        xb.enter_api_mode();

        SignalStrengthReceiver receiver;
        if (xb.get_valid_signal_strengths()[Constant.NUM_NODES] > 0)
        {
          receiver = new RelaySignalStrengthReceiver(xb);
        }
        else
        {
          receiver = new DirectSignalStrengthReceiver(xb);
        }

        uint[] avg_signals = new uint[8];

        avg_signals = receiver.get_avg_signal_strength(2, 200);

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
        //Test Code
        if (display_north)
        {
          l.AddRange(loc.get_locations(0, Orientation.North, 55));
          l.AddRange(loc.get_locations(1, Orientation.North, 55));
          l.AddRange(loc.get_locations(2, Orientation.North, 55));
          l.AddRange(loc.get_locations(3, Orientation.North, 55));
        }
        if (display_south)
        {
          l.AddRange(loc.get_locations(0, Orientation.South, 60));
          l.AddRange(loc.get_locations(1, Orientation.South, 60));
          l.AddRange(loc.get_locations(2, Orientation.South, 60));
          l.AddRange(loc.get_locations(3, Orientation.South, 60));
        }
        if (display_east)
        {
          l.AddRange(loc.get_locations(0, Orientation.East, 71));
          l.AddRange(loc.get_locations(1, Orientation.East, 71));
          l.AddRange(loc.get_locations(2, Orientation.East, 71));
          l.AddRange(loc.get_locations(3, Orientation.East, 71));
        }
        if (display_west)
        {
          l.AddRange(loc.get_locations(0, Orientation.West, 59));
          l.AddRange(loc.get_locations(1, Orientation.West, 59));
          l.AddRange(loc.get_locations(2, Orientation.West, 59));
          l.AddRange(loc.get_locations(3, Orientation.West, 59));
        }
      }

      l.Sort();
      locations = l;

      List<Cluster> clusters = Clusterer.cluster(locations, diameter);
      List<PositionWithProb> loc_probs = new List<PositionWithProb>();
      for (int i = 0; i < clusters.Count; i++)
      {
        loc_probs.Add(new PositionWithProb(clusters[i].location, clusters[i].probability));
      }
      PositionWithProbComparer compaerer = new PositionWithProbComparer();
      loc_probs.Sort(compaerer);

      Console.WriteLine();
      Console.WriteLine("{0} {1, 16}", "Position", "Probability");
      Console.WriteLine("{0} {1, 13}", "-----------", "-----------");
      Console.WriteLine("{0, 4} {1, 5}", "X", "Y");
      for (int i = 0; i < clusters.Count; i++)
      {
        Console.WriteLine("{0, 4:0.00}, {1, 5:0.00}: {2, 9:0.000}%", loc_probs[i].location.x,
          loc_probs[i].location.y, loc_probs[i].probability * 100);
      }
    }

    static string program_usage(string error_type)
    {
      return "\n"
           + "** " + error_type + "\n"
           + "   Correct program usage is displayed below. ** \n"
           + "\n"
           + "Usage: \n"
           + "  Program Name             Orientation                     Cluster Radius \n"
           + "  position_probability.exe [North|East|South|West|Unknown] [0, 1, ... , N]\n"
           + "\n"
           + "E.g. : \n"
           + "  C:\\> position_probability.exe North 1 \n";       
    }
  }
}

