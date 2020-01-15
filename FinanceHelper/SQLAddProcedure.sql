USE operationsdb
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetOperations]
	@sum float,
	@name nvarchar(30),
	@tax float,
	@IsOperationIncome bit
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO Operations (Sum, Name, Tax, IsOperationIncome) VALUES (@sum, @name, @tax, @IsOperationIncome)
END
GO
