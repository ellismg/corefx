using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using Xunit;
using System.Text;
using System.Threading.Tasks;

namespace System.Sorting.Tests
{
    public class SortTests
    {
        [Fact]
        public static void TestSort()
        {
            IComparer<int> icomparer = new IntegerComparer();

            TestSortHelper<int>(new int[] { }, 0, 0, icomparer);
            TestSortHelper<int>(new int[] { 5 }, 0, 1, icomparer);
            TestSortHelper<int>(new int[] { 5, 2 }, 0, 2, icomparer);

            TestSortHelper<int>(new int[] { 5, 2, 9, 8, 4, 3, 2, 4, 6 }, 0, 9, icomparer);
            TestSortHelper<int>(new int[] { 5, 2, 9, 8, 4, 3, 2, 4, 6 }, 3, 4, icomparer);
            TestSortHelper<int>(new int[] { 5, 2, 9, 8, 4, 3, 2, 4, 6 }, 3, 6, icomparer);

            IComparer<string> scomparer = new StringComparer();
            TestSortHelper<String>(new string[] { }, 0, 0, scomparer);
            TestSortHelper<String>(new string[] { "5" }, 0, 1, scomparer);
            TestSortHelper<String>(new string[] { "5", "2" }, 0, 2, scomparer);

            TestSortHelper<String>(new string[] { "5", "2", null, "8", "4", "3", "2", "4", "6" }, 0, 9, scomparer);
            TestSortHelper<String>(new string[] { "5", "2", null, "8", "4", "3", "2", "4", "6" }, 3, 4, scomparer);
            TestSortHelper<String>(new string[] { "5", "2", null, "8", "4", "3", "2", "4", "6" }, 3, 6, scomparer);
        }


        private static void TestSortHelper<T>(T[] array, int index, int length, IComparer<T> comparer)
        {


            T[] control = SimpleSort<T>(array, index, length, comparer);

            //TODO - Can use Reflection to get the derivedTypes of Sorting and invoking the methods. 
            //It's not so trivial because we are using Reflection with Generic <T>. 
            //TypeInfo[] mySortTestAlgorithms = FindAllDerivedTypesOfSorting();

            Sorting[] sortAlgos = new Sorting[] { new IntroSorting(), new InsertionSorting() };
            foreach(var algo in sortAlgos)
            {
                T[] spawn = (T[])(array.Clone());
                // get instance from algo
                algo.Sort<T>(spawn, index, length, comparer);
                Assert.True(ArraysAreEqual<T>((T[])spawn, control, comparer));
            }

         }

        private static T[] SimpleSort<T>(T[] a, int index, int length, IComparer<T> comparer)
        {
            T[] result = (T[])(a.Clone());
            if (length < 2)
                return result;

            for (int i = index; i < index + length - 1; i++)
            {
                T tmp = result[i];
                for (int j = i + 1; j < index + length; j++)
                {
                    if (comparer.Compare(tmp, result[j]) > 0)
                    {
                        result[i] = result[j];
                        result[j] = tmp;
                        tmp = result[i];
                    }
                }
            }
            return result;
        }

        private static bool ArraysAreEqual<T>(T[] a, T[] b, IComparer<T> comparer)
        {
            // If the same instances were passed, this is unlikely what the test intended.
            Assert.False(Object.ReferenceEquals(a, b));

            if (a.Length != b.Length)
                return false;
            for (int i = 0; i < a.Length; i++)
            {
                if (0 != comparer.Compare(a[i], b[i]))
                    return false;
            }
            return true;
        }

        private class IntegerComparer : IComparer<int>
        {
            public int Compare(object x, object y)
            {
                return Compare((int)x, (int)y);
            }

            public int Compare(int x, int y)
            {
                return x - y;
            }
        }

        private class StringComparer : IComparer<string>
        {
            public int Compare(object x, object y)
            {
                return Compare((string)x, (string)y);
            }

            public int Compare(string x, string y)
            {
                if (x == y)
                    return 0;
                if (x == null)
                    return -1;
                if (y == null)
                    return 1;
                return x.CompareTo(y);
            }
        }

        public static  TypeInfo [] FindAllDerivedTypesOfSorting()
        {
            TypeInfo selectedType = typeof(Sorting).GetTypeInfo();

            // Find all the derived classes of the selected type. 
            Assembly asm = selectedType.Assembly;
            TypeInfo[] subTypes = (asm.DefinedTypes
                .Where(t => t.IsClass && t.IsSubclassOf(selectedType.AsType()))).ToArray();

            return subTypes;
        }
           
    }
}
