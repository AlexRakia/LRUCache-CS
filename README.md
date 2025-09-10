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

