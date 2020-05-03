using System;
using static System.Console;
using static System.Math;

class main{
    static void Main(){
        WriteLine("Problem A:");

        // Finding first root of Cos(x). Result should be pi/2
        int evals = 0; 
        Func<vector,vector> cos = (x) => {
        evals++; 
        return new vector(Cos(x[0]));
        };
        // Starting point at 1.0
        vector x_0 = new vector(1.0);
        // precision
        double eps = 1e-4;
        // analytical result:
        double result = PI/2;
        vector root = rootfinding.newton(cos, x_0, eps);

        WriteLine($"\nTrying to find the first root of Cos(x) in the vicinity of x_0 = {x_0[0]}");
        WriteLine($"Accuracy:               {eps}");
        WriteLine($"Analytical result:      {result}");
        WriteLine($"Numerical result:       {root[0]}");
        WriteLine($"Deviation:              {root[0]-result}");
        WriteLine($"Number of evaluations:  {evals}");

        // Moving on to find the first extremum point of the Rosenbrock function
        evals = 0;
        Func<vector, vector> rosenbrock = (z) => {
            evals++;
            return new vector(-2*(1-z[0]+200*z[0]*(z[1]-z[0]*z[0])), 200*(z[1]-z[0]*z[0]));
        };
        // Starting point at (0.5, 1.5)
        vector z_0 = new vector(0.5, 1.5);
        // precision
        double eps1 = 1e-5;
        // analytical result:
        vector result1 = new vector (1.0, 1.0);
        vector root1 = rootfinding.newton(rosenbrock, z_0, eps1);

        WriteLine($"\nTrying to find the first extremum of the Rosenbrock function in the vicinity of z_0 = {z_0.toString()}");
        WriteLine($"Accuracy:               {eps1}");
        WriteLine($"Analytical result:      {result1.toString()}");
        WriteLine($"Numerical result:       {root1.toString()}");
        WriteLine($"Deviation:              {(root1-result1).toString()}");
        WriteLine($"Number of evaluations:  {evals}");  
    } // Main

} // main