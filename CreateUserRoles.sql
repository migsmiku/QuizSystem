USE quiz;
INSERT INTO UserRoles (UserRole) 
VALUES ('admin'), ('user');

INSERT INTO QuizCategories(QuizCategoryName)
VALUES ('.Net'), ('C#'), ('Sql Server')

INSERT INTO Users (UserName, FirstName, LastName, Email, DateOfBirth, [Password], UserRoleId)
VALUES ('admin', 'Admin', 'User', 'admin@example.com', '1990-01-01', 'mypassword', 1);
