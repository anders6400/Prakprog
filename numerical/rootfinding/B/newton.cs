using System;
using static System.Console;
using static System.Math;
using static System.Double;

public class rootfinding{
    public static vector newton(Func<vector, vector> f, vector x, double eps = 1e-3, double dx = 1e-7){
        int n = x.size;
        matrix J = new matrix(n,n);
        vector root = x.copy();
        vector f_r = f(root);
        vector z,fz;
        while(f_r.norm()>eps){
            for(int i = 0; i<n; i++){
                root[i] = root[i]+dx;
                vector df = f(root)-f_r;
                for(int j=0; j<n; j++){
                    J[i,j] = df[j]/dx;
                } // for
                root[i] -= dx;
            } // for
            QRdecompositionGS qr = new QRdecompositionGS(J);
            vector dr = qr.solve(-1*f_r);
            double lambda = 1.0;
            z = root+lambda*dr;
            fz = f(z);
            while(fz.norm()>(1-lambda/2)*f_r.norm()){
                double lambda_min = 1/64.0;
                if(lambda>lambda_min){
                    lambda = lambda/2;
                    fz = f(root+lambda*dr);
                } // if
                else{Error.WriteLine($"Bad step: lambda = {lambda_min}"); 
                break;
                } // else
            } // while
            root += lambda*dr;
            f_r = f(root);
        } // while
        return root;
    } // newton
} // rootfinding