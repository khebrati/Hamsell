-- approve, reject 
create table Hamsell.PostModerationResult(
PostModerationResultId integer AUTO_INCREMENT primary key,
PostModerationValue varchar(100) not null
);
select * from Hamsell.PostModerationResult;