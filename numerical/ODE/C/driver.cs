using System;
using static System.Math;
using static System.Console;
using System.Collections;
using System.Collections.Generic;

public partial class ode{

    public static vector rk12(Func<double, vector, vector> f, double a, vector ya, 
                            double b, double acc = 1e-3, double eps = 1e-3, double h = 0.1, 
                            List<double> xlist = null, List<vector> ylist = null, int limit = 999){
    return driver(f, a, ya, b, acc, eps, h, xlist, ylist, limit, rkstep12);
    }

    public static vector rk45(Func<double, vector, vector> f, double a, vector ya, 
                            double b, double acc = 1e-3, double eps = 1e-3, double h = 0.1, 
                            List<double> xlist = null, List<vector> ylist = null, int limit = 999){
    return driver(f, a, ya, b, acc, eps, h, xlist, ylist, limit, rkstep45);
    }

    public static vector driver(Func<double, vector, vector> f, double a, vector ya, double b, 
                            double acc, double eps, double h, List<double> xlist, List<vector> ylist,
                            int limit, Func<Func<double,vector,vector>,double, vector, double, vector[]> stepper){
    
    if(xlist!=null) {xlist.Clear(); xlist.Add(a);}
    if(ylist!=null) {ylist.Clear(); ylist.Add(ya);} 
    int steps = 0;
    while(a<b){
        if(steps>limit){
            Error.WriteLine($"ODE-driver: steps exceeded the assigned limit of {limit}");
            return ya;
        }
        if(a+h > b){
            h=b-a;
        }
        vector[] trial = stepper(f,a,ya,h);
        vector yh = trial[0];
        vector err = trial[1];
        vector tol = new vector(err.size);
        for(int i = 0; i < tol.size; i=i+1){
            tol[i] = Max(acc, Abs(yh[i])*eps)*Sqrt(h/(b-a));
            if(err[i]==0){
                err[i] = tol[i]/4;
            } // if
        } // for
        double err_factor = tol[0]/Abs(err[0]);
        for(int i = 0; i < tol.size; i=i+1){
            err_factor = Min(err_factor, Abs(tol[i]/err[i]));
        } // for
        double hnew = h*Min(Pow(err_factor,0.25)*0.95,2);
        int accept = 0;
        for(int i = 0; i<tol.size; i=i+1){
            if(Abs(err[i])>tol[i])
            accept = 1;
        } // for
        if(accept == 0){
            a += h; ya = yh; h = hnew; steps++;
            if(xlist != null) xlist.Add(a);
            if(ylist != null) ylist.Add(ya);
        } // if
        else{
            h = hnew;
            Error.WriteLine($"ODE-driver: unsuccessful step at {a}");
        } // else

    } // while
    return ya;
    } // driver

} // partial class