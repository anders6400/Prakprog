using System;
using static System.Console;
using static System.Math;
using static System.Double;

public static partial class quad{
    public static double adapt4CC(Func<double,double> f, double a, double b, 
                        double acc = 1e-3, double eps = 1e-3, int limit = 99){
        Func<double,double> F = (x) => f((a+b+(b-a)*Cos(x))/2)*Sin(x)*(b-a)/2;
        return adapt4(F,0,PI,acc,eps,limit);
    } // adapt4CC
} // quad