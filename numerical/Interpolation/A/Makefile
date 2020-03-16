all: out_dataA.txt out_splined_data.txt plot_linspline.svg

plot_linspline.svg: plot.gpi out_dataA.txt out_splined_data.txt
	gnuplot $<

out_splined_data.txt: main.exe
	mono $< > $@

out_dataA.txt : generatedata.exe
	mono $< > $@

generatedata.exe : generatedata.cs matlib.dll
	mcs -out:$@ -reference:matlib.dll $<

main.exe: main.cs matlib.dll out_dataA.txt
	mcs -out:$@ -reference:matlib.dll $<




matlib.dll: ../../matlib/matrix/vector.cs linspline.cs generatedata.cs
	mcs -target:library -out:$@ $^

clean:
		rm -f *.dll *.exe out* *log *.svg