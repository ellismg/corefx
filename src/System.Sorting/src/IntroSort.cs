using System.Collections.Generic;

namespace System.Sorting
{
    public class IntroSorting : Sorting
    {
        public IntroSorting()
        { }
        internal override void SortInternal<TKey>(TKey[] array, int index, int length, IComparer<TKey> comparer)
        {
            //It will call the current clr of Array.Sort Implementation; Just a wrap 
            Array.Sort<TKey>(array, index, length, comparer);
        }
        internal override void SortInternal<TKey, TValue>(TKey[] keys, TValue[] items, int index, int length, IComparer<TKey> comparer)
        {
            //It will call the current clr of Array.Sort Implementation; Just a wrap 
            Array.Sort<TKey, TValue>(keys, items, index, length, comparer);
        }
    }
}