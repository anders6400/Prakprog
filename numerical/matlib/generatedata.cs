using System;
using static System.Console;
using static System.Math;
using System.IO;

public class generatedata{
    public static void Main(){
    // Generating the data
    
        double dx = 0.66;
        double minx = 0.0;
        double maxx = 9.5;
        int N = (int) Floor ((maxx-minx)/dx);

        for(int i=0; i<N; i=i+1)
            WriteLine($"{minx+i*dx} {Sin(i*dx)}");
    }

// Reading data and converting into vector/array
    public static vector[] read_data(string filename){
    
        var datafile = new StreamReader(filename);
        int nol = 0;    //number of lines
        // Counting number of lines in array
        while(datafile.ReadLine() != null)
            nol = nol+1;

        datafile.Close();
        
        datafile = new StreamReader(filename);
        // Creating columns that goes into the file
        vector xs = new vector(nol);
        vector ys = new vector(nol);

        string line;
        int i = 0;
        while((line = datafile.ReadLine()) != null){
            string[] words = line.Split(' ');
            xs[i] = double.Parse(words[0]);
            ys[i] = double.Parse(words[1]);
            i = i+1;
        }
        vector[] data = new vector[]{xs,ys};
        return data;
    }

}