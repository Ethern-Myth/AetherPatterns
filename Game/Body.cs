using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class Body<T>
    {
        private enum Menu:int
        {
            Home, Continue, Info,
            Quad, Cubic, Quatric, Exit
        }
        public void postHeading()
        {
            Console.WriteLine();
            Console.WriteLine("Following options are available: ", Console.ForegroundColor = ConsoleColor.Cyan);
            Console.WriteLine("", Console.ForegroundColor = ConsoleColor.Magenta);
            Console.WriteLine("0. Return Home");
            Console.WriteLine("1. Continue to application");
            Console.WriteLine("2. Read information");
            Console.WriteLine("6. Exit");
        }
        public void PatternOptions()
        {
            Console.WriteLine();
            Console.WriteLine("Following pattens are available: ", Console.ForegroundColor = ConsoleColor.Cyan);
            Console.WriteLine("", Console.ForegroundColor = ConsoleColor.Magenta);
            Console.WriteLine("3. Quadratric Pattern");
            Console.WriteLine("4. Cubic Pattern");
            Console.WriteLine("5. Quartic Pattern");
            Console.WriteLine("0. Return Home");
            Console.WriteLine("6. Exit");
        }

        public int GetOption()
        {
            try
            {
                Console.WriteLine("", Console.ForegroundColor = ConsoleColor.White);
                Console.Write("Enter [0] or [1] or [2] or [6] to continue: ");
#pragma warning disable CS8604 // Possible null reference argument.
                int option = int.Parse(Console.ReadLine());
#pragma warning restore CS8604 // Possible null reference argument.
                return option;
            }
            catch 
            {
                Console.WriteLine("Option given was invalid");
                return GetOption();
            }
        }
        public int GetPatternOption()
        {
            try
            {
                Console.WriteLine("", Console.ForegroundColor = ConsoleColor.White);
                Console.Write("Enter [3] or [4] or [5] or [0] or [6] to continue: ");
#pragma warning disable CS8604 // Possible null reference argument.
                int option = int.Parse(Console.ReadLine());
#pragma warning restore CS8604 // Possible null reference argument.
                return option;
            }
            catch
            {
                Console.WriteLine("Option given was invalid");
                return GetOption();
            }
        }

        public void Display(int option)
        {
            Pattern<T> pattern;
            Console.Clear();
            var heading = new Heading();
            heading.WelcomeScreen();
            switch (option)
            {
                case (int)Menu.Home:
                    Console.Clear();
                    heading.WelcomeScreen();
                    postHeading();
                    Console.WriteLine();
                    Display(GetOption());
                    Console.WriteLine();
                    break;
                case (int)Menu.Continue:
                    Console.Clear();
                    heading.WelcomeScreen();
                    PatternOptions();
                    Display(GetPatternOption());
                    break;
                case (int)Menu.Info:
                    Console.Clear();
                    heading.WelcomeScreen();
                    var docs = new DocsReader();
                    Console.WriteLine(docs.Print(), Console.ForegroundColor = ConsoleColor.Green);
                    Console.WriteLine("", Console.ForegroundColor = ConsoleColor.White);
                    Console.WriteLine();
                    postHeading();
                    Display(GetOption());
                    break;
                case (int)Menu.Quad:
                    pattern = QuadraticPattern<T>.Instance;
                    Console.WriteLine("QUADRATIC PATTERN");
                    Console.WriteLine("\nBase Term: " + pattern.Base() + " \nFirst Layer First Term: " + pattern.Layer_1());
                    Print();
                    Console.WriteLine();
                    postHeading();
                    Display(GetOption());
                    break;
                case (int)Menu.Cubic:
                    pattern = CubicPattern<T>.Instance;
                    Console.WriteLine("CUBIC PATTERN");
                    Console.WriteLine("\nBase Term: " + pattern.Base() + " \nFirst Layer First Term: " + pattern.Layer_1()+ " \nSecond Layer First Term: " + pattern.Layer_2());
                    PrintCubic();
                    Console.WriteLine();
                    postHeading();
                    Display(GetOption());
                    break;
                case (int)Menu.Quatric:
                    pattern = QuatricPattern<T>.Instance;
                    Console.WriteLine("QUATRIC PATTERN");
                    Console.WriteLine("\nBase Term: " + pattern.Base() + " \nFirst Layer First Term: " + pattern.Layer_1() + " \nSecond Layer First Term: " + pattern.Layer_2() + " \nThird Layer First Term: " + pattern.Layer_3());
                    PrintQuartric();
                    Console.WriteLine();
                    postHeading();
                    Display(GetOption());
                    break;
                case (int)Menu.Exit:
                    Environment.Exit(0);
                    break;
                default:
                    Display(0);
                    break;
            }
        }
        private static void Print()
        {
            var pattern = QuadraticPattern<T>.Instance;
            Console.WriteLine();
            foreach (var item in pattern.FindNext().Item1)
            {
                Console.Write("{0};\t ", item);
            }
            Console.WriteLine();
            foreach (var item in pattern.FindNext().Item2)
            {
                Console.Write("{0,6}; ", item);
            }
            Console.WriteLine();
            for (int i = 0; i < pattern.FindNext().Item2.Count - 1; i++)
            {
                Console.Write("{0,8}; ", pattern.Base());
            }
        }
        private static void PrintCubic()
        {
            var pattern = CubicPattern<T>.Instance;
            Console.WriteLine();
            foreach (var item in pattern.FindNext().Item1)
            {
                Console.Write("{0};\t ", item);
            }
            Console.WriteLine();
            for (int i = 0; i < pattern.FindNext().Item2.Count; i++)
            {
                Console.Write("{0,5};\t", pattern.FindNext().Item2[i]);
            }
            Console.WriteLine();
            for (int i = 0; i < pattern.FindNext().Item3.Count-1; i++)
            {
                Console.Write("{0,6}; ", pattern.FindNext().Item3[i]);
            }
            Console.WriteLine();
            for (int i = 0; i < pattern.FindNext().Item3.Count-2; i++)
            {
                Console.Write("{0,7};", pattern.Base());
            }
        }
        private static void PrintQuartric()
        {
            var pattern = QuatricPattern<T>.Instance;
            Console.WriteLine();
            foreach (var item in pattern.FindNext().Item1)
            {
                Console.Write("{0};\t ", item);
            }
            Console.WriteLine();
            for (int i = 0; i < pattern.FindNext().Item2.Count; i++)
            {
                Console.Write("{0,5};\t", pattern.FindNext().Item2[i]);
            }
            Console.WriteLine();
            for (int i = 0; i < pattern.FindNext().Item3.Count - 1; i++)
            {
                Console.Write("{0,6}; ", pattern.FindNext().Item3[i]);
            }
            Console.WriteLine();
            for (int i = 0; i < pattern.FindNext().Item4.Count - 3; i++)
            {
                Console.Write("{0,7};", pattern.FindNext().Item4[i]);
            }
            Console.WriteLine();
            for (int i = 0; i < pattern.FindNext().Item4.Count - 5; i++)
            {
                Console.Write("{0,8}; ", pattern.Base());
            }
        }
    }
}
