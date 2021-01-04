create database FPL9
Go

use FPL9
------------ADMINS----------------------
create table Admins (
ID int  not null,
Fname varchar(50),
Lname varchar(50),
primary key (ID),
job char(1), -- P F C -- role is reserved keyword
) 

----------------USER-----------------------
create table Users (
ID int  not null,
primary key (ID),
Fname varchar(50),
Lname varchar(50),
U_Password int , -- password is reserved
Global_rank int, --rank is reserved
TeamName varchar(50),
Bank int,
TotalPoints int,
)

----------------CHIPS----------------------------
create table Chips (
ID int  not null,
primary key (ID),
C_Name varchar(50), -- name is reserved
C_Description varchar(1000),

)
---------------LEAGUES--------------------------
create table Leagues (
League_ID int  not null,
primary key (League_ID),
L_Name varchar(50), -- name is reserved
Createdby int , -- user ID
Foreign key (Createdby) references Users on delete set null on update no action,
)
-------------------CLUBS------------------
create table HomeClub(
ID int  not null,
primary key (ID),
Club_name varchar(50), --name is reserved
Position int , --rank
Points int ,
)

create table AwayClub(
ID int  not null,
primary key (ID),
Club_name varchar(50), --name is reserved
Position int , --rank
Points int ,
)
-----------------FIXTURES---------------------
create table Fixtures
(
Match_ID int  not null,
primary key (Match_ID),
M_Date date,
M_time time,
Home int  , ------------- FOREIGN
Away int , ------------- FOREIGN
Home_Score int,
Away_Score int, 
FOREIGN KEY (Home) REFERENCES HomeClub on delete set null on update no action,
FOREIGN KEY (Away) REFERENCES AwayClub on delete set null on update no action,
)

-----------------PLAYERS----------------------
create table Players (
ID int  not null,
primary key (ID),
Fname varchar(50),
Lname varchar(50),
Position char(1), -- M for Midfielder
				  -- G for goalkeeper
				  --D for defender
				  --F for forward
Club_ID int,  ------------- FOREIGN

Price int ,
Assists int ,
Goals int ,
Match_ID int , ------------- FOREIGN

Points int ,
Fit char(1), -- Y / N
FOREIGN KEY (Club_ID) REFERENCES HomeClub on delete set null on update no action,
FOREIGN KEY (Club_ID) REFERENCES AwayClub on delete set null on update no action, --not needed
FOREIGN KEY (Match_ID) REFERENCES Fixtures on delete set null on update no action ,
)

-- RELATION BETWEEN LEAGUES AND USERS --
create table Joined (
League_ID int  not null,


UserID int  not null,
primary key (League_ID,UserID),

User_rank int,

FOREIGN KEY (League_ID) REFERENCES Leagues on delete cascade on update no action,
FOREIGN KEY (UserID) REFERENCES Users on delete cascade on update no action,
)

-- RELATION BETWEEN PLAYERS AND USERS --
create table Pick_Team (
UserID int  not null,
PlayerID int  not null,

primary key (PlayerID,UserID),
FOREIGN KEY (UserID) REFERENCES Users on delete cascade on update no action ,
FOREIGN KEY (PlayerID) REFERENCES Players on delete cascade on update no action,
)

-- RELATION BETWEEN CHIPS AND USERS --
create table Uses (
UserID int  not null,
ChipID int  not null, 

Used int, -- 1 or 0

primary key (ChipID,UserID),
FOREIGN KEY (UserID) REFERENCES Users on delete cascade on update no action,
FOREIGN KEY (ChipID) REFERENCES Chips on delete cascade on update no action,
)

