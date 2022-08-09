

--GamePieces
CREATE TABLE GamePieces(
GamePieceId INT PRIMARY KEY IDENTITY(1,1),
GamePieceNumber INT NOT NULL DEFAULT -1,
Name nvarchar(20) NOT NULL
);

INSERT INTO GamePieces (GamePieceNumber, Name) VALUES (1, 'ROCK'),(2, 'PAPER'),(3, 'SCISSORS');
-- we use a PK apart fromt he avlue of the choice so that we can extend the app later without 
-- changing the choices others made years ago.
-- 1 = 2 ROCK
-- 2 = 4 PAPER
-- 3 = 5 SCISSORS
-- 4 = 6 LIZARD
-- 5 = 3 pebble
-- 6 = 1 Sandstone

--player
CREATE TABLE Players(
PlayerId UNIQUEIDENTIFIER PRIMARY KEY,
Fname VARCHAR(30) NOT NULL DEFAULT 'default_Firstname',
Lname VARCHAR(30) NOT NULL DEFAULT 'default_Lastname',
Wins INT NOT NULL DEFAULT 0,
Losses INT NOT NULL DEFAULT 0,
);

--Game
CREATE TABLE Games(
GameId UNIQUEIDENTIFIER PRIMARY KEY,
GameDate Date DEFAULT GETDATE(),
NumTies INT NOT NULL DEFAULT 0,-- could add a check to always be positive.
P1 UNIQUEIDENTIFIER NOT NULL FOREIGN KEY REFERENCES Players(PlayerId),
P2 UNIQUEIDENTIFIER NOT NULL FOREIGN KEY REFERENCES Players(PlayerId),
GameWinner_PlayerId UNIQUEIDENTIFIER NOT NULL FOREIGN KEY REFERENCES Players(PlayerId),
);

--round
CREATE TABLE Rounds(
RoundId UNIQUEIDENTIFIER PRIMARY KEY,
-- The FK reference to the PK of GamePiece is better because I may 
-- change the integer value of the 
-- gamepiece later. THe Fk value won't have to be changed.
P1Choice INT NOT NULL FOREIGN KEY REFERENCES GamePieces(GamePieceId),
P2Choice INT NOT NULL FOREIGN KEY REFERENCES GamePieces(GamePieceId),
GameId UNIQUEIDENTIFIER NOT NULL FOREIGN KEY REFERENCES Games(GameId),
RoundWinner_PlayerId UNIQUEIDENTIFIER NOT NULL FOREIGN KEY REFERENCES Players(PlayerId),
);



-- Player_GameJunction
CREATE TABLE Player_Game_Junction(
P1_PlayerId UNIQUEIDENTIFIER NOT NULL FOREIGN KEY REFERENCES Players(PlayerId),
P2_PlayerId UNIQUEIDENTIFIER NOT NULL FOREIGN KEY REFERENCES Players(PlayerId),
GameId UNIQUEIDENTIFIER NOT NULL FOREIGN KEY REFERENCES Players(PlayerId)
);
