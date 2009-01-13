using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using NSpec.Framework;

namespace FightinZigbees
{
  [Context]
  public class InputStreamParserTest
  {

    [Specification]
    public void read_one_word_space_delimited()
    {
      Stream s = new FileStream("fixtures/input_stream_parser/uint_space_delimited.txt", FileMode.Open, FileAccess.Read);
      InputStreamParser p = new InputStreamParser(s);

      for (uint i = 0; i < 10; ++i)
      {
        Specify.That(p.read_uint()).ShouldEqual(i);
      }
        
      Specify.That(p.is_eof()).ShouldBeTrue();
    }

    [Specification]
    public void reads_large_uints()
    {
      Stream s2 = new FileStream("fixtures/input_stream_parser/large_uint.txt", FileMode.Open, FileAccess.Read);
      InputStreamParser p2 = new InputStreamParser(s2);

      for (uint i = 1; i <= 10000000; i *= 10)
      {
        Specify.That(p2.read_uint()).ShouldEqual(i);
      }
    }

    [Specification]
    public void ensures_read_uint_does_not_read_chars()
    {

      MethodThatThrows mtt = delegate()
      {
        Stream s3 = new FileStream("fixtures/input_stream_parser/no_uint.txt", FileMode.Open, FileAccess.Read);
        InputStreamParser p3 = new InputStreamParser(s3);

        p3.read_uint();
      };

      Specify.ThrownBy(mtt).ShouldBeOfType(typeof(FormatException));
    }

    [Specification]
    public void reads_uint_line_delimited()
    {
      Stream s4 = new FileStream("fixtures/input_stream_parser/uint_line_delimited.txt", FileMode.Open, FileAccess.Read);
      InputStreamParser p4 = new InputStreamParser(s4);

      for (uint i = 0; i < 10; ++i)
      {
        Specify.That(p4.read_uint()).ShouldEqual(i);
      }
    }

    [Specification]
    public void reads_one_word_with_less_and_greater_signs_around_it()
    {
      Stream s5 = new FileStream("fixtures/input_stream_parser/word_test1.txt", FileMode.Open, FileAccess.Read);
      InputStreamParser p5 = new InputStreamParser(s5);
      Specify.That(p5.read_word()).ShouldEqual("<Hello>");
    }

    [Specification]
    public void reads_one_word_with_square_brackets_around_it()
    {

      Stream s6 = new FileStream("fixtures/input_stream_parser/word_test2.txt", FileMode.Open, FileAccess.Read);
      InputStreamParser p6 = new InputStreamParser(s6);
      Specify.That(p6.read_word()).ShouldEqual("[World!]");
    }

    [Specification]
    public void reads_two_words_space_delimited()
    {

      Stream s7 = new FileStream("fixtures/input_stream_parser/word_test3.txt", FileMode.Open, FileAccess.Read);
      InputStreamParser p7 = new InputStreamParser(s7);
      for (int i = 0; i < 2; i++)
      {
        if(i == 0)
          Specify.That(p7.read_word()).ShouldEqual("Hello");
        else
          Specify.That(p7.read_word()).ShouldEqual("World!");
      }
    }

    [Specification]
    public void reads_two_words_line_delimited()
    {

      Stream s8 = new FileStream("fixtures/input_stream_parser/word_test4.txt", FileMode.Open, FileAccess.Read);
      InputStreamParser p8 = new InputStreamParser(s8);
      for (int i = 0; i < 2; i++)
      {
        if (i == 0)
          Specify.That(p8.read_word()).ShouldEqual("Hello");
        else
          Specify.That(p8.read_word()).ShouldEqual("World!");
      }  
    }
  }
}
