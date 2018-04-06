using System;
namespace SkipList
{
    public class SkipListNode<T> where T : IComparable
    {
        public int Height => next.Length;
        public SkipListNode<T>[] next;
        public T val;

        //public SkipListNode<T> this[int index] => next[index];

        public SkipListNode(T myVal, int height)
        {
            next = new SkipListNode<T>[height];
            this.val = myVal;
        }

        public void Resize(int size)
        {
            var tmp = new SkipListNode<T>[size];
			for (int i = 0; i < next.Length; i++)
			{
                tmp[i] = next[i];
			}
            next = tmp;
        }
    }
}
