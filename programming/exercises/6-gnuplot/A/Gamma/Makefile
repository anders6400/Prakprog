all: Gamma.svg

Gamma.svg: gamma.gpi out.gamma.txt table.gamma.txt
	gnuplot $<



out.gamma.txt : main_gamma.exe
	mono $< > $@  

main_gamma.exe : main_gamma.cs math.dll
	mcs $< -reference:math.dll

math.dll : gamma.cs cmath.cs complex.cs
	mcs gamma.cs cmath.cs complex.cs -target:library -out:$@

table.gamma.txt: gamma.c
	tcc -run $< > $@

.PHONEY:clean
clean:
	rm --force *.dll *.exe out* *.svg
