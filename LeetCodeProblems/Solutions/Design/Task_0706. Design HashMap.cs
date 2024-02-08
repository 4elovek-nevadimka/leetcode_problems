namespace Solutions.Design
{
    internal class Task_0706
    {
        // #Array #Hash Table #Linked List #Design #Hash Function

        public void Run()
        {
            //MyHashMap myHashMap = new MyHashMap();
            //myHashMap.Put(1, 1); // The map is now [[1,1]]
            //myHashMap.Put(2, 2); // The map is now [[1,1], [2,2]]
            //myHashMap.Get(1);    // return 1, The map is now [[1,1], [2,2]]
            //myHashMap.Get(3);    // return -1 (i.e., not found), The map is now [[1,1], [2,2]]
            //myHashMap.Put(2, 1); // The map is now [[1,1], [2,1]] (i.e., update the existing value)
            //myHashMap.Get(2);    // return 1, The map is now [[1,1], [2,1]]
            //myHashMap.Remove(2); // remove the mapping for 2, The map is now [[1,1]]
            //myHashMap.Get(2);    // return -1 (i.e., not found), The map is now [[1,1]]

            MyHashMap myHashMap = new();
            myHashMap.Remove(2);
            myHashMap.Put(3, 11);
            myHashMap.Put(4, 13);
            myHashMap.Put(15, 6);
            myHashMap.Put(6, 15);
            myHashMap.Put(8, 8);
            myHashMap.Put(11, 0);
            myHashMap.Get(11);
            myHashMap.Put(1, 10);
            myHashMap.Put(12, 14);
        }

        internal class MyHashMap
        {
            private readonly int[] _valuesMap;
            public MyHashMap()
            {
                _valuesMap = new int[1_000_001];
                Array.Fill(_valuesMap, -1);
            }

            public void Put(int key, int value)
            {
                _valuesMap[key] = value;
            }

            public int Get(int key)
            {
                return _valuesMap[key];
            }

            public void Remove(int key)
            {
                _valuesMap[key] = -1;
            }
        }

        internal class MyHashMap2
        {
            public class MyPair
            {
                public int Key { get; set; }

                public int Value { get; set; }
            }

            private List<MyPair>[] _buckets;

            private int _elementsCount = 0;

            public MyHashMap2()
            {
                _buckets = new List<MyPair>[5];
            }

            public void Put(int key, int value)
            {
                var pair = GetPair(key, out int bucketIndex);
                if (pair != null)
                {
                    pair.Value = value;
                }
                else
                {
                    if (_elementsCount == _buckets.Length)
                    {
                        _buckets = CreateNewBuckets();
                        bucketIndex = GetHashCode(key) % _buckets.Length;
                        if (_buckets[bucketIndex] == null)
                        {
                            _buckets[bucketIndex] = new List<MyPair>();
                        }
                    }
                    _buckets[bucketIndex].Add(new MyPair() { Key = key, Value = value });
                    _elementsCount++;
                }
            }

            public int Get(int key)
            {
                var pair = GetPair(key);
                return pair != null ? pair.Value : -1;
            }

            public void Remove(int key)
            {
                var pair = GetPair(key, out int bucketIndex);
                if (pair != null)
                {
                    _buckets[bucketIndex].Remove(pair);
                    _elementsCount--;
                }
            }

            private List<MyPair>[] CreateNewBuckets()
            {
                var newBuckets = new List<MyPair>[_buckets.Length * 2];
                foreach (var list in _buckets)
                {
                    if (list != null)
                    {
                        foreach (var pair in list)
                        {
                            var newBucketIndex = GetHashCode(pair.Key) % newBuckets.Length;
                            if (newBuckets[newBucketIndex] == null)
                            {
                                newBuckets[newBucketIndex] = new List<MyPair>();
                            }
                            newBuckets[newBucketIndex].Add(pair);
                        }
                    }
                }
                return newBuckets;
            }

            private MyPair GetPair(int key)
            {
                return GetPair(key, out int bucketIndex);
            }

            private MyPair GetPair(int key, out int bucketIndex)
            {
                bucketIndex = GetHashCode(key) % _buckets.Length;
                if (_buckets[bucketIndex] == null)
                {
                    _buckets[bucketIndex] = new List<MyPair>();
                }
                return _buckets[bucketIndex].FirstOrDefault(x => x.Key == key);
            }

            private int GetHashCode(int key)
            {
                unchecked
                {
                    return 37 * 397 + key.GetHashCode();
                }
            }
        }
    }
}
