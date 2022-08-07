create database PowerLineDB collate SQL_Latin1_General_CP1_CI_AS

GO

use PowerLineDB

create table Consumers
(
    Id int not null constraint Consumers_PK primary key,
    Name varchar(20) not null
)

create table Orders
(
    Id int not null constraint Orders_PK primary key,
    ConsumerId int not null constraint Consumers_FK references Consumers
)

insert into Consumers (Id, Name) values (1, 'Max');
insert into Consumers (Id, Name) values (2, 'Pavel');
insert into Consumers (Id, Name) values (3, 'Ivan');
insert into Consumers (Id, Name) values (4, 'Leonid');

insert into Orders (Id, ConsumerId) values (1, 2);
insert into Orders (Id, ConsumerId) values (2, 4);

select name
from Consumers
where (select count(*) from Orders where ConsumerId = Consumers.Id) = 0;

GO