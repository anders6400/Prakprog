using System;
using static System.Math;
using static System.Console;
using System.Collections;
using System.Collections.Generic;
using System.IO;

static class main{
    static void Main(){
        // Function for the differential equation u'' = -u
        Func<double, vector, vector> diffeq = (x,y) => new vector(y[1],-y[0]);

        // Initial conditions for a sine function
        double a = 0;
        vector ya = new vector(0,1);
        
        // end point
        double b = 2*PI;
        // step size
        double h = 0.1;

        //accuracy
        double acc = 1e-4, eps = 1e-4;
        var xs1 = new List<double>();
        var ys1 = new List<vector>();
        var xs2 = new List<double>();
        var ys2 = new List<vector>();

        ode.rk12(diffeq,a,ya,b,acc,eps,h,xs1,ys1);
        ode.rk45(diffeq,a,ya,b,acc,eps,h,xs2,ys2);
        
        var dataRK12 = new StreamWriter("out.rk12.txt");
        for(int i=0; i<xs1.Count; i++){
            dataRK12.WriteLine($"{xs1[i]} {ys1[i][0]} {ys1[i][1]}");
        }
        dataRK12.Close();
        var dataRK45 = new StreamWriter("out.rk45.txt");
        for(int i=0; i<xs2.Count; i++){
            dataRK45.WriteLine($"{xs2[i]} {ys2[i][0]} {ys2[i][1]}");
        }
        dataRK45.Close();

        

    } // Main

} // main