-- RELATION BETWEEN ADMINS AND PLAYERS --
create table ManageP ( -- Manage players
AdminID int  not null,
PlayerID int  not null,

primary key (AdminID,PlayerID),
FOREIGN KEY (AdminID) REFERENCES Admins on delete cascade on update no action,
FOREIGN KEY (PlayerID) REFERENCES Players on delete cascade on update no action,
)
-- RELATION BETWEEN ADMINS AND FIXTURES --
create table ManageF ( -- Manage Fixtures
AdminID int  not null,
FixtureID int  not null,

primary key (AdminID,FixtureID),
FOREIGN KEY (AdminID) REFERENCES Admins on delete cascade on update no action,
FOREIGN KEY (FixtureID) REFERENCES Fixtures on delete cascade on update no action,
)
-- RELATION BETWEEN ADMINS AND CLUBS --
create table ManageC ( -- Manage Clubs
AdminID int  not null,
ClubID int  not null,

primary key (AdminID,ClubID),
FOREIGN KEY (AdminID) REFERENCES Admins on delete cascade on update no action,
FOREIGN KEY (ClubID) REFERENCES HomeClub on delete cascade on update no action,
FOREIGN KEY (ClubID) REFERENCES AwayClub on delete cascade on update no action, --not needed
)
------------------------------------------------FILLING TABLES----------------------------------------------
insert into Admins 
values(1,'Mariam','Elkhashab','P' ),
(2,'Aya','Sameh','P' ),
(3,'Marawan','Ehab','F' ),
(4,'Mohamed','Waleed','C' )

--------------------------------------------
insert into Users 
values(1,'Mariam','Elkhashab','1609999',0,'My FC',100,0),
(2,'Hagar','Mohamed','29039999',0,'My FC',100,0),
(3,'Abdelrahman','Salah','41119999',0,'Eleven',100,0),
(4,'Omar','Zidan','15151515',0,'Aliens',100,0),
(5,'Marawan','Ehab','10101010',0,'Graffiti',100,0),
(6,'Ahmed','Soliman','29119998',0,'Solimans',100,0),
(7,'Haleem','Ali','11111111',0,'SKT',100,0),
(8,'Ahmed','Kazem','15039999',0,'Qazem',100,0),
(9,'Mostafa','Saad','22222222',0,'Centurion',100,0),
(10,'Mohamed','Waleed','70070077',0,'Mado',100,0),
(11,'Seif','Khattab','14021999',0,'ASC',100,0),
(12,'Hesham','Ayman','44444444',0,'Khaleegy',100,0),
(13,'Abo','Trika','20122012',0,'Ahly',100,0),
(14,'Ahmed','Salah','99999999',0,'Spurs',100,0),
(15,'Mohamed','Reda','66666666',0,'Reda',100,0),
(16,'Moataz','Emad','88888888',0,'MEmad',100,0),
(17,'Abo','Khira','10010010',0,'AK7',100,0),
(18,'Kamal','Asran','12341234',0,'Kemo',100,0),
(19,'Abduallah','Ayman','12345678',0,'Dream Team',100,0),
(20,'Ibrahim','Ayman','13579246',0,'Monsters',100,0)
---------------------------------------------------------
insert into Chips 
values(1,'Wild Card','Allows you to make unlimited free transfers throughout a Gameweek with no points deductions from transfers already made in the same Gameweek.'),
(2,'Free Hit','Selecting this chip allows a player to make unlimited transfers for one week only at no points cost'),
(3,'Triple Captain','Allows you to pick 1 player to make his score tripled')

-------------------------------------------------------------
insert into Leagues (League_ID,L_Name,Createdby)
values(1,'VAR',6),
(2,'H2H',11),
(3,'Egypt',20),
(4,'Bein',15),
(5,'Gameweek',7)
-----------------------------------------------------------------------
insert into HomeClub (ID,Club_name,Position,Points)
values(1,'Arsenal',0,0),
(2,'Aston Villa',0,0),
(3,' Burnley',0,0),
(4,'Brighton',0,0),
(5,'Chelsea',0,0),
(6,'Crystal Palace',0,0),
(7,'Everton',0,0),
(8,'Fulham',0,0),
(9,'Leister',0,0),
(10,'Leeds',0,0),
(11,'Manchester City',0,0),
(12,'Manchester Utd',0,0),
(13,'Liverpool',0,0),
(14,'Tottenham',0,0),
(15,'Southampton',0,0),
(16,'Westham',0,0)
------------------------------------------------------------------
insert into AwayClub(ID,Club_name,Position,Points)
values(1,'Arsenal',0,0),
(2,'Aston Villa',0,0),
(3,' Burnley',0,0),
(4,'Brighton',0,0),
(5,'Chelsea',0,0),
(6,'Crystal Palace',0,0),
(7,'Everton',0,0),
(8,'Fulham',0,0),
(9,'Leister',0,0),
(10,'Leeds',0,0),
(11,'Manchester City',0,0),
(12,'Manchester Utd',0,0),
(13,'Liverpool',0,0),
(14,'Tottenham',0,0),
(15,'Southampton',0,0),
(16,'Westham',0,0)

