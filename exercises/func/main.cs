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
        WriteLine(result);
        
        double c=ninf, d=inf,result1;
        result1=quad.o8av(g,c,d);
        WriteLine(result1);
        
        double result2;
        result2 = quad.o8av(h,a,b);
        WriteLine(result2);

    return 0;
}
}