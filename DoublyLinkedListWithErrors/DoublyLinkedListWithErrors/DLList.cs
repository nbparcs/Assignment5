using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedListWithErrors
{
    public class DLList
    {
        public DLLNode head; // pointer to the head of the list
        public DLLNode tail; // pointer to the tail of the list
        public DLList() { head = null; tail = null; } // constructor
        /*-------------------------------------------------------------------
        * The methods below includes several errors. Your  task is to write
        * unit test to discover these errors. During delivery the tutor may
        * add or remove errors to adjust the scale of the effort required by
        */
        public void addToTail(DLLNode p)
        {
            if (head == null)
            {
                head = p;
                tail = p;
            }
            else
            {
                //original
                //tail.next = p;
                //tail = p;
                //p.previous = tail;

                //fixed
                tail.next = p;
                p.previous = tail;
                tail = p;
            }
        } // end of addToTail

        public void addToHead(DLLNode p)
        {
            if (head == null)
            {
                head = p;
                tail = p;
            }
            else
            {
                p.next = this.head;
                this.head.previous = p;
                head = p;
            }
        } // end of addToHead

        //public void removHead() //original
        public void removeHead() //typo fixed
        {
            if (this.head == null) return;
            
            if (this.head == this.tail) //remove if list has only 1 node
            {
                this.head = null;
                this.tail = null;
                return;
            }
            else
            {
                this.head = this.head.next; //if there is 1 node
                this.head.previous = null;
            }   
        } // removeHead

        public void removeTail()
        {
            if (this.tail == null) return;
            if (this.head == this.tail)
            {
                this.head = null;
                this.tail = null;
                return;
            }
            //added
            else
            {
                //if it has more than 1 node
                this.tail.previous.next = null;
                this.tail = this.tail.previous;
            }
        } // remove tail

        /*-------------------------------------------------
         * Return null if the string does not exist.
         * ----------------------------------------------*/
        public DLLNode search(int num)
        {
            DLLNode p = head;
            while (p != null)
            {
                //original
                //p = p.next;
                //if (p.num == num) break;

                //fixed
                if (p.num == num) // Check the node value
                {
                    return p; // Return the node if found
                }
                p = p.next; // Move to the next node
            }
            //return (p);
            return null; //fixed
        } // end of search (return pionter to the node);

        public void removeNode(DLLNode p)
        { // removing the node p.
            if (p == null) return; //added to check if p exists

            //added this if
            if (p == this.head && p == this.tail)
            {
                this.head = null;
                this.tail = null;
                return;
            }

            if (p.next == null)
            {
                this.tail = this.tail.previous;
                this.tail.next = null;
                p.previous = null;
                return;
            }
            if (p.previous == null)
            {
                this.head = this.head.next;
                p.next = null;
                this.head.previous = null;
                return;
            }

            p.next.previous = p.previous;
            p.previous.next = p.next;
            p.next = null;
            p.previous = null;
            //return;
        } // end of remove a node

        public int total()
        {
            DLLNode p = head;
            int tot = 0;
            while (p != null)
            {
                tot += p.num;
                //p = p.next.next;
                p = p.next; //fixed
            }
            return (tot);
        } // end of total
    } // end of DLList class
}
