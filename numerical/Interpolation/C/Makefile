all: plot_cspline.svg

plot_cspline.svg: plot.gpi out_dataC.txt out_csplined_data.txt
	gnuplot $<

out_csplined_data.txt: main.exe
	mono $< > $@

out_dataC.txt : generatedata.exe
	mono $< > $@

generatedata.exe : generatedata.cs matlib.dll
	mcs -out:$@ -reference:matlib.dll $<

main.exe: main.cs matlib.dll out_dataC.txt
	mcs -out:$@ -reference:matlib.dll $<


matlib.dll: ../../matlib/matrix/vector.cs cspline.cs generatedata.cs
	mcs -target:library -out:$@ $^

clean:
		rm -f *.dll *.exe out* *log *.svg