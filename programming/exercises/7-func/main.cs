using System;
using static System.Console;
using static System.Math;
class main{


static Func<double,double> f = (x) => Log(x)/Sqrt(x);

static Func<double,double> g = (x) => Exp(-Pow(x,2));

static double p = 2;
static Func<double,double> h = (x) => Pow(Log(1/x),p);

static int Main(){

        const double inf=System.Double.PositiveInfinity;
        const double ninf=System.Double.NegativeInfinity;
        double a=0,b=1,result;
        result=quad.o8av(f,a,b,acc:1e-6,eps:1e-6);
        WriteLine("Calculating the integral of ln(x)/sqrt(x) from 0 to 1:");
        WriteLine(result);
        WriteLine("Analytical result: -4");
        
        double c=ninf, d=inf,result1;
        result1=quad.o8av(g,c,d);
        WriteLine("\nCalculating the integral of exp(-x^2) from -inf to inf:");
        WriteLine(result1);
        WriteLine($"Analytical result: sqrt(pi) = {Sqrt(PI)}");
        
        WriteLine("\nCalculating the integral of ln(1/x)^p from 0 to 1:");
        WriteLine("For p = 2 we have:");
        double result2;
        result2 = quad.o8av(h,a,b);
        WriteLine(result2);


    return 0;
}
}