using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FightinZigbees
{
  class Ifstream
  {

    public Ifstream()
    {
      
    }

    public void open(FileStream stream)
    {
      this.stream = stream;
      this.reader = new StreamReader(this.stream);
    }
   
    public bool EOF()
    {
      bool answer = false;
      if(reader.Peek() == -1)
      {
        answer = true;
      }
      else
      {
        answer = false;
      }
      return answer;
    }

    public int read_int()
    {
      string s = read_word();
      return int.Parse(s);
    }

    public char read_char()
    {
      int trash;

      while (char.IsWhiteSpace((char)reader.Peek()))
      {
        trash = reader.Read();
      }
      return (char)reader.Read();
    }

    public string read_word()
    {
      int trash;
      string word = "";
      
      while (char.IsWhiteSpace((char)reader.Peek()))
      {
        trash = reader.Read();
      }

      while (!char.IsWhiteSpace((char)reader.Peek()) && reader.Peek() != -1)
      {
        word += reader.Read();
      }
      return word;
    }

    protected FileStream stream;
    protected StreamReader reader;
  }


}
