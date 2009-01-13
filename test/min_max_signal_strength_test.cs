using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using NSpec.Framework;

namespace FightinZigbees
{
  [Context]
  public class MinMaxSignalStrengthTest
  {
    [Specification]
    public void min_max_test() 
    {
      uint[] test_values_1 = { 15, 64, 19, 7, 0, 75, 73, 97, 41, 17 }; // 9,73
      uint[] test_values_2 = { 33, 6, 97, 24, 81, 85, 53, 49, 34, 100, 95, 23, 47, 31, 14, 57, 94, 17, 82, 7, 37, 64, 4, 83, 52 }; //20,82
      uint[] test_values_3 = { 0, 100 }; // 0,100
      uint[] test_values_4 = { }; // CONST.MAX_SIG_STR,0
      uint[] test_values_5 = { 5, 5, 5}; // 5,5
      uint[] test_values_6 = { 0, 100, 100, 100, 100 }; // 40,100
      uint[] test_values_7 = { 0, 0, 0, 0, 100 }; // 0,60

      List<uint> test_values = new List<uint>();
      MinMaxSignalStrength min_max = new MinMaxSignalStrength();

      test_values.AddRange(test_values_1);
      MinMax expected_min_max = new MinMax(9,73);
      MinMax actual_min_max = min_max.calculate_min_max_signal_strength(test_values) ;
      Specify.That(actual_min_max.ToString()).ShouldEqual(expected_min_max.ToString());

      test_values.Clear();
      test_values.AddRange(test_values_2);
      expected_min_max.min = 20;
      expected_min_max.max = 82;
      actual_min_max = min_max.calculate_min_max_signal_strength(test_values);
      Specify.That(actual_min_max.ToString()).ShouldEqual(expected_min_max.ToString());

      test_values.Clear();
      test_values.AddRange(test_values_3);
      expected_min_max.min = 0;
      expected_min_max.max = 100;
      actual_min_max = min_max.calculate_min_max_signal_strength(test_values);
      Specify.That(actual_min_max.ToString()).ShouldEqual(expected_min_max.ToString());

      test_values.Clear();
      test_values.AddRange(test_values_4);
      expected_min_max.min = Constant.MAX_SIG_STR;
      expected_min_max.max = 0;
      actual_min_max = min_max.calculate_min_max_signal_strength(test_values);
      Specify.That(actual_min_max.ToString()).ShouldEqual(expected_min_max.ToString());

      test_values.Clear();
      test_values.AddRange(test_values_5);
      expected_min_max.min = 5;
      expected_min_max.max = 5;
      actual_min_max = min_max.calculate_min_max_signal_strength(test_values);
      Specify.That(actual_min_max.ToString()).ShouldEqual(expected_min_max.ToString());

      test_values.Clear();
      test_values.AddRange(test_values_6);
      expected_min_max.min = 40;
      expected_min_max.max = 100;
      actual_min_max = min_max.calculate_min_max_signal_strength(test_values);
      Specify.That(actual_min_max.ToString()).ShouldEqual(expected_min_max.ToString());

      test_values.Clear();
      test_values.AddRange(test_values_7);
      expected_min_max.min = 0;
      expected_min_max.max = 60;
      actual_min_max = min_max.calculate_min_max_signal_strength(test_values);
      Specify.That(actual_min_max.ToString()).ShouldEqual(expected_min_max.ToString());

    }
  }
}
