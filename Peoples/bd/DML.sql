USE M_Peoples

INSERT INTO Funcionarios (nome,sobrenome,dataDeNascimento)
VALUES('Catarina','Strada','18/09/1980'),
('Tadeu','Vitelli','22/03/1960');

CREATE PROCEDURE OrdernarNomesASC
AS
SELECT * FROM Funcionarios ORDER BY Nome ASC


CREATE PROCEDURE MostrarFuncionarioPorNome @Nome VARCHAR(255)
AS 
SELECT * FROM Funcionarios WHERE Nome = @Nome

EXEC MostrarFuncionarioPorNome 'André'

CREATE PROCEDURE AdicionarFuncionario @nome VARCHAR(255), @sobrenome VARCHAR(255), @dataDeNascimento DATE
AS
INSERT INTO Funcionarios(nome,sobrenome,DataDeNascimento)
VALUES(@nome,@sobrenome,@dataDeNascimento) 


CREATE PROCEDURE DemitirFuncionario @id INT
AS
DELETE FROM Funcionarios WHERE idFuncionario = @id


EXEC AdicionarFuncionario "Teste", "sem nome", "15/06/2002"


ALTER TABLE Funcionarios ADD DataDeNascimento DATE 


UPDATE Funcionarios SET DataDeNascimento = '20/09/1973' WHERE idFuncionario = 1;

SELECT * FROM Funcionarios



