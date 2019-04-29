﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamToolUI.Main.Extension
{
    /// <summary>Provides generic extension methods for <seealso cref="int"/> arrays.</summary>S
    public static class IntArrayExtensions
    {
        /// <summary>Returns a string containing the ranges of an array of integers in a formatted way.</summary>
        /// <param name="s">The array of integers containing the values whose ranges to retrieve.</param>
        public static string ShowValuesWithRanges(this int[] s)
        {
            s = s.Sort(); // Sort the values
            string result = "";
            if (s.Length > 0)
            {
                int lastShownValue = s[0];
                int lastValueInCombo = s[0];
                result += lastShownValue.ToString();
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] > lastValueInCombo) // Determines whether the next value is not in a row
                    {
                        result += (result[result.Length - 1] == '-' ? s[i - 1].ToString() : "") + ", " + s[i].ToString();
                        lastValueInCombo = lastShownValue = s[i] + 1;
                    }
                    else if (s[i] == lastValueInCombo) // Determines whether the next value is in a row
                    {
                        if (i < s.Length - 1) // Determines whether the current index is not the last value
                        {
                            if (lastShownValue == lastValueInCombo) // Determines whether this is the start of a new combo
                                result += "-";
                        }
                        else if (i == s.Length - 1) // Determines whether the current index is the last value
                            result += s[i].ToString();
                        lastValueInCombo = s[i] + 1; // Set the last index in the combo to the current index
                    }
                }
            }
            return result;
        }

        /// <summary>Casts all the elements of the <seealso cref="int"/> array to <seealso cref="short"/> and returns the <seealso cref="short"/> array.</summary>
        /// <param name="a">The array of <seealso cref="int"/> whose elements to cast.</param>
        public static short[] CastToShort(this int[] a)
        {
            short[] result = new short[a.Length];
            for (int i = 0; i < a.Length; i++)
                result[i] = (short)a[i];
            return result;
        }
        /// <summary>Casts all the elements of the <seealso cref="short"/> array to <seealso cref="int"/> and returns the <seealso cref="int"/> array.</summary>
        /// <param name="a">The array of <seealso cref="short"/> whose elements to cast.</param>
        public static int[] CastToInt(this short[] a)
        {
            int[] result = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
                result[i] = a[i];
            return result;
        }
        /// <summary>Returns the maximum value within the array of integers.</summary>
        /// <param name="numbers">The array of integers whose maximum value to retrieve.</param>
        public static int Max(this int[] numbers)
        {
            int max = int.MinValue;
            for (int i = 0; i < numbers.Length; i++)
                if (numbers[i] > max)
                    max = numbers[i];
            return max;
        }
        /// <summary>Returns the minimum value within the array of integers.</summary>
        /// <param name="numbers">The array of integers whose minimum value to retrieve.</param>
        public static int Min(this int[] numbers)
        {
            int min = int.MaxValue;
            for (int i = 0; i < numbers.Length; i++)
                if (numbers[i] < min)
                    min = numbers[i];
            return min;
        }
        /// <summary>Decrements all the integers of the array by a value.</summary>
        /// <param name="a">The array of integers whose values to decrement.</param>
        /// <param name="decrement">The value to decrement the integers by.</param>
        public static int[] Decrement(this int[] a, int decrement)
        {
            for (int i = 0; i < a.Length; i++)
                a[i] -= decrement;
            return a;
        }
        /// <summary>Decrements the integers of the array within the specified range by a value.</summary>
        /// <param name="a">The array of integers whose values to decrement.</param>
        /// <param name="decrement">The value to decrement the integers by.</param>
        /// <param name="from">The first index of the integers to decrement.</param>
        /// <param name="to">The last index of the integers to decrement.</param>
        public static int[] Decrement(this int[] a, int decrement, int from, int to)
        {
            for (int i = from; i <= to; i++)
                a[i] -= decrement;
            return a;
        }
        /// <summary>Decrements all the integers of the array by one.</summary>
        /// <param name="a">The array of integers whose values to decrement by one.</param>
        public static int[] DecrementByOne(this int[] a)
        {
            for (int i = 0; i < a.Length; i++)
                a[i]--;
            return a;
        }
        /// <summary>Decrements the integers of the array within the specified range by one.</summary>
        /// <param name="a">The array of integers whose values to decrement by one.</param>
        /// <param name="from">The first index of the integers to decrement by one.</param>
        /// <param name="to">The last index of the integers to decrement by one.</param>
        public static int[] DecrementByOne(this int[] a, int from, int to)
        {
            for (int i = from; i <= to; i++)
                a[i]--;
            return a;
        }
        /// <summary>Decrements all the integers of the array by a value.</summary>
        /// <param name="a">The array of integers whose values to increment.</param>
        /// <param name="increment">The value to increment the integers by.</param>
        public static int[] Increment(this int[] a, int increment)
        {
            for (int i = 0; i < a.Length; i++)
                a[i] += increment;
            return a;
        }
        /// <summary>Decrements the integers of the array within the specified range by a value.</summary>
        /// <param name="a">The array of integers whose values to increment.</param>
        /// <param name="increment">The value to increment the integers by.</param>
        /// <param name="from">The first index of the integers to increment.</param>
        /// <param name="to">The last index of the integers to increment.</param>
        public static int[] Increment(this int[] a, int increment, int from, int to)
        {
            for (int i = from; i <= to; i++)
                a[i] += increment;
            return a;
        }
        /// <summary>Decrements all the integers of the array by one.</summary>
        /// <param name="a">The array of integers whose values to increment by one.</param>
        public static int[] IncrementByOne(this int[] a)
        {
            for (int i = 0; i < a.Length; i++)
                a[i]++;
            return a;
        }
        /// <summary>Decrements the integers of the array within the specified range by one.</summary>
        /// <param name="a">The array of integers whose values to increment by one.</param>
        /// <param name="from">The first index of the integers to increment by one.</param>
        /// <param name="to">The last index of the integers to increment by one.</param>
        public static int[] IncrementByOne(this int[] a, int from, int to)
        {
            for (int i = from; i <= to; i++)
                a[i]++;
            return a;
        }
        /// <summary>Returns a new array without the negative integer values of the original array.</summary>
        /// <param name="a">The array whose negative integer values will be removed.</param>
        public static int[] RemoveNegatives(this int[] a)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < a.Length; i++)
                if (a[i] >= 0)
                    result.Add(a[i]);
            return result.ToArray();
        }
        /// <summary>Returns a new array whose integer values are different than their respective indices in the original array.</summary>
        /// <param name="a">The array whose integer values matching their respective indices will be removed.</param>
        public static int[] RemoveElementsMatchingIndices(this int[] a)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < a.Length; i++)
                if (a[i] != i)
                    result.Add(a[i]);
            return result.ToArray();
        }
        /// <summary>Returns a new array whose integer values are different than their respective indices in the original array counting from the last index.</summary>
        /// <param name="a">The array whose integer values matching their respective indices counting from the last index will be removed.</param>
        public static int[] RemoveElementsMatchingIndicesFromEnd(this int[] a, int length)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < a.Length; i++)
                if (a[i] != length - a.Length + i)
                    result.Add(a[i]);
            return result.ToArray();
        }
        /// <summary>Returns a new array containing the indices of the integers in the array matching the specified value.</summary>
        /// <param name="a">The array whose integer indices will be returned.</param>
        /// <param name="value">The value to match.</param>
        public static int[] GetIndicesOfMatchingValues(this int[] a, int value)
        {
            List<int> indices = new List<int>();
            for (int i = 0; i < a.Length; i++)
                if (a[i] == value)
                    indices.Add(i);
            return indices.ToArray();
        }
    }
}
