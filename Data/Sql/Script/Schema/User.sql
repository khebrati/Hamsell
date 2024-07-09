create table Hamsell.User(
AccountID integer primary key references Account,
CityID int references City,
UserStatusId integer references UserStatus not null
);
desc Hamsell.User;