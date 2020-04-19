using System;
using static System.Math;
using static System.Console;
using System.Collections;
using System.Collections.Generic;
using System.IO;

static class main{
    static void Main(){
        // Initial parameters
        double t_0 = 0;     // starting time (in days)
        double T_C1 = 2;     // Typical time between contacts
        double T_r = 14;    // Recovery time
        double N = 6e6;     // Population of DK
        double I_0 = 100;   // Number of Infected at t_0

        // Initial condition
        vector ya = new vector(N-I_0, I_0, 0);

        // Accuracy and timespan
        double acc = 1e-5;
        double eps = 1e-5;
        double h = 0.1;
        double t_f = 250;   // End time (1 year)

        var xs = new List<double>();
        var ys = new List<vector>();
        ode.rk45(SIR(N,T_C1,T_r), t_0, ya, t_f, acc, eps, h, xs, ys);

        var results1 = new StreamWriter("outB1.data.txt");
        for(int i=0; i<xs.Count; i++){
            results1.WriteLine($"{xs[i]} {ys[i][0]} {ys[i][1]} {ys[i][2]}");
        }
        results1.Close();

        double T_C2 = 3;
        ode.rk45(SIR(N,T_C2,T_r), t_0, ya, t_f, acc, eps, h, xs, ys);
        var results2 = new StreamWriter("outB2.data.txt");
        for(int i=0; i<xs.Count; i++){
            results2.WriteLine($"{xs[i]} {ys[i][0]} {ys[i][1]} {ys[i][2]}");
        }
        results2.Close();

        double T_C3 = 5;
        ode.rk45(SIR(N,T_C3,T_r), t_0, ya, t_f, acc, eps, h, xs, ys);
        var results3 = new StreamWriter("outB3.data.txt");
        for(int i=0; i<xs.Count; i++){
            results3.WriteLine($"{xs[i]} {ys[i][0]} {ys[i][1]} {ys[i][2]}");
        }
        results3.Close();

        double T_C4 = 7;
        ode.rk45(SIR(N,T_C4,T_r), t_0, ya, t_f, acc, eps, h, xs, ys);
        var results4 = new StreamWriter("outB4.data.txt");
        for(int i=0; i<xs.Count; i++){
            results4.WriteLine($"{xs[i]} {ys[i][0]} {ys[i][1]} {ys[i][2]}");
        }
        results4.Close();
        
    } // Main

    // Differential equations that describe the dynamics of the population:
    static Func<double, vector, vector> SIR(double N, double T_C, double T_r){
        return (x,y) => {
            vector ydiff = new vector(3);
            ydiff[0] = -(y[1]*y[0])/(N*T_C);
            ydiff[1] = (y[1]*y[0])/(N*T_C)-y[1]/T_r;
            ydiff[2] = y[1]/T_r;
            return ydiff;
        };
    } // SIR

} // main