USE quiz;
GO
--.Net
INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType) 
VALUES (1, '.NET is a framework developed by which company?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect) 
VALUES (1, 'Microsoft', 1), (IDENT_CURRENT('Questions'), 'Google', 0), (IDENT_CURRENT('Questions'), 'Apple', 0), (IDENT_CURRENT('Questions'), 'Oracle', 0);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType) 
VALUES (1, 'Which of the following languages can be used to create .NET applications?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect) 
VALUES (2, 'C#', 1), (IDENT_CURRENT('Questions'), 'Java', 0), (IDENT_CURRENT('Questions'), 'Python', 0), (IDENT_CURRENT('Questions'), 'All of the above', 1);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType) 
VALUES (1, 'Which of the following is not a part of the .NET Framework?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect) 
VALUES (3, 'ASP.NET', 0), (IDENT_CURRENT('Questions'), 'Windows Forms', 0), (IDENT_CURRENT('Questions'), 'ADO.NET', 0), (IDENT_CURRENT('Questions'), 'SQL Server', 1);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType) 
VALUES (1, 'Which of the following is not a feature of C#?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect) 
VALUES (4, 'Object-oriented programming', 0), (IDENT_CURRENT('Questions'), 'Structured programming', 1), (IDENT_CURRENT('Questions'), 'Event-driven programming', 0), (IDENT_CURRENT('Questions'), 'Functional programming', 0);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType) 
VALUES (1, 'Which of the following is not a feature of the Common Language Runtime (CLR)?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect) 
VALUES (5, 'Memory management', 0), (IDENT_CURRENT('Questions'), 'Code execution', 0), (IDENT_CURRENT('Questions'), 'Code compilation', 1), (IDENT_CURRENT('Questions'), 'Code security', 0);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType) 
VALUES (1, 'Which of the following is not a feature of the .NET Framework Class Library (FCL)?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect) 
VALUES (6, 'Data access', 0), (IDENT_CURRENT('Questions'), 'Data encryption', 0), (IDENT_CURRENT('Questions'), 'Data compression', 0), (IDENT_CURRENT('Questions'), 'Data visualization', 1);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType) 
VALUES (1, 'Which of the following is not a .NET data type?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect) 
VALUES (7, 'int', 0), (IDENT_CURRENT('Questions'), 'bool', 0), (IDENT_CURRENT('Questions'), 'char', 0), (IDENT_CURRENT('Questions'), 'byte', 1);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType) 
VALUES (1, 'Which of the following is not a .NET exception?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect)
VALUES (IDENT_CURRENT('Questions'), 'IndexOutOfRangeException', 0), (IDENT_CURRENT('Questions'), 'FileNotFoundException', 0), (IDENT_CURRENT('Questions'), 'DivideByZeroException', 0), (IDENT_CURRENT('Questions'), 'InvalidInputException', 1);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType)
VALUES (1, 'Which of the following is not a .NET collection class?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect)
VALUES (IDENT_CURRENT('Questions'), 'List<T>', 0), (IDENT_CURRENT('Questions'), 'Dictionary<TKey, TValue>', 0), (IDENT_CURRENT('Questions'), 'Queue<T>', 0), (IDENT_CURRENT('Questions'), 'MyCollection<T>', 1);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType)
VALUES (1, 'Which of the following is not a .NET attribute?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect)
VALUES (IDENT_CURRENT('Questions'), 'ObsoleteAttribute', 0), (IDENT_CURRENT('Questions'), 'SerializableAttribute', 0), (IDENT_CURRENT('Questions'), 'DebuggerDisplayAttribute', 0), (IDENT_CURRENT('Questions'), 'InvalidAttribute', 1);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType)
VALUES (1, 'Which of the following is not a .NET design pattern?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect)
VALUES (IDENT_CURRENT('Questions'), 'Singleton', 0), (IDENT_CURRENT('Questions'), 'Factory', 0), (IDENT_CURRENT('Questions'), 'Decorator', 0), (IDENT_CURRENT('Questions'), 'MyDesignPattern', 1);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType)
VALUES (1, 'Which of the following is not a .NET serialization method?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect)
VALUES (IDENT_CURRENT('Questions'), 'Binary', 0), (IDENT_CURRENT('Questions'), 'XML', 0), (IDENT_CURRENT('Questions'), 'JSON', 0), (IDENT_CURRENT('Questions'), 'MySerialization', 1);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType)
VALUES (1, 'Which of the following is not a .NET remoting method?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect)
VALUES (IDENT_CURRENT('Questions'), 'HTTP', 0), (IDENT_CURRENT('Questions'), 'TCP', 0), (IDENT_CURRENT('Questions'), 'IPC', 0), (IDENT_CURRENT('Questions'), 'MyRemoting', 1);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType)
VALUES (1, 'Which of the following is not a .NET ORM tool?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect)
VALUES (IDENT_CURRENT('Questions'), 'Entity Framework', 0), (IDENT_CURRENT('Questions'), 'NHibernate', 0), (IDENT_CURRENT('Questions'), 'Dapper', 0), (IDENT_CURRENT('Questions'), 'MyORM', 1);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType)
VALUES (1, 'Which of the following is not a .NET web development framework?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect)
VALUES (IDENT_CURRENT('Questions'), 'ASP.NET', 0), (IDENT_CURRENT('Questions'), 'ASP.NET Core', 0), (IDENT_CURRENT('Questions'), 'Ruby on Rails', 1), (IDENT_CURRENT('Questions'), 'Express.js', 0);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType)
VALUES (1, 'Which of the following is not a .NET dependency injection framework?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect)
VALUES (IDENT_CURRENT('Questions'), 'Autofac', 0), (IDENT_CURRENT('Questions'), 'Ninject', 0), (IDENT_CURRENT('Questions'), 'Simple Injector', 0), (IDENT_CURRENT('Questions'), 'MyDI', 1);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType)
VALUES (1, 'Which of the following is not a .NET unit testing framework?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect)
VALUES (IDENT_CURRENT('Questions'), 'NUnit', 0), (IDENT_CURRENT('Questions'), 'xUnit', 0), (IDENT_CURRENT('Questions'), 'MSTest', 0), (IDENT_CURRENT('Questions'), 'MyTest', 1);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType)
VALUES (1, 'Which of the following is not a .NET logging framework?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect)
VALUES (IDENT_CURRENT('Questions'), 'NLog', 0), (IDENT_CURRENT('Questions'), 'log4net', 0), (IDENT_CURRENT('Questions'), 'Serilog', 0), (IDENT_CURRENT('Questions'), 'MyLog', 1);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType)
VALUES (1, 'Which of the following is not a .NET cloud platform?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect)
VALUES (IDENT_CURRENT('Questions'), 'Azure', 0), (IDENT_CURRENT('Questions'), 'AWS', 0), (IDENT_CURRENT('Questions'), 'Google Cloud', 0), (IDENT_CURRENT('Questions'), 'MyCloud', 1);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType)
VALUES (1, 'Which of the following is not a .NET container platform?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect)
VALUES (IDENT_CURRENT('Questions'), 'Docker', 0), (IDENT_CURRENT('Questions'), 'Kubernetes', 0), (IDENT_CURRENT('Questions'), 'Mesos', 1), (IDENT_CURRENT('Questions'), 'LXD', 0);

--C#
INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType) 
VALUES (2, 'What is the main difference between a struct and a class in C#?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect) 
VALUES (21, 'Structs are value types and classes are reference types', 1), (IDENT_CURRENT('Questions'), 'Structs can inherit from other structs and classes can not', 0), (IDENT_CURRENT('Questions'), 'Structs can have constructors and classes can not', 0), (IDENT_CURRENT('Questions'), 'Structs can be null and classes can not', 0);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType) 
VALUES (2, 'Which of the following is the correct way to declare an array in C#?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect) 
VALUES (22, 'int[] myArray;', 1), (IDENT_CURRENT('Questions'), 'int myArray[];', 0), (IDENT_CURRENT('Questions'), 'array<int> myArray;', 0), (IDENT_CURRENT('Questions'), 'list<int> myArray;', 0);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType) 
VALUES (2, 'What is the purpose of a namespace in C#?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect) 
VALUES (23, 'To organize code and prevent naming conflicts', 1), (IDENT_CURRENT('Questions'), 'To provide security to the code', 0), (IDENT_CURRENT('Questions'), 'To increase the performance of the code', 0), (IDENT_CURRENT('Questions'), 'To provide versioning of the code', 0);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType) 
VALUES (2, 'Which of the following is the correct way to declare a constant in C#?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect) 
VALUES (24, 'const int x = 5;', 1), (IDENT_CURRENT('Questions'), 'final int x = 5;', 0), (IDENT_CURRENT('Questions'), 'static int x = 5;', 0), (IDENT_CURRENT('Questions'), 'readonly int x = 5;', 0);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType) 
VALUES (2, 'What is the purpose of the "using" keyword in C#?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect) 
VALUES (25, 'To import a namespace', 1), (IDENT_CURRENT('Questions'), 'To create a new object', 0), (IDENT_CURRENT('Questions'), 'To define a variable', 0), (IDENT_CURRENT('Questions'), 'To start a loop', 0);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType) 
VALUES (2, 'What is the correct syntax for declaring a method in C#?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect) 
VALUES (26, 'public void MyMethod() { // code }', 1), (IDENT_CURRENT('Questions'), 'void MyMethod { // code }', 0), (IDENT_CURRENT('Questions'), 'function MyMethod() { // code }', 0), (IDENT_CURRENT('Questions'), 'method MyMethod() { // code }', 0);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType) 
VALUES (2, 'Which of the following is the correct way to create an object of a class in C#?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect)
VALUES (IDENT_CURRENT('Questions'), 'MyClass obj = new MyClass();', 1), (IDENT_CURRENT('Questions'), 'MyClass obj;', 0), (IDENT_CURRENT('Questions'), 'new MyClass();', 0), (IDENT_CURRENT('Questions'), 'MyClass obj();', 0);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType)
VALUES (2, 'Which of the following is the correct syntax for a property in C#?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect)
VALUES (IDENT_CURRENT('Questions'), 'public int MyProperty { get; set; }', 1), (IDENT_CURRENT('Questions'), 'int MyProperty { get; set; }', 0), (IDENT_CURRENT('Questions'), 'public int getMyProperty() { return _myProperty; }', 0), (IDENT_CURRENT('Questions'), 'int _myProperty;', 0);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType)
VALUES (2, 'Which of the following is not a control flow statement in C#?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect)
VALUES (IDENT_CURRENT('Questions'), 'if', 0), (IDENT_CURRENT('Questions'), 'switch', 0), (IDENT_CURRENT('Questions'), 'while', 0), (IDENT_CURRENT('Questions'), 'transfer', 1);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType)
VALUES (2, 'What is the correct syntax for a for loop in C#?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect)
VALUES (IDENT_CURRENT('Questions'), 'for (int i = 0; i < 10; i++) { // code }', 1), (IDENT_CURRENT('Questions'), 'for i in 0..10 { // code }', 0), (IDENT_CURRENT('Questions'), 'repeat (10) { // code }', 0), (IDENT_CURRENT('Questions'), 'do { // code } while (i < 10);', 0);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType)
VALUES (2, 'Which of the following is the correct syntax for a try-catch block in C#?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect)
VALUES (IDENT_CURRENT('Questions'), 'try { // code } catch (Exception e) { // code }', 1), (IDENT_CURRENT('Questions'), 'try { // code } catch { // code }', 0), (IDENT_CURRENT('Questions'), 'try { // code } finally { // code }', 0), (IDENT_CURRENT('Questions'), 'catch { // code } try { // code }', 0);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType)
VALUES (2, 'Which of the following is not a C# access modifier?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect)
VALUES (IDENT_CURRENT('Questions'), 'public', 0), (IDENT_CURRENT('Questions'), 'private', 0), (IDENT_CURRENT('Questions'), 'protected', 0), (IDENT_CURRENT('Questions'), 'myAccess', 1);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType)
VALUES (2, 'Which of the following is not a C# operator?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect)
VALUES (IDENT_CURRENT('Questions'), '+', 0), (IDENT_CURRENT('Questions'), '-', 0), (IDENT_CURRENT('Questions'), '*', 0), (IDENT_CURRENT('Questions'), 'myOperator', 1);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType)
VALUES (2, 'Which of the following is not a C# delegate?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect)
VALUES (IDENT_CURRENT('Questions'), 'Action', 0), (IDENT_CURRENT('Questions'), 'Func', 0), (IDENT_CURRENT('Questions'), 'Predicate', 0), (IDENT_CURRENT('Questions'), 'MyDelegate', 1);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType)
VALUES (2, 'Which of the following is not a C# event?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect)
VALUES (IDENT_CURRENT('Questions'), 'EventHandler', 0), (IDENT_CURRENT('Questions'), 'EventHandler<TEventArgs>', 0), (IDENT_CURRENT('Questions'), 'MyEvent', 1), (IDENT_CURRENT('Questions'), 'CustomEventHandler', 0);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType)
VALUES (2, 'What is the purpose of the "as" keyword in C#?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect)
VALUES (IDENT_CURRENT('Questions'), 'To cast an object to a specific type and return null if the cast is not possible', 1), (IDENT_CURRENT('Questions'), 'To create a new object', 0), (IDENT_CURRENT('Questions'), 'To define a variable', 0), (IDENT_CURRENT('Questions'), 'To start a loop', 0);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType)
VALUES (2, 'What is the purpose of the "is" keyword in C#?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect)
VALUES (IDENT_CURRENT('Questions'), 'To check if an object is of a specific type', 1), (IDENT_CURRENT('Questions'), 'To create a new object', 0), (IDENT_CURRENT('Questions'), 'To define a variable', 0), (IDENT_CURRENT('Questions'), 'To start a loop', 0);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType)
VALUES (2, 'What is the purpose of the "lock" keyword in C#?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect)
VALUES (IDENT_CURRENT('Questions'), 'To synchronize access to a specific block of code', 1), (IDENT_CURRENT('Questions'), 'To create a new object', 0), (IDENT_CURRENT('Questions'), 'To define a variable', 0), (IDENT_CURRENT('Questions'), 'To start a loop', 0);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType)
VALUES (2, 'Which of the following is not a C# collection?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect)
VALUES (IDENT_CURRENT('Questions'), 'List', 0), (IDENT_CURRENT('Questions'), 'Dictionary', 0), (IDENT_CURRENT('Questions'), 'Queue', 0), (IDENT_CURRENT('Questions'), 'MyCollection', 1);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType)
VALUES (2, 'Which of the following is not a C# exception?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect)
VALUES (IDENT_CURRENT('Questions'), 'ArgumentException', 0), (IDENT_CURRENT('Questions'), 'InvalidOperationException', 0), (IDENT_CURRENT('Questions'), 'NullReferenceException', 0), (IDENT_CURRENT('Questions'), 'MyException', 1);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType) 
VALUES (3, 'Which of the following is not a data type in SQL Server?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect) 
VALUES (IDENT_CURRENT('Questions'), 'INT', 0), (IDENT_CURRENT('Questions'), 'VARCHAR', 0), (IDENT_CURRENT('Questions'), 'DATETIME', 0), (IDENT_CURRENT('Questions'), 'MYTYPE', 1);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType) 
VALUES (3, 'What is the purpose of the SELECT statement in SQL Server?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect) 
VALUES (IDENT_CURRENT('Questions'), 'To retrieve data from a table', 1), (IDENT_CURRENT('Questions'), 'To insert data into a table', 0), (IDENT_CURRENT('Questions'), 'To update data in a table', 0), (IDENT_CURRENT('Questions'), 'To delete data from a table', 0);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType) 
VALUES (3, 'Which of the following is the correct syntax for a SELECT statement in SQL Server?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect) 
VALUES (IDENT_CURRENT('Questions'), 'SELECT column1, column2 FROM table1', 1), (IDENT_CURRENT('Questions'), 'SELECT * FROM table1', 0), (IDENT_CURRENT('Questions'), 'SELECT column1, column2 IN table1', 0), (IDENT_CURRENT('Questions'), 'SELECT column1, column2 OF table1', 0);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType) 
VALUES (3, 'Which of the following is not a clause in a SELECT statement in SQL Server?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect) 
VALUES (IDENT_CURRENT('Questions'), 'WHERE', 0), (IDENT_CURRENT('Questions'), 'GROUP BY', 0), (IDENT_CURRENT('Questions'), 'HAVING', 0), (IDENT_CURRENT('Questions'), 'MYCLAUSE', 1);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType) 
VALUES (3, 'What is the purpose of the FROM clause in a SELECT statement in SQL Server?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect) 
VALUES (IDENT_CURRENT('Questions'), 'To specify the table from which to retrieve data', 1), (IDENT_CURRENT('Questions'), 'To specify the columns to retrieve', 0), (IDENT_CURRENT('Questions'), 'To specify the conditions for the data to be retrieved', 0), (IDENT_CURRENT('Questions'), 'To specify the order of the data to be retrieved', 0);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType) 
VALUES (3, 'Which of the following is not a operator in SQL Server?', 1);
INSERT INTO Options (QuestionID, OptionText,IsCorrect)
VALUES (IDENT_CURRENT('Questions'), '=', 0), (IDENT_CURRENT('Questions'), '>', 0), (IDENT_CURRENT('Questions'), '<', 0), (IDENT_CURRENT('Questions'), 'MYOPERATOR', 1);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType)
VALUES (3, 'Which of the following is not a aggregate function in SQL Server?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect)
VALUES (IDENT_CURRENT('Questions'), 'COUNT', 0), (IDENT_CURRENT('Questions'), 'SUM', 0), (IDENT_CURRENT('Questions'), 'AVG', 0), (IDENT_CURRENT('Questions'), 'MYFUNCTION', 1);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType)
VALUES (3, 'What is the purpose of the JOIN clause in SQL Server?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect)
VALUES (IDENT_CURRENT('Questions'), 'To combine rows from two or more tables based on a related column between them', 1), (IDENT_CURRENT('Questions'), 'To insert data into a table', 0), (IDENT_CURRENT('Questions'), 'To update data in a table', 0), (IDENT_CURRENT('Questions'), 'To delete data from a table', 0);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType)
VALUES (3, 'Which of the following is not a type of JOIN in SQL Server?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect)
VALUES (IDENT_CURRENT('Questions'), 'INNER JOIN', 0), (IDENT_CURRENT('Questions'), 'LEFT JOIN', 0), (IDENT_CURRENT('Questions'), 'RIGHT JOIN', 0), (IDENT_CURRENT('Questions'), 'MYJOIN', 1);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType)
VALUES (3, 'What is the purpose of the UNION operator in SQL Server?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect)
VALUES (IDENT_CURRENT('Questions'), 'To combine the result set of two or more SELECT statements', 1), (IDENT_CURRENT('Questions'), 'To insert data into a table', 0), (IDENT_CURRENT('Questions'), 'To update data in a table', 0), (IDENT_CURRENT('Questions'), 'To delete data from a table', 0);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType)
VALUES (3, 'Which of the following is not a DDL command in SQL Server?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect)
VALUES (IDENT_CURRENT('Questions'), 'CREATE', 0), (IDENT_CURRENT('Questions'), 'ALTER', 0), (IDENT_CURRENT('Questions'), 'DROP', 0), (IDENT_CURRENT('Questions'), 'MYCOMMAND', 1);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType)
VALUES (3, 'Which of the following is not a DML command in SQL Server?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect)
VALUES (IDENT_CURRENT('Questions'), 'SELECT', 0), (IDENT_CURRENT('Questions'), 'INSERT', 0), (IDENT_CURRENT('Questions'), 'UPDATE', 0), (IDENT_CURRENT('Questions'), 'MYCOMMAND', 1);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType)
VALUES (3, 'Which of the following is not a DCL command in SQL Server?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect)
VALUES (IDENT_CURRENT('Questions'), 'GRANT', 0), (IDENT_CURRENT('Questions'), 'REVOKE', 0), (IDENT_CURRENT('Questions'), 'DENY', 0), (IDENT_CURRENT('Questions'), 'MYCOMMAND', 1);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType)
VALUES (3, 'Which of the following is not a constraint in SQL Server?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect)
VALUES (IDENT_CURRENT('Questions'), 'PRIMARY KEY', 0), (IDENT_CURRENT('Questions'), 'FOREIGN KEY', 0), (IDENT_CURRENT('Questions'), 'UNIQUE', 0), (IDENT_CURRENT('Questions'), 'MYCONSTRAINT', 1);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType)
VALUES (3, 'Which of the following is not a T-SQL function in SQL Server?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect)
VALUES (IDENT_CURRENT('Questions'), 'COUNT', 0), (IDENT_CURRENT('Questions'), 'SUM', 0), (IDENT_CURRENT('Questions'), 'AVG', 0), (IDENT_CURRENT('Questions'), 'MYFUNCTION', 1);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType)
VALUES (3, 'What is the purpose of the EXISTS keyword in SQL Server?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect)
VALUES (IDENT_CURRENT('Questions'), 'To check if a subquery returns any rows', 1), (IDENT_CURRENT('Questions'), 'To insert data into a table', 0), (IDENT_CURRENT('Questions'), 'To update data in a table', 0), (IDENT_CURRENT('Questions'), 'To delete data from a table', 0);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType)
VALUES (3, 'Which of the following is not a type of index in SQL Server?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect)
VALUES (IDENT_CURRENT('Questions'), 'CLUSTERED', 0), (IDENT_CURRENT('Questions'), 'NONCLUSTERED', 0), (IDENT_CURRENT('Questions'), 'FULLTEXT', 0), (IDENT_CURRENT('Questions'), 'MYINDEX', 1);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType)
VALUES (3, 'What is the purpose of the STUFF function in SQL Server?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect)
VALUES (IDENT_CURRENT('Questions'), 'To insert a string into another string at a specific position', 1), (IDENT_CURRENT('Questions'), 'To select data from a table', 0), (IDENT_CURRENT('Questions'), 'To update data in a table', 0), (IDENT_CURRENT('Questions'), 'To delete data from a table', 0);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType)
VALUES (3, 'Which of the following is not a type of backup in SQL Server?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect)
VALUES (IDENT_CURRENT('Questions'), 'FULL', 0), (IDENT_CURRENT('Questions'), 'DIFFERENTIAL', 0), (IDENT_CURRENT('Questions'), 'TRANSACTION LOG', 0), (IDENT_CURRENT('Questions'), 'MYBACKUP', 1);

INSERT INTO Questions (QuizCategoryID, QuestionText, QuestionType)
VALUES (3, 'What is the purpose of the COALESCE function in SQL Server?', 1);
INSERT INTO Options (QuestionID, OptionText, IsCorrect)
VALUES (SCOPE_IDENTITY(), 'To return the first non-null expression in a list of expressions', 1), (SCOPE_IDENTITY(), 'To select data from a table', 0), (SCOPE_IDENTITY(), 'To update data in a table', 0), (SCOPE_IDENTITY(), 'To delete data from a table', 0);