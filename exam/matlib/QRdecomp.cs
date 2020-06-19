using System;
using static System.Console;
using static System.Math;
using System.IO;

public class QRdecompositionGS{

    public readonly matrix Q,R;
    public QRdecompositionGS(matrix A){
        Q = A.copy();
        R = new matrix(Q.size2,Q.size2);
        
        GramSchmidt(A);
    }

    void GramSchmidt(matrix A){
        int n = Q.size1;  // Number of rows
        int m = Q.size2;  // Number of columns

        for(int i = 0;i < m;i=i+1){
            double innerproduct1 = 0;
            for(int k = 0;k < n; k=k+1){
                innerproduct1 += Q[k,i]*Q[k,i];   
            }
            R[i,i]=Sqrt(innerproduct1); // Diagonal elements

            for(int k = 0; k < n; k=k+1){
                Q[k,i] = Q[k,i]/R[i,i];
            } // normalization 

            // Off-diagonal elements
            for(int j = i+1; j < m; j=j+1){
                double innerproduct2 = 0;
                for(int k = 0; k < n; k=k+1){
                    innerproduct2 += Q[k,i]*Q[k,j];
                }
                R[i,j] = innerproduct2;
                for(int k = 0; k < n; k = k+1){
                    Q[k,j] = Q[k,j]-innerproduct2*Q[k,i];
                }

            }

        }

    } // GS

    public vector solve(vector b){
        vector x = Q.transpose()*b;
        double sum;
        for(int i = x.size-1; i>=0; i--){
            sum = x[i];
            for(int k=i+1; k<x.size; k++){
                sum -= R[i,k]*x[k];
            }
            x[i] = sum/R[i,i];
        }
        return x;
    } // Solve


    public matrix inverse(){
        int n = Q.size1;
        int m = Q.size2;
        if(n != m) Error.Write("Matrix must be a square matrix!");

        matrix S = new matrix(n,m);
        vector e = new vector(n);
        for(int i = 0; i<n; i++){
            e[i] = 1;
            S[i] = solve(e);
            e[i] = 0;
        }
        return S;
    }

} // class

