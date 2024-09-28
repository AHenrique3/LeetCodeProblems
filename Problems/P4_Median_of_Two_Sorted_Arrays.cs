using System.Collections.Generic;

namespace Problems
{
    public class P4_Median_of_Two_Sorted_Arrays
    {
        public static void RunTests()
        {
            Utilities.Output.Print("Test Case 1: ");
            Utilities.Output.PrintLine(FindMedianSortedArrays([1, 3], [2]));

            Utilities.Output.Print("Test Case 2: ");
            Utilities.Output.PrintLine(FindMedianSortedArrays([1, 2], [3, 4]));
        }

        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var tot = nums1.Length + nums2.Length;
            var res = 0.0;
            var i = 1;
            if (tot % 2 == 0) //even -> find middle elements
            {
                foreach (var elem in OrderedSequence(nums1, nums2))
                {
                    if (i == tot / 2)
                        res = elem;
                    if (i == (tot / 2) + 1)
                    {
                        res = (res + elem) / 2.0;
                        break;
                    }
                    i++;
                }
            }
            else //odd -> find element
            {
                foreach (var elem in OrderedSequence(nums1, nums2))
                {
                    if (i == (tot + 1) / 2)
                    {
                        res = elem;
                        break;
                    }
                    i++;
                }
            }
            return res;

            IEnumerable<int> OrderedSequence(int[] nums1, int[] nums2)
            {
                var i = 0;
                var j = 0;

                while (i + j < nums1.Length + nums2.Length)
                {
                    int? n1 = i < nums1.Length ? nums1[i] : null;
                    int? n2 = j < nums2.Length ? nums2[j] : null;

                    if (n1 <= n2 || (n1 != null && n2 == null))
                    {
                        yield return (int)n1;
                        i++;
                    }
                    if (n1 > n2 || (n1 == null && n2 != null))
                    {
                        yield return (int)n2;
                        j++;
                    }
                }
            }
        }
    }
}