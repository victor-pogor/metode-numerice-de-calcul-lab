FROM tianon/latex

ENV DIR /lab-01

RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections
RUN apt update && \
    apt install -y wget \
        git \
        make \
        apt-transport-https \
        unzip \
		fonts-croscore
RUN wget -O /usr/share/fonts/xits-math.otf https://github.com/khaledhosny/xits-math/raw/master/XITSMath-Regular.otf && \
		wget http://bbgentoo.ilb.ru/distfiles/PTSansOFL.zip && \
		wget http://bbgentoo.ilb.ru/distfiles/PTMonoOFL.zip && \
		unzip -o PTSansOFL.zip -d /usr/share/fonts/ && unzip -o PTMonoOFL.zip -d /usr/share/fonts/ && \
		rm -f PTSansOFL.zip PTMonoOFL.zip && \
		fc-cache -f -v

VOLUME $DIR
WORKDIR $DIR