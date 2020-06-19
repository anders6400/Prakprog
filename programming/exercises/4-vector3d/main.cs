using System;
class main{
	static int Main(){
	
		vector3d v = new vector3d(1,1,2);
		vector3d u = new vector3d(0,1,0);
		
		Console.WriteLine($"Dot product of v = (1,1,2) and u = (0,1,0)");
		Console.WriteLine($"v*u = {vector3d.dotproduct(u,v)}");
		Console.WriteLine("Vector product:");
		Console.WriteLine($"v x u = {vector3d.vectorproduct(v,u)}");
		Console.WriteLine("Magnitude of v:");
		Console.WriteLine($"|v| = {v.magnitude()}");

	return 0;
	}
}
