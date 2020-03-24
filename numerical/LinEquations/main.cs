using System;
using static System.Console;
using static System.Math;

class main{
    static void Main(){
        int n = 6;
        int m = 4;

        // Problem A1:
        WriteLine($"Problem A1: QR-factorization on a random {n}x{m} matrix A: \n");

        matrix A = generatematrix(n,m);

        // Printing our random matrix A
        A.print("Matrix A =");
	    QRdecompositionGS decomp = new QRdecompositionGS(A);
    
        // Printing the orthogonal matrix Q
        matrix Q = decomp.Q;
        Q.print("\nDecomposed component  Q = "); 
        
        // Printing the upper triangle matrix R
        matrix R = decomp.R;
        R.print("\nDecomposed component R = ");

        // Checking that Q^T*Q is equal to the identity
        (Q.transpose()*Q).print("\nQ^(T)*Q = ");

        // Checking that QR=A by substracting A from QR to yield the null matrix
        (Q*R-A).print("\n Q*R-A = "); 

        n = 3;
        // Problem A2:
        WriteLine($"\nProblem A2: QR-factorization on a random {n}x{n} matrix A solving Ax=b: \n");
        vector b = generatevector(n);
        A = generatematrix(n,n);
        decomp = new QRdecompositionGS(A);
        b.print("Vector b = ");
        A.print("\nSquare matrix A = ");
        vector x = decomp.solve(b);
        // Printing the solution to Ax=b
        x.print("\nVector x = ");
        WriteLine("\nChecking that x is indeed the solution: ");
        (A*x-b).print("\nA*x-b = ");


        // Problem B:
        A = generatematrix(n,n);
        decomp = new QRdecompositionGS(A);
        WriteLine($"\nProblem B: Matrix inverse by Gram-Schmidt QR factorization \n");
        matrix B = decomp.inverse();
        B.print("A^(-1) = ");
        (A*B).print("\n A*A^(-1) = ");

        // Problem C:
        
  
    }

    static matrix generatematrix(int n, int m){
        matrix A = new matrix(n,m);
        var rnd = new Random();

        for(int i=0; i<n; i++){
            for(int j=0; j<m; j++){
                A[i,j] = 10*rnd.NextDouble();
            }
        }
        return A;
    }

    static vector generatevector(int n){
        vector b = new vector(n);
        var rnd = new Random();
        for(int i=0; i<n; i++){
            b[i] = 10*rnd.NextDouble();
        }
        return b;
    }


}

