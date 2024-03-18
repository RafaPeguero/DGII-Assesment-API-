ATTACH DATABASE ':memory:' AS [test];
create table [test].Taxpayer
(
    TaxpayerId long         not null
        constraint Taxpayer_pk
            primary key,
    Name       varchar(100),
    Type       varchar(100) not null,
    Status     varchar(100) not null
);



