

--Drop Table dbo.PersonalDetails
--Drop Table dbo.AcademeicDetails
--Drop Table dbo.AddressDetails
--Drop Table dbo.FeeDetails

Create table dbo.PersonalDetails
(

StudentId varchar(50) ,
ApplicantName nvarchar(200),
FatherName nvarchar(200),
MotherName nvarchar(200),
RegistrationNo varchar(100),
NatureOfDocument nvarchar(max),
ReasonOfApplying nvarchar(max),
status bit not null
);


Create table dbo.AcademeicDetails
(
AcademeicDetailsId nvarchar(50),
StudentId varchar(50) ,
Course varchar(50) ,
Semester varchar(50) ,
Year varchar(50) ,
CollegeName varchar(100) ,
MarksScored decimal,
MaxMark decimal,
UploadFileId varchar(50),
status bit
);


Create table dbo.AddressDetails
(
AddressDetailsId varchar(50),
StudentId varchar(50) ,
FullAddress nvarchar(max),
PhoneNumberOffice varchar(20),
PhoneNumberResidence varchar(20),
EmailId varchar(100),
status bit
);

Create table dbo.FeeDetails
(
FeeDetailsId varchar(50),
StudentId varchar(50) ,
TransactionId varchar(100),
Date dateTime,
PayeeName varchar(200),
FathersName varchar(200),
DOB dateTime,
PhoneNumberOffice varchar(20),
FeeCode varchar(50),
FeeDetails varchar(200),
FeeDescription nvarchar(max),
Amount decimal,
UploadFileId varchar(50),
status bit
);

CREATE TABLE [dbo].[UploadFeeDetails]
(
[FileId] nvarchar(50) NOT NULL PRIMARY KEY,
[FileName] [nvarchar](100) NULL,
[FileSize] [nvarchar](50) NULL,
[FileExtension] [nvarchar](20) NULL,
[FilePath] [nvarchar](500) NULL,
CreatedBy varchar(50) ,
CreatedOn varchar(50) default(getdate()),
status int default(0)
)



go

create PROCEDURE [dbo].[GetUploadedFeeDetailsbyId]
	-- Add the parameters for the stored procedure here
	@FileId nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM [UploadFeeDetails]
	WHERE FileId = @FileId and status = 1
END
go
Create PROCEDURE [dbo].[DeleteUploadedFeeById]
	-- Add the parameters for the stored procedure here
	@FileId nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update [UploadFeeDetails] set status = 0
	WHERE FileId = @FileId
END
go


Create PROCEDURE [dbo].[InsertUploadFeeDetails]
	-- Add the parameters for the stored procedure here
	@FileId nvarchar(50),
	@FileName nvarchar(100),
	@FileSize nvarchar(50),
	@FileExtension nvarchar(100),
	@FilePath nvarchar(500),
	@CreatedBy nvarchar(50),
	@Status int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [UploadFeeDetails](
		FileId,
		FileName,
		FileSize ,
		FileExtension ,
		FilePath ,
		CreatedBy,
		Status 
	)VALUES(
		@FileId,
		@FileName,
		@FileSize ,
		@FileExtension ,
		@FilePath ,
		@CreatedBy ,
		@Status
	)
END