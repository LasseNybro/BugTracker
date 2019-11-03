USE master;
DROP DATABASE BugTrackerDB;
CREATE DATABASE BugTrackerDB;
USE BugTrackerDB;
CREATE TABLE UserTable(Username VarChar(20), Password Char(64), Level int);