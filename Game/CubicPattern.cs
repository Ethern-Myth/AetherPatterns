using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal sealed class CubicPattern<T> : Pattern<T>
    {
        private CubicPattern() { }
        public static readonly CubicPattern<T> Instance = new CubicPattern<T>();

        private const double A_BASE = 6;
        private const double A_FIRST_LAYER = 12;
        private const double A_SECOND_LAYER = 7;

        private const double B_FIRST_LAYER = 2;
        private const double B_SECOND_LAYER = 3;

        private double A => (dynamic)Base() / A_BASE;
        private double B => ((dynamic)Layer_1() - (A_FIRST_LAYER * A)) / B_FIRST_LAYER;
        private double C => (dynamic)Layer_2() - ((A_SECOND_LAYER * A) + (B_SECOND_LAYER * B));
        private new T Sum() => (dynamic)Base() + Layer_1() + Layer_2();
        private new T Layer_3() => Sum();
        private double D => (dynamic)Layer_3() - (A + B + C);

        private List<double> FirstLayer()
        {
            List<double> pattern = new List<double>();
            pattern.Add(Convert.ToDouble(Layer_1()));
            for (int i = pattern.Count; i < TopLayer().Count -1; i++)
            {
                pattern.Add(pattern.Last<double>() + Convert.ToDouble(Base()));
            }
            return pattern;
        }
        private List<double> SecondLayer(List<double> firstLayer)
        {
            double[] pattern = firstLayer.ToArray();
            List<double> second_layer = new List<double>();
            double[] second_one = pattern[1..2];
            double difference = second_one[0] - Convert.ToDouble(Base());
            if (difference == (dynamic)Layer_1())
            {
                second_layer.Add(Convert.ToDouble(Layer_2()));
                for (int i = second_layer.Count; i < firstLayer.Count; i++)
                    second_layer.Add(second_layer.Last<double>() + Convert.ToDouble(pattern[i-1]));
            }
            return second_layer;
        }
        private List<double> TopLayer(int limit = 10)
        {
            List<double> pattern = new List<double>();
            for (int i = 0; i < limit; i++)
            {
                pattern.Add((A * Math.Pow(i + 1, 3)) + (B * Math.Pow(i + 1, 2)) + (C * (i + 1)) + D);
            }
            return pattern;
        }

        public new (List<double>, List<double>, List<double>) FindNext(int limit = 10)
        {
            return (TopLayer(limit), SecondLayer(FirstLayer()),FirstLayer());
        }
    }
}
