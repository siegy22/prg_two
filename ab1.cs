using System;
using System.Threading;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;

class AB1
{

    class Task1
    {
        public static string Ask(string number, string question)
        {
            Console.WriteLine(number + ": " + question);
            return Console.ReadLine();
        }

        public static string Ask(string number, string question, bool required)
        {
            Console.WriteLine(number + ": " + question);
            string answer = Console.ReadLine();
            if (required && string.IsNullOrEmpty(answer)) {
                return Ask(number, question, required);
            }
            return answer;
        }

        public static string Ask(string number, string question, bool required, bool withSparkles)
        {
            if (withSparkles) {
                return "✨" + Ask(number, question, required) + "✨";
            }

            return Ask(number, question, required);
        }
    }

    public class Task2
    {
        // NICHT abstract, weil nicht alle Tiere auf dieser Welt je in diesem Programm
        // implementiert werden.
        public class Animal
        {
            private string _name;

            public Animal(string name)
            {
                this._name = name;
            }

            public virtual void MakeSound()
            {
                Console.WriteLine("meow?");
            }

            public void SayName()
            {
                Console.WriteLine(this._name);
            }
        }

        public class Tiger : Animal
        {
            public Tiger(string name) : base(name)
            {
            }

            public override void MakeSound()
            {
                Console.WriteLine("ROAR");
            }
        }

        public class Elephant : Animal
        {
            public Elephant(string name) : base(name)
            {
            }

            public override void MakeSound()
            {
                Console.WriteLine("Töröööö");
            }
        }

        public class Zebra : Animal
        {
            public Zebra(string name) : base(name)
            {
            }

            public override void MakeSound()
            {
                Console.WriteLine("I'm a zebra");
            }
        }
    }

    public class Task3
    {
        public interface IConvertable
        {
            void Convert();
        }

        public class Data : IConvertable
        {
            public void Convert()
            {
                Console.Write("Converting Data....");
                Thread.Sleep(1000);
                Console.WriteLine("   done!");
                    }
        }

        public class Foo : IConvertable
        {
            public void Convert()
            {
                Console.Write("Converting Foo....");
                Thread.Sleep(100);
                Console.WriteLine("   done!");
            }
        }

    }

    public class Task5
    {
        public class Item : IDisposable
        {
            private string _myString;

            public Item(string myString)
            {
                this._myString = myString;
            }

            public void Dispose()
            {
                Console.WriteLine("Disposing" + this._myString);
                this._myString = String.Empty;
            }

        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("-------- Aufgabe 1 -------");
        Console.WriteLine(Task1.Ask("1", "Wie ist deine Name?"));
        Console.WriteLine(Task1.Ask("1", "Wie alt bist du? (Anwort zwingend.)", true));
        Console.WriteLine(Task1.Ask("1", "Was ist dein Hobby?", true, true));

        Console.WriteLine("-------- Aufgabe 2 -------");
        Task2.Animal cat = new Task2.Animal("Cat");
        cat.MakeSound();
        Task2.Tiger tiger = new Task2.Tiger("Tiger XYZ");
        tiger.MakeSound();

        Console.WriteLine("-------- Aufgabe 3 -------");
        List<Task3.IConvertable> list = new List<Task3.IConvertable>();
        list.Add(new Task3.Data());
        list.Add(new Task3.Foo());
        foreach (Task3.IConvertable i in list)
        {
            i.Convert();
        }

        Console.WriteLine("-------- Aufgabe 4 -------");
        Console.WriteLine("List implements IList implements ICollection");
        List<string> strList = new List<string>();
        strList.Add("Foo");
        strList.Add("Bar");
        Console.WriteLine(strList);

        Console.WriteLine("-------- Aufgabe 5 -------");
        new Task5.Item("bla");

    }
}
