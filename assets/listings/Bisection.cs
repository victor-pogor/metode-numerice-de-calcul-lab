namespace LaboratorProgMetNumCalcul
{
    using LaboratorProgMetNumCalcul.Exceptions;
    using System;
    using static Table;

    public static class Bisection
    {
        public static void Solve(Func<double, double> function, ref double beginInterval, ref double endInterval, double precision)
        {
            if (beginInterval > endInterval)
            {
                throw new SolveException("Alegeti intervalele astfel, incat sa se satisfaca conditia a<b.");
            }

            if (function(beginInterval) * function(endInterval) > 0)
            {
                throw new SolveException("Valorile functiei au aceleasi semne. Alegeti alte intervale.");
            }

            double y1;
            double y2;
            double middleInterval;

            PrintRow(nameof(beginInterval), nameof(endInterval), nameof(middleInterval), nameof(precision));

            while (Math.Abs(beginInterval - endInterval) > precision)
            {
                middleInterval = (beginInterval + endInterval) / 2;
                PrintRow(beginInterval.ToString(), endInterval.ToString(), middleInterval.ToString(), Math.Abs(beginInterval - endInterval).ToString());

                y1 = function(beginInterval);
                y2 = function(middleInterval);

                if (y1 * y2 < 0)
                {
                    endInterval = middleInterval;
                }
                else
                {
                    beginInterval = middleInterval;
                }
            }
        }
    }
}
