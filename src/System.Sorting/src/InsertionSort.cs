using System; 
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace System.Sorting
{
    public class InsertionSorting : Sorting
    {
        public InsertionSorting() { }
        internal override void SortInternal<Tkey>(Tkey[] array, int index, int length, IComparer<Tkey> comparer) 
        {

            //Cheking the input parameters conditions.
            Contract.Requires(array != null);
            Contract.Requires(index >= 0);
            Contract.Requires(length >= 0);
            Contract.Requires(length <= array.Length);
            Contract.Requires(length + index <= array.Length);

            int i, j;
            int high = index + length - 1;
            Tkey t;
            for (i = index; i < high; i++)
            {
                j = i;
                t = array[i + 1];
                while (j >= index && comparer.Compare(t, array[j]) < 0)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = t;
            }
        }


        internal override void SortInternal<TKey, TValue>(TKey[] keys, TValue[] items, int index, int length, IComparer<TKey> comparer)
        {
            Contract.Requires(keys != null);
            Contract.Requires(items != null);
            Contract.Requires(comparer != null);
            Contract.Requires(index >= 0);
            Contract.Requires(length >= 0);
            Contract.Requires(length <= keys.Length);
            Contract.Requires(length + index <= keys.Length);
            Contract.Requires(length + index <= items.Length);

            if (length < 2)
                return;

            int i, j;
            int high = length + index - 1;
            TKey t;
            TValue tValue;

            for (i = index; i < high; i++)
            {
                j = i;
                t = keys[i + 1];
                tValue = (items != null) ? items[i + 1] : default(TValue);
                while (j >= index && comparer.Compare(t, keys[j]) < 0)
                {
                    keys[j + 1] = keys[j];
                    if (items != null)
                        items[j + 1] = items[j];
                    j--;
                }
                keys[j + 1] = t;
                if (items != null)
                    items[j + 1] = tValue;
            }
        }
    }
}