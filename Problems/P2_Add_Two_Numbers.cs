using System;
using System.Collections.Generic;

namespace Problems
{
    public class P2_Add_Two_Numbers
    {
        public static void RunTests()
        {
            Utilities.Output.Print("Test Case 1: ");
            Utilities.Output.PrintLine(
                AddTwoNumbers(
                    new ListNode(2, new ListNode(4, new ListNode(3))),
                    new ListNode(5, new ListNode(6, new ListNode(4)))
                ).Serialize()
            );

            Utilities.Output.Print("Test Case 3: ");
            Utilities.Output.PrintLine(
                AddTwoNumbers(
                    new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9))))))),
                    new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9))))
                ).Serialize()
            );
        }

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var zero = new ListNode(0);

            var response = zero;
            ListNode? tail = null;
            var carrier = new ListNode(0);
            while (l1 != zero || l2 != zero || carrier.val != 0)
            {
                var newNode = new ListNode(0);
                (carrier.val, newNode.val) = Math.DivRem(carrier.val + l1.val + l2.val, 10);

                if (response == zero)
                    response = newNode;
                else
                    tail.next = newNode;
                tail = newNode;

                l1 = l1.next ?? zero;
                l2 = l2.next ?? zero;
            }

            return response;
        }

        public class ListNode
        {
            public int val;
            public ListNode? next;
            public ListNode(int val = 0, ListNode? next = null)
            {
                this.val = val;
                this.next = next;
            }

            /// <summary>Extra method to help debug</summary>
            public IEnumerable<int> Serialize()
            {
                var node = this;
                do
                {
                    yield return node.val;
                    node = node.next;
                } while (node != null);
            }
        }
    }
}