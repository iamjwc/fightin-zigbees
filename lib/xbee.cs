using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;

namespace FightinZigbees
{
  public class Xbee
  {
    protected SerialPort s;

    string[]   com_ports;
    string     com_port;
    const int  COM_BAUD = 38400;
    
    public Xbee()
    {
      int cnt = 0;
      com_ports = SerialPort.GetPortNames();
      if (com_ports.Length <= 0)
        throw new Exception("No device is connected");

      com_port = com_ports[cnt];
      //I don't think this is the right thing to do, but it is a start
      while (com_port.CompareTo("COM3") < 0)
      {
        if (cnt >= com_ports.Length)
          throw new Exception("No device is connected");
        cnt++;
        com_port = com_ports[cnt];
      }
      this.s = new SerialPort(com_port, COM_BAUD, Parity.None, 8);
    }

    private void SerialDataReceivedEventHandler(object sender, SerialDataReceivedEventArgs e)
    {
      SerialPort s = (SerialPort)sender;
    }

    public void enter_api_mode()
    {
      System.Threading.Thread.Sleep(1100);
      this.s.Write("+++");
      System.Threading.Thread.Sleep(1100);

      this.s.Write("ATAP1\r");
      this.s.Write("ATAC\r");
      this.s.Write("ATCN\r");
    }

    public void open(){ this.s.Open(); }
    public void close(){ this.s.Close(); }

    public Packet read_packet()
    {
      byte[] b = new byte[3];
      uint length;

      do 
      {
        b[0] = read_byte();
      } while(b[0] != 0x7E);

      b[1] = read_byte();
      b[2] = read_byte();
      length = TypeConversions.bytes_to_uint(b[1], b[2]);

      byte[] packet = new byte[length + 5];
      b.CopyTo(packet, 0);

      for (int i = 0; i < length; i++)
      {
        packet[i + 3] = read_byte();
      }
      packet[length + 4] = read_byte();

      return Packet.parse(packet);
    }

    public int[] get_valid_signal_strengths()
    {
      //All this initial stuff just checks to see if they are using
      //a relay Zigbee or not.
      int[] valid_signals = new int[Constant.NUM_NODES + 1];
      for (int i = 0; i < 100; i++)
      {
        Packet packet = this.read_packet();
        uint address = packet.get_address();
        if ((address >= Constant.NODE_1_ADDR) && (address <= Constant.NODE_7_ADDR))
        {
          valid_signals[address % Constant.NODE_1_ADDR]++;
        }
      }
      return valid_signals;
    }

    protected byte read_byte()
    {
      byte[] b = new byte[1];
      this.s.Read(b, 0, 1);
      return b[0];
    }
  }
}
