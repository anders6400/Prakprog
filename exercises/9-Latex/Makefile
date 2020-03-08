all:erf_report.pdf

erf_report.pdf: erf_report.tex plot-erf.tex
		pdflatex $<
		pdflatex $<

plot-erf.tex: plot-erf.gpi out-erf.txt table-erf.txt
		gnuplot $<

out-erf.txt: main.exe
		mono $< > $@

main.exe: main.cs erf.cs matlib.dll
		mcs $(word 1,$^) $(word 2,$^) -reference:matlib.dll



LIBDIR = ../matlib
SRC := $(LIBDIR)/integration/quado8.cs
SRC += $(LIBDIR)/matrix/vector.cs
SRC += $(LIBDIR)/ode/ode.cs
matlib.dll: $(SRC)
	mcs $^ -target:library -out:$@

clean:
		rm -f *.log *.aux *.pdf out* *.eps plot-erf.tex *.exe *.dll

