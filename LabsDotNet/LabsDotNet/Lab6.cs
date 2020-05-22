using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;

namespace LabsDotNet
{
    internal class Lab6
    {
        public Lab6()
        {
            // Task1();
            // Task2();
            Task3();
            // Task4();
            // Task5();
            // Task6();
            //Task7();
        }

        private static void Task1()
        {
            Logger.LogTaskInfo();
            
            var input = File.ReadLines($"Lab6_Task1_input.txt").ToList();

            for (var i = 0; i < input.Count; i++)
            {
                new Thread(a =>
                {
                    if ("yolo" == input[(int)a])
                    {
                        Console.WriteLine($"line {(int)a + 1} with word yolo");
                    }
                }).Start(i);
            }
        }

        private static readonly double[,] MainMatrix = new double[5,5];
        private static readonly double[] MainVector = new double[5];
        private static readonly double[] ResultVector = new double[5];
        
        private static void Task2()
        {
            Logger.LogTaskInfo();

            var random = new Random();

            for (var i1 = 0; i1 < MainMatrix.GetLength(0); i1++)
            {
                for (var j = 0; j < MainMatrix.GetLength(1); j++)
                {
                    MainMatrix[i1,j] = random.Next(0, 5);
                    Console.Write(MainMatrix[i1,j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            for (var i2 = 0; i2 < MainVector.Length; i2++)
            {
                MainVector[i2] = random.Next(0, 5);
                Console.Write(MainVector[i2] + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
            Thread thread = null;

            for (var i = 0; i < MainMatrix.GetLength(0); i++)
            {
                thread = new Thread(obj =>
                {
                    for (var v = 0; v < MainVector.Length; v++)
                    {
                        ResultVector[(int)obj] += MainMatrix[(int)obj,v] * MainVector[v];
                    }
                });
                thread.Start(i);
            }

            thread?.Join();

            foreach (var item in ResultVector)
            {
                Console.Write(item + " ");
            }
        }

        private static void Task3()
        {
            Logger.LogTaskInfo();
            
            var army1 = new Army(30, "White");
            var army2 = new Army(30, "Red");
            
            army1.Enemy = army2;
            army2.Enemy = army1;
            new Thread(Fight).Start(army1);
            new Thread(Fight).Start(army2);
        }

        private static void Fight(object armyObject)
        {
            var army = (Army)armyObject;

            while (army.Soldiers > 0 && army.Enemy.Soldiers > 0)
            {
                army.Attack();
                army.Heal();
            }
            if (army.Soldiers > 0)
            {
                Console.WriteLine($"{army.Title} win");
                Console.WriteLine($"{army.Enemy.Title} lost");
            }
        }

        private class Army
        {
            public int Soldiers { private set; get; }
            public Army Enemy;
            public readonly string Title;

            public Army(int soldiers, string title)
            {
                Soldiers = soldiers;
                Title = title;
            }

            public void Attack()
            {
                var killAmount = new Random().Next(5, 10);
                Enemy.Soldiers -= killAmount;
                Console.WriteLine($"{Title} army kills {killAmount} soldiers of {Enemy.Title} army and they now have {Enemy.Soldiers}");
            }

            public void Heal()
            {
                var healAmount = new Random().Next(1, 5);
                Soldiers += healAmount;
                Console.WriteLine($"{Title} army heals {healAmount} soldiers and now has {Soldiers} army");
                Thread.Sleep(1000);
            }
        }
        
        
        private static void Task4()
        {
            Logger.LogTaskInfo();

            var sheeps = new List<Vector2>()
            {
                RandomPosition(),
                RandomPosition(),
                RandomPosition()
            };

            while (sheeps.Count > 0 && sheeps.Count < 20)
            {
                var wolf = RandomPosition();
                Console.WriteLine($"Wolf at {wolf}");

                for (var index = 0; index < sheeps.Count; index++) sheeps[index] = RandomPosition();
                sheeps.ForEach(sheep => Console.WriteLine($"Sheep at {sheep}"));

                var eaten = sheeps.RemoveAll(sheep => sheep == wolf);
                var born = sheeps.Count(sheep => sheeps.Count(x => x == sheep) > 1);

                for (var i = 0; i < born; i++)
                {
                    sheeps.Add(RandomPosition());
                    Console.WriteLine($"New sheep was born!");
                }

                Console.WriteLine($"{eaten} sheeps eaten");
                Console.WriteLine("");
                
                Thread.Sleep(100);
            }
            
            if (sheeps.Count <= 0) Console.WriteLine("Sheeps lost!");
            if (sheeps.Count >= 20) Console.WriteLine("Sheeps won!");
            static Vector2 RandomPosition() => new Vector2(new Random().Next(0, 4), new Random().Next(0, 4));
        }
        
        private static void Task5()
        {
            Logger.LogTaskInfo();

            const string primeNumbersOutput = @"PrimeNumbers.txt";
            const string fibonacciNumbersOutput = @"FibonacciNumbers.txt";

            var simpleNumbersThread  = new Thread(() =>
            {
                using var sw = new StreamWriter( primeNumbersOutput);
                for (var i = 1; i < 200; i++)
                {
                    if (IsPrimeNumber(i))
                    {
                        sw.WriteLine(i.ToString());
                    }
                }
            });

            var fibonacciThread = new Thread(() =>
            {
                using var sw = new StreamWriter(fibonacciNumbersOutput);
                var first = 0;
                var second = 1;
                sw.WriteLine(first.ToString());
                for (var i = 0; i < 10; i++)
                {
                    var aux = first;
                    first = second;
                    second += aux;
                    sw.WriteLine(first.ToString());
                }
            });
            simpleNumbersThread.Start();
            fibonacciThread.Start();          
            
            simpleNumbersThread.Join();
            fibonacciThread.Join();

            CountNumbers(primeNumbersOutput);
            CountNumbers(fibonacciNumbersOutput);
        }

        private static void CountNumbers(string path)
        {
            using var sw = new StreamReader(path);
            string line;
            var count = 0;
            while ((line = sw.ReadLine()) != null)
            {
                count++;
                Console.Write($"{line}, ");
            }

            Console.WriteLine($"\nКоличество чисел в файле {path.Substring(path.LastIndexOf("/") + 1)} = {count}\n");
        }

        private static bool IsPrimeNumber(int n)
        {
            for (var i = 2; i < n/2; i++)
                if (n % i == 0)
                    return false;

            return n > 1;
        }
        
        private static void Task6()
        {
            Logger.LogTaskInfo();
            
            const string data = @"Task6.txt";
            var writeFileThread = new Thread(() =>
            {
                Console.WriteLine("Ввод данных в файл");
                var rand = new Random();
                using var writer = new StreamWriter(data);
                for (var i = 1; i < 10; i++)
                {
                    writer.WriteLine(rand.Next(100));
                }
            });
            
            
            var readFileThread = new Thread(() =>
            {
                using var reader = new StreamReader(data);
                string line;
                Console.WriteLine("Вывод данных из файла");
                while ((line = reader.ReadLine()) != null)
                {
                    Console.Write($"{line}, ");
                }
            });
            
            writeFileThread.Start();
            writeFileThread.Join();
            readFileThread.Start();
            readFileThread.Join();
        }
        
        private static void Task7()
        {
            Logger.LogTaskInfo();

            new Thread(obj =>
            {
                var x = (int) obj;
                int a = 1, b = 1;
                double W = 1;
                while (true)
                {
                    W += a * Math.Sin(b * x);
                    a *= 2;
                    W -= a * Math.Cos(b * x);
                    a *= 2;
                    b++;
                    Console.WriteLine($"Новое значение: {W}");
                    Thread.Sleep(1000);
                }
            }).Start(2);
        }
    }
}