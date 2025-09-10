using System;
using System.Collections.Generic;

namespace LRUCache_CS
{
    internal class Node
    {
        public string _key;
        public int _value;
        public Node Prev = null;
        public Node Next = null;

        public Node(string key, int value)
        {
            _key = key;
            _value = value;
            Prev = null;
            Next = null;
        }
    }

    internal class LRUCache_CS
    {
        public int _capacity;
        public Node _linkedListHead = null; // Doubly-Linked List
        public Node _linkedListTail = null;
        public Dictionary<string, Node> _dic;


        // Constructor
        public LRUCache_CS(int capacity)
        {
            if (capacity < 1)
                throw new ArgumentOutOfRangeException("Capacity should be positive (Greater than Zero)");
            _capacity = capacity;
            _dic = new Dictionary<string, Node>();
            _linkedListHead = _linkedListTail = null;
        }

        private void MoveToHead(Node requestedNode)
        {
            if (requestedNode == _linkedListHead)
            {   // Already at head, nothing to do
                return;
            }

            // Update tail if we're moving the tail node
            if (requestedNode == _linkedListTail)
            {
                _linkedListTail = requestedNode.Prev;
                if (_linkedListTail != null)
                {
                    _linkedListTail.Next = null;
                }
            }

            // Disconnect the requested node from its current position
            if (requestedNode.Prev != null)
                requestedNode.Prev.Next = requestedNode.Next;
            if (requestedNode.Next != null)
                requestedNode.Next.Prev = requestedNode.Prev;

            // Put the requested node at the head of the linkedList
            requestedNode.Prev = null; // Clear prev pointer
            requestedNode.Next = _linkedListHead;

            if (_linkedListHead != null)
                _linkedListHead.Prev = requestedNode;

            _linkedListHead = requestedNode;  // Put the requested node at the head 
        }


        public void AddUpdate(string key, int value)
        {
            if (_linkedListHead == null)
            {
                // Case 1: The list needs to be created: O(1)
                _linkedListHead = _linkedListTail = new Node(key, value);
                _dic.Add(key, _linkedListHead);
            }
            else
            {
                // Case 2: The list is already created
                if (_dic.ContainsKey(key))
                {
                    _dic[key]._value = value;   // Case 2.1:  Simple update case: O(1)
                    // move the node to the head
                    MoveToHead(_dic[key]);
                }
                else
                {
                    // Case 2.2:
                    // The list doesn't have the given key, so we need to add it
                    if (_dic.Count >= _capacity)
                    {
                        // Case 2.2.1: Capacity could be exceeded
                        // We remove the "least recently used" node from the structure,
                        // which is to be found as the tail of the linked list.
                        var lruKey = _linkedListTail._key;
                        _linkedListTail = _linkedListTail.Prev;
                        if (_linkedListTail != null)
                            _linkedListTail.Next = null;
                        _dic.Remove(lruKey);  // Made a room for a new node
                        if (_dic.Count == 0)
                        {
                            // Case 2.2.1.1: Structure became empty
                            _linkedListHead = null;  // Edge case when there is no element remained in the structure
                            _linkedListHead = _linkedListTail = new Node(key, value);
                        }
                        else
                        {
                            // Case 2.2.1.2: Structure still has elements
                            var oldHead = _linkedListHead;
                            _linkedListHead = new Node(key, value);
                            _linkedListHead.Next = oldHead;
                            oldHead.Prev = _linkedListHead;
                        }
                        _dic.Add(key, _linkedListHead); // adding the new node
                    }
                    else
                    {
                        // Case: capacity will not be exceeded, we add the node to the head 
                        var oldHead = _linkedListHead;
                        _linkedListHead = new Node(key, value);
                        _linkedListHead.Next = oldHead;
                        oldHead.Prev = _linkedListHead;
                        _dic.Add(key, _linkedListHead);
                    }
                }
            }
        }

        public bool Get(string key, out int value)
        {
            if (_dic.Count < 1)
                throw new Exception("Empty structure");

            if (!_dic.ContainsKey(key))
                throw new KeyNotFoundException("The requested Key was not found in the cache");

            value = _dic[key]._value;

            var requestedNode = _dic[key];  // The node containing the requested key
            // Already at head, nothing to do
            MoveToHead(requestedNode);
            return true;
        }
    }
}