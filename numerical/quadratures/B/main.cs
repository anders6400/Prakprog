using System;
using static System.Console;
using static System.Math;

class main{
    static void Main(){
        WriteLine("Problem B:\n");
        int evals = 0;
        Func<double,double> f1 = (x) => {evals++; return 1/Sqrt(x);};
        double a = 0;
        double b = 1;
        double acc = 1e-4;
        double eps = 1e-4;
        double result1 = 2.0;
        double tol1 = acc+eps*Abs(result1);
        
        // adapt4
        double Q1 = quad.adapt4(f1,a,b,acc,eps);
        int evals_adapt4 = evals;
        double error1 = Abs(Q1-result1);

        // adapt4CC
        evals = 0;
        double QCC1 = quad.adapt4CC(f1,a,b,acc,eps);
        int evals_adapt4CC = evals;
        double errorCC1 = Abs(QCC1-result1);
        

        // Starting with the first function 1/Sqrt(x)
        WriteLine($"Integrating the function 1/Sqrt(x) from {a} to {b}: \n");
        WriteLine($"Result from adapt4:     {Q1}");
        WriteLine($"Analytical result:      {result1}");
        WriteLine($"Deviation:              {error1}");
        WriteLine($"Allowed tolerance:      {tol1}");
        WriteLine($"Number of evaluations:  {evals_adapt4}");
        if(error1<=tol1) WriteLine("Tolerance not exceeded, test passed!");
        else WriteLine("Error exceed tolerance, test failed!");

        WriteLine($"\nWith the Clenshaw-Curtis transformation:\n");
        WriteLine($"Result from adapt4CC:   {QCC1}");
        WriteLine($"Analytical result:      {result1}");
        WriteLine($"Deviation:              {errorCC1}");
        WriteLine($"Allowed tolerance:      {tol1}");
        WriteLine($"Number of evaluations:  {evals_adapt4CC}");
        if(errorCC1<=tol1) WriteLine("Tolerance not exceeded, test passed!");
        else WriteLine("Error exceed tolerance, test failed!");

        // Moving on to the next function Log(x)/Sqrt(x)
        evals = 0;
        Func<double,double> f2 = (x) => {evals++; return Log(x)/Sqrt(x);};
        double result2 = -4;
        double tol2 = acc+eps*Abs(result2);

        // adapt4
        double Q2 = quad.adapt4(f2,a,b,acc,eps);
        evals_adapt4 = evals;
        double error2 = Abs(Q2-result2);

        // adapt4CC
        evals = 0;
        double QCC2 = quad.adapt4CC(f2,a,b,acc,eps);
        evals_adapt4CC = evals;
        double errorCC2 = Abs(QCC2-result2);

        WriteLine($"\nIntegrating the function Log(x)/Sqrt(x) from {a} to {b}: \n");
        WriteLine($"Result from adapt4:     {Q2}");
        WriteLine($"Analytical result:      {result2}");
        WriteLine($"Deviation:              {error2}");
        WriteLine($"Allowed tolerance:      {tol2}");
        WriteLine($"Number of evaluations:  {evals_adapt4}");
        if(error2<=tol2) WriteLine("Tolerance not exceeded, test passed!");
        else WriteLine("Error exceed tolerance, test failed!");

        WriteLine($"\nWith the Clenshaw-Curtis transformation:\n");
        WriteLine($"Result from adapt4CC:   {QCC2}");
        WriteLine($"Analytical result:      {result2}");
        WriteLine($"Deviation:              {errorCC2}");
        WriteLine($"Allowed tolerance:      {tol2}");
        WriteLine($"Number of evaluations:  {evals_adapt4CC}");
        if(errorCC2<=tol2) WriteLine("Tolerance not exceeded, test passed!");
        else WriteLine("Error exceed tolerance, test failed!");
        
        // Moving on to last function 4*sqrt(1-x^2)
        evals = 0;
        Func<double,double> f3 = (x) => {evals++; return 4*Sqrt(1-Pow(x,2));};
        double result3 = PI;
        double tol3 = acc+eps*Abs(result3);

        // adapt4
        double Q3 = quad.adapt4(f3,a,b,acc,eps);
        evals_adapt4 = evals;
        double error3 = Abs(Q3-result3);

        // adapt4CC
        evals = 0;
        double QCC3 = quad.adapt4CC(f3,a,b,acc,eps);
        evals_adapt4CC = evals;
        double errorCC3 = Abs(QCC3-result3);

        // o8av
        evals = 0;
        double Q_o8av = quad.o8av(f3,a,b,acc,eps);
        double evals_o8av = evals;
        double error_o8av = Abs(Q_o8av-result3);
        

        WriteLine($"\nIntegrating the function 4*Sqrt(1-x^2) from {a} to {b}: \n");
        WriteLine($"Result from adapt4:     {Q3}");
        WriteLine($"Analytical result:      {result3}");
        WriteLine($"Deviation:              {error3}");
        WriteLine($"Allowed tolerance:      {tol3}");
        WriteLine($"Number of evaluations:  {evals_adapt4}");
        if(error3<=tol3) WriteLine("Tolerance not exceeded, test passed!");
        else WriteLine("Error exceed tolerance, test failed!");

        WriteLine($"\nWith the Clenshaw-Curtis transformation:\n");
        WriteLine($"Result from adapt4CC:   {QCC3}");
        WriteLine($"Analytical result:      {result3}");
        WriteLine($"Deviation:              {errorCC3}");
        WriteLine($"Allowed tolerance:      {tol3}");
        WriteLine($"Number of evaluations:  {evals_adapt4CC}");
        if(errorCC3<=tol3) WriteLine("Tolerance not exceeded, test passed!");
        else WriteLine("Error exceed tolerance, test failed!");


        WriteLine($"\nComparison with the matlib o8av routine:\n");
        WriteLine($"Result from o8av:       {Q_o8av}");
        WriteLine($"Analytical result:      {result3}");
        WriteLine($"Deviation:              {error_o8av}");
        WriteLine($"Allowed tolerance:      {tol3}");
        WriteLine($"Number of evaluations:  {evals_o8av}");
        if(errorCC3<=tol3) WriteLine("Tolerance not exceeded, test passed!");
        else WriteLine("Error exceed tolerance, test failed!");   
            
    } // Main

} // main