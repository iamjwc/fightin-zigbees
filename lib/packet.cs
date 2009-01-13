using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;

namespace FightinZigbees
{
  public class Packet
  {
    protected byte api_identifier, signal_strength, options, checksum;
    protected byte[] message;
    protected uint address, message_length;

    const byte START_DELIMITER = 0x7E;

    public static Packet parse(byte[] p)
    {
      if (START_DELIMITER != p[0])
        throw new Exception("Start Delimiter Not Found.");

      Packet packet = new Packet();
      // We subtract 5 from the total length
      // to get the message length.
      packet.message_length = TypeConversions.bytes_to_uint(p[1], p[2]) - 5;

      packet.api_identifier = p[3];
      packet.address = TypeConversions.bytes_to_uint(p[4], p[5]);
      packet.signal_strength = p[6];
      packet.options = p[7];
      
      packet.message = new byte[packet.message_length];
      for (int i = 0; i < packet.message_length; ++i)
      {
        packet.message[i] = p[i + 8];
      }
      
      packet.checksum = p[packet.message_length + 8];

      return packet;
    }
    
    public byte get_api_identifier(){ return this.api_identifier; }
    public byte get_signal_strength(){ return this.signal_strength; }
    public byte get_options() { return this.options; }
    public byte get_checksum() { return this.checksum; }
    public uint get_message_length() { return this.message_length; }
    public uint get_address() { return this.address; }
    public byte[] get_message(){ return this.message; }
    public uint get_relay_address()
    {
      if (message_length <= 1)
        throw new Exception("No message was received");
      return TypeConversions.bytes_to_uint(this.message[0], this.message[1]);
    }
    public byte get_relay_signal_strength()
    {
      if (message_length <= 1)
        throw new Exception("No message was received");
      return this.message[3];
    }
  }
}