using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FightinZigbees
{
  public class InputStreamParser
  {

    public InputStreamParser(Stream stream)
    {
      this.stream = stream;
      this.reader = new StreamReader(this.stream);
    }

    public bool is_eof()
    {
      return reader.Peek() == -1;
    }

    /// <summary>
    /// Throws Formatting Exception if you try to
    /// read something that is not a digit
    /// </summary>
    /// <returns></returns>
    public uint read_uint()
    {
      StringBuilder s = new StringBuilder();

      trash_white_space();
      while (char.IsDigit((char)reader.Peek()))
        s.Append((char)reader.Read());

      return uint.Parse(s.ToString());
    }

    public char read_char()
    {
      trash_white_space();
      return (char)reader.Read();
    }

    protected void trash_white_space()
    {
      while (char.IsWhiteSpace((char)reader.Peek()))
        reader.Read();
    }

    public string read_word()
    {
      StringBuilder word = new StringBuilder();

      trash_white_space();

      while (!char.IsWhiteSpace((char)reader.Peek()) && !this.is_eof())
        word.Append((char)reader.Read());

      return word.ToString();
    }

    protected Stream stream;
    protected StreamReader reader;
  }


}
