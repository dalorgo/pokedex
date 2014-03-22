CREATE TABLE Abilities (
	GUID 			CHAR(128) PRIMARY KEY,
	Name 			CHAR(128),
	Effect 			CHAR(128),
	BattleEffect 	CHAR(128)
);

CREATE TABLE Natures (
	GUID 	CHAR(128) PRIMARY KEY,
	Name 	CHAR(128),
	Effect 	CHAR(128)
);

CREATE TABLE Moves (
	GUID 		CHAR(128) PRIMARY KEY,
	Name 		CHAR(128),
	Type_ 		CHAR(20),
	Kind 		CHAR(20),
	Power_		CHAR(20),
	Accuracy	CHAR(20),
	PP			INT
);

CREATE TABLE Types (
	GUID	CHAR(128) PRIMARY KEY,
	Name	CHAR(20)
);

CREATE TABLE Ability (
	PokemonUID	CHAR(128),
	AbilityUID	CHAR(128),
	PRIMARY KEY (PokemonUID, AbilityUID)
);

CREATE TABLE Nature (
	PokemonUID	CHAR(128),
	NatureUID	CHAR(128),
	PRIMARY KEY (PokemonUID, NatureUID)
);

CREATE TABLE Evolutions (
	PokemonUIDFrom	CHAR(128),
	PokemonUIDTO	CHAR(128),
	Level_			INT,
	Method			CHAR(64),
	PRIMARY KEY (PokemonUIDFrom, PokemonUIDTo)
);

CREATE TABLE MoveSet (
	PokemonUID	CHAR(128),
	MoveUID		CHAR(128),
	Level_		INT,
	PRIMARY KEY (PokemonUID, MoveUID)
);

CREATE TABLE TMs (
	PokemonUID	CHAR(128),
	MoveUID		CHAR(128),
	PRIMARY KEY (PokemonUID, MoveUID)
);

CREATE TABLE Type_ (
	PokemonUID	CHAR(128),
	TypeUID		CHAR(128),
	PRIMARY KEY	(PokemonUID, TypeUID)
);
