drop table if exists gyartok;
create table gyartok
(
    id int not null,
    nev varchar2(200) not null,
    
    constraint pk_gyartok primary key(id)
);