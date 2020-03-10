all: Erf.svg

Erf.svg: erf.gpi out.erf.txt table.erf.txt
	gnuplot $<


out.erf.txt: main_erf.exe
	mono $< >$@

main_erf.exe: main_erf.cs matlib.dll
	mcs $< -reference:matlib.dll


LIBDIR = ../Gamma
SRC = $(LIBDIR)/gamma.cs

matlib.dll: $(SRC)
	mcs $< -target:library -out:$@

clean:
		rm -rf *.exe *.dll *.svg out*