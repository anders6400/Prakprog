all: plot_qspline.svg

plot_qspline.svg: plot.gpi out_dataB.txt out_qsplined_data.txt
	gnuplot $<

out_qsplined_data.txt: main.exe
	mono $< > $@

out_dataB.txt : generatedata.exe
	mono $< > $@

generatedata.exe : generatedata.cs matlib.dll
	mcs -out:$@ -reference:matlib.dll $<

main.exe: main.cs matlib.dll out_dataB.txt
	mcs -out:$@ -reference:matlib.dll $<


matlib.dll: ../../matlib/matrix/vector.cs qspline.cs generatedata.cs
	mcs -target:library -out:$@ $^

clean:
		rm -f *.dll *.exe out* *log *.svg