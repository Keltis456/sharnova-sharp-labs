using System;
using System.Threading;

namespace LabsDotNet
{
    internal class Lab4
    {
        public Lab4()
        {
            //Task1();
            Task2();
        }

        private static void Task1()
        {
            Logger.LogTaskInfo();
            
            var ping = new Ping();
            var pong = new Pong();

            ping.OnPing += pong.DoPong;
            pong.OnPong += ping.DoPing;
            
            ping.DoPing();
        }

        private class Pong
        {
            public event Action OnPong;

            public void DoPong()
            {
                Thread.Sleep(1000);
                Console.WriteLine("Pong");
                OnPong?.Invoke();
            }
        }

        private class Ping
        {
            public event Action OnPing;

            public void DoPing()
            {
                Thread.Sleep(1000);
                Console.WriteLine("Ping");
                OnPing?.Invoke();
            }
        }

        private static void Task2()
        {
            Logger.LogTaskInfo();

            var rabbit = new Rabbit();
            var hunter = new Hunter();

            rabbit.OnMove += hunter.LogPosition;
            rabbit.OnMove += (x, y) => Console.WriteLine($"Lambda : Position : {x} : {y}");;
            rabbit.OnMove += delegate(int x, int y) { Console.WriteLine($"Anonymous : Position : {x} : {y}"); };
            
            rabbit.Move();
            rabbit.Move();
            rabbit.Move();
        }

        private class Hunter
        {
            public void LogPosition(int x, int y)
            {
                Console.WriteLine($"Position : {x} : {y}");
            }
        }

        private class Rabbit
        {
            private int x;
            private int y;

            public event Action<int,int> OnMove;

            public void Move()
            {
                x = new Random().Next();
                y = new Random().Next();

                OnMove?.Invoke(x, y);
            }
        }
    }

}