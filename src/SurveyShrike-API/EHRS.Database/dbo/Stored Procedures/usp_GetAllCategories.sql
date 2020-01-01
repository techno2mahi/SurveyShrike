-- [usp_GetAllCategories] 20
CREATE PROC [dbo].[usp_GetAllCategories]
(@CategoryId integer) as

BEGIN 
 WITH Tree_CTE(CategoryId, Name, ShortName, Description, Popularity,[Image],IconClass, ParentCategoryId, Level)
AS
(
    SELECT cat.*, catRel.ParentCategoryId,0   FROM Category cat 
	inner join CategoryRelation catRel on cat.CategoryId = catRel.ChildCategoryId where catRel.ParentCategoryId = 0
    UNION ALL
	SELECT cat.*, catRel.ParentCategoryId,Level + 1  FROM Category cat 
	inner join CategoryRelation catRel on cat.CategoryId = catRel.ChildCategoryId
	inner join Tree_CTE on catRel.ParentCategoryId = Tree_CTE.CategoryId 
)
SELECT distinct * FROM Tree_CTE order by CategoryId  -- todo why there is duplicate records coming 

END
