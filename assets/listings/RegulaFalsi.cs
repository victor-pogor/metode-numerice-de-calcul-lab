namespace LaboratorProgMetNumCalcul
{
    using LaboratorProgMetNumCalcul.Exceptions;
    using System;
    using static Table;

    public static class RegulaFalsi
    {
        public static double Solve(Func<double, double> function, double beginInterval, double endInterval, double precision)
        {
            if (beginInterval > endInterval)
            {
                throw new SolveException("Alegeti intervalele astfel, incat sa se satisfaca conditia a<b.");
            }

            if (function(beginInterval) * function(endInterval) > 0)
            {
                throw new SolveException("Valorile functiei au aceleasi semne. Alegeti alte intervale.");
            }

            int i = 0;
            double middleInterval;

            PrintRow(nameof(beginInterval), nameof(endInterval), nameof(middleInterval), nameof(precision));

            do
            {
                middleInterval = (beginInterval * function(endInterval) - endInterval * function(beginInterval)) / (function(endInterval) - function(beginInterval));
                PrintRow(beginInterval.ToString(), endInterval.ToString(), middleInterval.ToString(), Math.Abs(function(middleInterval)).ToString());
                i++;

                if (function(beginInterval) * function(middleInterval) > 0)
                {
                    beginInterval = middleInterval;
                }
                else
                {
                    endInterval = middleInterval;
                }

            } while (Math.Abs(function(middleInterval)) > precision);

            return middleInterval;
        }
    }
}
