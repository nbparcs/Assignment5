using DoublyLinkedListWithErrors;

namespace DLLTest
{
    [TestClass]
    public class DLLTests
    {
        [TestMethod]
        public void TestAddToTail_SingleNode()
        {
            {
                var list = new DLList();
                var node = new DLLNode(1);

                list.addToTail(node);

                Assert.AreEqual(node, list.head, "Head should point to the new node.");
                Assert.AreEqual(node, list.tail, "Tail should point to the new node.");
                Assert.IsNull(list.head.next, "Head next should be null.");
                Assert.IsNull(list.tail.previous, "Tail previous should be null.");
            }
        }

        // 1 - Add to TAIL Empty Node 
        [TestMethod]
        public void TestAddToTail_EmptyList()
        {
            {
                var list = new DLList();
                var newNode = new DLLNode(1);

                list.addToTail(newNode);

                Assert.AreEqual(newNode, list.tail, "New node doesn't equal tail");
                Assert.AreEqual(newNode, list.head, "New node doesn't equal tail");
            }
        }

        // 1 - Add to TAIL Multiple Nodes
        [TestMethod]
        public void TestAddToTail_MultipleNodes()
        {
            var list = new DLList();
            var firstNode = new DLLNode(1);
            var secondNode = new DLLNode(2);

            list.addToTail(firstNode);
            list.addToTail(secondNode);

            Assert.AreEqual(firstNode, list.head, "Head should point to first node.");
            Assert.AreEqual(secondNode, list.tail, "Tail should point to second node.");
            Assert.AreEqual(secondNode, firstNode.next, "First node next should point to the second node.");
            Assert.AreEqual(firstNode, secondNode.previous, "Second node previous should point to the first node.");
        }

        //2 - Add to HEAD Single Node
        [TestMethod]
        public void TestAddToHead_SingleNode()
        {
            var list = new DLList();
            var node = new DLLNode(1);

            list.addToHead(node);

            Assert.AreEqual(node, list.head, "Head should point to the new node.");
            Assert.AreEqual(node, list.tail, "Tail should point to the new node.");
            Assert.IsNull(list.head.next, "Head next should be null.");
            Assert.IsNull(list.tail.previous, "Tail previous should be null.");
        }

        // 2 - Add to HEAD Empty Node 
        [TestMethod]
        public void TestAddToHead_EmptyList()
        {
            {
                var list = new DLList();
                var newNode = new DLLNode(1);

                list.addToHead(newNode);

                Assert.AreEqual(newNode, list.tail, "New node doesn't equal tail");
                Assert.AreEqual(newNode, list.head, "New node doesn't equal tail");
            }
        }

        // 2 - Add to HEAD Multiple Node 
        [TestMethod]
        public void TestAddToHead_MultipleNodes()
        {
            var list = new DLList();
            var firstNode = new DLLNode(1);
            var secondNode = new DLLNode(2);

            list.addToHead(firstNode);
            list.addToHead(secondNode);

            Assert.AreEqual(secondNode, list.head, "Head should point to the second node.");
            Assert.AreEqual(firstNode, list.tail, "Tail should point to the first node.");
            Assert.AreEqual(firstNode, secondNode.next, "Second node next should point to the first node.");
            Assert.AreEqual(secondNode, firstNode.previous, "First node previous should point to the second node.");
        }

        // 3 - Test for removHead single node
        [TestMethod]
        public void TestRemoveHead_SingleNode()
        {
            var list = new DLList();
            var node = new DLLNode(1);
            list.addToHead(node);

            list.removeHead(); //fixed
            //list.removHead(); //typo

            Assert.IsNull(list.head, "Head should be null after removing the only node.");
            Assert.IsNull(list.tail, "Tail should be null after removing the only node.");
        }

        // 3 - Test for removHead if empty node
        [TestMethod]
        public void TestRemoveHead_EmptyList()
        {
            DLList list = new DLList();
            //list.removHead();
            list.removeHead();//fixed

            Assert.IsNull(list.head, "New node doesn't equal head");
            Assert.IsNull(list.tail, "New node doesn't equal tail");
            //Assert.AreEqual(newNode, list.head, "New node doesn't equal tail");
        }

        // 3 - Test for removHead multiple nodes
        [TestMethod]
        public void TestRemoveHead_MultipleNodes()
        {
            var list = new DLList();
            var firstNode = new DLLNode(1);
            var secondNode = new DLLNode(2);
            var thirdNode = new DLLNode(3);

            list.addToTail(firstNode);
            list.addToTail(secondNode);
            list.addToTail(thirdNode);

            //list.removHead(); // Remove the third node
            list.removeHead(); // Remove the third node  FIXED

            Assert.AreEqual(thirdNode, list.tail, "Tail should point to the second node after removing the third node.");
            Assert.AreEqual(secondNode, list.head, "First node's next should point to the second node.");
            //Assert.IsNull(firstNode, "First node is not null");
        }

        // 4 - Test for removeTail method
        [TestMethod]
        public void TestRemoveTail_SingleNode()
        {
            var list = new DLList();
            var node = new DLLNode(1);
            list.addToTail(node);

            list.removeTail();

            Assert.IsNull(list.head, "Head should be null after removing the only node.");
            Assert.IsNull(list.tail, "Tail should be null after removing the only node.");
        }

        // 4 - Test for removeTail Multiple 
        [TestMethod]
        public void TestRemoveTail_MultipleNodes()
        {
            var list = new DLList();
            var firstNode = new DLLNode(1);
            var secondNode = new DLLNode(2);
            list.addToTail(firstNode);
            list.addToTail(secondNode);

            list.removeTail();

            Assert.AreEqual(firstNode, list.tail, "Tail should point to the first node after removing the second node.");
            Assert.IsNull(list.tail.next, "Tail next should be null after removing the second node.");
        }

