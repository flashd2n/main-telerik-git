using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms
{
    class Startup
    {
        private static void DisplayExecutionTime(Action action)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            action();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }

        private static void Main(string[] args)
        {
            #region InsertionSortAlgorithmTest
            Console.WriteLine("---------- INSERTION SORT ALGORITHM ----------");

            Console.WriteLine("Integer:");

            DisplayExecutionTime(() =>
            {
                int[] integerArray = { 7, 3, 110, -200000, 1, 0, 1, 0, 999, 91231, 13333, -700, 1, -123, 3333, 111, 222, 13, 1, 7 };

                Console.Write("\tRandom:\t");
                InsertionSortAlgorithmTester.InsertionSortAlgorithm(integerArray);
            });

            DisplayExecutionTime(() =>
            {
                int[] integerArray = { -200000, -700, -123, 0, 0, 1, 1, 1, 1, 3, 7, 7, 13, 110, 111, 222, 999, 3333, 13333, 91231 };

                Console.Write("\tSorted:\t");
                InsertionSortAlgorithmTester.InsertionSortAlgorithm(integerArray);
            });

            DisplayExecutionTime(() =>
            {
                int[] integerArray = { 91231, 13333, 3333, 999, 222, 111, 110, 13, 7, 7, 3, 1, 1, 1, 1, 0, 0, -123, -700, -200000 };

                Console.Write("\tRev:\t");
                InsertionSortAlgorithmTester.InsertionSortAlgorithm(integerArray);
            });

            Console.WriteLine("Double:");

            DisplayExecutionTime(() =>
            {
                double[] doubleArray = { 7.13, 3.11, 110.2, -200000.991, 1.0, 0, 1.0, 0, 999.0, 91231.6, 13333.1, -700.0, 1.0, -123.1, 3333.333, 111.1, 222.2, 13.3, 1.0, 7.1 };

                Console.Write("\tRandom:\t");
                InsertionSortAlgorithmTester.InsertionSortAlgorithm(doubleArray);
            });

            DisplayExecutionTime(() =>
            {
                double[] doubleArray = { -200000.991, -700, -123.1, 0, 0, 1, 1, 1, 1, 3.11, 7.1, 7.13, 13.3, 110.2, 111.1, 222.2, 999, 3333.333, 13333.1, 91231.6 };

                Console.Write("\tSorted:\t");
                InsertionSortAlgorithmTester.InsertionSortAlgorithm(doubleArray);
            });

            DisplayExecutionTime(() =>
            {
                double[] doubleArray = { 91231.6, 13333.1, 3333.333, 999, 222.2, 111.1, 110.2, 13.3, 7.13, 7.1, 3.11, 1, 1, 1, 1, 0, 0, -123.1, -700, -200000.991 };

                Console.Write("\tRev:\t");
                InsertionSortAlgorithmTester.InsertionSortAlgorithm(doubleArray);
            });

            Console.WriteLine("String:");

            DisplayExecutionTime(() =>
            {
                string[] stringArray = { "c", "test", "off", "a", "g", "debug", "int", "a", "c", "help", "off", "common", "sql", "git", "float", "char", "team", "file", "start", "int" };

                Console.Write("\tRandom:\t");
                InsertionSortAlgorithmTester.InsertionSortAlgorithm(stringArray);
            });

            DisplayExecutionTime(() =>
            {
                string[] stringArray = { "a", "a", "c", "c", "char", "common", "debug", "file", "float", "g", "git", "help", "int", "int", "off", "off", "sql", "start", "team", "test" };

                Console.Write("\tSorted:\t");
                InsertionSortAlgorithmTester.InsertionSortAlgorithm(stringArray);
            });

            DisplayExecutionTime(() =>
            {
                string[] stringArray = { "test", "team", "start", "sql", "off", "off", "int", "int", "help", "git", "g", "float", "file", "debug", "common", "char", "c", "c", "a", "a" };

                Console.Write("\tRev:\t");
                InsertionSortAlgorithmTester.InsertionSortAlgorithm(stringArray);
            });

            Console.WriteLine();
            #endregion

            #region SelectionSortAlgorithmTest
            Console.WriteLine("---------- SELECTION SORT ALGORITHM ----------");
            Console.WriteLine("Integer: ");

            DisplayExecutionTime(() =>
            {
                int[] integerArray = { 7, 3, 110, -200000, 1, 0, 1, 0, 999, 91231, 13333, -700, 1, -123, 3333, 111, 222, 13, 1, 7 };

                Console.Write("\tRandom:\t");
                SelectionSortAlgorithmTester.SelectionSortAlgorithm(integerArray);
            });

            DisplayExecutionTime(() =>
            {
                int[] integerArray = { -200000, -700, -123, 0, 0, 1, 1, 1, 1, 3, 7, 7, 13, 110, 111, 222, 999, 3333, 13333, 91231 };

                Console.Write("\tSorted:\t");
                SelectionSortAlgorithmTester.SelectionSortAlgorithm(integerArray);
            });

            DisplayExecutionTime(() =>
            {
                int[] integerArray = { 91231, 13333, 3333, 999, 222, 111, 110, 13, 7, 7, 3, 1, 1, 1, 1, 0, 0, -123, -700, -200000 };

                Console.Write("\tRev:\t");
                SelectionSortAlgorithmTester.SelectionSortAlgorithm(integerArray);
            });

            Console.WriteLine("Double:");

            DisplayExecutionTime(() =>
            {
                double[] doubleArray = { 7.13, 3.11, 110.2, -200000.991, 1.0, 0, 1.0, 0, 999.0, 91231.6, 13333.1, -700.0, 1.0, -123.1, 3333.333, 111.1, 222.2, 13.3, 1.0, 7.1 };

                Console.Write("\tRandom:\t");
                SelectionSortAlgorithmTester.SelectionSortAlgorithm(doubleArray);
            });

            DisplayExecutionTime(() =>
            {
                double[] doubleArray = { -200000.991, -700, -123.1, 0, 0, 1, 1, 1, 1, 3.11, 7.1, 7.13, 13.3, 110.2, 111.1, 222.2, 999, 3333.333, 13333.1, 91231.6 };

                Console.Write("\tSorted:\t");
                SelectionSortAlgorithmTester.SelectionSortAlgorithm(doubleArray);
            });

            DisplayExecutionTime(() =>
            {
                double[] doubleArray = { 91231.6, 13333.1, 3333.333, 999, 222.2, 111.1, 110.2, 13.3, 7.13, 7.1, 3.11, 1, 1, 1, 1, 0, 0, -123.1, -700, -200000.991 };

                Console.Write("\tRev:\t");
                SelectionSortAlgorithmTester.SelectionSortAlgorithm(doubleArray);
            });
            
            Console.WriteLine("String:");

            DisplayExecutionTime(() =>
            {
                string[] stringArray = { "c", "test", "off", "a", "g", "debug", "int", "a", "c", "help", "off", "common", "sql", "git", "float", "char", "team", "file", "start", "int" };

                Console.Write("\tRandom:\t");
                SelectionSortAlgorithmTester.SelectionSortAlgorithm(stringArray);
            });

            DisplayExecutionTime(() =>
            {
                string[] stringArray = { "a", "a", "c", "c", "char", "common", "debug", "file", "float", "g", "git", "help", "int", "int", "off", "off", "sql", "start", "team", "test" };

                Console.Write("\tSorted:\t");
                SelectionSortAlgorithmTester.SelectionSortAlgorithm(stringArray);
            });

            DisplayExecutionTime(() =>
            {
                string[] stringArray = { "test", "team", "start", "sql", "off", "off", "int", "int", "help", "git", "g", "float", "file", "debug", "common", "char", "c", "c", "a", "a" };

                Console.Write("\tRev:\t");
                SelectionSortAlgorithmTester.SelectionSortAlgorithm(stringArray);
            });

            Console.WriteLine();
            #endregion

            #region QuicksortAlgorithmTest
            Console.WriteLine("---------- QUICKSORT ALGORITHM ----------");
            Console.WriteLine("Integer: ");

            DisplayExecutionTime(() =>
            {
                int[] integerArray = { 7, 3, 110, -200000, 1, 0, 1, 0, 999, 91231, 13333, -700, 1, -123, 3333, 111, 222, 13, 1, 7 };
                int leftIntegerElementIndex = 0;
                int rightIntegerElementIndex = integerArray.Length - 1;

                Console.Write("\tRandom:\t");
                QuicksortAlgorithmTester.QuicksortAlgorithm(integerArray, leftIntegerElementIndex, rightIntegerElementIndex);
            });

            DisplayExecutionTime(() =>
            {
                int[] integerArray = { -200000, -700, -123, 0, 0, 1, 1, 1, 1, 3, 7, 7, 13, 110, 111, 222, 999, 3333, 13333, 91231 };
                int leftIntegerElementIndex = 0;
                int rightIntegerElementIndex = integerArray.Length - 1;

                Console.Write("\tSorted:\t");
                QuicksortAlgorithmTester.QuicksortAlgorithm(integerArray, leftIntegerElementIndex, rightIntegerElementIndex);
            });

            DisplayExecutionTime(() =>
            {
                int[] integerArray = { 91231, 13333, 3333, 999, 222, 111, 110, 13, 7, 7, 3, 1, 1, 1, 1, 0, 0, -123, -700, -200000 };
                int leftIntegerElementIndex = 0;
                int rightIntegerElementIndex = integerArray.Length - 1;

                Console.Write("\tRev:\t");
                QuicksortAlgorithmTester.QuicksortAlgorithm(integerArray, leftIntegerElementIndex, rightIntegerElementIndex);
            });

            Console.WriteLine("Double:");

            DisplayExecutionTime(() =>
            {
                double[] doubleArray = { 7.13, 3.11, 110.2, -200000.991, 1.0, 0, 1.0, 0, 999.0, 91231.6, 13333.1, -700.0, 1.0, -123.1, 3333.333, 111.1, 222.2, 13.3, 1.0, 7.1 };
                int leftDoubleElementIndex = 0;
                int rightDoubleElementIndex = doubleArray.Length - 1;

                Console.Write("\tRandom:\t");
                QuicksortAlgorithmTester.QuicksortAlgorithm(doubleArray, leftDoubleElementIndex, rightDoubleElementIndex);
            });

            DisplayExecutionTime(() =>
            {
                double[] doubleArray = { -200000.991, -700, -123.1, 0, 0, 1, 1, 1, 1, 3.11, 7.1, 7.13, 13.3, 110.2, 111.1, 222.2, 999, 3333.333, 13333.1, 91231.6 };
                int leftDoubleElementIndex = 0;
                int rightDoubleElementIndex = doubleArray.Length - 1;

                Console.Write("\tSorted:\t");
                QuicksortAlgorithmTester.QuicksortAlgorithm(doubleArray, leftDoubleElementIndex, rightDoubleElementIndex);
            });

            DisplayExecutionTime(() =>
            {
                double[] doubleArray = { 91231.6, 13333.1, 3333.333, 999, 222.2, 111.1, 110.2, 13.3, 7.13, 7.1, 3.11, 1, 1, 1, 1, 0, 0, -123.1, -700, -200000.991 };
                int leftDoubleElementIndex = 0;
                int rightDoubleElementIndex = doubleArray.Length - 1;

                Console.Write("\tRev:\t");
                QuicksortAlgorithmTester.QuicksortAlgorithm(doubleArray, leftDoubleElementIndex, rightDoubleElementIndex);
            });

            Console.WriteLine("String:");

            DisplayExecutionTime(() =>
            {
                string[] stringArray = { "c", "test", "off", "a", "g", "debug", "int", "a", "c", "help", "off", "common", "sql", "git", "float", "char", "team", "file", "start", "int" };
                int leftStringElementIndex = 0;
                int rightStringElementIndex = stringArray.Length - 1;

                Console.Write("\tRandom:\t");
                QuicksortAlgorithmTester.QuicksortAlgorithm(stringArray, leftStringElementIndex, rightStringElementIndex);
            });

            DisplayExecutionTime(() =>
            {
                string[] stringArray = { "a", "a", "c", "c", "char", "common", "debug", "file", "float", "g", "git", "help", "int", "int", "off", "off", "sql", "start", "team", "test" };
                int leftStringElementIndex = 0;
                int rightStringElementIndex = stringArray.Length - 1;

                Console.Write("\tSorted:\t");
                QuicksortAlgorithmTester.QuicksortAlgorithm(stringArray, leftStringElementIndex, rightStringElementIndex);
            });

            DisplayExecutionTime(() =>
            {
                string[] stringArray = { "test", "team", "start", "sql", "off", "off", "int", "int", "help", "git", "g", "float", "file", "debug", "common", "char", "c", "c", "a", "a" };
                int leftStringElementIndex = 0;
                int rightStringElementIndex = stringArray.Length - 1;

                Console.Write("\tRev:\t");
                QuicksortAlgorithmTester.QuicksortAlgorithm(stringArray, leftStringElementIndex, rightStringElementIndex);
            });

            Console.WriteLine();
            #endregion
        }
    }
}
