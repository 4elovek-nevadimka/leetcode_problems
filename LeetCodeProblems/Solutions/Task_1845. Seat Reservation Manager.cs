using System.Collections;

namespace Solutions
{
    internal class Task_1845
    {
    }

    public class SeatManager
    {

        private readonly PriorityQueue<int, int> _reservations = new();

        public SeatManager(int n)
        {
            _reservations.Enqueue(1, 1);
        }

        public int Reserve()
        {
            var reserved = _reservations.Dequeue();
            if (_reservations.Count == 0)
            {
                _reservations.Enqueue(reserved + 1, reserved + 1);
            }
            return reserved;
        }

        public void Unreserve(int seatNumber)
        {
            _reservations.Enqueue(seatNumber, seatNumber);
        }
    }

    public class SeatManager2
    {

        private readonly SortedSet<int> _reservations = new SortedSet<int>();

        public SeatManager2(int n)
        {
            for (var i = 1; i <= n; i++)
            {
                _reservations.Add(i);
            }
        }

        public int Reserve()
        {
            var toRemove = _reservations.First();
            _reservations.Remove(toRemove);
            return toRemove;
        }

        public void Unreserve(int seatNumber)
        {
            _reservations.Add(seatNumber);
        }
    }

    public class OrderedSet<T> : ICollection<T>
    {
        private readonly IDictionary<T, LinkedListNode<T>> m_Dictionary;
        private readonly LinkedList<T> m_LinkedList;

        public OrderedSet()
            : this(EqualityComparer<T>.Default)
        {
        }

        public OrderedSet(IEqualityComparer<T> comparer)
        {
            m_Dictionary = new Dictionary<T, LinkedListNode<T>>(comparer);
            m_LinkedList = new LinkedList<T>();
        }

        public int Count => m_Dictionary.Count;

        public virtual bool IsReadOnly => m_Dictionary.IsReadOnly;

        void ICollection<T>.Add(T item)
        {
            Add(item);
        }

        public bool Add(T item)
        {
            if (m_Dictionary.ContainsKey(item)) return false;
            var node = m_LinkedList.AddLast(item);
            m_Dictionary.Add(item, node);
            return true;
        }

        public void Clear()
        {
            m_LinkedList.Clear();
            m_Dictionary.Clear();
        }

        public bool Remove(T item)
        {
            if (item == null) return false;
            var found = m_Dictionary.TryGetValue(item, out var node);
            if (!found) return false;
            m_Dictionary.Remove(item);
            m_LinkedList.Remove(node);
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return m_LinkedList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Contains(T item)
        {
            return item != null && m_Dictionary.ContainsKey(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            m_LinkedList.CopyTo(array, arrayIndex);
        }
    }
}
