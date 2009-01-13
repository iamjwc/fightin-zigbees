using System;
using System.Collections.Generic;
using System.Text;
using NSpec.Framework;

namespace FightinZigbees
{
  [Context]
  public class LocationTest
  {
    [Specification]
    public void simple_fourty_five_degree_spec()
    {
      Location l0 = new Location(0, 0);
      Location l1 = new Location(5, 0);
      Location l2 = new Location(5, 5);
      float angle = l0.angle_between(l1, l2);
      Specify.That(Math.Round(angle, 5)).ShouldEqual(Math.Round(Math.PI / 4, 5));
    }

    [Specification]
    public void ninety_degree_from_origin_spec()
    {
      Location l0 = new Location(0, 0);
      Location quadrant2 = new Location(-5, 5);
      Location quadrant1 = new Location(5, 5);
      float angle = l0.angle_between(quadrant1, quadrant2);

      Specify.That(Math.Round(angle, 5)).ShouldEqual(Math.Round(Math.PI / 2, 5));
    }

    [Specification]
    public void one_hundered_and_eighty_degree_from_origin_spec()
    {
      Location l0 = new Location(0, 0);
      Location l1 = new Location(5, 0);
      Location l2 = new Location(-5, 0);
      float angle = l0.angle_between(l1, l2); 

      Specify.That(Math.Round(angle, 5)).ShouldEqual(Math.Round(Math.PI, 5));
    }

    [Specification]
    public void two_angles_per_quadrant_test()
    {
      Location l0 = new Location(0, 0);
      Location quadrant1 = new Location(1, 0);
      Location loc;

      loc = new Location(-2, -1);
      Specify.That(Math.Round(l0.angle_between(quadrant1, loc), 5)).ShouldEqual(3.60524);

      loc = new Location(-1, -2);
      Specify.That(Math.Round(l0.angle_between(quadrant1, loc), 5)).ShouldEqual(4.24874);

      loc = new Location(1, -2);
      Specify.That(Math.Round(l0.angle_between(quadrant1, loc), 5)).ShouldEqual(5.17604);

      loc = new Location(2, -1);
      Specify.That(Math.Round(l0.angle_between(quadrant1, loc), 5)).ShouldEqual(5.81954);
    }

    [Specification]
    public void two_hundred_and_twenth_five_degree_from_origin_spec()
    {
      Location l0 = new Location(0, 0);
      Location quadrant2 = new Location(-5, 5);
      Location quadrant1 = new Location(5, 0);
      float angle = l0.angle_between(quadrant2, quadrant1);

      Specify.That(Math.Round(angle, 5)).ShouldEqual(Math.Round((5 * Math.PI) / 4, 5));
    }

    [Specification]
    public void two_hundred_and_seventy_degree_from_origin_spec()
    {
      Location l0 = new Location(0, 0);
      Location quadrant2 = new Location(-5, 5);
      Location quadrant1 = new Location(5, 5);
      float angle = l0.angle_between(quadrant2, quadrant1);

      Specify.That(Math.Round(angle, 5)).ShouldEqual(Math.Round((3 * Math.PI) / 2, 5));
    }

    [Specification]
    public void two_hundred_and_seventy_degree_spec()
    {
      Location l0 = new Location(10, 10);
      Location l1 = new Location(5, 15);
      Location l2 = new Location(15, 15);
      float angle = l0.angle_between(l1, l2);

      Specify.That(Math.Round(angle, 5)).ShouldEqual(Math.Round((3 * Math.PI) / 2, 5));
    }

    //[Specification]
    //public void one_hundred_and_sixty_five_degree_spec()
    //{
    //  Location l0 = new Location(-2, 1);
    //  Location l1 = new Location(0, 0);
    //  Location l2 = new Location(1, 0);
    //  float angle = l1.angle_between(l0, l2);

    //  Specify.That(Math.Round(angle, 5)).ShouldEqual(153.43494);
    //}

    [Specification]
    public void compare_angles()
    {
      LocationComparerByAngle comp = new LocationComparerByAngle();
      comp.compare_with = new Location(0, 0);

      Location quadrant1 = new Location(5, 5);
      Location quadrant2 = new Location(-5, 5);
      Location quadrant3 = new Location(-5, -5);
      Location quadrant4 = new Location(5, -5);

      Specify.That(comp.Compare(quadrant1, quadrant2)).ShouldEqual(-1);
      Specify.That(comp.Compare(quadrant1, quadrant4)).ShouldEqual(-1);
      Specify.That(comp.Compare(quadrant2, quadrant2)).ShouldEqual(0);
      Specify.That(comp.Compare(quadrant4, quadrant3)).ShouldEqual(1);
      Specify.That(comp.Compare(quadrant4, quadrant1)).ShouldEqual(1);

      comp.compare_clockwise = true;
      
      Specify.That(comp.Compare(quadrant1, quadrant2)).ShouldEqual(1);
      Specify.That(comp.Compare(quadrant1, quadrant4)).ShouldEqual(1);
      Specify.That(comp.Compare(quadrant2, quadrant2)).ShouldEqual(0);
      Specify.That(comp.Compare(quadrant4, quadrant3)).ShouldEqual(-1);
      Specify.That(comp.Compare(quadrant4, quadrant1)).ShouldEqual(-1);
    }

