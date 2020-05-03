using System;
using static System.Console;
using static System.Math;

class main{
    static void Main(){
        WriteLine("Problem A:\n");
        Func<double,double> f = (x) => Sqrt(x);
        double a = 0;
        double b = 1;
        double acc = 1e-5;
        double eps = 1e-5;
        double result1 = 2.0/3;
        double tol = acc+eps*result1;
        double Q1 = quad.adapt4(f,a,b,acc,eps);
        double error = Abs(Q1-result1);

        // Starting with the first function Sqrt(x)
        WriteLine($"Integrating the function Sqrt(x) from 0 to 1: \n");
        WriteLine($"Result from adapt4:     {Q1}");
        WriteLine($"Analytical result:      {result1}");
        WriteLine($"Deviation:              {error}");
        WriteLine($"Allowed tolerance:      {tol}");
        if(error<=tol) WriteLine("Tolerance not exceeded, test passed!");
        else WriteLine("Error exceed tolerance, test failed!");
        
        Func<double,double> f1 = (x) => 4*Sqrt(1-Pow(x,2));
        double result2 = PI;
        double tol1 = acc+eps*result2;
        double Q2 = quad.adapt4(f1,a,b,acc,eps);
        double error1 = Abs(Q2-result2);
        // Moving on to the next function 4*sqrt(1-x^2)
        WriteLine($"\nIntegrating the function 4*Sqrt(1-x^2) from 0 to 1: \n");
        WriteLine($"Result from adapt4:     {Q2}");
        WriteLine($"Analytical result:      {result2}");
        WriteLine($"Deviation:              {error1}");
        WriteLine($"Allowed tolerance:      {tol1}");
        if(error<=tol) WriteLine("Tolerance not exceeded, test passed!");
        else WriteLine("Error exceed tolerance, test failed!");


    }

}