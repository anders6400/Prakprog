all: Erf.svg

Erf.svg: erf.gpi out.erf.txt table.erf.txt
	gnuplot $<


out.erf.txt: main_erf.exe
	mono $< >$@

main_erf.exe: main_erf.cs math.dll
	mcs $< -reference:math.dll


math.dll : gamma.cs cmath.cs complex.cs
	mcs gamma.cs cmath.cs complex.cs -target:library -out:$@

clean:
		rm -rf *.exe *.dll *.svg out*