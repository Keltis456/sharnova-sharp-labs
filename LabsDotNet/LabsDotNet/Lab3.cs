using System;
using System.Numerics;

namespace LabsDotNet
{
    internal class Lab3
    {
        public Lab3()
        {
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
            Task6();
            Task7();
            Task8();
        }

        private static void Task1()
        {
            Logger.LogTaskInfo();
            
            var tvset = new TvSet();
            tvset.SetChannel(5);
            tvset.PrevChannel();
            tvset.NextChannel();
            Console.WriteLine(tvset.Channel);
        }
        
        private static void Task2()
        {
            Logger.LogTaskInfo();

            Console.WriteLine(new Student("Ivan", 3, false));
            Console.WriteLine(new Student("Karl"));
            Console.WriteLine(new Student("Karoline", award: true));
        }

        private static void Task3()
        {
            Logger.LogTaskInfo();

            var audio = new Audio {Volume = 90};
            Console.WriteLine("Audio volume set to " + audio.Volume);
        }
        
        private static void Task4()
        {
            Logger.LogTaskInfo();

            var fridge = new Fridge();
            fridge.Enable();
            fridge.ChangeMode(Fridge.Mode.Frost);
        }
        
        private static void Task5()
        {
            Logger.LogTaskInfo();

            var circle = new Circle(Vector2.Zero, 100);
            Console.WriteLine(circle.GetLength());
            Console.WriteLine(circle.IsInCircle(Vector2.One));
            Console.WriteLine(circle);
        }
        
        
        private static void Task6()
        {
            Logger.LogTaskInfo();

            Console.WriteLine(new Geometric(Vector2.Zero));
            new GeometricCircle(Vector2.One, 5).Draw();
            new GeometricTriangle(Vector2.Zero, new Vector2(1,2),new Vector2(0,1), new Vector2(-1,5) ).Draw();
        }
        
        
        private static void Task7()
        {
            Logger.LogTaskInfo();

            Console.WriteLine(new Square(5).Perimeter());
            Console.WriteLine(new Cube(5).Perimeter());
        }
        
        private static void Task8()
        {
            Logger.LogTaskInfo();

            var rectangle = new Rectangle(new Vector2(50, 60), new Vector2(70, 90));
            Console.WriteLine(rectangle + " : " + rectangle.GetHashCode());
        }
    }

    internal class TvSet
    {
        public uint Channel { get; private set; }

        public void SetChannel(uint i) => Channel = i;
        public void NextChannel() => Channel++;
        public void PrevChannel() => Channel--;
    }
    
    internal class Student
    {
        private string name;
        private int course;
        private bool award;

        public Student(string name = "", int course = 1, bool award = false)
        {
            this.name = name;
            this.course = course;
            this.award = award;
        }

        public override string ToString() => $"Student {name} of {course} course with {award} award";
    }

    internal class Audio
    {
        private int volume;

        public int Volume
        {
            set
            {
                if (value >= 0 && value <= 100) 
                    volume = value;
            }
            get => volume;
        }
    }
    
    public class Fridge
    {
        public enum Mode
        {
            Normal,
            Frost,
            Defrosting
        }

        private Mode fridgeMode;
        private bool isEnabled;
        
        public void Enable()
        {
            isEnabled = true;
            Log();
        }
        
        public void Disable()
        {
            isEnabled = false;
            Log();
        }
        
        public void ChangeMode(Mode mode)
        {
            fridgeMode = mode;
            Log();
        }
        
        private void Log()
        {
            Console.WriteLine(isEnabled ? "Fridge enabled" : "Fridge disabled");
            Console.WriteLine("FridgeMode : " + fridgeMode);
        }
    }

    class Circle
    {
        private Vector2 center;
        private float radius;
        
        public Circle()
        {
            
        }

        public Circle(Vector2 center, float radius)
        {
            this.center = center;
            this.radius = radius;
        }

        public double GetLength() => 2 * Math.PI * radius;
        public static double GetLength(float radius) => 2 * Math.PI * radius;
        
        public Circle CreateCircle() => new Circle(center, radius);
        public Circle CreateCircle(Vector2 center, float radius) => new Circle(center, radius);

        public bool IsInCircle(Vector2 point) =>
            Math.Pow(point.X - center.X, 2) + Math.Pow(point.Y - center.Y, 2) < radius * radius;

        public override string ToString() => $"Center : {center} Radius : {radius}";
    }

    internal class Geometric
    {
        protected readonly Vector2 Center;

        public Geometric(Vector2 center)
        {
            this.Center = center;
        }
    }

    internal class GeometricCircle : Geometric
    {
        private float radius;
        
        public GeometricCircle(Vector2 center, float radius) : base(center)
        {
            this.radius = radius;
        }

        public void Draw()
        {
            Console.WriteLine(this);
        }
    }
    
    internal class GeometricTriangle : Geometric
    {
        private Vector2 x,y,z;
        
        public GeometricTriangle(Vector2 center, Vector2 x, Vector2 y, Vector2 z) : base(center)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public void Draw()
        {
            Console.WriteLine(this);
        }
    }

    internal class Square
    {
        protected readonly float A;

        public Square(float a)
        {
            this.A = a;
        }

        public virtual float Perimeter() => A * 4;
    }

    internal class Cube : Square
    {
        public Cube(float a) : base(a)
        {
        }

        public override float Perimeter() => A * 12;
    }

    internal class Rectangle
    {
        private readonly Vector2 a;
        private readonly Vector2 b;

        public Rectangle(Vector2 a, Vector2 b)
        {
            this.a = a;
            this.b = b;
        }

        public override string ToString()
        {
            return $"A : {a} B : {b}";
        }
        public override bool Equals(object obj)
        {
            return ((Rectangle) obj)?.a == a && ((Rectangle) obj).b == b;
        }

        public override int GetHashCode()
        {
            return 21;
        }
    }
}