using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _01.LinkedQueue;

namespace LinkedQueue.Tests
{
    [TestClass]
    public class LinkedQueueTests
    {
        private static CustomLinkedQueue<int> queue;

        [TestInitialize]
        public void TestInit()
        {
            queue = new CustomLinkedQueue<int>();
        }

        [TestCleanup]
        public void TestClean()
        {
        }

        [TestMethod]
        public void Count_AddNewElementsInQueue_ShouldReturnCount()
        {
            int queueCount = 100;
            for (int i = 0; i < queueCount; i++)
            {
                queue.Enqueue(i);
            }

            Assert.AreEqual(queueCount, queue.Count, "The queue count is not correct.");
        }

        [TestMethod]
        public void Count_AddAndRemoveSeveralNewElementsInQueue_ShouldReturnCorrectCount()
        {
            int queueAddCount = 100;
            for (int i = 0; i < queueAddCount; i++)
            {
                queue.Enqueue(i);
            }

            int queueRemoveCount = 20;
            for (int i = 0; i < queueRemoveCount; i++)
            {
                queue.Dequeue();
            }

            Assert.AreEqual(queueAddCount - queueRemoveCount, queue.Count, "The queue count is not correct.");
        }

        [TestMethod]
        public void Enqueue_NewElementInQueue_ShouldAddElement()
        {
            queue.Enqueue(2);

            Assert.AreEqual(1, queue.Count, "The queue count is not correct.");
        }

        [TestMethod]
        public void Enqueue_NewElementsInQueue_ShouldAddElementsCorrectly()
        {
            var numbersList = new List<int>{2, 3, 4, 5};

            for (int i = 0; i < numbersList.Count; i++)
            {
                queue.Enqueue(numbersList[i]);
            }

            int index = 0;
            foreach (var element in queue)
            {
                Assert.AreEqual(true, element.Equals(numbersList[index]));
                index++;
            }

            Assert.AreEqual(4, queue.Count, "The queue count is not correct.");
        }

        [TestMethod]
        public void Dequeue_ElementFromQueue_ShouldRemoveFirstElement()
        {
            queue.Enqueue(2);
            queue.Enqueue(3);

            var result = queue.Dequeue();

            Assert.AreEqual(1, queue.Count, "The queue count is not correct.");
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Dequeue_SeveralElementsFromQueue_ShouldRemoveElementsCorrectly()
        {
            var numbersList = new List<int> { 2, 3, 4, 5 };

            for (int i = 0; i < numbersList.Count; i++)
            {
                queue.Enqueue(numbersList[i]);
            }

            int index = 0;
            foreach (var element in queue)
            {
                var removedItem = queue.Dequeue();
                Assert.AreEqual(removedItem, numbersList[index]);
                index++;
            }

            Assert.AreEqual(0, queue.Count, "The queue count is not correct.");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Dequeue_EmptyQueue_ShouldShouldThrow()
        {
            queue.Dequeue();
        }
        
    }
}
