
create table Hamsell.Report(
	ReportID integer AUTO_INCREMENT primary key,
    PostID integer references Post,
    UserId integer references User,
    ReportTypeId integer references ReportType,
    ReportDate datetime
);
desc Hamsell.Report;
