IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'AssociateCourseDetails')
BEGIN
  CREATE TABLE [dbo].[AssociateCourseDetails] (  
     [ID]										UNIQUEIDENTIFIER NOT NULL,  
     [AssociateID]								INT  NOT NULL,  
     [AssociateName]							VARCHAR NOT NULL,
	 [Course]									VARCHAR NULL,
	 [Stack]									VARCHAR NULL,
	 [Training_Vendor]							VARCHAR NULL,	 
	 [Recommendation]							VARCHAR NULL,
	 [Reporting_Status]							VARCHAR NULL,	 
	 [Grade2]									VARCHAR NULL,
	 [Level_Description]						VARCHAR NULL,
	 [DepartmentDescription]					VARCHAR NULL,
	 [DepartmentGroup]							VARCHAR NULL,
	 [Classification]							VARCHAR NULL,
	 [HorizontalName]							VARCHAR NULL,
	 [VerticalName]								VARCHAR NULL,	 
     CONSTRAINT [PK_dbo.AssociateCourseDetails] PRIMARY KEY CLUSTERED ([ID] ASC)  
 )   
END
GO