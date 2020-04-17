using System;
using static System.Console;
using static System.Math;
using System.IO;
using System.Diagnostics;

class main{
    static void Main(){
        
        // B1: Measure the time it takes to diagonalize a random matrix with the Jacobi cyclic method
    
    WriteLine("Problem B1:");
    WriteLine("Checking that the Jacobi cycle method  scales as O(n^3) by plotting the timer values as a function of matrix dimension.");
    WriteLine("A plot of this can be seen in plotB1.svg");
    int nMax = 200;
    Stopwatch timer = new Stopwatch();
    
    StreamWriter datafileB1 = new StreamWriter("out.dataB1.txt"); 


    for(int n = 10; n<nMax;n+=5){
    matrix A = generateRandommatrix(n,n);
    vector e = new vector(n);
    matrix V = new matrix(n,n);
    timer.Start();
    int sweeps = jacobi.jacobi_cyclic(A,e,V);
    timer.Stop();
    // matrix dimension             runtime               number of sweeps 
    datafileB1.WriteLine($"{Log(n)} \t {Log(timer.ElapsedMilliseconds)} \t {sweeps}");
    }
    datafileB1.Close();

    // B2: Comparing the Jacobi cyclic and the Jacobi row method of first eigenvalue
    timer.Reset();
    nMax = 100;
    StreamWriter datafileB2 = new StreamWriter("out.dataB2.txt");
    for(int n = 10; n<nMax;n+=5){
    matrix A1 = generateRandommatrix(n,n);
    matrix A2 = A1.copy();
    matrix A3 = A1.copy();
    vector e1 = new vector(n);
    vector e2 = new vector(n);
    vector e3 = new vector(n);
    matrix V1 = new matrix(n,n);
    matrix V2 = new matrix(n,n);
    matrix V3 = new matrix(n,n);
    timer.Start();
    int sweeps = jacobi.jacobi_cyclic(A1,e1,V1);
    timer.Stop();
    double time1 = timer.ElapsedMilliseconds;

    timer.Restart();
    int reps1 = jacobimod.jacobiRow(A2,e2,V2,1);
    timer.Stop();
    double time2 = timer.ElapsedMilliseconds;
    
    timer.Restart();
    int reps2 = jacobimod.jacobiRow(A3,e3,V3,n);
    timer.Stop();
    double time3 = timer.ElapsedMilliseconds;

    // matrix dimension             runtime               number of sweeps/reps 
    datafileB2.WriteLine($"{n} \t {time1} \t {time2} \t {time3} \t {sweeps} \t {reps1} \t {reps2}");
    }
    datafileB2.Close();
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