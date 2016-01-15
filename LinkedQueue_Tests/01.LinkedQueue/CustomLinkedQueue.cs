namespace _01.LinkedQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CustomLinkedQueue<T> : IEnumerable<T>
    {
        private QueueNode<T> head;
        private QueueNode<T> tail;

        public int Count { get; private set; }

        public void Enqueue(T element)
        {
            var newNode = new QueueNode<T>(element);
            if (this.Count == 0)
            {
                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                this.tail.NextNode = newNode;
                this.tail = newNode;
            }
            this.Count++;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            var item = this.head.Value;
            this.head = this.head.NextNode;
            this.Count--;

            if (this.Count == 0)
            {
                this.head = null;
            }

            return item;
        }

        public bool Contains(T element)
        {
            int index = 0;
            QueueNode<T> currentNode = this.head;
            while (currentNode != null)
            {
                if (object.Equals(currentNode.Value, element))
                {
                    return true;
                }

                currentNode = currentNode.NextNode;
                index++;
            }

            return false;
        }

        public void Clear()
        {
            this.head = null;
            this.tail = null;
            this.Count = 0;
        }

        // Views the first element in the Queue but does not remove it.
        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            return this.head.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this.head;
            while (current != null)
            {
                yield return current.Value;
                current = current.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
