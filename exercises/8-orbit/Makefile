all: plot.svg

plot.svg: plot.gpi out.txt
	gnuplot $<

out.txt: Exercise_A.exe
	mono $< 1>$@ 2>log

Exercise_A.exe: Exercise_A.cs matlib.dll
	mcs $< -reference:matlib.dll

matlib.dll: ../matlib/matrix/vector.cs ../matlib/ode/ode.cs
	mcs -target:library -out:$@ $^

clean:
		rm -f *.exe out* *log *.dll