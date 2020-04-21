using System;
using static System.Math;
using static System.Console;
using System.Collections;
using System.Collections.Generic;
using System.IO;

static class main{
    static void Main(){
        // The problem at hand is a 2-dimensional problem. Each body in our 3-body simulation
        // has 2 coordinates x and y. This gives a total of 6 coordinates to account for.
        // It is assumed that all 3 bodies have the same mass, i.e. 1, and the gravitational constant is set to 1.
        // The setting parameters
        double t_0 = 0;     // starting time
        double MG = 1;      // Mass
        // The following initial conditions can be found in the Chenciner & Montgomery article (Figure text 1)
        // Initial conditions for position:
        vector r1_0 = new vector(new double[] {0.97000436,-0.24308753});
        vector r2_0 = -1*r1_0.copy();
        vector r3_0 = new vector(new double[] {0,0});
        // Initial conditions for velocities:
        vector v3_0 = new vector(new double[] {-0.93240737, -0.86473146});
        vector v2_0 = -0.5*v3_0.copy();
        vector v1_0 = -0.5*v3_0.copy();
        // Collecting all the vectors in one (one to rule them all):
        vector y0 = new vector(new double[] {r1_0[0],r1_0[1],r2_0[0],r2_0[1],r3_0[0],r3_0[1],
                                v1_0[0],v1_0[1],v2_0[0],v2_0[1],v3_0[0],v3_0[1]});

        // Accuracy and timespan
        double acc = 1e-5;
        double eps = 1e-5;
        double h = 1e-3;
        double t_f = 10;   

        var xs = new List<double>();
        var ys = new List<vector>();
        ode.rk45(EOM(MG), t_0, y0, t_f, acc, eps, h, xs, ys);

        var results = new StreamWriter("outC.data.txt");
        for(int i=0; i<xs.Count; i++){
            results.WriteLine($"{xs[i]} {ys[i][0]} {ys[i][1]} {ys[i][2]} {ys[i][3]} {ys[i][4]} {ys[i][5]}");
        }

        results.Close();

    } // Main

    // Differential equations that describes the dynamics of the 3-body problem:
    static Func<double, vector, vector> EOM(double MG){
        return (x,y) => {
            // A coordinate vector for each body:
            vector r1 = new vector(new double[] {y[0], y[1]});
            vector r2 = new vector(new double[] {y[2], y[3]});
            vector r3 = new vector(new double[] {y[4], y[5]});

            // The differential equations found on Wiki-3-body problem
            vector r1diff = -MG*(r1-r2)/Pow((r1-r2).norm(),3) - MG*(r1-r3)/Pow((r1-r3).norm(),3);
            vector r2diff = -MG*(r2-r3)/Pow((r2-r3).norm(),3) - MG*(r2-r1)/Pow((r2-r1).norm(),3);
            vector r3diff = -MG*(r3-r1)/Pow((r3-r1).norm(),3) - MG*(r3-r2)/Pow((r3-r2).norm(),3);
            return new vector(new double[] {y[6], y[7], y[8], y[9], y[10], y[11],
            r1diff[0], r1diff[1], r2diff[0], r2diff[1], r3diff[0], r3diff[1]});
        }; // func
    } // EOM

} // main