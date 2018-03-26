IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'AssociateCourseDetails')
BEGIN
  CREATE TABLE [dbo].[AssociateCourseDetails] (  
     [ID]										INT IDENTITY(1, 1) NOT NULL,  
     [AssociateID]								VARCHAR(50)  NOT NULL,  
     [AssociateName]							VARCHAR(50) NOT NULL,
	 [Course]									VARCHAR(50) NULL,
	 [Stack]									VARCHAR(50) NULL,
	 [Training_Vendor]							VARCHAR(50) NULL,	 
	 [Recommendation]							VARCHAR(50) NULL,
	 [Reporting_Status]							VARCHAR(50) NULL,	 
	 [Grade2]									VARCHAR(50) NULL,
	 [Level_Description]						VARCHAR(50) NULL,
	 [DepartmentDescription]					VARCHAR(50) NULL,
	 [DepartmentGroup]							VARCHAR(50) NULL,
	 [Classification]							VARCHAR(50) NULL,
	 [HorizontalName]							VARCHAR(50) NULL,
	 [VerticalName]								VARCHAR(50) NULL,	 
     CONSTRAINT [PK_dbo.AssociateCourseDetails] PRIMARY KEY CLUSTERED ([ID] ASC)  
 )   
END
GO
