USE [Creditos]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 12/11/2017 20:18:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cliente](
	[IdCliente] [int] NOT NULL,
	[Nombre] [varchar](50) NULL,
	[ApellidoPaterno] [varchar](50) NULL,
	[ApellidoMaterno] [varchar](50) NULL,
	[TipoDocumento] [char](3) NULL,
	[NumeroDocumento] [varchar](11) NULL,
	[Sexo] [char](1) NULL,
	[FechaNac] [datetime] NULL,
	[Direccion] [varchar](200) NULL,
	[CodigoPostal] [varchar](50) NULL,
	[EstadoCivil] [char](1) NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Credito]    Script Date: 12/11/2017 20:18:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Credito](
	[IdCredito] [int] IDENTITY(1,1) NOT NULL,
	[TipoCredito] [int] NULL,
	[IdCliente] [int] NULL,
	[Fecha] [datetime] NULL,
	[Monto] [decimal](18, 2) NULL,
	[DiaPago] [datetime] NULL,
	[Tasa] [decimal](18, 2) NULL,
	[Comision] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Credito] PRIMARY KEY CLUSTERED 
(
	[IdCredito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Credito]  WITH CHECK ADD  CONSTRAINT [FK_Credito_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[Credito] CHECK CONSTRAINT [FK_Credito_Cliente]
GO
/****** Object:  StoredProcedure [dbo].[sp_cliente_listar]    Script Date: 12/11/2017 20:18:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[sp_cliente_listar]
AS
BEGIN
SELECT [IdCliente]
      ,[Nombre]
      ,[ApellidoPaterno]
      ,[ApellidoMaterno]
      ,[TipoDocumento]
      ,[NumeroDocumento]
      ,[Sexo]
      ,[FechaNac]
      ,[Direccion]
      ,[CodigoPostal]
      ,[EstadoCivil]
  FROM [dbo].[Cliente]
  
END

GO
/****** Object:  StoredProcedure [dbo].[sp_cliente_obtener]    Script Date: 12/11/2017 20:18:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[sp_cliente_obtener](
 @pNumeroDocumento VARCHAR(11)
)
AS
BEGIN
SELECT [IdCliente]
      ,[Nombre]
      ,[ApellidoPaterno]
      ,[ApellidoMaterno]
      ,[TipoDocumento]
      ,[NumeroDocumento]
      ,[Sexo]
      ,[FechaNac]
      ,[Direccion]
      ,[CodigoPostal]
      ,[EstadoCivil]
  FROM [dbo].[Cliente]
  WHERE [NumeroDocumento]=@pNumeroDocumento
END

GO
/****** Object:  StoredProcedure [dbo].[sp_credito_actualizar]    Script Date: 12/11/2017 20:18:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_credito_actualizar]
(
   @IdCredito int,
   @TipoCredito int,
   @IdCliente int,
   @Fecha datetime,
   @Monto Decimal(18,2),
   @DiaPago date,
   @Tasa decimal(18,2),
   @Comision decimal(18,2)
)
as
begin
 UPDATE [dbo].[Credito]
   SET [TipoCredito] = @TipoCredito
      ,[IdCliente] =@IdCliente
      ,[Fecha] = @Fecha
      ,[Monto] = @Monto
      ,[DiaPago] = @DiaPago
      ,[Tasa] = @Tasa
      ,[Comision] = @Comision
 WHERE IdCredito=@IdCredito

end

GO
/****** Object:  StoredProcedure [dbo].[sp_credito_eliminar]    Script Date: 12/11/2017 20:18:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_credito_eliminar]
(
   @IdCredito int
)
as
begin
 DELETE [dbo].[Credito]
 WHERE IdCredito=@IdCredito

end

GO
/****** Object:  StoredProcedure [dbo].[sp_credito_listar]    Script Date: 12/11/2017 20:18:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_credito_listar]
as
begin

SELECT [IdCredito]
      ,[TipoCredito]
      ,[IdCliente]
      ,[Fecha]
      ,[Monto]
      ,[DiaPago]
      ,[Tasa]
      ,[Comision]
  FROM [dbo].[Credito]
end;

GO
/****** Object:  StoredProcedure [dbo].[sp_credito_obtener]    Script Date: 12/11/2017 20:18:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_credito_obtener]
(
	@IdCredito int
)
AS
BEGIN
SELECT IdCredito
      ,TipoCredito
      ,IdCliente
      ,Fecha
      ,Monto
      ,DiaPago
      ,Tasa
      ,Comision
  FROM dbo.Credito
  WHERE IdCredito = @IdCredito
END;


GO
/****** Object:  StoredProcedure [dbo].[sp_credito_registrar]    Script Date: 12/11/2017 20:18:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[sp_credito_registrar]
(
   @TipoCredito int,
   @IdCliente int,
   @Fecha datetime,
   @Monto Decimal(18,2),
   @DiaPago date,
   @Tasa decimal(18,2),
   @Comision decimal(18,2),
   @IdCredito int OUTPUT
)
as
begin
INSERT INTO [dbo].[Credito]
           ([TipoCredito]
           ,[IdCliente]
           ,[Fecha]
           ,[Monto]
           ,[DiaPago]
           ,[Tasa]
           ,[Comision])
     VALUES
           (   @TipoCredito ,
			   @IdCliente ,
			   @Fecha ,
			   @Monto ,
			   @DiaPago ,
			   @Tasa ,
			   @Comision 
			    )
	set @IdCredito=SCOPE_IDENTITY()
	RETURN @IdCredito
end

GO
