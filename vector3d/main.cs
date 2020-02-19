using System;
class main{
	static int Main(){
	
		vector3d v = new vector3d(1,1,2);
		vector3d u = new vector3d(0,1,0);
		
		Console.WriteLine(vector3d.dotproduct(u,v));
		Console.WriteLine(vector3d.vectorproduct(v,u));
		Console.WriteLine(v.magnitude());

	return 0;
	}
}
