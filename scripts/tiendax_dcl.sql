CREATE DATABASE [Tiendax]
GO

USE [Tiendax]
GO

CREATE LOGIN [ignem] WITH PASSWORD = 'clarotest';

CREATE USER [ignem] FOR LOGIN [ignem];

CREATE SCHEMA [mant];

GRANT SELECT, INSERT, UPDATE, DELETE ON SCHEMA :: [mant] TO [ignem];