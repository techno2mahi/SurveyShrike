--exec [dbo].[usp_GetPatients] @PageIndex=1,@PageSize=10,@SortName='sort_polupar',@SortDirection=0, @SearchTerm = '', @AdmissionDateFrom = null, @AdmissionDateTo = null
CREATE PROC  [dbo].[usp_GetPatients]
(
@PageIndex integer ,
@PageSize integer, 
-- sort paramas 
@SortName varchar(50),
@SortDirection bit,

--filter params  
@SearchTerm varchar(50),
@AdmissionDateFrom DateTime,
@AdmissionDateTo DateTime
) 

AS
BEGIN  
 
--SELECT PatientId ,  
--	Name,
--    'M' as Gender,
--    29 as Age, 
--    TreatmentDescription ,
--	[CityId],
--    'sdfsdf' as CityName,
--	[Address]  ,
--	'sdfsdf' as ContactNo,
--	'sdfsdf' ProfilePictureName,	
--	'sdfsdf' [Allergies],
--	'sdfsdf' [AlternateContacts],
--	[IsActive] ,
--	[IsDeleted]
--from Patient
 
	  
-- Development Settings	 
						 set @PageSize = 5;

-- Development Settings	 

	CREATE TABLE #Patients(PatientId bigInt NOT NULL, 
			[Name] [nvarchar](100) NOT NULL,
			[TreatmentDescription] [nvarchar](500)  NULL,
			[CityId] [int] NOT NULL,
			[CityName] varchar(120),
			[Address] [nvarchar](200) NOT NULL, 
			ContactNo varchar(15), 
			ProfilePictureName varchar(100),
			[IsActive] [bit] NOT NULL,
			[IsDeleted] [bit] NOT NULL
	 )
INSERT INTO #Patients
	SELECT  l.[PatientId] ,l.Name , [TreatmentDescription]  
			,l.[CityId], '' as [CityName], [Address] ,
			isNull(lc.[ContactNo], '') ContactNo, '' as ProfilePictureName,
			l.[IsActive] ,l.[IsDeleted]      
    
	FROM [dbo].[Patient] l
	LEFT JOIN [dbo].PatientContact lc on l.PatientId = lc.PatientId and lc.ContactTypeId = 1 

	WHERE( (@SearchTerm = '') OR (@SearchTerm <> '' AND l.Name like '%'+ @SearchTerm +'%'))	 
		 AND ((@AdmissionDateFrom is null	AND @AdmissionDateTo is null ) OR (l.CreatedOn between @AdmissionDateFrom and @AdmissionDateTo))		  
		 AND L.IsActive = 1 
		 AND L.IsDeleted = 0		 
	ORDER BY CASE WHEN (@SortName = 'sort_name' and @SortDirection   = 1) THEN l.Name END ASC,
			 CASE WHEN (@SortName = 'sort_name' and @SortDirection   = 0) THEN l.Name END DESC,
	    	 CASE WHEN (@SortName = 'sort_date_admitted' and  @SortDirection    = 0) THEN l.CreatedOn END DESC,
			 CASE WHEN (@SortName = 'sort_date_admitted' and @SortDirection   = 1) THEN l.CreatedOn END ASC 
	 OFFSET @PageSize * (@PageIndex - 1) ROWS
	 FETCH NEXT @PageSize ROWS ONLY;
	  

	-- **********************************************************
	-- Now Get the Meta datas like service Categories and  
	-- **********************************************************
    --  select * from #Patients  
	 
    
	
	SELECT list.PatientId,  
	list.Name,
	'M' as Gender,
    29 as Age, 
	TreatmentDescription,
	ct.[CityId],
	ct.Name  [CityName],
	[Address] , 
	isNull(ContactNo, '') as ContactNo,
	lMedia.ServerFileName as ProfilePictureName,
	[IsActive] ,
	[IsDeleted] ,
	STUFF(ISNULL((SELECT ', ' + cat.Name
                FROM PatientAllergy liscat
				INNER JOIN Allergy cat on liscat.AllergyId = cat.AllergyId
                WHERE liscat.PatientId = list.PatientId 
                FOR XML PATH (''), TYPE).value('.','VARCHAR(max)'), ''), 1, 2, '') [Allergies],
	STUFF(ISNULL((SELECT ', ' + CAST (liscon.ContactNo as varchar(15))
                FROM PatientContact liscon 
                WHERE liscon.PatientId = list.PatientId 
                FOR XML PATH (''), TYPE).value('.','VARCHAR(max)'), ''), 1, 2, '') [AlternateContacts]
	FROM #Patients list
	INNER JOIN City ct on list.CityId = ct.CityId
	LEFT JOIN (SELECT lm.PatientMediaId, lm.PatientId  , f.ServerFileName
				FROM  [dbo].PatientMedia lm 
				INNER JOIN [dbo].[File] f on lm.FileId =    f.FileId and  f.FileTypeId = 1
				WHERE lm.IsPrimary = 1
				  ) AS lMedia on list.PatientId = lMedia.PatientId   
	
	DROP TABLE #Patients
  
  --exec [usp_GetPatients] 194, 14,'ChIJs2y7EDVeUjoRvJe_U0y7WY4',1, 10, 'New', 1, 13 ,1
