USE [master]
GO

IF DB_ID('weather_db') IS NOT NULL
  set noexec on

CREATE DATABASE weather_db
GO

USE weather_db
GO


CREATE TABLE weather(
  Id int IDENTITY(1,1) PRIMARY KEY,
  SensorType varchar(16) not null,
  Date Datetime2 not null,
  Value Decimal(5,2) default 0.0
)
GO