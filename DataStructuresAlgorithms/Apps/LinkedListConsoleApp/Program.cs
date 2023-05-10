//using LinkedList.Singly;

//var node1 = new SinglyLinkedListNode<int>();
//node1.Value = 55;

//var node2 = new SinglyLinkedListNode<int>();
//node2.Value = 60;

//var node3 = new SinglyLinkedListNode<int>();
//node3.Value = 65;

//node1.Next = node2;
//node2.Next = node3;

//Console.WriteLine(node1);
//Console.WriteLine(node1.Next);
//Console.WriteLine(node2.Next);
//Console.WriteLine(node1.Next.Next);

//Console.WriteLine(new String('-',20));

//// ? 
//var current = node1;
//while(current != null)
//{
//    Console.Write($"{current,-5} ");
//    current = current.Next;
//}

//Console.ReadKey();

using LinkedList.Singly;

var linkedList = new SinglyLinkedList<int>();
linkedList.AddFirst(1);
linkedList.AddFirst(2);
linkedList.AddFirst(3);
linkedList.AddFirst(4);
foreach (var item in linkedList)
{
    Console.WriteLine(item);
}
//linkedList.Where(n => n > 2)
//    .ToList().ForEach(n => Console.WriteLine(n));