END 











 /*
 --exec [dbo].[usp_GetPatients] @CityId=194,@CategoryId=94,@PlaceId='ChIJETaK5okZDTkRESXJDBNrIMA',@PageIndex=0,@PageSize=10,@SortName='sort_polupar',@SortDirection=0,@StateId=13,@CountryId=1

declare @CityId integer = 194 , 
@CategoryId integer = 94, 
@PlaceId VARCHAR(50) = 'ChIJETaK5okZDTkRESXJDBNrIMA', 
@PageIndex integer = 0,
@PageSize integer = 10, 

-- sort paramas 
@SortName varchar(50)='sort_polupar',
@SortDirection bit = 0,

--filter params  
@StateId integer =13 ,
@CountryId integer=1
DECLARE @AreaId  as bigint 
	IF(@PlaceId <> '')
	BEGIN
		SELECT top 1 @AreaId =  AreaId FROM Area WHERE PlaceId = @PlaceId
		print @AreaId
	END
SELECT TOP 10 l.[PatientId] ,[BusinessName] , [BusinessDescription] ,[YearStarted]
	,l.[CityId], [Address], [Area], [Landmark],[PinCode], lc.ContactNo, lMedia.ServerFileName ,
	isnull(listReview.ReviewCount, 0) as [ReviewCount],
	ISNULL( listReview.ReviewAverage , 1) as [ReviewAverage],
	l.[IsActive] ,l.[IsDeleted]      
    
	FROM [dbo].[Patient] L
    INNER JOIN [dbo].[PatientCategory] lcat  on  l.PatientId = lcat.PatientId and lcat.CategoryId = @CategoryId
	LEFT JOIN [dbo].PatientContact lc on l.PatientId = lc.PatientId and lc.ContactTypeId = 1	
    -- remove this join by adding a column at the Patient table for profile pic server file name
	LEFT JOIN (SELECT lm.PatientMediaId, lm.PatientId  , f.ServerFileName
				FROM  [dbo].PatientMedia lm 
				INNER JOIN [dbo].[File] f on lm.FileId =    f.FileId and  f.FileTypeId = 1
				WHERE lm.IsPrimary = 1
				  ) AS lMedia on l.PatientId = lMedia.PatientId 
	LEFT JOIN [dbo].[PatientServiceLocation] lsl  on l.PatientId = lsl.PatientId	 
	LEFT JOIN (  select [Patient].PatientId, AVG(lr.RatingId) as ReviewAverage, Count(lr.RatingId) ReviewCount  
				 from [dbo].[Patient] 
				 left join PatientReview lr on [Patient].PatientId = lr.PatientId 
				 group by [Patient].PatientId 
				 ) as listReview  on l.PatientId = listReview.PatientId  
	WHERE ((@PlaceId <> '' AND (lsl.AreaId = @AreaId 
								OR (lsl.IsCityLevel = 1 AND lsl.CityId = @CityId) 
	 		  					OR (lsl.IsStateLevel = 1 AND lsl.StateId = @StateId)
	 							OR (lsl.IsCountryLevel = 1 AND 1=1)))
	 		OR (@PlaceId = '' AND (lsl.CityId = @CityId 
									OR (lsl.IsStateLevel = 1 AND lsl.StateId = @StateId)
		 							OR (lsl.IsCountryLevel = 1 AND 1=1))) -- whole city					
		   ) 
		 AND L.IsActive = 1 
		 AND L.IsDeleted = 0	
 
 */
