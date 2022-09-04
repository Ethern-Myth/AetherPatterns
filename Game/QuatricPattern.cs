namespace Game
{
    internal sealed class QuatricPattern<T> : Pattern<T>
    {
        private const double A_BASE = 24;
        private const double A_FIRST_MIDDLE = 60;
        private const double A_SECOND_MIDDLE = 50;
        private const double A_THIRD_MIDDLE = 15;

        private const double B_FIRST_MIDDLE = 6;
        private const double B_SECOND_MIDDLE = 12;
        private const double B_THIRD_MIDDLE = 7;

        private const double C_SECOND_MIDDLE = 2;
        private const double C_THIRD_MIDDLE = 3;

        private QuatricPattern() {  }
        public static readonly QuatricPattern<T> Instance = new QuatricPattern<T>();

        private double A => (dynamic)Base() / A_BASE;
        private double B => ((dynamic)Layer_1() - (A_FIRST_MIDDLE * A)) / B_FIRST_MIDDLE;
        private double C => ((dynamic)Layer_2() - ((A_SECOND_MIDDLE * A) + (B_SECOND_MIDDLE * B))) / C_SECOND_MIDDLE;
        private double D => ((dynamic)Layer_3() - ((A_THIRD_MIDDLE * A) + (B_THIRD_MIDDLE * B) + (C_THIRD_MIDDLE * C)));
        private new T Sum() => (dynamic)Base() + Layer_1() + Layer_2() + Layer_3();
        private new T Layer_4() => Sum();
        private double E => (dynamic)Layer_4() - (A + B + C + D);
        private List<double> TopPattern(int limit= 10)
        {
            List<double> pattern = new List<double>();
            for (int i = 0; i < limit; i++)
            {
                pattern.Add((A * Math.Pow(i + 1, 4)) + (B * Math.Pow(i + 1, 3)) + (C * Math.Pow(i + 1, 2)) + (D * (i + 1)) + E);
            }
            return pattern;
        }
        private List<double> FirstLayer()
        {
            List<double> pattern = new List<double>();
            pattern.Add(Convert.ToDouble(Layer_1()));
            for (int i = pattern.Count; i < TopPattern().Count; i++)
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
                for (int i = second_layer.Count; i < firstLayer.Count - 1; i++)
                    second_layer.Add(second_layer.Last<double>() + Convert.ToDouble(pattern[i - 1]));
            }
            return second_layer;
        }
        private List<double> ThirdLayer(List<double> secondLayer)
        {
            double[] pattern = secondLayer.ToArray();
            List<double> third_layer = new List<double>();
            double[] second_one = pattern[1..2];
            double difference = second_one[0] - Convert.ToDouble(Layer_1());
            if (difference == (dynamic)Layer_2())
            {
                third_layer.Add(Convert.ToDouble(Layer_3()));
                for (int i = third_layer.Count; i < secondLayer.Count; i++)
                    third_layer.Add(third_layer.Last<double>() + Convert.ToDouble(pattern[i - 1]));
            }
            return third_layer;
        }

        public new (List<double>, List<double>, List<double>, List<double>) FindNext(int limit = 10)
        {
            return (TopPattern(limit), ThirdLayer(SecondLayer(FirstLayer())),SecondLayer(FirstLayer()), FirstLayer());
        }
    }
}
