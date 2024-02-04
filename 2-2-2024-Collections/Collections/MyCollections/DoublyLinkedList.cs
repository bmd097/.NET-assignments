using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyCollections {
    /// <summary>
    /// Its for Internal Purpose
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class Node<T> {
        public T data;
        public Node<T> prev;
        public Node<T> next;
        public Node(object data) {
            this.data = (T)data;
        }
    }
    /// <summary>
    /// Its for Internal Purpose
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class DoublyLinkedList<T> {
        Node<T> head;
        Node<T> tail;
        int count { get; set; }
        public int Count { get { return count; } }
        public DoublyLinkedList(){
            head = tail = null;
            count = 0;
        }
        public void AddLast(T item) {
            if (count == 0) {
                head = tail = new Node<T>(item);
                count++;
                return;
            }
            count++;
            tail.next = new Node<T> (item);
            tail.next.prev = tail;
            tail = tail.next;
        }
        public void AddFirst(T item) {
            if (count == 0) {
                head = tail = new Node<T>(item);
                count++;
                return;
            }
            count++;
            Node<T> newNode = new Node<T>(item);
            newNode.next = head;
            head.prev = newNode;
            head = newNode;
        }
        public bool RemoveLast(out T res) {
            if (count == 1) {
                res = tail.data;
                head = tail = null;
                count = 0;
                return true;
            }
            res = default(T);
            if (count == 0) return false;
            T data = tail.data;
            tail = tail.prev;
            tail.next = null;
            count--;
            res = data;
            return true;
        }
        public bool RemoveFirst(out T res) {
            if (count == 1) {
                res = tail.data;
                head = tail = null;
                count = 0;
                return true;
            }
            res = default(T);
            if (count == 0) return false;
            T data = head.data;
            head = head.next;
            head.prev = null;
            count--;
            res = data;
            return true;
        }
        public bool GetFirst(out T res) {
            res = default(T);
            if(count == 0) return false;
            T data = head.data;
            res = data;
            return true;
        }
        public bool GetLast(out T res) {
            res = default(T);
            if (count == 0) return false;
            T data = tail.data;
            res = data;
            return true;
        }
        public bool GetAt(int index, out T res) {
            res = default(T);
            if (count == 0) return false;
            if (index >= count) return false;
            Node<T> trav = head;
            while (index-- > 0) trav = trav.next;
            res = trav.data;
            return true;
        }

        public bool RemoveAt(int index, out T res) {
            res = default(T);
            if (index == 0) return RemoveFirst(out res);
            if(index == count -1) return RemoveLast(out res);
            if (count == 0) return false;
            if (index >= count) return false;
            Node<T> prev = null;
            Node<T> curr = head;
            while(index-- > 0) {
                prev = curr;
                curr = curr.next;
            }
            res = curr.data;
            Node<T> next = curr.next;
            if(prev != null) 
                prev.next = next;
            if(next != null)
                next.prev = prev;
            count--;
            return true;
        }
        public String PrintList() {
            StringBuilder sb = new StringBuilder();
            Node<T> trav = head;
            while (trav != null) {
                sb.Append(trav.data.ToString()+" ");
                trav = trav.next;
            }
            return sb.ToString();
        }
        public int IndexOf(T value) {
            int index = 0;
            Node<T> curr = head;
            while (curr != null) {
                if(curr.data.Equals(value)) return index;
                index++;
                curr = curr.next;
            }
            return -1;
        }
        public void Add(int index, T value) {
            if (index < 0 || index > Count) return;
            if(index == 0) {
                AddFirst(value);
                return;
            }
            if(index  == Count) {
                AddLast(value);
                return;
            }
            Node<T> prev = null;
            Node<T> curr = head;
            while(index --> 0) {
                prev = curr;
                curr = curr.next;
            }
            Node<T> newNode = new Node<T>(value);
            prev.next = newNode;
            newNode.prev = prev;
            newNode.next = curr;
            if(curr!=null)
                curr.prev = newNode;
            count++;
        }
        public void Remove(T value) {
            if(Count == 0) return;
            if (head.data.Equals(value)) {
                T o;
                RemoveFirst(out o);
                return;
            }
            Node<T> prev = null;
            Node<T> curr = head;
            while(curr != null) {
                if (curr.data.Equals(value)) {
                    prev.next = curr.next;
                    if(curr.next!=null)
                        curr.next.prev = prev;
                    count--;
                    return;
                } else {
                    prev = curr;
                    curr = curr.next;
                }
            }
        }
        public Node<T> GetHeadNode() {
            return head;
        }

    }

}
