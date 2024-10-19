namespace Question2
{
    class Source
    {
        public int Add(int a, int b, int c)
        {
            return a + b + c;
        }
        public double Add(double a, double b, double c)
        {
            return a + b + c;
        }

    }

    class Program
    {
        public static void Main(string[] args)
        {
            Source source = new Source();
            source.Add(1, 2, 3);
            source.Add(1.2, 3.7, 3.2);
        }
    }

}
