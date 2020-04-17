all: out.txt plotA.svg

plotA.svg: plotA.gpi SolutionsA.txt
	gnuplot $<

out.txt : main.exe
	mono $< > $@

main.exe: main.cs matlib.dll
	mcs $(word 1, $^) -reference:matlib.dll -out:$@ 


LIBDIR = ../../matlib
SRC = $(LIBDIR)/matrix/matrix.cs
SRC += $(LIBDIR)/matrix/vector.cs
SRC += ../../LinEquations/QRdecomp.cs
SRC += jacobiAlg.cs
SRC += Hamiltonian.cs

matlib.dll : $(SRC)
	mcs -target:library -out:$@ $^

clean: 
		rm -f *.txt *.dll *.exe *log *.svg