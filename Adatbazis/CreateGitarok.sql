CREATE TABLE gitarok
(
    sorozatszam VARCHAR2(16) NOT NULL,
    tipus VARCHAR2(60) NOT NULL,
    gyarto_id INT NOT NULL,
    gyartas_datum DATE NOT NULL,
    balkezes NUMBER(1,0) NOT NULL,
    erintok_szama INT NOT NULL,
    hangszedok VARCHAR2(3) NOT NULL,
    
    CONSTRAINT pk_gitarok PRIMARY KEY(sorozatszam),
    CONSTRAINT fk_gyartok FOREIGN KEY(gyarto_id) REFERENCES gyartok(id),
    CONSTRAINT ch_hangszedok CHECK(hangszedok in ('SSS', 'SSH', 'HH', 'H', 'HSH', 'SS'))
);