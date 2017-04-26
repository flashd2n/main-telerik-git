using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMathTests
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
            #region AddMethodsTest
            Console.WriteLine("---------- ADD ----------");

            DisplayExecutionTime(() =>
            {
                Console.Write("Int:\t\t");
                AddTester.AddInteger();
            });

            DisplayExecutionTime(() =>
            {
                Console.Write("Long:\t\t");
                AddTester.AddLong();
            });

            DisplayExecutionTime(() =>
            {
                Console.Write("Float:\t\t");
                AddTester.AddFloat();
            });

            DisplayExecutionTime(() =>
            {
                Console.Write("Double:\t\t");
                AddTester.AddDouble();
            });

            DisplayExecutionTime(() =>
            {
                Console.Write("Decimal:\t");
                AddTester.AddDecimal();
            });

            Console.WriteLine();
            #endregion

            #region SubtractMethodsTest
            Console.WriteLine("---------- SUBTRACT ----------");

            DisplayExecutionTime(() =>
            {
                Console.Write("Int:\t\t");
                SubtractTester.SubtractInteger();
            });

            DisplayExecutionTime(() =>
            {
                Console.Write("Long:\t\t");
                SubtractTester.SubtractLong();
            });

            DisplayExecutionTime(() =>
            {
                Console.Write("Float:\t\t");
                SubtractTester.SubtractFloat();
            });

            DisplayExecutionTime(() =>
            {
                Console.Write("Double:\t\t");
                SubtractTester.SubtractDouble();
            });

            DisplayExecutionTime(() =>
            {
                Console.Write("Decimal:\t");
                SubtractTester.SubtractDecimal();
            });

            Console.WriteLine();
            #endregion

            #region IncrementMethodsTest
            Console.WriteLine("---------- INCREMENT ----------");

            DisplayExecutionTime(() =>
            {
                Console.Write("Int:\t\t");
                IncrementTester.IncrementInteger();
            });

            DisplayExecutionTime(() =>
            {
                Console.Write("Long:\t\t");
                IncrementTester.IncrementLong();
            });

            DisplayExecutionTime(() =>
            {
                Console.Write("Float:\t\t");
                IncrementTester.IncrementFloat();
            });

            DisplayExecutionTime(() =>
            {
                Console.Write("Double:\t\t");
                IncrementTester.IncrementDouble();
            });

            DisplayExecutionTime(() =>
            {
                Console.Write("Decimal:\t");
                IncrementTester.IncrementDecimal();
            });

            Console.WriteLine();
            #endregion

            #region MultiplyMethodsTest
            Console.WriteLine("---------- MULTIPLY ----------");

            DisplayExecutionTime(() =>
            {
                Console.Write("Int:\t\t");
                MultiplyTester.MultiplyInteger();
            });

            DisplayExecutionTime(() =>
            {
                Console.Write("Long:\t\t");
                MultiplyTester.MultiplyLong();
            });

            DisplayExecutionTime(() =>
            {
                Console.Write("Float:\t\t");
                MultiplyTester.MultiplyFloat();
            });

            DisplayExecutionTime(() =>
            {
                Console.Write("Double:\t\t");
                MultiplyTester.MultiplyDouble();
            });

            DisplayExecutionTime(() =>
            {
                Console.Write("Decimal: \t");
                MultiplyTester.MultiplyDecimal();
            });

            Console.WriteLine();
            #endregion

            #region DevideMethodsTest
            Console.WriteLine("---------- DIVIDE ----------");

            DisplayExecutionTime(() =>
            {
                Console.Write("Int:\t\t");
                DivideTester.DivideInteger();
            });

            DisplayExecutionTime(() =>
            {
                Console.Write("Long:\t\t");
                DivideTester.DivideLong();
            });

            DisplayExecutionTime(() =>
            {
                Console.Write("Float:\t\t");
                DivideTester.DivideFloat();
            });

            DisplayExecutionTime(() =>
            {
                Console.Write("Double:\t\t");
                DivideTester.DivideDouble();
            });

            DisplayExecutionTime(() =>
            {
                Console.Write("Decimal:\t");
                DivideTester.DivideDecimal();
            });

            Console.WriteLine();
            #endregion
        }
    }
}
