using System;
using System.Collections.Generic;
using System.Reflection;
using System.Diagnostics.Contracts;
using System.Text;

namespace System.Sorting
{

    /// <summary>
    /// Base class that defines the signature methods for possible derived classes 
    /// which will be implementing diffrent types of Sorting Algorithms.
    /// </summary>
    public abstract class Sorting 
    {

        public Sorting ()
        { }

        #region Methods of array of keys only 

        /// <summary>
        /// Sorts the elements of an array. 
        /// </summary>
        /// <param name="array">array to be sorted</param>
        public virtual void Sort<T>(T[] array) //where T : IComparable
        {
            if (array == null)
                throw new ArgumentNullException("array");
            Sort<T>(array, array.GetLowerBound(0), array.Length, null);
        }


        /// <summary>
        /// Sorts the elements in a section of an array. The sort compares the
        /// elements to each other using the given IComparer interface. If
        /// comparer is null, the elements are compared to each other using
        /// the IComparable interface, which in that case must be implemented
        /// by all elements in the given section of the array.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="comparer"></param>
        public virtual void Sort<T> (T[] array, IComparer<T> comparer) //where T : IComparable
        {
            if (array == null)
                throw new ArgumentNullException("array");
            Sort<T>(array, array.GetLowerBound(0), array.Length, comparer);
        }


        /// <summary>
        /// Sorts the elements in a section of an array. The sort compares the
        /// elements to each other using the IComparable interface, which
        /// must be implemented by all elements in the given section of the array.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        public virtual void Sort<T>(T[] array, int index, int length) //where T : IComparable
        {
            if (array == null)
                throw new ArgumentNullException("array");
            this.Sort<T>(array, index, length, null);
        }

              
        /// <summary>
        /// Sorts the elements in a section of an array. The sort compares the
        /// elements to each other using the given IComparer interface. If
        /// comparer is null, the elements are compared to each other using
        /// the IComparable interface, which in that case must be implemented
        /// by all elements in the given section of the array.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <param name="comparer"></param>
        public void Sort<T> (T[] array, int index, int length, IComparer<T> comparer) //where T : IComparable
        {
            if (array == null)
                throw new ArgumentNullException("array");
            if (index < 0 || length < 0)
                //throw new ArgumentOutOfRangeException((length < 0 ? "length" : "index"), Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
                throw new ArgumentOutOfRangeException((length < 0 ? "length" : "index"), "ArgumentOutOfRange_NeedNonNegNum");
            if (array.Length - index < length)
                //throw new ArgumentException(Environment.GetResourceString("Argument_InvalidOffLen"));
                throw new ArgumentException("Argument_InvalidOffLen");

            if (length < 2)
                return;
            
            //Delegating the implementation to the derived classes which will implement different types of sorting algorithms. 
            SortInternal<T>(array, index, length, comparer);
            
        }


        /// <summary>
        /// Sorts the elements in a section of an array. The sort compares the
        /// elements to each other using the given IComparer interface. If
        /// comparer is null, the elements are compared to each other using
        /// the IComparable interface, which in that case must be implemented
        /// by all elements in the given section of the array.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <param name="comparer"></param>
        internal virtual void SortInternal<T>(T[] array, int index, int length, IComparer<T> comparer) //where T : IComparable
        {
            // Each type of derived sorting Class will implement a different type of sorting algorithm
        }

        #endregion

        #region Methods of arrays of keys and values pair 

        /// <summary>
        /// Sorts the elements of two arrays based on the keys in the first array.
        /// Elements in the keys array specify the sort keys for
        /// corresponding elements in the items array. The sort compares the
        /// keys to each other using the IComparable interface, which must be
        /// implemented by all elements of the keys array.
        /// </summary>
        /// <param name="array">array to be sorted</param>
        public virtual void Sort<TKey, TValue>(TKey[] keys, TValue[] items) //where TKey : IComparable
        {
            if (keys == null)
                throw new ArgumentNullException("keys");
            Sort<TKey, TValue>(keys, items, keys.GetLowerBound(0), keys.Length, null);
        }

        /// <summary>
        /// Sorts the elements of two arrays based on the keys in the first array.
        /// Elements in the keys array specify the sort keys for
        /// corresponding elements in the items array. The sort compares the
        /// keys to each other using the given IComparer interface. If
        /// comparer is null, the elements are compared to each other using
        /// the IComparable interface, which in that case must be implemented
        /// by all elements of the keys array
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="keys"></param>
        /// <param name="items"></param>
        /// <param name="comparer"></param>
        public virtual void Sort<TKey, TValue>(TKey[] keys, TValue[] items, IComparer<TKey> comparer) //where TKey : IComparable
        {
            if (keys == null)
                throw new ArgumentNullException("keys");
            Sort<TKey>(keys, keys.GetLowerBound(0), keys.Length, comparer);
        }


        /// <summary>
        /// Sorts the elements in a section of two arrays based on the keys in the
        /// first array. Elements in the keys array specify the sort keys for
        /// corresponding elements in the items array. The sort compares the
        /// keys to each other using the given IComparer interface. If
        /// comparer is null, the elements are compared to each other using
        /// the IComparable interface, which in that case must be implemented
        /// by all elements of the given section of the keys array.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="keys"></param>
        /// <param name="items"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        public virtual void Sort<TKey, TValue>(TKey[] keys, TValue[] items, int index, int length) //where TKey : IComparable
        {
            if (keys == null)
                throw new ArgumentNullException("keys");
            Sort<TKey, TValue>(keys, items, index, length, null);
        }

        /// <summary>
        /// Sorts the elements in a section of two arrays based on the keys in the
        /// first array. Elements in the keys array specify the sort keys for
        /// corresponding elements in the items array. The sort compares the
        /// keys to each other using the given IComparer interface. If
        /// comparer is null, the elements are compared to each other using
        /// the IComparable interface, which in that case must be implemented
        /// by all elements of the given section of the keys array.
        /// </summary>
        /// <param name="keys"></param>
        /// <param name="items"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <param name="comparer"></param>
        public void Sort <TKey, TValue>(TKey[] keys, TValue[] items, int index, int length, IComparer<TKey> comparer) //where TKey : IComparable
        {
            if (keys == null)
                throw new ArgumentNullException("keys");
            if (index < 0 || length < 0)
                //throw new ArgumentOutOfRangeException((length < 0 ? "length" : "index"), Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
                throw new ArgumentOutOfRangeException((length < 0 ? "length" : "index"), "ArgumentOutOfRange_NeedNonNegNum");
            if (keys.Length - index < length || (items != null && index > items.Length - length))
                //throw new ArgumentException(Environment.GetResourceString("Argument_InvalidOffLen"));
                throw new ArgumentException("Argument_InvalidOffLen");

            if (length < 2)
                return;

            if (items == null)
            {
                Sort<TKey>(keys, index, length, comparer);
                return;
            }

            SortInternal(keys, items, index, length, comparer);
        }

        internal virtual void SortInternal<T, TValue>(T[] keys, TValue[] items, int index, int length, IComparer<T> comparer) //where T : IComparable
        {
            // Each type of derived sorting Class will implement a different type of sorting algorithm
        }
        #endregion
       
    }


}
