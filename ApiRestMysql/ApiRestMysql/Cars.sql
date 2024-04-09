CREATE DATABASE carsdb;
use carsdb;

CREATE TABLE cars (
    id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    make VARCHAR(45),
    model VARCHAR(45),
    color VARCHAR(45),
    year INT,
    doors INT
);