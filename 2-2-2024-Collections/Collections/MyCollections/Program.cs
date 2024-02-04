using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyCollections {
    internal class Program {
        static void Main(string[] args) {
            DoublyLinkedList<int> doublyLinkedList = new DoublyLinkedList<int>();
            doublyLinkedList.AddLast(1);
            doublyLinkedList.AddLast(2);
            doublyLinkedList.PrintList();
            doublyLinkedList.AddFirst(3);
            Console.WriteLine(doublyLinkedList.Count);
            doublyLinkedList.PrintList();
            int res;
            doublyLinkedList.RemoveLast(out res);
            doublyLinkedList.PrintList();
            doublyLinkedList.RemoveFirst(out res);
            doublyLinkedList.PrintList();
            Console.WriteLine(res);
            Console.WriteLine(doublyLinkedList.Count);
            doublyLinkedList.AddLast(1);
            doublyLinkedList.AddLast(2);
            doublyLinkedList.PrintList();
            doublyLinkedList.RemoveAt(20, out res);
            doublyLinkedList.RemoveAt(1, out res);
            doublyLinkedList.PrintList();
            doublyLinkedList.RemoveAt(0, out res);
            doublyLinkedList.PrintList();

            ArrayList arrayList = new ArrayList();
            arrayList.Add(10);
            arrayList.Add(20);
            arrayList.Add(30);
            arrayList.Insert(2, 15);
            Console.WriteLine(arrayList[2] + " " + arrayList[3]);

            LinkedList<int> linkedList = new LinkedList<int>();
            linkedList.Add(1);

            linkedList.Add(2);
            linkedList.Add(3);
            linkedList.Add(4);
            linkedList.RemoveAt(2);
            Console.WriteLine(linkedList[0] + " " + linkedList[1] + " " + linkedList[2]);

            ObservableCollection<int> oc = new ObservableCollection<int>();
            oc.CollectionChanged += (s, e) => {
                Console.WriteLine(s + " 1 " + e);
            };
            oc.CollectionChanged += (s, e) => {
                Console.WriteLine(s + " 2 " + e);
            };

            Thread.Sleep(3000);
            oc.Add(34);
            Thread.Sleep(3000);
            oc.Remove(34);

            ArrayList array = new ArrayList();
            array[0] = 160;
            array[1] = 67;
            array[3] = 76;
            array[2] = 67;
            array[4] = 576;
            array[5] = 867;
            array[6] = 976;
            array[7] = 776;
            array[8] = 576;
            array[9] = 576;
            Console.WriteLine(array.Count);
            foreach (object i in array)
                Console.WriteLine(i);


            Console.ReadLine();


        }
    }
}
