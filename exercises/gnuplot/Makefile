all: Gamma.svg Gamma-error.svg

Gamma.svg: gamma.gpi out.gamma.txt
	gnuplot $<

Gamma-error.svg: gamma-error.gpi out.gamma.error.txt
	gnuplot $<

out.gamma.txt out.gamma.error.txt : main_erf_gamma.exe
	mono $< > out.gamma.txt 2> out.gamma.error.txt

main_erf_gamma.exe : main_erf_gamma.cs math.dll
	mcs $< -out:$@ -reference:math.dll

math.dll : errorgamma.cs
	mcs $< -target:library -out:$@

.PHONEY:clean
clean:
	rm --force *.dll *.exe out* *.svg
