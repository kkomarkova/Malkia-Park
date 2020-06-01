/***********************************************************************************************************
This script creates the database named MalkiaPark
************************************************************************************************************/
USE master;
GO
IF DB_ID('MalkiaPark') IS NOT NULL
DROP DATABASE MalkiaPark;
GO

CREATE DATABASE MalkiaPark;
GO

USE MalkiaPark;
--The tables for MalkiaPark database

CREATE TABLE Adopters(
OId INT PRIMARY KEY IDENTITY(1,1),
Username VARCHAR(50) NOT NULL,
Password VARCHAR(50) NOT NULL
);
GO

CREATE TABLE Types(
TId INT PRIMARY KEY,
Type VARCHAR(50) NOT NULL,
Origine VARCHAR(50) NOT NULL,
El INT NOT NULL,
ZooMap INT NOT NULL,
);
GO
CREATE TABLE Animals(
AId INT PRIMARY KEY ,
Name VARCHAR(50) NOT NULL,
Dob DATE NULL,
TId INT FOREIGN KEY REFERENCES Types(TId),
IMAGE VARCHAR(50) NULL
);
GO
CREATE TABLE AnimalsAdopters(
AdoptionID INT PRIMARY KEY IDENTITY(1,1),
OId INT FOREIGN KEY REFERENCES Adopters(OId),
AId INT FOREIGN KEY REFERENCES Animals(AId),
Date DATETIME NULL,
);

GO

