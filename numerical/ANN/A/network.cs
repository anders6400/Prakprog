using System;
using static System.Console;
using static System.Math;

public class ann{
    public int n;   // number of hidden neurons
    public vector Params;
    Func<double,double> f;  // activation function

    // Begin constructor
    public ann(int nNeurons, Func<double, double> actFunc){
        n = nNeurons;
        f = actFunc;
        this.Params = new vector(3*n);

    } // ann


    public double feedforward(double x){
        double sum = 0;
        for(int i = 0; i<n; i++){
            double a = Params[3*i+0];
            double b = Params[3*i+1];
            double w = Params[3*i+2];
            sum += f((x-a)/b)*w;
        } // for
        return sum;
    } // feedforward

    public void train(vector x, vector y){

        Func<vector, double> H = (v) => {

            double sum = 0;
            Params = v;
            for(int i=0; i<x.size; i++){
                sum += (feedforward(x[i])-y[i])*(feedforward(x[i])-y[i]);
            } // for
            return sum/x.size;
        };
        vector vStart = Params;
        vector vmin = minimization.qnewton(H, vStart);
    } // train


} // network