-----------------------------------------------------------------
insert into Fixtures
values(1,null,null,1,2,0,0),
(2,null,null,3,4,0,0),
(3,null,null,5,6,0,0),
(4,null,null,7,8,0,0),
(5,null,null,9,10,0,0),
(6,null,null,11,12,0,0),
(7,null,null,13,14,0,0),
(8,null,null,15,16,0,0)
-------------------------------------------------------------------
insert into Players (ID,Fname,Lname,Position,Club_ID,Price,Assists,Goals,Match_ID,Points,Fit)
values(1,'Kevin','DeBruyne','M',11,11,0,0,6,0,'Y'),
(2,'Mohamed','Salah','M',13,12,0,0,7,0,'Y'),
(3,'Bruno','Fernandes','M',12,9,0,0,6,0,'Y'),
(4,'Jack','Grealish','M',2,7,0,0,1,0,'Y'),
(5,'Harry','Kane','F',14,10,0,0,7,0,'Y'),
(6,'Alex','McCarthy','G',15,4,0,0,7,0,'Y'),
(7,'Emiliano','Martinez','G',2,5,0,0,1,0,'Y'),
(8,'Stuart','Dallas','D',10,4,0,0,5,0,'Y'),
(9,'Kurt','Zoma','D',5,6,0,0,3,0,'Y'),
(10,'Jamie','Vardy','F',9,11,0,0,5,0,'Y'),
(11,'Mohamed','Elneny','M',1,5,0,0,1,0,'Y'),
(12,'Bernd','Leno','G',1,5,0,0,1,0,'Y'),
(13,'Heung Min','Son','M',14,9,0,0,7,0,'Y'),
(14,'Marcus','Rashford','M',12,8,0,0,6,0,'Y'),
(15,'James','Rodriguez','M',7,8,0,0,4,0,'N'),
(16,'Michail','Antonio','F',16,6,0,0,8,0,'Y'),
(17,'Charlie','Taylor','D',3,4,0,0,2,0,'Y'),
(18,'Tariq','Lamptey','D',4,5,0,0,2,0,'N'),
(19,'Patric','Van Aanholt','D',6,5,0,0,3,0,'Y'),
(20,'Aleks','Mitrovic','F',8,5,0,0,4,0,'Y')

