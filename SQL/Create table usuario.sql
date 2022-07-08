
use[DungeonFinder]


CREATE TABLE Usuario(
	idUsuario int IDENTITY(1,1) PRIMARY KEY,
	email varchar(100),
	password varchar(64)
)
