using System;
using static System.Console;
using static System.Math;
using System.IO;

class main{
    public static void Main(){
        WriteLine("Problem A1:");
        WriteLine("Rosenbrock's valley function");
        // Find a minimum of the Rosenbrock's valley function f(x,y)=(1-x)^2+100*(y-x^2)^2.
        vector xstart = new vector(0.0,0.0);
        double eps = 1e-7;
        int evals = 0;
        Func<vector, double> rosenbrock = delegate(vector x){
            evals++;
            double y = (1-x[0])*(1-x[0])+100*(x[1]-x[0]*x[0])*(x[1]-x[0]*x[0]);
            return y;
        };
        vector xmin = minimization.qnewton(rosenbrock, xstart);
        vector result = new vector(1.0, 1.0);

        WriteLine("\nMinimization of Rosenbrock's valley function:");
        WriteLine($"Start value:            {xstart.toString()}");
        WriteLine($"Accuracy:               {eps}");
        WriteLine($"Minimum:                {xmin.toString()}");
        WriteLine($"Analytical minimum:     {result.toString()}");
        WriteLine($"Deviation:              {(xmin-result).toString()}");
        WriteLine($"Number of evaluations:  {evals}");

        WriteLine("\nProblem A2:");
        WriteLine("Himmelblau's function");
        // Find a minimum of the Rosenbrock's valley function f(x,y)=(1-x)^2+100*(y-x^2)^2.
        xstart = new vector(1.0,1.0);
        evals = 0;
        Func<vector, double> himmelblau = delegate(vector x){
            evals++;
            double y = Pow(x[0]*x[0]+x[1]-11,2)+Pow(x[0]+x[1]*x[1]-7,2);
            return y;
        };
        xmin = minimization.qnewton(himmelblau, xstart);
        result = new vector(3.0, 2.0);

        WriteLine("\nMinimization of Himmelblau's function:");
        WriteLine($"Start value:            {xstart.toString()}");
        WriteLine($"Accuracy:               {eps}");
        WriteLine($"Minimum:                {xmin.toString()}");
        WriteLine($"Analytical minimum:     {result.toString()}");
        WriteLine($"Deviation:              {(xmin-result).toString()}");
        WriteLine($"Number of evaluations:  {evals}");

    } // Main
} // main