insert into Players
values (21,'Sadio','Mane','M',13,12,0,0,7,0,'Y'),
(22,'Danny','Ings','F',15,8,0,0,8,0,'Y'),
(23,'Vicente','Guaita','G',6,5,0,0,3,0,'Y'),
(24,'Yerry','Mina','D',7,6,0,0,4,0,'Y')
------------------FILLING RELATIONSHIPS---------------------------------------------------------------------------
insert into Pick_Team
values (1,1 ),(1,2),(1,3),(1,6),(1,4),(1,8),(1,10),(1,17),(1,18),(1,13),(1,16),
	   (2,5),(2,7),(2,11),(2,19),(2,20),(2,9),(2,14),(2,15),(2,16),(2,1),(2,17),
	   (3,20),(3,19),(3,17),(3,15),(3,14),(3,12),(3,5),(3,3),(3,2),(3,1),(3,4),
	   (4,21),(4,22),(4,23),(4,24),(4,1),(4,2),(4,13),(4,3),(4,5),(4,18),(4,4),
	   (5,1),(5,2),(5,3),(5,24),(5,4),(5,8),(5,10),(5,7),(5,5),(5,18),(5,21),

	   (6,1 ),(6,2),(6,3),(6,6),(6,4),(6,8),(6,10),(6,17),(6,18),(6,13),(6,16),
	   (7,5),(7,7),(7,11),(7,19),(7,20),(7,9),(7,14),(7,15),(7,16),(7,1),(7,17),
	   (8,20),(8,19),(8,17),(8,15),(8,14),(8,12),(8,5),(8,3),(8,2),(8,1),(8,4),
	   (9,21),(9,22),(9,23),(9,24),(9,1),(9,2),(9,13),(9,3),(9,5),(9,18),(9,4),
	   (10,1),(10,2),(10,3),(10,24),(10,4),(10,8),(10,10),(10,7),(10,5),(10,18),(10,21),

	   (11,1 ),(11,2),(11,3),(11,6),(11,4),(11,8),(11,10),(11,17),(11,18),(11,13),(11,16),
	   (12,5),(12,7),(12,11),(12,19),(12,20),(12,9),(12,14),(12,15),(12,16),(12,1),(12,17),
	   (13,20),(13,19),(13,17),(13,15),(13,14),(13,12),(13,5),(13,3),(13,2),(13,1),(13,4),
	   (14,21),(14,22),(14,23),(14,24),(14,1),(14,2),(14,13),(14,3),(14,5),(14,18),(14,4),
	   (15,1),(15,2),(15,3),(15,24),(15,4),(15,8),(15,10),(15,7),(15,5),(15,18),(15,21),

	   (16,1 ),(16,2),(16,3),(16,6),(16,4),(16,8),(16,10),(16,17),(16,18),(16,13),(16,16),
	   (17,5),(17,7),(17,11),(17,19),(17,20),(17,9),(17,14),(17,15),(17,16),(17,1),(17,17),
	   (18,20),(18,19),(18,17),(18,15),(18,14),(18,12),(18,5),(18,3),(18,2),(18,1),(18,4),
	   (19,21),(19,22),(19,23),(19,24),(19,1),(19,2),(19,13),(19,3),(19,5),(19,18),(19,4),
	   (20,1),(20,2),(20,3),(20,24),(20,4),(20,8),(20,10),(20,7),(20,5),(20,18),(20,21)

--------------------------------------------------------------------------------------------
insert into Joined
values(1,1,0),(2,2,0),(3,3,0),(4,4,0),(5,5,0),(1,6,0),(2,7,0),(3,8,0),(4,9,0),(5,10,0),
	  (1,11,0),(2,12,0),(3,13,0),(4,14,0),(5,15,0),(1,16,0),(2,17,0),(3,18,0),(4,19,0),(5,20,0)
---------------------------------------------------------------------------------------------
insert into ManageP
values (1,1),(1,2),(1,3),(1,4),(1,5),(1,6),(1,7),(1,8),(1,9),(1,10),
	   (2,11),(2,12),(2,13),(2,14),(2,15),(2,16),(2,17),(2,18),(2,19),(2,20)
---------------------------------------------------------------------------------------------
insert into ManageF
values(2,1),(2,2),(2,3),(2,4),(2,5),(2,6),(2,7),(2,8)
------------------------------------------------------------
insert into ManageC
values(3,1),(3,2),(3,3),(3,4),(3,5),(3,6),(3,7),(3,8),
	  (3,9),(3,10),(3,11),(3,12),(3,13),(3,14),(3,15),(3,16)
------------------------------------------------------------
--relation between user and chips

insert into Uses
values(1,1,0),(2,2,0),(3,3,0),(4,1,0),(5,2,0),(6,3,0),(7,1,0),(8,2,0),(9,3,0),
	   (10,1,0),(11,2,0),(12,3,0),(13,1,0),(14,2,0),(15,3,0),(16,1,0),(17,2,0),(18,3,0),
	   (19,1,0),(20,2,0)
---------------------------------------------------------------------