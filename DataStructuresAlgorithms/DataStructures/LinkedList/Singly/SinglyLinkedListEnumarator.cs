using System.Collections;

namespace LinkedList.Singly
{
    public class SinglyLinkedListEnumarator<T> : IEnumerator<T>
    {
        private SinglyLinkedListNode<T>? Head { get; set; }
        private SinglyLinkedListNode<T>? Curr { get; set; }
        public T Current => Curr.Value;
        object IEnumerator.Current => Current;
        public SinglyLinkedListEnumarator(SinglyLinkedListNode<T>? head)
        {
            Head = head;
            Curr = null;
        }

        public void Dispose()
        {
            Head = null;
        }

        public bool MoveNext()
        {
            if (Head == null)
            {
                return false;
            }
            if (Curr == null)
            {
                Curr = Head;
                return true;
            }
            if (Curr.Next is not null)
            {
                Curr = Curr.Next;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}