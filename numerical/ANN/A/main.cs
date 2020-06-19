using System;
using static System.Math;
using static System.Console;
using System.IO;

class main{
    public static void Main(){

        // Start by generating data points for later training:
        int K = 100;
        double a = 0;
        double b = 3*PI;
        double dK = b-a;
        Func<double, double> f = (v) => Sqrt(v)*Cos(v);
        vector xs = new vector(K);
        vector ys = new vector(K);
        for(int i=0; i<K; i=i+1){
            xs[i] = a + dK*i/(K-1);
            ys[i] = f(xs[i]);
            WriteLine($"{xs[i]} {ys[i]}");
        }

        // Define activation function and number of neurons
        Func<double, double> act = (v) => v*Exp(-Pow(v,2));
        int neurons = 5;
        ann  Anetwork = new ann(neurons, act);

        vector p = new vector(neurons*3);
        for(int i = 0; i<neurons; i++){
            p[i*3] = a+dK*i/(neurons-1);
            p[3*i+1] = 1;
            p[3*i+2] = 1;
        }

        // Train Anetwork with the generated data and extract parameters
        Anetwork.Params = p;
        Anetwork.train(xs, ys);

        // Write out data for plotting
        StreamWriter outfile = new StreamWriter("out.data.txt");
        for(double i = a; i<b; i+=0.125){
            double predictVal = Anetwork.feedforward(i);
            outfile.WriteLine($"{i} {predictVal}");
        }
        outfile.Close();

    } // Main

} // main