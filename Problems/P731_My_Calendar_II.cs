using System.Collections.Generic;

namespace Problems
{
    public class P731_My_Calendar_II
    {
        public static void RunTests()
        {
            Utilities.Output.Print("Test Case 1: ");
            var cal = new MyCalendarTwo();
            Utilities.Output.PrintSkip(cal.Book(10, 20));
            Utilities.Output.PrintSkip(cal.Book(50, 60));
            Utilities.Output.PrintSkip(cal.Book(10, 40));
            Utilities.Output.PrintSkip(cal.Book(5, 15));
            Utilities.Output.PrintSkip(cal.Book(5, 10));
            Utilities.Output.PrintSkip(cal.Book(25, 55));
        }

        public class MyCalendarTwo
        {
            public List<Slice> Slices { get; set; }

            public MyCalendarTwo()
            {
                Slices = [new Slice(int.MinValue, int.MaxValue, null)];
            }

            public bool Book(int start, int end)
            {
                var overlaps = new Dictionary<Slice, byte>();
                foreach (var slice in Slices)
                {
                    var rel = slice.Relation(start, end);
                    if (rel <= 6)
                    {
                        if (slice.Doubled == true)
                            return false;
                        overlaps.Add(slice, rel);
                    }
                }
                foreach (var keypair in overlaps)
                {
                    //Equal|Cover -> Do nothing
                    if (keypair.Value == 2 || keypair.Value == 5)//Inside L and Cut L -> Keep L add new R
                    {
                        Slices.Add(new Slice(end, keypair.Key.End, keypair.Key.Doubled));
                        keypair.Key.End = end;
                    }
                    if (keypair.Value == 3)//Inside C -> Keep C add L and R
                    {
                        Slices.Add(new Slice(keypair.Key.Start, start, keypair.Key.Doubled));
                        Slices.Add(new Slice(end, keypair.Key.End, keypair.Key.Doubled));
                        keypair.Key.Start = start;
                        keypair.Key.End = end;
                    }
                    if (keypair.Value == 4 || keypair.Value == 6)//Inside R -> Keep R add new L
                    {
                        Slices.Add(new Slice(keypair.Key.Start, start, keypair.Key.Doubled));
                        keypair.Key.Start = start;
                    }
                    keypair.Key.Doubled = keypair.Key.Doubled == false;
                }
                return true;
            }
        }

        public class Slice
        {
            public int Start { get; set; }
            public int End { get; set; }

            public bool? Doubled { get; set; }

            public Slice(int start, int end, bool? dub = false)
            {
                Start = start;
                End = end;
                Doubled = dub;
            }

            public byte Relation(int start, int end)
            {
                if (start < Start && End < end)
                    return 1;//Cover
                if (start == Start && End < end)
                    return 1;//Cover Left
                if (start < Start && End == end)
                    return 1;//Cover Right

                if (Start == start && end < End)
                    return 2;//Inside Left
                if (Start < start && end < End)
                    return 3;//Inside Center
                if (Start < start && end == End)
                    return 4;//Inside Right

                if (start < Start && (Start < end && end < End))
                    return 5;//Cut Left
                if ((Start < start && start < End) && End < end)
                    return 6;//Cut Right

                if (end == Start)
                    return 7;//Touch Left
                if (End == start)
                    return 8;//Touch Right

                if (end < Start)
                    return 9;//Sep Left
                if (End < start)
                    return 10;//Sep Right

                return 0;//Equal
            }
        }
    }
}