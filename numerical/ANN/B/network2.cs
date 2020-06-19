using System;
using static System.Math;
using static System.Console;

public class annAdv : ann{

    static Func<double, double> gaussian = (x) => Exp(-Pow(x,2));

    static Func<double, double> gaussianAntiD = (x) => Sqrt(PI)/2*math.erf(x);

    static Func<double, double> gaussianD = (x) => -2*x*Exp(-Pow(x,2));

    public annAdv(int nNeurons) : base(nNeurons, gaussian){ }


    public double feedforward_Deriv(double x){
        double sum = 0;
        for(int i = 0; i<n; i++){
            double a = Params[3*i+0];
            double b = Params[3*i+1];
            double w = Params[3*i+2];
            sum += gaussianD((x-a)/b)*w/b;
        } // for
        return sum;
    } // feedforward_Deriv

    public double feedforward_AntiD(double x){
        double sum = 0;
        for(int i = 0; i<n; i++){
            double a = Params[3*i+0];
            double b = Params[3*i+1];
            double w = Params[3*i+2];
            sum += gaussianAntiD((x-a)/b)*w*b;
            sum -= gaussianAntiD((x_0-a)/b)*w*b;
        } // for
        return sum;
    } // feedforward_AntiD
} // annAdv