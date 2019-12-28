namespace LaboratorProgMetNumCalcul
{
    using System;

    public static class Program
    {
        public static void Main(string[] args)
        {
            double y1, y2;

            Console.Write("Introduceti a=");
            double beginInterval = Convert.ToDouble(Console.ReadLine());

            Console.Write("Introduceti b=");
            double endInterval = Convert.ToDouble(Console.ReadLine());

            Console.Write("Introduceti e=");
            double precision = Convert.ToDouble(Console.ReadLine());

            if (beginInterval > endInterval)
            {
                Console.Write("Alegeti intervalele astfel, incit sa se satisfaca conditia a<b.");
                return;
            }

            if (CalculateFunction(beginInterval) * CalculateFunction(endInterval) > 0)
            {
                Console.Write("Valorile functiei au aceleasi semne. Alegeti alte intervale.");
                return;
            }

            while (Math.Abs(beginInterval - endInterval) > precision)
            {
                double middleInterval = (beginInterval + endInterval) / 2;

                y1 = CalculateFunction(beginInterval);
                y2 = CalculateFunction(middleInterval);

                if (y1 * y2 < 0)
                {
                    endInterval = middleInterval;
                }
                else
                {
                    beginInterval = middleInterval;
                }
            }

            Console.WriteLine($"a={beginInterval}\tb={endInterval}");
        }

        private static double CalculateFunction(double x)
        {
            return Math.Pow(x, 3) + (10 * x) - 9;
        }
    }
}