        // 5 - Test for search method
        [TestMethod]
        public void TestSearch_NodeExists()
        {
            var list = new DLList();
            var node = new DLLNode(1);
            list.addToTail(node);

            var result = list.search(1);

            Assert.AreEqual(node, result, "Search should return the node with the matching value.");
        }

        //5 - Test for search node does not exist
        [TestMethod]
        public void TestSearch_NodeDoesNotExist()
        {
            var list = new DLList();
            var node = new DLLNode(1);
            list.addToTail(node);

            var result = list.search(2);

            Assert.IsNull(result, "Search should return null if no node found.");
        }

        //6 - Test for removeNode method
        [TestMethod]
        public void TestRemoveNode_SingleNode()
        {
            var list = new DLList();
            var node = new DLLNode(1);
            
            list.addToTail(node);
            list.removeNode(node);

            Assert.IsNull(list.head, "Head should be null after removing node.");
            Assert.IsNull(list.tail, "Tail should be null after removing node.");
        }

        //6 - Test for removeNode multiple
        [TestMethod]
        public void TestRemoveNode_MultipleNodes()
        {
            var list = new DLList();
            var firstNode = new DLLNode(1);
            var secondNode = new DLLNode(2);
            var thirdNode = new DLLNode(3);
            list.addToTail(firstNode);
            list.addToTail(secondNode);
            list.addToTail(thirdNode);

            list.removeNode(secondNode);

            Assert.AreEqual(firstNode.next, thirdNode, "First node's next should point to the third node.");
            Assert.AreEqual(thirdNode.previous, firstNode, "Third node's previous should point to the first node.");
        }

        // 7 - Total multiple
        [TestMethod]
        public void TestTotal_MultipleNodes()
        {
            var list = new DLList();
            var firstNode = new DLLNode(1);
            var secondNode = new DLLNode(2);
            var thirdNode = new DLLNode(3);
            list.addToTail(firstNode);
            list.addToTail(secondNode);
            list.addToTail(thirdNode);

            var total = list.total();

            Assert.AreEqual(6, total, "Total should sum up node values considering every other node.");
        }

        // 7 - Total multiple
        [TestMethod]
        public void TestAddToTail_MultipleNodes_PreviousPointer()
        {
            var list = new DLList();
            var firstNode = new DLLNode(1);
            var secondNode = new DLLNode(2);

            list.addToTail(firstNode);
            list.addToTail(secondNode);

            Assert.AreEqual(firstNode, secondNode.previous, "Second node's previous should point to the first node.");
            Assert.AreEqual(secondNode, firstNode.next, "First node's next should point to the second node.");
        }

        [TestMethod]
        public void TestSearch_FirstNode()
        {
            var list = new DLList();
            var firstNode = new DLLNode(1);
            list.addToTail(firstNode);

            var result = list.search(1);

            Assert.AreEqual(firstNode, result, "Search should return the first node when its value matches.");
        }

        [TestMethod]
        public void TestTotal_SkippingNodes()
        {
            var list = new DLList();
            var firstNode = new DLLNode(1);
            var secondNode = new DLLNode(2);
            var thirdNode = new DLLNode(3);
            list.addToTail(firstNode);
            list.addToTail(secondNode);
            list.addToTail(thirdNode);

            var total = list.total();

            Assert.AreEqual(6, total, "Total should sum up 1 + 3, skipping the second node.");
        }

        //20
        [TestMethod]
        public void TestAddToTail_IncorrectPreviousPointer()
        {
            var list = new DLList();
            var firstNode = new DLLNode(1);
            var secondNode = new DLLNode(2);

            list.addToTail(firstNode);
            list.addToTail(secondNode);

            // This will fail if previous pointer of secondNode is not set correctly
            Assert.AreEqual(firstNode, secondNode.previous, "Second node's previous should point to the first node.");
            Assert.IsNull(firstNode.previous, "First node's previous should be null.");
        }

        [TestMethod]
        public void TestAddToHead_IncorrectNextPointer()
        {
            var list = new DLList();
            var firstNode = new DLLNode(1);
            var secondNode = new DLLNode(2);

            list.addToHead(firstNode);
            list.addToHead(secondNode);

            // This will fail if next pointer of secondNode is not set correctly
            Assert.AreEqual(firstNode, secondNode.next, "Second node's next should point to the first node.");
            Assert.IsNull(firstNode.next, "First node's next should be null.");
        }

        [TestMethod]
        public void TestRemoveNode_IncorrectPointers()
        {
            var list = new DLList();
            var firstNode = new DLLNode(1);
            var secondNode = new DLLNode(2);
            var thirdNode = new DLLNode(3);
            list.addToTail(firstNode);
            list.addToTail(secondNode);
            list.addToTail(thirdNode);

            list.removeNode(secondNode);

            // This will fail if pointers are not updated correctly
            Assert.AreEqual(firstNode, list.head, "Head should be the first node.");
            Assert.AreEqual(thirdNode, list.tail, "Tail should be the third node.");
            Assert.AreEqual(thirdNode, firstNode.next, "First node's next should point to the third node.");
            Assert.AreEqual(firstNode, thirdNode.previous, "Third node's previous should point to the first node.");
        }

        [TestMethod]
        public void TestSearch_NodeNotFound()
        {
            var list = new DLList();
            var node = new DLLNode(1);
            list.addToTail(node);

            var result = list.search(2); // Searching for a non-existing value

            Assert.IsNull(result, "Search should return null if the node with the specified value does not exist.");
        }

        [TestMethod]
        public void TestTotal_EmptyList()
        {
            var list = new DLList();

            var total = list.total();

            Assert.AreEqual(0, total, "Total should be 0 when the list is empty.");
        }
    }
}