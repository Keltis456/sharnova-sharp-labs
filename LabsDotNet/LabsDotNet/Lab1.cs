using System;

namespace LabsDotNet
{
    internal class Lab1
    {
        public Lab1()
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
        }
        
        private static void Task1()
        {
            Logger.LogTaskInfo();
            
            int x1 = 1;
            Console.WriteLine(x1);
        }

        private static void Task2()
        {
            Logger.LogTaskInfo();

            string str1;
            Console.WriteLine("Ваше iм'я?");
            str1 = Console.ReadLine();
            string str2 = "Добрий день " + str1;
            Console.WriteLine(str2);
        }
        
        private static void Task3()
        {
            Logger.LogTaskInfo();

            var v1 = 'v';
            v1 = 'c';
            Console.WriteLine(v1);
        }
        
        private static void Task4()
        {
            Logger.LogTaskInfo();

            const int a = 4;
            Console.WriteLine("Периметр равен: " + a * 4);
        }
        
        private static void Task5()
        {
            Logger.LogTaskInfo();

            const int x = 1;
            const int y = 2;
            Console.WriteLine("Результат: " + (x + y) / 2);
        }
        
        private static void Task6()
        {
            Logger.LogTaskInfo();

            const int R1 = 1;
            const int R2 = 2;
            var S1 = Math.PI * Math.Pow(R1, 2);
            var S2 = Math.PI * Math.Pow(R2, 2);
            var S3 = Math.Abs(S1 - S2);

            Console.WriteLine($"Площадь первого: {S1} \n Площадь второго: {S2} \n Площадь кольца: {S3}");
        }
        
        private static void Task7()
        {
            Logger.LogTaskInfo();

            const int a = 21;
            Console.WriteLine($"{a.ToString()[0]} {a.ToString()[1]}");
        }
        
        private static void Task8()
        {
            Logger.LogTaskInfo();

            const int sec = 3000;
            Console.WriteLine($"Прошло {sec / 3600} целых часов");
        }

        private static void Task9()
        {
            Logger.LogTaskInfo();

            const int A = 16, B = 14, C = 13;
            Console.WriteLine(A < B == B < C);
        }
        
        private static void Task10()
        {
            Logger.LogTaskInfo();

            const int number = 857;
            Console.WriteLine(number.ToString().Length == 3 && number % 2 == 1);
        }
        
        private static void Task11()
        {
            Logger.LogTaskInfo();

            int i1 = 10;
            int i2 = 21;
            long l = i1 + i2;
            Console.WriteLine(l);
        }

        private static void Task12()
        {
            Logger.LogTaskInfo();

            long l1 = 30;
            long l2 = 23;
            byte b = Convert.ToByte(l1 + l2);
            Console.WriteLine(b);
        }
    }
}