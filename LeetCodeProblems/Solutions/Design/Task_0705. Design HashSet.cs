namespace Solutions.Design
{
    internal class Task_0705
    {
        // #Array #Hash Table #Linked List #Design #Hash Function

        internal class MyHashSet
        {
            private readonly bool[] _valuesMap;

            public MyHashSet()
            {
                _valuesMap = new bool[1_000_001];
            }

            public void Add(int key)
            {
                _valuesMap[key] = true;
            }

            public void Remove(int key)
            {
                _valuesMap[key] = false;
            }

            public bool Contains(int key)
            {
                return _valuesMap[key];
            }
        }
    }
}
