using static System.Console;
using static System.Math;
class main{
	string s="old string\n";	
	static int Main(){
		double x=1.23;
		int nmax=100;
		string s="hello\n";
		{double y=0;}
		Write(s);
		int two=2;
		int one=1;
		if(two>one){Write("2>1\n");}
		else{Write("2!>1\n");}
		
		int i=0;
		for(i=0;i<10;i++){Write("i={0}\n",i);}
		
		i=0;
		while(i<10){Write("while loop: i={0}\n",i);i++;}
		
		double[] v = new double[10];
		for(i=0;i<10;++i){v[i]=Sin(i);}
		for(i=0;i<10;++i){Write($"v[{i}]={v[i]}\n");}
		for(i=0;i<10;++i){Write("v[{0}]={1}\n",i,v[i]);}

	return 0;
	}
}


