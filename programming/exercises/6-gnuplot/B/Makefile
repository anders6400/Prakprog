all: lngamma.svg

lngamma.svg: lngamma.gpi out_lngamma.txt 
	gnuplot $<

out_lngamma.txt: main_lngamma.exe
	mono $< > $@

main_lngamma.exe: main_lngamma.cs math.dll
	mcs $< -reference:math.dll

math.dll : gamma.cs cmath.cs complex.cs
	mcs gamma.cs cmath.cs complex.cs -target:library -out:$@

clean:
		rm -rf *.exe out* *.svg *.dll