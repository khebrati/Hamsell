create table Hamsell.City(
CityID integer AUTO_INCREMENT primary key,
ProvinceID integer not null references Province,
CityName varchar(100)
);
desc Hamsell.City;
select * from Hamsell.City;