using System;
using static System.Math;
using static System.Console;

public class minimization{

    public static readonly double eps = 1e-7;
    public static vector qnewton(Func<vector, double> f, vector xstart, double acc=1e-7){
        
        int nsteps = 0, n = xstart.size;
        vector x = xstart;
        matrix B = new matrix(n,n);
        B.set_identity();
        vector g = gradient(f,x);
        vector dx = -B*g;

        // Lineseach
        while(nsteps<999){
            if(g.norm() < acc){
                Error.WriteLine("Norm of Gradient < accuracy goal");
                break;
            } // if
            if(dx.norm() < eps*x.norm()){
                Error.WriteLine("|dx| < eps*|x|");
                break;
            } // if

            double fx = f(x), lambda = 1;
            vector increm = lambda*dx;
            while(f(x+increm) > fx){
                lambda /= 2;
                increm = lambda*dx;
                if(lambda < eps){
                    B.set_identity();
                    break;
                } // if
            } // while
            nsteps++;
            vector y = gradient(f, x+increm);
            vector dy = y - g;
            vector u = increm-B*dy;
            double uTdy = u%dy;
            if(Abs(increm.dot(dy)) > eps){
                B.update(u,u,1/uTdy);
            }// if
            x += increm;
            fx = f(x);
            g = y;
            dx = -B*g;
        } // while
        return x;
    } // qnewton

    public static vector gradient(Func<vector, double> f, vector x){
        vector g = new vector(x.size);
        double fx = f(x), dx;
        for(int i = 0; i<x.size; i=i+1){
            dx = Abs(x[i])*eps;
            if(Abs(x[i]) < Sqrt(eps)){
            dx = eps;
            } // if
            x[i] += dx;
            g[i] = (f(x)-fx)/dx;
            x[i] -= dx;
        } // for
        return g;
    } // gradient

} // minimization