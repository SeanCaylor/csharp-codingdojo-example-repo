# [Data Structures](../data_structures) Algo Schedule

---

## [Week 1 - Singly Linked Lists](../data_structures/SinglyLinkedList.js)

- [Intro](../data_structures/SinglyLinkedListIntro.js)

### Extra Linked List Algos

- [displayFolderStructure](../recursion/displayFolderStructure/displayFolderStructure.js)
- [questionMarks](../strings/questionMarks.js)

## [Week 2 - Stacks and Queues](../data_structures)

- [Stacks and Queues Intro](../data_structures/StacksAndQueues.md)
- [Stack](../data_structures/Stack.js)

### W2 Mon

- A Stack is a LIFO (Last in First Out) data structure
- Design a class to represent a stack using an array to store the items
- Create these methods for each of the Stack classes with O(1) time complexity:
  - push (adds new item and returns new size)
  - pop (returns removed item)
  - isEmpty
  - size
  - peek (return top item without removing)
- Recreate the stack class using a singly linked list to store the items instead of an array

### W2 Tue

- [Queue.js](../data_structures/Queue.js)
- A Queue is a FIFO (First in First Out) data structure
- Design a class to represent a queue using an array to store the items.
- Recreate the queue class using a singly linked list to store the items.
- Create these methods for each classes:
  - enqueue (add item, return new size)
  - dequeue (remove and return item)
  - isEmpty
  - size
  - front (return first item without removing)
- Time complexities should be as follows:
  - Array Queue: enqueue: O(1), dequeue: O(n), size: O(1), front: O(1)
  - Linked List Queue: enqueue: O(1), dequeue: O(1), size: O(1), front: O(1)

### W2 Wed

- [Queue.js](../data_structures/Queue.js)

- compareQueues
  - Write a method on the Queue class that, given another queue, will return whether they are equal (same items in same order).
  - Use ONLY the provided queue methods, do not manually index the queue items via bracket notation, use no extra array or objects.
  - Restore the queues to their original state
- queueIsPalindrome
  - Write a method on the Queue class that returns whether or not the queue is a palindrome
  - Use only 1 stack as additional storage (no additional arrays / objects).
  - Do not manually index the queue via bracket notation, use the provided queue methods and stack methods, restore the queue to original order when done.
- Extra: MinStack
  - Design a stack that supports push, pop, top, and min methods where the min method retrieves the minimum int in the stack
  - Bonus: retrieve min element in constant time (no looping).

### W2 Thur

- [sumOfHalvesEqual](../data_structures/Queue.js)
  - Create a method on the array Queue class that returns whether or not the sum of the first half of the queue is equal to the sum of the second half
  - DO NOT manually index the queue items via bracket notation, only use the provided queue methods, use no additional arrays or objects for storage.
  - Restore the queue to it's original state before returning.
- [TwoStackQueue](../data_structures/QueueUsingTwoStacks.js)

### W2 Fri

- [PriorityQueue](../data_structures/PriorityQueue.js)

  - Create enqueue and dequeue methods. _You can loop and index the underlying array._
  - Design a new PriorityQueue class where the queue maintains an ascending order when items are added based on a queue item's provided priority integer value. A priority value of 1 is most important which means it should be at the front of the queue, the first to be dequeued.
  - A priority queue item could be any data type.

## [Week 3 - Binary Search Tree](../data_structures/BinarySearchTree.js)

- [BST Intro](../data_structures/BinarySearchTree.md)

## Week 4 - Min Heap & Linked Lists Part 2

### W4 Mon - [SinglyLinkedList](../data_structures/SinglyLinkedList.js)

### W4 Tue - [DoublyLinkedList](../data_structures/DoublyLinkedList.js)

### W4 Wed - [DoublyLinkedList](../data_structures/DoublyLinkedList.js)

### W4 Thur - [Heap.js](../data_structures/Heap.js)

- [Heaps Intro](../data_structures/Heaps.md)
