namespace _01.LinkedQueue
{
    using System;

    class QueueMain
    {
        public static void Main()
        {
            var q = new CustomLinkedQueue<int>();

            q.Enqueue(1);
            Console.WriteLine(q.Peek());
        }
    }
}