    [Specification]
    public void location_list_sort_works_properly()
    {
      List<Location> l = new List<Location>();
      for (int i = 0; i < 10; ++i)
        l.Add(new Location(4 - i, 10));

      LocationComparerByAngle comparer = new LocationComparerByAngle();
      comparer.compare_clockwise = true;
      comparer.compare_with = new Location(0,0);
      l.Sort(comparer);


      for (int i = 0; i < 10; ++i)
        Specify.That(l[i].x).ShouldEqual(-5 + i);
    }

    [Specification]
    public void check_that_the_Equals_method_works()
    {
      Location loc1 = new Location(5, 6);
      Location loc2 = new Location(5, 6);
      Location loc3 = new Location(5, 5);
      Location loc4 = new Location(6, 5);

      Specify.That(loc1.Equals(loc2)).ShouldBeTrue();
      Specify.That(loc1.Equals(loc3)).ShouldBeFalse();
      Specify.That(loc1.Equals(loc4)).ShouldBeFalse();
      Specify.That(loc3.Equals(loc4)).ShouldBeFalse();
    }

    [Specification]
    public void X_Y_test()
    {
      Location loc = new Location(0, 1);
      Specify.That(loc.x).ShouldEqual(0);
      Specify.That(loc.y).ShouldEqual(1);

      Location loc2 = new Location(1, 0);
      Specify.That(loc2.x).ShouldEqual(1);
      Specify.That(loc2.y).ShouldEqual(0);

      Location loc3 = new Location(5, 6);
      Specify.That(loc3.x).ShouldEqual(5);
      Specify.That(loc3.y).ShouldEqual(6);
    }

    [Specification]
    public void test_the_distance_from_one_loc_to_another()
    {
      Location loc1 = new Location(5, 6);
      Location loc2 = new Location(5, 6);
      Location loc3 = new Location(5, 5);
      Location loc4 = new Location(20, -5);

      Specify.That(loc1.distance_from(loc2)).ShouldEqual(0);
      float x_dist = 5 - 5;
      float y_dist = 6 - 5;
      Specify.That(loc1.distance_from(loc3)).ShouldEqual((float)Math.Sqrt(Math.Pow(x_dist, 2) + Math.Pow(y_dist, 2)));
      x_dist = 5 - 5;
      y_dist = 5 - 6;
      Specify.That(loc3.distance_from(loc1)).ShouldEqual((float)Math.Sqrt(Math.Pow(x_dist, 2) + Math.Pow(y_dist, 2)));
      x_dist = 5 - 20;
      y_dist = 6 - -5;
      Specify.That(loc1.distance_from(loc4)).ShouldEqual((float)Math.Sqrt(Math.Pow(x_dist, 2) + Math.Pow(y_dist, 2)));
    }

    [Specification]
    public void ensure_dup_dups()
    {
      Location loc = new Location(2, 3);
      Specify.That(loc.dup().Equals(loc)).ShouldBeTrue();
      Location new_loc = loc.dup();
      Specify.That(new_loc.x).ShouldEqual(2);
      Specify.That(new_loc.y).ShouldEqual(3);
      Specify.That(new_loc.Equals(loc)).ShouldBeTrue();
    }

    [Specification]
    public void check_that_the_CompareTo_method_works()
    {
      Location loc1 = new Location(5, 6);
      Location loc2 = new Location(5, 6);
      Location loc3 = new Location(7, 5);
      Location loc4 = new Location(6, 5);
      Location loc5 = new Location(6, 6);
      Location loc6 = new Location(6, 4);

      Specify.That(loc1.CompareTo(loc2)).ShouldEqual(0);
      Specify.That(loc1.CompareTo(loc3)).ShouldEqual(-1);
      Specify.That(loc1.CompareTo(loc4)).ShouldEqual(-1);
      Specify.That(loc3.CompareTo(loc4)).ShouldEqual(1);
      Specify.That(loc4.CompareTo(loc5)).ShouldEqual(-1);
      Specify.That(loc4.CompareTo(loc6)).ShouldEqual(1);
    }

    [Specification]
    public void setting_compare_with_in_LocationComparerByAngle()
    {
      Location loc = new Location(0, 0);

      LocationComparerByAngle lcba = new LocationComparerByAngle();
      lcba.compare_with = loc;

      Specify.That(lcba.compare_with.Equals(loc)).ShouldBeTrue();
    }

    [Specification]
    public void setting_compare_clockwise_in_LocationComparerByAngle()
    {
      LocationComparerByAngle lcba = new LocationComparerByAngle();

      lcba.compare_clockwise = true;
      Specify.That(lcba.compare_clockwise).ShouldBeTrue();

      lcba.compare_clockwise = false;
      Specify.That(lcba.compare_clockwise).ShouldBeFalse();
    }
  }
}
