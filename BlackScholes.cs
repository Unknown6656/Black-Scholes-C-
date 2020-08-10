using System;

namespace BlackScholes
{
    public enum OptionType { Put, Call }

    public static class BlackSholes
    {
        /* The Black and Scholes (1973) Stock option formula
         * C# Implementation
            S = Stock price
            X = Strike price
            T = Years to maturity
            r = Risk-free rate
            v = Volatility
        */
        public static double BlackScholes(OptionType type, double S, double X, double T, double r, double v)
        {
            double d1 = 0d;
            double d2 = 0d;
            
            d1 = (Math.Log(S / X) + (r + v * v / 2d) * T) / (v * Math.Sqrt(T));
            d2 = d1 - v * Math.Sqrt(T);

            return type switch {
                OptionType.Call => S * CND(d1) - X * Math.Exp(-r * T) * CND(d2),
                OptionType.Put => X * Math.Exp(-r * T) * CND(-d2) - S * CND(-d1),
            };
        }

        public static double CND(double X)
        {
            double L = 0d;
            double K = 0d;
            double dCND = 0d;
            const double a1 = .31938153; 
            const double a2 = -.356563782; 
            const double a3 = 1.781477937;
            const double a4 = -1.821255978;
            const double a5 = 1.330274429;

            L = Math.Abs(X);
            K = 1d / (1d + .2316419 * L);
            dCND = 1d - 1d / Math.Sqrt(2 * Math.PI) * 
                Math.Exp(-L * L / 2d) * (a1 * K + a2 * K  * K + a3 * Math.Pow(K, 3d) + 
                a4 * Math.Pow(K, 4d) + a5 * Math.Pow(K, 5d));

            return X < 0 ? 1d - dCND : dCND;
        }
    }
}
