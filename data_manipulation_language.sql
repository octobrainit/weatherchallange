USE weather_db
GO

insert into weather values('Humitidy','2020-12-01',0.5);
insert into weather values('Temperature','2020-12-01',35.8);
insert into weather values('Rainfall','2020-12-01',0.75);

update weather set Date = '2022-08-02 00:00:00.0000000' where Id = 3