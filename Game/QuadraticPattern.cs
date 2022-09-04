namespace Game
{
    internal sealed class QuadraticPattern<T> : Pattern<T>
    {
        private QuadraticPattern() { }

        public static readonly QuadraticPattern<T> Instance = new QuadraticPattern<T>();

        private const double A_BASE = 2;
        private const double A_MIDDLE = 3;
        private new T Layer_2() => Sum();
        public override (List<double>, List<double>) FindNext(int limit = 5)
        {
            double a = (dynamic)Base() / A_BASE;
            double b = (dynamic)Layer_1() - (A_MIDDLE * a);
            double c = (dynamic)Layer_2() - (a + b);
            List<double> topPattern = TopPattern(a, b, c, limit);
            return (topPattern, MiddlePattern(topPattern));
        }
       
    }
}
