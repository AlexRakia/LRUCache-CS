using System;

namespace LRUCache_CS
{
    internal class Program
    {
        private static LRUCache_CS _cache;
        static void Main(string[] args)
        {
            _cache = new LRUCache_CS(3);

            Console.WriteLine("=== Testing LRU Cache ===");

            // Add items
            _cache.AddUpdate("A", 1);
            _cache.AddUpdate("B", 2);
            _cache.AddUpdate("C", 3);

            Console.WriteLine("\nAfter adding A, B, C:");
            DisplayCache();

            // Access A (should move to head)
            _cache.Get("A", out int valueA);
            Console.WriteLine($"\nAccessed A: {valueA}");
            DisplayCache();

            // Add D (should evict B)
            _cache.AddUpdate("D", 4);
            Console.WriteLine("\nAfter adding D (should evict B):");
            DisplayCache();

            // Try to access evicted B
            //if (_cache.Get("B", out int valueB))
            //{
            //    Console.WriteLine($"\nFound B: {valueB}");
            //}
            //else
            //{
            //    Console.WriteLine("\nB was evicted (expected)");
            //}

            // Update existing key C
            _cache.AddUpdate("C", 30);
            Console.WriteLine("\nAfter updating C to 30:");
            DisplayCache();

            Console.WriteLine("Press Any Key...");
            Console.ReadKey();
        }

        public static void DisplayCache()
        {
            Console.WriteLine($"Cache (Capacity: {_cache._capacity}, Used Count: {_cache._dic.Count}):");
            Node current = _cache._linkedListHead;
            Console.Write("Head -> ");
            while (current != null)
            {
                Console.Write($"[{current._key}:{current._value}] -> ");
                current = current.Next;
            }
            Console.WriteLine("Tail");
        }
    }
}
