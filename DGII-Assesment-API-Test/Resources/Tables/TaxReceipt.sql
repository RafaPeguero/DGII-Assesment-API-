ATTACH DATABASE ':memory:' AS [test];
create table [test].TaxReceipt
(
    TaxPayerId long           not null,
    Ncf        varchar(100)   not null,
    Amount     decimal(10, 2) not null,
    Itbis18    decimal(10, 2) not null,
    Id         integer        not null
        constraint TaxReceipt_pk
            primary key autoincrement
)

