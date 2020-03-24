all: plotA.svg plotC.svg out.txt


plotA.svg: plotA.gpi results.txt data.txt
	gnuplot $(word 1,$^)

plotC.svg: plotC.gpi resultsWithUnc.txt data.txt
	gnuplot $(word 1,$^)

out.txt results.txt data.txt resultsWithUnc.txt: main.exe
	mono $< > $@

main.exe: main.cs LeastSquares.cs matlib.dll
	mcs $(word 1, $^) $(word 2, $^) -reference:matlib.dll -out:$@ 


LIBDIR = ../matlib
SRC = $(LIBDIR)/matrix/matrix.cs
SRC += $(LIBDIR)/matrix/vector.cs
SRC += ../LinEquations/QRdecomp.cs

matlib.dll : $(SRC)
	mcs -target:library -out:$@ $^

clean: 
		rm -f *.txt *.dll *.exe *log *.svg