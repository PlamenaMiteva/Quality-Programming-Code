namespace CustomLinkedList.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DynamicListTests
    {
        private static DynamicList<int> list;

        [TestInitialize]
        public void TestInit()
        {
            list = new DynamicList<int>();
        }

        [TestCleanup]
        public void TestClean()
        {
        }

        [TestMethod]
        public void Count_AddNewElementsInList_ShouldReturnCount()
        {
            int listCount = 100;
            for (int i = 0; i < listCount; i++)
            {
                list.Add(i);
            }

            Assert.AreEqual(listCount, list.Count, "The queue count is not correct.");
        }

        [TestMethod]
        public void Count_AddAndRemoveSeveralNewElementsInList_ShouldReturnCorrectCount()
        {
            int listAddCount = 100;
            for (int i = 0; i < listAddCount; i++)
            {
                list.Add(i);
            }

            int listRemoveCount = 20;
            for (int i = 0; i < listRemoveCount; i++)
            {
                list.RemoveAt(i);
            }

            Assert.AreEqual(listAddCount - listRemoveCount, list.Count, "The queue count is not correct.");
        }

        [TestMethod]
        public void DynamicList_GetElementAtValidIndex_ShouldReturnTheElement()
        {
            list.Add(2);
            var element = list[0];

            Assert.AreEqual(2, element, "Element at given index position is not correct.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DynamicList_GetElementAtNonExistingIndex_ShouldReturnException()
        {
            var element = list[20];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DynamicList_GetElementAtNegativeIndex_ShouldReturnException()
        {
            var element = list[-20];
        }

        [TestMethod]
        public void Add_AddElementToEmptyList_ShouldAddElement()
        {
            list.Add(3);

            Assert.AreEqual(1, list.Count, "The list count is not correct.");
            Assert.AreEqual(3, list[0], "Element is not added to the end of the list.");
        }

        [TestMethod]
        public void Add_AddElementToNonEmptyList_ShouldAddElementAtTheEnd()
        {
            list.Add(3);
            list.Add(37);
            list.Add(-8);

            Assert.AreEqual(3, list.Count, "The list count is not correct.");
            Assert.AreEqual(3, list[0], "Incorrect element at position 0");
            Assert.AreEqual(37, list[1], "Incorrect element at position 1");
            Assert.AreEqual(-8, list[2], "Incorrect element at position 2");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveAt_RemoveElementAtNonExistingIndex_ShouldReturnException()
        {
            list.RemoveAt(200);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveAt_RemoveElementAtNegativeIndex_ShouldReturnException()
        {
            var element = list[-20];
        }

        [TestMethod]
        public void RemoveAt_RemoveElementAtIndex_ShouldRemoveElementSuccessfully()
        {
            list.Add(5);
            list.Add(-34);
            list.Add(204);

            list.RemoveAt(1);

            //create list with the same values for the test purposes
            var testList = new DynamicList<int>();
            testList.Add(5);
            testList.Add(204);

            Assert.AreEqual(2, list.Count, "The list count is not correct.");
            for (int i = 0; i < testList.Count; i++)
            {
                Assert.AreEqual(testList[i], list[i], "Elements at position {0} are not equal", i);
            }
        }

        [TestMethod]
        public void Remove_RemoveExistingItem_ShouldRemoveItemCorrectly()
        {
            list.Add(30);
            list.Add(-295);
            list.Add(83);

            list.Remove(-295);

            //create list with the same values for the test purposes
            var testList = new DynamicList<int>();
            testList.Add(30);
            testList.Add(83);

            Assert.AreEqual(2, list.Count, "The list count is not correct.");
            for (int i = 0; i < testList.Count; i++)
            {
                Assert.AreEqual(testList[i], list[i], "Elements at position {0} are not equal", i);
            }
        }

        [TestMethod]
        public void Remove_RemoveNonExistingItem_ShouldReturnMinusOne()
        {
            list.Add(30);
            list.Add(-295);
            list.Add(83);

            var result = list.Remove(-2);

            Assert.AreEqual(3, list.Count, "The list count is not correct.");
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void IndexOf_IndexOfExistingItem_ShouldReturnIndex()
        {
            list.Add(30);
            list.Add(-295);
            list.Add(83);

            var result = list.IndexOf(83);

            Assert.AreEqual(2, result, "Returned index of the searched item is not correct.");
        }

        [TestMethod]
        public void IndexOf_IndexOfNonExistingItem_ShouldReturnMinusOne()
        {
            list.Add(30);
            list.Add(-295);
            list.Add(83);

            var result = list.IndexOf(8);

            Assert.AreEqual(-1, result, "Returned index of the searched item is not correct.");
        }

        [TestMethod]
        public void Contains_ContainsExistingItem_ShouldReturnTrue()
        {
            list.Add(53);
            list.Add(-384);
            list.Add(24);

            var result = list.Contains(53);

            Assert.AreEqual(true, result, "Does not find an existing item in the list.");
        }

        [TestMethod]
        public void Contains_ContainsNonExistingItem_ShouldReturnFalse()
        {
            list.Add(53);
            list.Add(-384);
            list.Add(24);

            var result = list.Contains(3);

            Assert.AreEqual(false, result, "Returns true when searching for a non-existing item in the list.");
        }
    }
}
