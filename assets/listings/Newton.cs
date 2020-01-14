namespace LaboratorProgMetNumCalcul
{
    using System;
    using static Table;

    public static class Newton
    {
        /// <summary>
        /// Solves the specified function using the Newton's method.
        /// </summary>
        /// <param name="function">The function.</param>
        /// <param name="functionDerivate">The derivative function.</param>
        /// <param name="x0">The starting point.</param>
        /// <param name="precision">The precision of the calculation.</param>
        /// <returns>Returns the solution of the function.</returns>
        public static double Solve(Func<double, double> function, Func<double, double> functionDerivate, double x0, double precision)
        {
            double x1 = x0 - function(x0) / functionDerivate(x0);
            PrintRow(nameof(x0), nameof(x1), nameof(precision));

            while (Math.Abs(x1 - x0) > precision)
            {
                PrintRow(x0.ToString(), x1.ToString(), precision.ToString());
                x0 = x1;
                x1 = x0 - function(x0) / functionDerivate(x0);
            }
            return x1;
        }
    }
}
