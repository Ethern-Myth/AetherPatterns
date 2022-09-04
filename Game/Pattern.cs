namespace Game
{
    internal class Pattern<T> : RandomNumber<T>, IMethod<T>
    {
        private readonly T _base;
        private readonly T _layer_1;
        private readonly T _layer_2;
        private readonly T _layer_3;
        private readonly T _layer_4;
        protected Pattern()
        {
            _base = R_Number();
            _layer_1 = R_Number(11, 31);
            _layer_2 = R_Number(31, 41);
            _layer_3 = R_Number(41, 51);
            _layer_4 = R_Number(51, 61);
        }

        public virtual T Base() => _base;
        public virtual T Layer_1() => _layer_1;
        public virtual T Layer_2() => _layer_2;
        public virtual T Layer_3() => _layer_3;
        public virtual T Layer_4() => _layer_4;
        public virtual (List<double>, List<double>) FindNext(int limit = 5) =>
            (TopPattern(0, 0, 0), MiddlePattern(TopPattern(0, 0, 0)));

        protected List<double> TopPattern(double a, double b, double c, int limit=5)
        {
            List<double> pattern = new List<double>();
            for (int i = 0; i < limit; i++)
            {
                pattern.Add(a * Math.Pow(i + 1, 2) + b * (i + 1) + c);
            }
            return pattern;
        }
        protected List<double> MiddlePattern(List<double> topPattern)
        {
            double[] pattern = topPattern.ToArray();
            List<double> middle_pattern = new List<double>();
            double[] second_two = pattern[..2];
            double difference = second_two[1] - second_two[0];
            if (difference == (dynamic)Layer_1())
            {
                middle_pattern.Add(difference);
                for (int i = middle_pattern.Count; i < topPattern.Count - 1; i++)
                    middle_pattern.Add(middle_pattern.Last<double>() + Convert.ToDouble(Base()));
            }
            return middle_pattern;
        }

        protected T Sum() => (dynamic)Base() + Layer_1();
       
    }
}
