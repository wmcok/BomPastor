﻿CREATE TABLE [dbo].[FORMS]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [FORMULARIO] NCHAR(70) NOT NULL, 
    [DESCRICAO] NCHAR(250) NOT NULL, 
    [MODULO] NCHAR(70) NOT NULL, 
    [OPERACAO] NCHAR(20) NOT NULL, 
    [ESTATUS] NCHAR(1) NOT NULL 
)
