using System;
using static System.Console;
using static System.Math;
using System.IO;

class main{
    static void Main(){
        
        // Testing that the jacobiAlgorithm works:
        
        int n =5;
        
        vector e = new vector(n);
        matrix V = new matrix(n,n);
        matrix A = generateRandommatrix(n,n);
        matrix B = A.copy();
        int sweeps = jacobi.jacobi_cyclic(A,e,V);
        WriteLine("---------Problem A1----------");
        WriteLine("\nTesting that the Jacobi algorithm works as intended:");
        A.print("\nRandom square matrix A:");
        WriteLine("\nEigenvalue decomposition of A=V*D*V^T:");     
        (V.transpose()*B*V).print("\nD = V^T*A*V = ");
        e.print("\nListed eigenvalues:\t");
        WriteLine($"\nNumber of sweeps required to diagonalize A: {sweeps}");

        // Particle in a box
        n = 50;
        matrix H = Hamiltonian.boxHamilton(n);
        B = H.copy();
        V = new matrix(n,n);
        e = new vector(n);
        sweeps = jacobi.jacobi_cyclic(H,e,V);
        WriteLine("\n---------Problem A2----------");
        WriteLine("\nNow solving for a particle in a box.");
        WriteLine($"\nThe dimensions of the soon to be diagonalized Hamiltonian is {n}x{n}");
        WriteLine("\nComparison of the calculated eigenvalues and the exact:\n");
        WriteLine("n Calculated     Exact:");
        for (int k=0; k < n/3; k++){
            double exact = PI*PI*(k+1)*(k+1);
            double calculated = e[k];
            WriteLine($"{k} {calculated:f4}\t {exact:f4}");
        }

        // plotting time
        StreamWriter solutions = new StreamWriter("SolutionsA.txt");

        for(int i = 0; i<n; i++){
            solutions.Write($"{i*(1.0/n)}");
            for(int k = 0; k<5; k++){
                solutions.Write($" {V[i,k]}");
            }
            solutions.Write("\n");
        }
        solutions.Close();

    }


    static matrix generateRandommatrix(int n, int m){
        matrix A = new matrix(n,n);
        var rnd = new Random();
        for(int i=0; i<n; i++){
            for(int j=i; j<n; j++){
                A[i,j] = 10*rnd.NextDouble();
                A[j,i] = A[i,j];
            }
        }
        return A;
    }

}