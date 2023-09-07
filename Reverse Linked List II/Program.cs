namespace Reverse_Linked_List_II
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);
            int left = 2;
            int right = 4;
            Solution s = new Solution();
            var answer = s.ReverseBetween(head, left, right);
        }
    }

    public class ListNode
    {
        public int val { get; set; }
        public ListNode next { get; set; }
        public ListNode(int val)
        {
            this.val = val;
        }

        public ListNode(int val, ListNode next)
        {
            this.val = val;
            this.next = next;
        }
    }

    /**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
    /**
     * Definition for singly-linked list.
     * public class ListNode {
     *     public int val;
     *     public ListNode next;
     *     public ListNode(int val=0, ListNode next=null) {
     *         this.val = val;
     *         this.next = next;
     *     }
     * }
     */
    public class Solution
    {
        public ListNode ReverseBetween(ListNode head, int left, int right)
        {
            if (head == null || head.next == null) return head;
            var dummy = new ListNode(0, head);
            // Step 1 - take two pointer, leftPrev and cur, assign leftPrev to dummy and cur to head, itirate till left reach the starting node of reverse
            // Step 2 - start reversing until (right - left + 1) posiition , once this loop gets end, cur would be at just after the right node and prev would be at the right node
            // Step 3 - now we just have to link, leftPrev.next(left most node after reverse).next = cur(node after the right node) AND leftPrev->next = prev(right node)

            // Step 1
            ListNode leftPrev = dummy;
            var cur = head;
            var tempLeft = left;
            while (tempLeft > 1)
            {
                leftPrev = cur;
                cur = cur?.next;
                tempLeft--;
            }
            // Step 2
            ListNode prev = null;
            int length = right - left + 1;
            while (length > 0)
            {
                var next = cur?.next;
                cur.next = prev;
                prev = cur;
                cur = next;
                length--;
            }

            // Step 3
            leftPrev.next.next = cur;
            leftPrev.next = prev;

            return dummy.next;
        }
    }
}