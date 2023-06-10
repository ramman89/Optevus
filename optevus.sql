CREATE TABLE [policies] (
    [PolicyId] int NOT NULL primary key,
    [DateOfPurchase] datetime2 NOT NULL,
    [CustomerId] int NOT NULL,
    [Fuel] nvarchar(max) NOT NULL,
    [VehicleSegment] nvarchar(max) NOT NULL,
    [Premium] int NOT NULL,
    [BodilyInjury] bit NOT NULL,
    [CustomerGender] nvarchar(max) NOT NULL,
    [CustomerIncomeGroup] nvarchar(max) NOT NULL,
    [CustomerRegion] nvarchar(max) NULL,
    [CustomerMaritalStatus] bit NOT NULL,
);

Insert into policies values
(12343,'1/16/2017',400,'CNG','A',958,1,'Male','0-$25k','North',1),
(12346,'1/26/2018',400,'CNG','A',1958,1,'Male','0-$25k','South',1),
(12347,'2/16/2018',401,'CNG','A',2958,1,'Male','0-$25k','North',1),
(12348,'2/26/2018',400,'CNG','A',9581,1,'Male','0-$25k','South',1),
(12349,'2/06/2018',402,'CNG','A',4958,1,'Male','0-$25k','North',1)


