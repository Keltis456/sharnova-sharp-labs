using System;
using System.Linq;

namespace LabsDotNet
{
    internal class Lab2
    {
        public Lab2()
        {
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
            Task6();
            Task7();
            Task8();
            Task9();
            Task10();
            Task11();
            Task12();
            Task13();
            Task14();
            Task15();
            Task16();
        }

        private static void Task1()
        {            
            Logger.LogTaskInfo();
            int[] array = {3,-4,5};
            var positivesCount = array.Count(x => x >= 0);
            Console.WriteLine($"Positive numbers count: {positivesCount}, negative numbers count: {array.Length - positivesCount}");
        }

        private static void Task2()
        {            
            Logger.LogTaskInfo();
        
            int[] array = {3,4,5};
        
            if (array[0] < array[1] == array[1] < array[2])
            {
                array = array.Select(x => x * 2).ToArray();
            }
            else
            {
                array = array.Select(x => x * -1).ToArray();
            }

            Console.WriteLine($"A:{array[0]} B:{array[1]} C:{array[2]}");
        }
        
        private static void Task3()
        {            
            Logger.LogTaskInfo();

            const int n = 5;
            var array = new int[n];
        
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = 1 + i * 2;
                Console.WriteLine(array[i]);
            }
        }
        
        private static void Task4()
        {            
            Logger.LogTaskInfo();

            var array = new int[5,5];

            for (var i = 0; i < array.GetLength(0); i += 2)
            for (var j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = i+1;
                Console.WriteLine(array[i, j]);
            }
        }
        
        private static void Task5()
        {            
            Logger.LogTaskInfo();

            var a = 1;
            var b = 5;
            var sum = 0;

            for (var i = a; i <= b; i++)
            {
                sum += i * i;
            }

            Console.WriteLine(sum);
        }
        
        private static void Task6()
        {            
            Logger.LogTaskInfo();

            var a = 1;
            var b = 5;

            for (var i = a; i <= b; i++)
            for (var j = 0; j < i; j++)
            {
                Console.WriteLine(i);
            }
        }
        
        private static void Task7()
        {            
            Logger.LogTaskInfo();

            var n = 9;
            while (n % 3 == 0) n /= 3;
            Console.WriteLine(n == 1);
        }
        
        private static void Task8()
        {
            Logger.LogTaskInfo();
            
            const int p = 10;
            int distance = 10, days;

            for (days = 1; distance < 200; ++days)
                distance += distance * p / 100;

            Console.WriteLine($"Days = {days}, distance = {distance}");
        }
        
        private static int Task9()
        {
            Logger.LogTaskInfo();
            
            Console.WriteLine("Enter A: ");
            var A = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter B: ");
            var B = int.Parse(Console.ReadLine());

            return A + B;
        }
        
        private static void Task10()
        {
            Logger.LogTaskInfo();

            Console.WriteLine(InvertDigits());
        }

        private static int InvertDigits(uint K = 123456) => int.Parse(K.ToString().Reverse().ToString());

        private static void Task11()
        {
            Logger.LogTaskInfo();

            TrianglePS(0, out var P, out var S);
            Console.WriteLine($"{P} {S}");
        }

        private static void TrianglePS(float a, out float P, out float S)
        {
            P = 3 * a;
            S = a * a * (float)Math.Sqrt(3) / 4;
        }
        
        private static void Task12()
        {
            Logger.LogTaskInfo();

            float X = 0, Y = 0;
            MinMax(ref X, ref Y);
            Console.WriteLine($"{X} {Y}");
        }

        private static void MinMax(ref float X, ref float Y)
        {
            if (X < Y) return;
            var tmp = X;
            X = Y;
            Y = tmp;
        }

        private static int Task13(params int[] numbers)
        {
            Logger.LogTaskInfo();

            return numbers.Sum();
        }

        private static void Task14()
        {
            Logger.LogTaskInfo();

            DigitSum(1234);
        }

        private static int DigitSum(int K)
        {
            if (K == 0) return 0;
            return (K % 10 + DigitSum(K / 10));
        }
        
        private static void Task15()
        {
            Logger.LogTaskInfo();

            Console.WriteLine(Calculate(2,2,MathOperation.add));
        }
        
        private enum MathOperation
        {
            add,
            sub,
            mul,
            div
        }

        private static float Calculate(float first, float second, MathOperation op)
        {
            return op switch
            {
                MathOperation.add => (first + second),
                MathOperation.sub => (first - second),
                MathOperation.mul => (first * second),
                MathOperation.div => (second == 0 ? 0 : first / second),
                _ => 0
            };
        }

        private static void Task16()
        {
            Logger.LogTaskInfo();

            var products = new Product[3];
            products[0].Name =  "Name";
            products[0].Date = "2021-10-10";
            products[0].Mass =  600;
            products[0].Price = 60.65f;
            products[0].Supplier = "Supplier";
            products[0].ShelfLife = "2011-12-12";
            
            products[1].Name = "Name2";
            products[1].Date = "2020-02-02";
            products[1].Mass = 600;
            products[1].Price = 60.65f;
            products[1].Supplier = "Supplier2";
            products[1].ShelfLife = "1021-12-12";
            
            products[2] = 
                new Product(
                    "Name3", 
                    "2010-09-09",
                    234,
                    234, 
                    "Supplier3",
                    "ShelfLife"
                    );
        }
    }
}