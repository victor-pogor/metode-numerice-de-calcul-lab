all: build run

build:
	latexmk -xelatex -synctex=1 main.tex

run:
	xreader main.pdf &

clean:
	rm -f *.aux \
	*.fdb_latexmk \
	*.fls \
	*.lof \
	*.lot \
	*.log \
	*.out \
	*.synctex.gz \
	*.toc

docker:
	docker build -t docker-latex .
	docker run --rm -ti -v ${PWD}:/lab-01:Z docker-latex bash -c "make build && make clean"
