USE quiz;
GO

-- Add a new column 'NewColumnName' to table 'TableName' in schema 'SchemaName'
ALTER TABLE Users
    ADD UserStatus /*new_column_name*/ BIT /*new_column_datatype*/ NOT NULL DEFAULT(1)/*new_column_nullability*/
GO

ALTER TABLE Questions
    ADD QuestionStatus /*new_column_name*/ BIT /*new_column_datatype*/ NOT NULL DEFAULT(1)/*new_column_nullability*/
GO

ALTER TABLE Users
    ADD Phone /*new_column_name*/ VARCHAR(12) /*new_column_datatype*/ NULL /*new_column_nullability*/,
        [Address] /*new_column_name*/ VARCHAR(255) /*new_column_datatype*/ NULL /*new_column_nullability*/
GO