--	Insert data into Type table
INSERT INTO [dbo].[Types] ([TId], [Type], [Origine], [El], [ZooMap]) VALUES (1001, N'African Spurred Tortoise', N'Africa', 4, 5)
INSERT INTO [dbo].[Types] ([TId], [Type], [Origine], [El], [ZooMap]) VALUES (1002, N'American Jaguar', N'South Western America', 2, 12)
INSERT INTO [dbo].[Types] ([TId], [Type], [Origine], [El], [ZooMap]) VALUES (1003, N'American Puma', N'America', 1, 21)
INSERT INTO [dbo].[Types] ([TId], [Type], [Origine], [El], [ZooMap]) VALUES (1004, N'Barn Owl', N'Globaly', 1, 1)
INSERT INTO [dbo].[Types] ([TId], [Type], [Origine], [El], [ZooMap]) VALUES (1005, N'Bengal Tiger', N'Southeast Asia', 5, 17)
INSERT INTO [dbo].[Types] ([TId], [Type], [Origine], [El], [ZooMap]) VALUES (1006, N'Bacterian Camel', N'Central Asia', 6, 14)
INSERT INTO [dbo].[Types] ([TId], [Type], [Origine], [El], [ZooMap]) VALUES (1007, N'Black And White Lemur', N'Madagascar', 1, 8)
INSERT INTO [dbo].[Types] ([TId], [Type], [Origine], [El], [ZooMap]) VALUES (1008, N'Black Panther', N'Asia', 4, 6)
INSERT INTO [dbo].[Types] ([TId], [Type], [Origine], [El], [ZooMap]) VALUES (1009, N'Blue And Yellow Mascaw', N'South America', 1, 1)
INSERT INTO [dbo].[Types] ([TId], [Type], [Origine], [El], [ZooMap]) VALUES (1010, N'Bobcat', N'North America', 1, 4)
INSERT INTO [dbo].[Types] ([TId], [Type], [Origine], [El], [ZooMap]) VALUES (1011, N'Brown Bear', N'North America', 1, 10)
INSERT INTO [dbo].[Types] ([TId], [Type], [Origine], [El], [ZooMap]) VALUES (1012, N'Cap Barred Goose', N'Australia ', 1, 1)
INSERT INTO [dbo].[Types] ([TId], [Type], [Origine], [El], [ZooMap]) VALUES (1013, N'Carcal Desert Lynx', N'Africa', 1, 6)
INSERT INTO [dbo].[Types] ([TId], [Type], [Origine], [El], [ZooMap]) VALUES (1014, N'Cheetah', N'Africa', 3, 13)
INSERT INTO [dbo].[Types] ([TId], [Type], [Origine], [El], [ZooMap]) VALUES (1015, N'Clouded Leopard', N'Southeast Asia', 3, 7)
INSERT INTO [dbo].[Types] ([TId], [Type], [Origine], [El], [ZooMap]) VALUES (1016, N'Domestic Sheep', N'Globaly', 1, 3)
INSERT INTO [dbo].[Types] ([TId], [Type], [Origine], [El], [ZooMap]) VALUES (1017, N'Desert Lion', N'Africa', 4, 16)
INSERT INTO [dbo].[Types] ([TId], [Type], [Origine], [El], [ZooMap]) VALUES (1018, N'Donkey', N'Globaly', 1, 14)
INSERT INTO [dbo].[Types] ([TId], [Type], [Origine], [El], [ZooMap]) VALUES (1019, N'Eurasian Lynx', N'Eurasia Temperate Zone', 1, 4)
INSERT INTO [dbo].[Types] ([TId], [Type], [Origine], [El], [ZooMap]) VALUES (1020, N'Siberian Tiger', N'Russia ', 5, 19)
INSERT INTO [dbo].[Types] ([TId], [Type], [Origine], [El], [ZooMap]) VALUES (1021, N'White Desert Lion', N'Africa', 4, 9)
INSERT INTO [dbo].[Types] ([TId], [Type], [Origine], [El], [ZooMap]) VALUES (1022, N'Grey Wolf', N'Northern Hemisphere', 1, 11)
INSERT INTO [dbo].[Types] ([TId], [Type], [Origine], [El], [ZooMap]) VALUES (1023, N'Llama', N'Peru', 1, 22)
INSERT INTO [dbo].[Types] ([TId], [Type], [Origine], [El], [ZooMap]) VALUES (1024, N'Leopard', N'Subsaharan Africa', 3, 7)
--Insert into Animals table
INSERT INTO [dbo].[Animals] ([AId], [Name], [Dob], [TId], [Image]) VALUES (1, N'Malkia', N'2013-06-25', 1017, N'/Assets/Malkia.jpg')
INSERT INTO [dbo].[Animals] ([AId], [Name], [Dob], [TId], [Image]) VALUES (2, N'Adele', N'2014-07-05', 1017, N'/Assets/Adelle.jpg')
INSERT INTO [dbo].[Animals] ([AId], [Name], [Dob], [TId], [Image]) VALUES (3, N'Benji', N'2016-11-11', 1008, N'/Assets/Benji.jpg')
INSERT INTO [dbo].[Animals] ([AId], [Name], [Dob], [TId], [Image]) VALUES (4, N'Brutus', N'2016-05-22', 1019, N'/Assets/Brutus.jpg')
INSERT INTO [dbo].[Animals] ([AId], [Name], [Dob], [TId], [Image]) VALUES (5, N'Bubu', NULL, 1023, N'/Assets/Bubu.jpg')
INSERT INTO [dbo].[Animals] ([AId], [Name], [Dob], [TId], [Image]) VALUES (6, N'Cattleya', N'2016-09-09', 1015, N'/Assets/Catteleya.jpg')
INSERT INTO [dbo].[Animals] ([AId], [Name], [Dob], [TId], [Image]) VALUES (7, N'Cezar', N'2009-06-22', 1017, N'/Assets/Cezar.jpg')
INSERT INTO [dbo].[Animals] ([AId], [Name], [Dob], [TId], [Image]) VALUES (8, N'Charlie', N'2016-09-08', 1013, N'/Assets/Charlie.jpg')
INSERT INTO [dbo].[Animals] ([AId], [Name], [Dob], [TId], [Image]) VALUES (9, N'Clyde', N'2015-09-29', 1003, N'/Assest/Clyde.jpg')
INSERT INTO [dbo].[Animals] ([AId], [Name], [Dob], [TId], [Image]) VALUES (10, N'Diego', N'2016-08-26', 1017, N'/Assest/Diego.jpg')
INSERT INTO [dbo].[Animals] ([AId], [Name], [Dob], [TId], [Image]) VALUES (11, N'Diana', N'2012-09-08', 1014, N'/Assets/Diana.jpg')
INSERT INTO [dbo].[Animals] ([AId], [Name], [Dob], [TId], [Image]) VALUES (12, N'Elza', N'2006-09-05', 1017, N'/Assets/Elza.jpg')
INSERT INTO [dbo].[Animals] ([AId], [Name], [Dob], [TId], [Image]) VALUES (13, N'Eurazijsky', NULL, 1022, N'/Assets/Eurazijsky.jpg')
INSERT INTO [dbo].[Animals] ([AId], [Name], [Dob], [TId], [Image]) VALUES (14, N'Falco', N'2017-03-22', 1005, N'/Assets/Falco.jpg')
INSERT INTO [dbo].[Animals] ([AId], [Name], [Dob], [TId], [Image]) VALUES (15, N'Franco', N'2017-07-01', 1002, N'/Assets/Franco.jpg')
INSERT INTO [dbo].[Animals] ([AId], [Name], [Dob], [TId], [Image]) VALUES (16, N'Fredy', N'2008-01-01', 1001, N'/Assets/Fredy.jpg')
INSERT INTO [dbo].[Animals] ([AId], [Name], [Dob], [TId], [Image]) VALUES (17, N'Garfield', NULL, 1010, N'/Assets/Garfield.jpg')
INSERT INTO [dbo].[Animals] ([AId], [Name], [Dob], [TId], [Image]) VALUES (18, N'Hildegard', N'1985-01-01', 1011, N'/Assets/HIldegard.jpg')
INSERT INTO [dbo].[Animals] ([AId], [Name], [Dob], [TId], [Image]) VALUES (19, N'Jonatan', N'2014-05-07', 1007, N'/Assets/Jonatan.jpg')
INSERT INTO [dbo].[Animals] ([AId], [Name], [Dob], [TId], [Image]) VALUES (20, N'Kamil', N'2015-04-14', 1006, N'/Assets/Kamil.jpg')
INSERT INTO [dbo].[Animals] ([AId], [Name], [Dob], [TId], [Image]) VALUES (21, N'Kamila', N'2017-12-26', 1018, N'/Assets/Kamila.jpg')
INSERT INTO [dbo].[Animals] ([AId], [Name], [Dob], [TId], [Image]) VALUES (22, N'Kamu', N'2008-08-17', 1017, N'/Assets/Kamu.jpg')
INSERT INTO [dbo].[Animals] ([AId], [Name], [Dob], [TId], [Image]) VALUES (23, N'Lamy', NULL, 1023, N'/Assets/Lamy.jpg')
INSERT INTO [dbo].[Animals] ([AId], [Name], [Dob], [TId], [Image]) VALUES (24, N'Leos', N'2013-07-06', 1024, N'/Assets/Leos.jpg')
INSERT INTO [dbo].[Animals] ([AId], [Name], [Dob], [TId], [Image]) VALUES (25, N'Mary', N'2012-09-08', 1014, N'/Assets/Mary.jpg')
INSERT INTO [dbo].[Animals] ([AId], [Name], [Dob], [TId], [Image]) VALUES (26, N'Mautzi', N'2017-03-22', 1005, N'/Assets/Mautzi.jpg')
INSERT INTO [dbo].[Animals] ([AId], [Name], [Dob], [TId], [Image]) VALUES (27, N'Maya', N'2015-05-17', 1002, N'/Assets/Maya.jpg')
INSERT INTO [dbo].[Animals] ([AId], [Name], [Dob], [TId], [Image]) VALUES (28, N'Oblacik', N'2013-04-15', 1015, N'/Assets/Oblacik.jpg')
INSERT INTO [dbo].[Animals] ([AId], [Name], [Dob], [TId], [Image]) VALUES (29, N'Paolo', N'2014-01-01', 1009, N'/Assets/Paolo&Majo.jpg')
INSERT INTO [dbo].[Animals] ([AId], [Name], [Dob], [TId], [Image]) VALUES (30, N'Majo', N'2011-01-01', 1009, N'/Assets/Paolo&Majo.jpg')
INSERT INTO [dbo].[Animals] ([AId], [Name], [Dob], [TId], [Image]) VALUES (31, N'Plaminenka', NULL, 1004, N'/Assets/Palminenka.jpg')
INSERT INTO [dbo].[Animals] ([AId], [Name], [Dob], [TId], [Image]) VALUES (32, N'Shakira', N'2016-04-16', 1005, N'/Assets/Shakira.jpg')
INSERT INTO [dbo].[Animals] ([AId], [Name], [Dob], [TId], [Image]) VALUES (33, N'Ovca', NULL, 1016, N'/Assets/sheep.jpg')
INSERT INTO [dbo].[Animals] ([AId], [Name], [Dob], [TId], [Image]) VALUES (34, N'Somare', N'2017-12-26', 1018, N'/Assets/Somare.jpg')
INSERT INTO [dbo].[Animals] ([AId], [Name], [Dob], [TId], [Image]) VALUES (35, N'Spol', N'2015-04-07', 1007, N'/Assets/Spol.jpg')
INSERT INTO [dbo].[Animals] ([AId], [Name], [Dob], [TId], [Image]) VALUES (36, N'Timur', NULL, 1020, N'/Assets/Timur.jpg')
INSERT INTO [dbo].[Animals] ([AId], [Name], [Dob], [TId], [Image]) VALUES (37, N'Trudy', N'1992-01-01', 1011, N'/Assets/Trudy.jpg')
INSERT INTO [dbo].[Animals] ([AId], [Name], [Dob], [TId], [Image]) VALUES (38, N'Vlk Dravy', NULL, 1022, N'/Assets/VLKDravy.jpg')
INSERT INTO [dbo].[Animals] ([AId], [Name], [Dob], [TId], [Image]) VALUES (39, N'Zemnarka', NULL, 1012, N'/Assets/Zemnarka.jpg')
INSERT INTO [dbo].[Animals] ([AId], [Name], [Dob], [TId], [Image]) VALUES (40, N'Alex', N'2016-08-26', 1017, N'/Assets/Alex.png')
-- Insert data into Adopters table
INSERT INTO [dbo].[Adopters] ([OId], [Username], [Password]) VALUES (101, N'rania', N'ra12')
INSERT INTO [dbo].[Adopters] ([OId], [Username], [Password]) VALUES (102, N'katerina', N'ka34')
INSERT INTO [dbo].[Adopters] ([OId], [Username], [Password]) VALUES (103, N'anastasija', N'an56')
INSERT INTO [dbo].[Adopters] ([OId], [Username], [Password]) VALUES (104, N'james', N'ja78')
INSERT INTO [dbo].[Adopters] ([OId], [Username], [Password]) VALUES (105, N'lucas', N'lu90')
INSERT INTO [dbo].[Adopters] ([OId], [Username], [Password]) VALUES (106, N'john', N'jo23')
INSERT INTO [dbo].[Adopters] ([OId], [Username], [Password]) VALUES (107, N'smith', N'sm45')
INSERT INTO [dbo].[Adopters] ([OId], [Username], [Password]) VALUES (108, N'sam', N'sa67')
INSERT INTO [dbo].[Adopters] ([OId], [Username], [Password]) VALUES (109, N'jack', N'ja89')
INSERT INTO [dbo].[Adopters] ([OId], [Username], [Password]) VALUES (110, N'katy', N'ka01')
INSERT INTO [dbo].[Adopters] ([OId], [Username], [Password]) VALUES (111, N'jessica', N'je10')
INSERT INTO [dbo].[Adopters] ([OId], [Username], [Password]) VALUES (112, N'patricia', N'pa98')
INSERT INTO [dbo].[Adopters] ([OId], [Username], [Password]) VALUES (113, N'martina', N'ma76')
INSERT INTO [dbo].[Adopters] ([OId], [Username], [Password]) VALUES (114, N'vicky', N'vi54')
INSERT INTO [dbo].[Adopters] ([OId], [Username], [Password]) VALUES (115, N'alex', N'al32')
INSERT INTO [dbo].[Adopters] ([OId], [Username], [Password]) VALUES (116, N'felix', N'fe95')
INSERT INTO [dbo].[Adopters] ([OId], [Username], [Password]) VALUES (117, N'ayan', N'ay93')
INSERT INTO [dbo].[Adopters] ([OId], [Username], [Password]) VALUES (118, N'adam', N'ad72')
INSERT INTO [dbo].[Adopters] ([OId], [Username], [Password]) VALUES (119, N'oline', N'ol93')
INSERT INTO [dbo].[Adopters] ([OId], [Username], [Password]) VALUES (120, N'otto', N'ot72')
GO
--Insert data into AnimalsAdopter table
INSERT INTO [dbo].[AnimalsAdopters] ([AdoptionId], [OId], [AId], [Date]) VALUES (0, 0, 0, N'2020-05-15 00:00:00')
INSERT INTO [dbo].[AnimalsAdopters] ([AdoptionId], [OId], [AId], [Date]) VALUES (501, 101, 1, N'2019-02-05 00:00:00')
INSERT INTO [dbo].[AnimalsAdopters] ([AdoptionId], [OId], [AId], [Date]) VALUES (502, 102, 6, N'2019-01-14 00:00:00')
INSERT INTO [dbo].[AnimalsAdopters] ([AdoptionId], [OId], [AId], [Date]) VALUES (503, 101, 34, N'2020-04-02 00:00:00')
INSERT INTO [dbo].[AnimalsAdopters] ([AdoptionId], [OId], [AId], [Date]) VALUES (504, 106, 24, N'2019-12-12 00:00:00')
INSERT INTO [dbo].[AnimalsAdopters] ([AdoptionId], [OId], [AId], [Date]) VALUES (505, 108, 34, N'2019-04-02 00:00:00')
GO