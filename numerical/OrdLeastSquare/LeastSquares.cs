using System;
using static System.Console;
using static System.Math;

public class OrdLeastSquares{
    vector c;
    matrix sigma;

    public OrdLeastSquares(vector x, vector y, vector dy, Func<double,double>[] fs){
        int n = y.size;
        int m = fs.Length;
        matrix A = new matrix(n,m);
        vector b = new vector(n);   // Creating the matrix and vector going into QRdecomp.
        for(int i=0; i<n; i=i+1){
            b[i] = y[i]/dy[i];
            for(int j = 0; j<m; j=j+1){
                A[i,j] = fs[j](x[i])/dy[i];
            }
        } // Matrix and vector ready for QRdecomp

        QRdecompositionGS QRdecomp = new QRdecompositionGS(A);
        c = QRdecomp.solve(b);
        matrix sigmainv = QRdecomp.R.transpose()*QRdecomp.R;
        QRdecompositionGS cov = new QRdecompositionGS(sigmainv);
        sigma = cov.inverse();
        
    }

    public vector fit(){
        return c;
    }

    public matrix covMat(){
        return sigma;
    }

    public vector calUncertainty(){
        sigma = this.covMat();
        vector dc = new vector(sigma.size1);
        for(int i = 0; i < dc.size; i=i+1){
            dc[i] = Sqrt(sigma[i,i]);
        }
        return dc;
    }



}