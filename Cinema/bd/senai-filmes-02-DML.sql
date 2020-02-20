USE Filmes_manha;

INSERT INTO Generos	(Nome)
VALUES				('Ação')
					,('Drama');
					
INSERT INTO Filmes	(Titulo, IdGenero)
VALUES				('A vida é bela', 2)
					,('Rambo', 1);

CREATE PROCEDURE deletarGenero @idGenero INT
AS
ALTER TABLE Filmes NOCHECK CONSTRAINT ALL
DELETE FROM Generos WHERE IdGenero = @idGenero
ALTER TABLE Filmes CHECK CONSTRAINT ALL
UPDATE Filmes SET IdGenero = NULL WHERE IdGenero = @idGenero 

CREATE PROCEDURE MostarTodosOsFilmes
AS
SELECT Filmes.IdFilme,Filmes.IdGenero,Titulo,Nome AS Genero FROM Filmes
INNER JOIN Generos ON Filmes.IdGenero = Generos.IdGenero

--DROP PROC MostarTodosOsFilmes

EXEC MostarTodosOsFilmes

SELECT * FROM Filmes
SELECT * FROM Generos
DELETE FROM Filmes WHERE IdFilme=8
INSERT INTO Filmes(Titulo,IdGenero)
VALUES('Selavi',1)

UPDATE Filmes SET IdGenero = 1 WHERE IdFilme = 7