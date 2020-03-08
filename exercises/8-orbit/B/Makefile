all: plotBiii.svg

plotBiii.svg: plotBi.gpi outi.txt
	gnuplot $<

outi.txt: ExerciseB.exe
	mono $< 1>$@ 2>log

ExerciseB.exe: ExerciseB.cs matlib.dll
	mcs $< -reference:matlib.dll

matlib.dll: ../../matlib/matrix/vector.cs ../../matlib/ode/ode.cs
	mcs -target:library -out:$@ $^

clean:
		rm -f *.exe *.dll out* *log