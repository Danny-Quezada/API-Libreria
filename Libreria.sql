CREATE DATABASE Libreria
GO
USE Libreria
GO
CREATE TABLE Libros(
Id int IDENTITY(1,1) NOT NULL,
ISBN varchar(15) NOT NULL,
Titulo varchar(50) NOT NULL,
Autor varchar(50) NOT NULL,
Temas varchar(50) NOT NULL,
Editorial varchar(50) NOT NULL
)
GO
ALTER TABLE Libros
ADD PRIMARY KEY (Id)
GO
INSERT INTO Libros(ISBN, Titulo, Autor, Temas, Editorial) VALUES (
'84-121-2310-1','El tránsito terreno','Plasencia, Juan Luis','Filosofía','Larrosa Mas, S.L.')
GO
INSERT INTO Libros(ISBN, Titulo, Autor, Temas, Editorial) VALUES (
'84-7489-146-9','Sistemas operativos','Bazilian Eric','Técnica','GGG&G')
GO
INSERT INTO Libros(ISBN, Titulo, Autor, Temas, Editorial) VALUES (
'84-305-0473-7','Poemas intrínsecos','Llorens Antonia','Poesía','Deloria Editores')
GO
INSERT INTO Libros(ISBN, Titulo, Autor, Temas, Editorial) VALUES (
'84-473-0120-6','Avances en Arquitectura','Richter, Helmut','Técnica, Historia','TechniBooks')
GO
INSERT INTO Libros(ISBN, Titulo, Autor, Temas, Editorial) VALUES (
'84-206-1704-0','Las balas del bien','Leverling, Janet','Novela','GGG&G')
GO
INSERT INTO Libros(ISBN, Titulo, Autor, Temas, Editorial) VALUES (
'84-226-2128-2','La mente y el sentir','Plasencia, Juan Luis','Filosofía','Larrosa Mas, S.L.')
GO
INSERT INTO Libros(ISBN, Titulo, Autor, Temas, Editorial) VALUES (
'84-7908-349-2','Ensayos póstumos','Bertomeu, Andrés','Psicología, Ensayo','Deloria Editores')
GO
INSERT INTO Libros(ISBN, Titulo, Autor, Temas, Editorial) VALUES (
'84-578-0214-8','La dualidad aparente','Sanabria, Carmelo','Novela, Filosofía','Larrosa Mas, S.L.')
GO
INSERT INTO Libros(ISBN, Titulo, Autor, Temas, Editorial) VALUES (
'84-02-08696-9','Arquitectura y arte','Richter, Helmut','Técnica, Arte','Grisham Publishing')
GO
INSERT INTO Libros(ISBN, Titulo, Autor, Temas, Editorial) VALUES (
'84-01-92101-5','Historia de Occidente','Dulac, George','Historia','McCoy Hill')
GO
INSERT INTO Libros(ISBN, Titulo, Autor, Temas, Editorial) VALUES (
'84-7634-421-1','Sentimiento popular','Llorens, Antonia','Poesía','Larrosa Mas, S.L.')
GO
INSERT INTO Libros(ISBN, Titulo, Autor, Temas, Editorial) VALUES (
'84-404-8586-7','Amigos o enemigos','Sanabria, Carmelo','Novela, Psicología','GGG&G')
GO
INSERT INTO Libros(ISBN, Titulo, Autor, Temas, Editorial) VALUES (
'84-205-1101-3','La burguesía del XIX','Dulac, George','Historia','Deloria Editores')
GO
INSERT INTO Libros(ISBN, Titulo, Autor, Temas, Editorial) VALUES (
'84-212-2121-2','Procesadores cuánticos','Bazilian, Eric','Técnica, Ciencia','Grisham Publishing')
GO
INSERT INTO Libros(ISBN, Titulo, Autor, Temas, Editorial) VALUES (
'84-444-0027-3','Canto de esperanza','Davolio, Nancy','Poesía','McCoy Hill')
GO