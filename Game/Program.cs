using System.Runtime.InteropServices;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var pattern = QuatricPattern<int>.Instance;
            //Console.WriteLine("Base: " + pattern.Base());
            //Console.WriteLine("Layer 1: " + pattern.Layer_1());
            //Console.WriteLine("Layer 2: "+ pattern.Layer_2());
            //Console.WriteLine("Layer 3: "+ pattern.Layer_3());
            //Console.WriteLine("Layer 4: " + pattern.Layer_4());

            //Console.WriteLine();

            //foreach (var item in pattern.FindNext().Item1)
            //{
            //    Console.Write("{0};\t ", item);
            //}
            //Console.WriteLine();
            //for (int i = 0; i < pattern.FindNext().Item2.Count; i++)
            //{
            //    Console.Write("{0,5};\t", pattern.FindNext().Item2[i]);
            //}
            //Console.WriteLine();
            //for (int i = 0; i < pattern.FindNext().Item3.Count-1; i++)
            //{
            //    Console.Write("{0,6}; ", pattern.FindNext().Item3[i]);
            //}
            //Console.WriteLine();
            //for (int i = 0; i < pattern.FindNext().Item4.Count-3; i++)
            //{
            //    Console.Write("{0,7};", pattern.FindNext().Item4[i]);
            //}
            //Console.WriteLine();
            //for (int i = 0; i < pattern.FindNext().Item4.Count-5; i++)
            //{
            //    Console.Write("{0,8}; ", pattern.Base());
            //}


            var heading = new Heading();
            var body = new Body<int>();
            heading.WelcomeScreen();
            body.postHeading();
            body.Display(body.GetOption());
            Console.ReadLine();
        }
    }
}