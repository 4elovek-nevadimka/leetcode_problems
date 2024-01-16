namespace Solutions.Design
{
    internal class Task_0380
    {
        public class RandomizedSet
        {

            private Random _random = new Random();
            private List<int> _list = new List<int>();
            private HashSet<int> _hash = new HashSet<int>();

            public RandomizedSet()
            {

            }

            public bool Insert(int val)
            {
                var result = _hash.Add(val);
                if (result)
                    _list.Add(val);
                return result;
            }

            public bool Remove(int val)
            {
                var result = _hash.Remove(val);
                if (result)
                    _list.Remove(val);
                return result;
            }

            public int GetRandom()
            {
                return _list[_random.Next(_list.Count)];
            }
        }

        public class RandomizedSet2
        {
            private readonly Random _random = new();
            private readonly List<int> _list = new();
            private readonly Dictionary<int, int> _dic = new();

            public RandomizedSet2() { }

            public bool Insert(int val)
            {
                if (_dic.ContainsKey(val))
                    return false;

                _list.Add(val);
                _dic[val] = _list.Count - 1;
                return true;
            }

            public bool Remove(int val)
            {
                if (!_dic.ContainsKey(val))
                    return false;

                var lastItem = _list[^1];
                var itemIndex = _dic[val];

                _list[itemIndex] = lastItem;
                _dic[lastItem] = itemIndex;

                _list.RemoveAt(_list.Count - 1);
                _dic.Remove(val);

                return true;
            }

            public int GetRandom()
            {
                return _list[_random.Next(_list.Count)];
            }
        }

        /**
         * Your RandomizedSet object will be instantiated and called as such:
         * RandomizedSet obj = new RandomizedSet();
         * bool param_1 = obj.Insert(val);
         * bool param_2 = obj.Remove(val);
         * int param_3 = obj.GetRandom();
         */
    }
}
