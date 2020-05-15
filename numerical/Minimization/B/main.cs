using System;
using static System.Console;
using static System.Math;
using System.IO;

class main{
    public static void Main(){
        // Fit the Breit-Wigner function to the data and determine the mass and the width of the Higgs Boson

        int n = 0;
        string[] data = File.ReadAllLines("higgs.data");
        foreach(string line in data){
            n++;
        } // foreach
        vector E = new vector(n);
        vector sigma = new vector(n);
        vector err = new vector(n);

        for(int i = 0; i<n; i=i+1){
            string[] s = data[i].Split(' ');
            E[i] = double.Parse(s[0]);
            sigma[i] = double.Parse(s[1]);
            err[i] = double.Parse(s[2]);
        } // for

        double eps = 1e-3;
        int evals = 0;
        Func<double, vector, double> F = delegate(double e, vector x){
            double y = x[2]/(Pow(e-x[0],2)+Pow(x[1],2)/4);
            return y;
        };

        Func<vector, double> D = delegate(vector x){
            evals++;
            double y = 0;
            for(int i = 0; i < n; i=i+1){
                y += Pow(F(E[i],x) - sigma[i],2)/err[i]/err[i];
            } // for
            return y;
        };

        vector xstart = new vector(110,2,6);
        vector xmin = minimization.qnewton(D, xstart, eps);
        WriteLine("Problem B:");
        WriteLine("\nMinimization of Higgs data with Breit-Wigner fit:");        
        WriteLine($"Accuracy:               {eps}");
        WriteLine($"Mass:                   {xmin[0]:f3}");
        WriteLine($"Width:                  {xmin[1]:f3}");
        WriteLine($"# of evaluations:       {evals}");
      
        
        var fit_data = new StreamWriter("out.results.txt");
        for(double energy = 101; energy<159; energy+=1.0/32){
            fit_data.WriteLine($"{energy} {F(energy,xmin)}");
        } //for

        fit_data.Close();
        

    } // Main
} // main