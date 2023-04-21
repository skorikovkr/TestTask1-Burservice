using System.Collections;
using System.Collections.Generic;

namespace TestTask1.Infrastructure
{
    public class MyList<T> : IEnumerable<T>
        where T : IComparable<T> 
    {
        private List<T> _list = new List<T>();

        public MyList(IEnumerable<T> elements)
        {
            foreach (var el in elements)
                _list.Add(el);
        }

        public void Sort(bool asc = true) {
            QuickSort(_list, 0, _list.Count - 1);
            if (!asc) Reverse();
        }

        public void Reverse() { 
            _list.Reverse();
        }

        private void QuickSort(List<T> list, int left, int right)
        {
            if (left >= right) return;
            int newPivot = QuickSortHelper(list, left, right);
            QuickSort(list, left, newPivot - 1);
            QuickSort(list, newPivot + 1, right);
        }

        private int QuickSortHelper(List<T> list, int left, int right) {
            var pivot = list[right];
            var i = left;
            for (int j = left; j < right; j++) {
                if (list[j].CompareTo(pivot) <= 0) {
                    var t = list[i];
                    list[i] = list[j];
                    list[j] = t;
                    i++;
                }
            }
            var temp = list[i];
            list[i] = list[right];
            list[right] = temp;
            return i;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
