create table Hamsell.User(
AccountID integer primary key references Account,
CityID int references City,
UserStatusId integer references UserStatus
);
desc Hamsell.User;