using System;
using static System.Console;
using static System.Math;
using static System.Double;

public static partial class quad{
    public static double adapt4(Func<double,double> f, double a, double b,
                    double acc=1e-3, double eps=1e-3, int limit=99, double f2 = NaN, double f3 = NaN){
    double dx = b-a;
    double f1 = f(a+dx/6.0);
    double f4 = f(a+5*dx/6.0);
    if(IsNaN(f2)){
        f2 = f(a+2*dx/6.0);
        f3 = f(a+4*dx/6.0);
    } // if
    double Q = (2*f1+f2+f3+2*f4)/6.0*dx;
    double q = (f1+f2+f3+f4)/4*dx;
    double err = Abs(Q-q)/1.9;
    if(limit == 0){
        Error.WriteLine($"Adapt: limit reached: a={a} b={b}");
        return Q;
    } // if
    if(err < acc+eps*Abs(Q)){
        return Q;
    } // if
    else{
        double q1 = adapt4(f,a,(a+b)/2.0,acc/Sqrt(2),eps,limit-1,f1,f2);
        double q2 = adapt4(f,(a+b)/2,b,acc/Sqrt(2),eps,limit-1,f3,f4);
        Q = q1+q2;
        return Q;
        
    }  // else

    } // adapt4



} // quad