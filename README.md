# LRUCache-CS

Design a data structure that follows the constraints of a Least Recently Used (LRU) cache.

Implement the LRUCache class:

*LRUCache(int capacity) Initialize the LRU cache with positive size capacity.
*int get(int key) Return the value of the key if the key exists, otherwise return -1.
*void put(int key, int value) Update the value of the key if the key exists. -Otherwise, 
                              add the key-value pair to the cache. 
                              If the number of keys exceeds the capacity from this operation, evict the least recently used key.

The functions get and put must each run in O(1) average time complexity.
 
Example 1:

Input
["LRUCache", "put", "put", "get", "put", "get", "put", "get", "get", "get"]
[[2], [1, 1], [2, 2], [1], [3, 3], [2], [4, 4], [1], [3], [4]]
Output
[null, null, null, 1, null, -1, null, -1, 3, 4]

Explanation
LRUCache lRUCache = new LRUCache(2);
lRUCache.put(1, 1); // cache is {1=1}
lRUCache.put(2, 2); // cache is {1=1, 2=2}
lRUCache.get(1);    // return 1
lRUCache.put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
lRUCache.get(2);    // returns -1 (not found)
lRUCache.put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
lRUCache.get(1);    // return -1 (not found)
lRUCache.get(3);    // return 3
lRUCache.get(4);    // return 4
 

Constraints:

1 <= capacity <= 3000
0 <= key <= 104
0 <= value <= 105
At most 2 * 105 calls will be made to get and put.



# LRUCache-CS
LRUCache-CSharp implementation using O(1) time complex on all CRUD Operations


=== Testing LRU Cache ===
After adding A, B, C:
Cache (Capacity: 3, Used Count: 3):
Head -> [C:3] -> [B:2] -> [A:1] -> Tail

Accessed A: 1
Cache (Capacity: 3, Used Count: 3):
Head -> [A:1] -> [C:3] -> [B:2] -> Tail

After adding D (should evict B):
Cache (Capacity: 3, Used Count: 3):
Head -> [D:4] -> [A:1] -> [C:3] -> Tail

After updating C to 30:
Cache (Capacity: 3, Used Count: 3):
Head -> [C:30] -> [D:4] -> [A:1] -> Tail

S:\LRUCache-CS.exe (process 36048) exited with code 0 (0x0).
To automatically close the console when debugging stops, enable Tools->Options->Debugging->Automatically close the console when debugging stops.
Press any key to close this window . . .

