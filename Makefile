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

docker-image:
	docker build -t docker-latex . --file Dockerfile

compile:
	docker run --rm -v ${PWD}:/lab-01:Z docker-latex bash -c "make build && make clean"

publish: docker-image compile