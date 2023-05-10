using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList.Singly
{
    public class SinglyLinkedList<T> : IEnumerable<T>
    {
        // Auto-implemented propert
        public SinglyLinkedListNode<T>? Head { get; set; }

        public SinglyLinkedList()
        {

        }

        /// <summary>
        /// Bağlı listenin başına eleman ekler
        /// </summary>
        /// <param name="item"></param>
        public void AddFirst(T item)
        {
            // düğüm oluşturman gerekir!
            var node = new SinglyLinkedListNode<T>()
            {
                Value = item
            };

            // Head boş mu?
            if (Head is null)
            {
                Head = node;
                return;
            }

            node.Next = Head;
            Head = node;
            return;
        }

        /// <summary>
        /// Bağlı listenin sonuna eleman ekler. 
        /// </summary>
        /// <param name="item"></param>
        public void AddLast(T item)
        {
            // T ifadesini düğüme çevir
            var node = new SinglyLinkedListNode<T>(item);

            // Head kontrol et
            if (Head is null)
            {
                Head = node;
                return;
            }

            // Son elemana kadar git
            var current = Head;
            var prev = current;
            while (current != null)
            {
                prev = current;
                current = current.Next;
            }
            prev.Next = node;
            return;
        }

        /// <summary>
        ///  a - [b] - c                    x -> c
        /// </summary>
        public void AddBefore(SinglyLinkedListNode<T> node, T item)
        {
            if (Head is null)
            {
                AddFirst(item);
                return;
            }

            var newNode = new SinglyLinkedListNode<T>(item);

            var current = Head;
            var prev = current;

            while (current is not null)
            {
                if (current.Equals(node))
                {
                    newNode.Next = prev.Next;
                    prev.Next = newNode;
                    return;
                }
                prev = current;
                current = current.Next;
            }
            throw new Exception("The node could not be found in the linked list.");
        }

        /// <summary>
        /// Week 4 - Verilen düğümden sonraya verilen T değerini ekler.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="item"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void AddAfter(SinglyLinkedListNode<T> node, T item)
        {
            // throw new NotImplementedException();

            SinglyLinkedListNode<T> new_node = new SinglyLinkedListNode<T>(item);

            if (Head is null)
            {
                AddFirst(item);
            }

            var current = Head;
            while (current is not null)
            {
                if (current.Equals(node))
                {
                    new_node.Next = current.Next;
                    current.Next = new_node;
                    return;
                }

                current = current.Next;
            }

            throw new Exception("The node could not be found in the linked list.");
        }

        /// <summary>
        /// Week 4 - Bağlı listenin başındaki düğümü çıkarır.
        /// Çıkarılan düğümün değerini geri döndürür.
        /// </summary>
        /// <returns></returns>
        public T RemoveFirst()
        {
            // throw new NotImplementedException();

            if (Head is null)
            {
                throw new Exception("Linked list is empty!");
            }

            T item = Head.Value;

            Head = Head.Next;

            return item;
        }

        /// <summary>
        /// Week 4 - Bağlı listenin sonundaki düğümü çıkarır.
        /// Çıkarılan düğümün değerini geri döndürür.
        /// </summary>
        /// <returns></returns>
        public T RemoveLast()
        {
            // throw new NotImplementedException();

            if (Head is null)
            {
                throw new Exception("Linked list is empty!");
            }

            var current = Head;

            if (current.Next is null)
            {
                T item = current.Value;
                Head = null;
                return item;
            }

            while (current is not null)
            {
                if (current.Next.Next is null)
                {
                    T item = current.Next.Value;
                    current.Next = null;
                    return item;
                }

                current = current.Next;
            }

            throw new Exception();
        }

        /// <summary>
        /// Week 4 - Bağlı listeden verilen düğümü çıkarır.
        /// Eğer düğüm bağlı listede bulunmuyorsa hata fırlatır.
        /// Çıkarılan değeri geri döndürür.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public T Remove(SinglyLinkedListNode<T> node)
        {
            if (Head is null)
                throw new Exception("The linked list is empty!");

            if (Head.Value.Equals(node.Value))
                return RemoveFirst();

            var current = Head;
            while (current.Next != null)
            {
                if (current.Next.Value.Equals(node.Value))
                {
                    T item = node.Value;
                    current.Next = current.Next.Next;
                    return item;
                }
                current = current.Next;
            }
            throw new Exception("Node not found!");
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new SinglyLinkedListEnumarator<T>(this.Head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
