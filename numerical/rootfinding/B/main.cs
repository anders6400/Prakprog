using System;
using static System.Console;
using static System.Math;
using System.IO;

class main{
    static void Main(){
        WriteLine("Problem B:");

        double rmax = 8;
        double eps = 1e-5;
        double evals = 0;
        Func<vector,vector> M = (v) => {
        evals++;
        double e = v[0];
        double fmax = swave(e,rmax,eps);
        return new vector(fmax);
        };
        
        // Starting point at -1.0
        vector v_0 = new vector(-1.0);
        // analytical result:
        double result = -1.0/2;
        vector root = rootfinding.newton(M, v_0, eps);
        double energy = root[0];

        WriteLine($"\nTrying to find the lowest root of the equation M(epsilon) in the vicinity of v_0 = {v_0[0]}");
        WriteLine($"Accuracy:               {eps}");
        WriteLine($"Analytical result:      {result}");
        WriteLine($"Numerical result:       {energy}");
        WriteLine($"Deviation:              {energy-result}");
        WriteLine($"Number of evaluations:  {evals}");

        var data = new StreamWriter("out.data.txt");
        for(double r=0; r<= rmax; r+=rmax/100){
            data.WriteLine($"{r} {swave(energy,r,eps)} {r*Exp(-r)}");
        }
        data.Close();
    } // Main

public static double swave(double e, double r, double acc){
    double rmin = 1e-3;
    if(r<rmin) return r-r*r;
    else{
        vector fmin = new vector(rmin-rmin*rmin, 1-2*rmin);
        Func<double, vector, vector> diff_eq = (x,f) => new vector(f[1],-2*(f[0]/x+e*f[0]));
        vector fmax = ode.rk45(diff_eq,rmin,fmin,r,acc:acc,eps:0,h:1e-3);
        return fmax[0];
    } // else
} // swave

} // main