FROM composer

COPY . /usr/src/app
WORKDIR /usr/src/app

RUN composer install

EXPOSE 8000

CMD ["php", "example.php"]