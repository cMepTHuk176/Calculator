namespace Calculator
{
    public static class Inaccuracy
    {
        public static double AdditiveInaccuracy(double inaccuracy, double limit) =>
            inaccuracy * limit / 100D;

        public static double MultiplicativeInaccuracy(double inaccuracy, double measured) =>
            AdditiveInaccuracy(inaccuracy, measured);

        public static double FullInaccuracy(double c, double d, double measured, double limit) =>
            ((c - d) * measured / 100D) + (d / 100D * limit);
    }
}
