USE M_Peoples

INSERT INTO Funcionarios (nome,sobrenome)
VALUES('Catarina','Strada'),
('Tadeu','Vitelli');


CREATE PROCEDURE AdicionarFuncionario @nome VARCHAR(255), @sobrenome VARCHAR(255)
AS
INSERT INTO Funcionarios(nome,sobrenome)
VALUES(@nome,@sobrenome)


CREATE PROCEDURE DemitirFuncionario @id INT
AS
DELETE FROM Funcionarios WHERE idFuncionario = @id


EXEC DemitirFuncionario 4

SELECT * FROM Funcionarios

EXEC AdicionarFuncionario André, Azevedo






