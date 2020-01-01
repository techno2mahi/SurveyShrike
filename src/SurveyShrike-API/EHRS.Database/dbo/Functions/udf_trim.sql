 
CREATE FUNCTION [dbo].[udf_trim]
(
 
	@val nvarchar(200)
)
RETURNS nvarchar(200)
AS
BEGIN
 Declare @result nvarchar(200);
   SET @result = LTRIM(@val)
    SET @result = RTRIM(@val)

	return @result
END

